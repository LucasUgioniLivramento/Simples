using System;

namespace Visita.Application.DTOs
{
    public class VisitaPaginadoResult
    {
        public string Id { get; set; }
        public int CodigoVisita { get; set; }
        public int CodigoCliente { get; set; }
        public string NomeCliente { get; set; }
        public DateTime DataInicio { get; set; }
        public bool Sincronizado { get; set; }
    }
}
