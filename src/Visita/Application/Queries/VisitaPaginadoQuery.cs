using Core.Mediator.Domain;
using Visita.Application.DTOs;
using System.Collections.Generic;

namespace Visita.Application.Queries
{
    public class VisitaPaginadoQuery : Query<IEnumerable<VisitaPaginadoResult>>
    {
        public int CodigoVendedor { get; set; }
        public string NomeCliente { get; set; }
        public int NumeroPagina { get; set; }
        public int QuantidadeDeItensPorPagina { get; set; }
        public int TamanhoDeCaracteresParaMostrarPesquisa { get; set; }
    }
}
