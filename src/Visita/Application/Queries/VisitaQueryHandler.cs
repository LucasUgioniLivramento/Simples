using MediatR;
using System.Threading.Tasks;
using System.Threading;
using System.Data.Common;
using Dapper;
using System.Linq;
using System.Collections.Generic;
using Visita.Application.DTOs;
using System.Data;
using System;
using Visita.Domain;
using Core.Mediator;

namespace Visita.Application.Queries
{
    public class VisitaQueryHandler : QueryHandler,
                IRequestHandler<VisitaPaginadoQuery, IEnumerable<VisitaPaginadoResult>>
    {
        private IVisitaRepository _repository;
        private DbConnection _connection;
        public VisitaQueryHandler(DbConnection connection, IVisitaRepository repository)
        {
            _connection = connection;
            _repository = repository;
        }

        public async Task<IEnumerable<VisitaPaginadoResult>> Handle(
            VisitaPaginadoQuery query,
            CancellationToken cancellationToken)
        {
            DynamicParameters parameters = new DynamicParameters();
            var tabela = "visita";
            var builder = new SqlBuilder();
            var skip = query.NumeroPagina * query.QuantidadeDeItensPorPagina;
            var take = query.QuantidadeDeItensPorPagina;

            var builderTemplate = builder.AddTemplate("SELECT /**select**/ FROM " + tabela + " /**join**/ /**innerjoin**/ /**leftjoin**/ /**where**/ /**orderby**/ "
                                                    + " limit " + take + " offset " + skip);
            builder.Select("visita.guid")
                   .Select("visita.cdvisita")
                   .Select("visita.cdcliente")
                   .Select("cliente.nmcliente")
                   .Select("visita.dtinicio")
                   .Select("visita_tracking.timestamp")
                   .Join("cliente on cliente.cdcliente = visita.cdcliente")
                   .LeftJoin("visita_tracking on visita_tracking.guid = visita.guid");

            if (query.CodigoVendedor > 0)
            {
                builder.Where("visita.cdvendedor = @CodigoVendedor");
                parameters.Add("@CodigoVendedor", query.CodigoVendedor, DbType.Int64, ParameterDirection.Input);
            }

            if (query.NomeCliente.Length >= query.TamanhoDeCaracteresParaMostrarPesquisa)
            {
                builder.Where("cliente.cdcliente in (select cdcliente from cliente" +
                              "where flexcluido = 0" +
                              "and flativo = 1" +
                              "and upper(nmcliente) like upper('%" + query.NomeCliente.ToUpper() + "%')" +
                              "order by cdcliente)")
                    .OrderBy("visita.cdpedido");
            }
            else
                builder.OrderBy("visita.cdcliente");

            var resultado = await _connection.QueryAsync<dynamic>(builderTemplate.RawSql, parameters);

            var ultimoTimestamp = await ObterUltimaSincronizacao();
            return Mapear(resultado.ToList(), ultimoTimestamp);
        }

        private async Task<Int64> ObterUltimaSincronizacao()
        {
            DynamicParameters parameters = new DynamicParameters();
            var tabela = "scope_info_client";
            var builder = new SqlBuilder();

            var builderTemplate = builder.AddTemplate("SELECT /**select**/ FROM " + tabela + " /**join**/ /**innerjoin**/ /**leftjoin**/ /**where**/ /**orderby**/ ");
            builder.Select("scope_last_sync_timestamp");

            builder.Where("sync_scope_name = @Scope");
            parameters.Add("@Scope", "DefaultSync", DbType.String, ParameterDirection.Input);
            var resultado = await _connection.QueryAsync<dynamic>(builderTemplate.RawSql, parameters);
            return (Int64)resultado.First().scope_last_sync_timestamp;
        }

        private IEnumerable<VisitaPaginadoResult> Mapear(IEnumerable<dynamic> dynamics, Int64 ultimoTimestamp)
        {
            List<VisitaPaginadoResult> results = new List<VisitaPaginadoResult>();
            foreach (var visita in dynamics.ToList())
            {
                Int64 timestamp = (visita.timestamp != null) ? Convert.ToInt64(visita.timestamp) : 99999999999999999;
                var teste = new VisitaPaginadoResult()
                {
                    Id            = (string)visita.guid,
                    CodigoVisita  = (int)visita.cdvisita,
                    CodigoCliente = (int)visita.cdcliente,
                    NomeCliente   = (string)visita.nmcliente,
                    DataInicio    = (DateTime)visita.dtinicio,
                    Sincronizado  = (timestamp > ultimoTimestamp) && ((int)visita.cdvisita == 0)
                };
                results.Add(teste);
            }
            return results;
        }

        public Visita.Domain.Visita ObterPorId(string id)
        {
            return _repository.ObterPorId(id);
        }
    }
}
