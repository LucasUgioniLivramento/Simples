using Core.Domain;
using System;

namespace Visita.Domain
{
    public class Visita : IAggregateRoot
    {
        public Visita(int cdcliente, int? cdempresa, int? cdpedido, int cdsituacaovisita, int? cdvendedor, int cdvisita, string deobservacao, DateTime dtfim, DateTime dtinicio, int flexcluido, int flsituacao, string guid, string hrfim, string hrinicio, string pedidocliguid, long timestamp)
        {
            this.cdcliente = cdcliente;
            this.cdempresa = cdempresa;
            this.cdpedido = cdpedido;
            this.cdsituacaovisita = cdsituacaovisita;
            this.cdvendedor = cdvendedor;
            this.cdvisita = cdvisita;
            this.deobservacao = deobservacao;
            this.dtfim = dtfim;
            this.dtinicio = dtinicio;
            this.flexcluido = flexcluido;
            this.flsituacao = flsituacao;
            this.guid = guid;
            this.hrfim = hrfim;
            this.hrinicio = hrinicio;
            this.pedidocliguid = pedidocliguid;
            this.timestamp = timestamp;
        }

        public int cdcliente { get; private set; }
        public int? cdempresa { get; private set; }
        public int? cdpedido { get; private set; }
        public int cdsituacaovisita { get; private set; }
        public int? cdvendedor { get; private set; }
        public int cdvisita { get; private set; }
        public string deobservacao { get; private set; }
        public DateTime dtfim { get; private set; }
        public DateTime dtinicio { get; private set; }
        public int flexcluido { get; private set; }
        public int flsituacao { get; private set; }
        public string guid { get; private set; }
        public string hrfim { get; private set; }
        public string hrinicio { get; private set; }
        public string? pedidocliguid { get; private set; }
        public long timestamp { get; private set; }

        public void InformarCodigoCliente(int codigoCliente) => cdcliente = codigoCliente;
        public void InformarCodigoSituacaoVisita(int codigosituacaovisita) => cdsituacaovisita = codigosituacaovisita;
        public void InformarCodigoVendedor(int codigoVendedor) => cdvendedor = codigoVendedor;
        public void InformarObservacao(string observacao) => deobservacao = observacao;
        public void InformarDataFim(DateTime dataFim) => dtfim = dataFim;
        public void InformarDataInicio(DateTime dataInicio) => dtinicio = dataInicio;
        public void InformarExcluido(int excluido) => flexcluido = excluido;
        public void InformarSituacao(int situacao) => flsituacao = situacao;
        public void InformarHoraFim(string horaFim) => hrfim = horaFim;
        public void InformarHoraInicio(string horaInicio) => hrinicio = horaInicio;

    }
}
