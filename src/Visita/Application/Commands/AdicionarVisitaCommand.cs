using Core.Mediator.Domain;
using System;

namespace Visita.Application.Commands
{
    public class AdicionarVisitaCommand : Command
    {
        public AdicionarVisitaCommand(int cdcliente, int? cdempresa, int? cdpedido, int cdsituacaovisita, int? cdvendedor, int cdvisita, string deobservacao, DateTime dtfim, DateTime dtinicio, int flexcluido, int flsituacao, string guid, string hrfim, string hrinicio, string pedidocliguid, long timestamp)
        {
            this.cdcliente  = cdcliente;
            this.cdempresa  = cdempresa;
            this.cdpedido   = cdpedido;
            this.cdsituacaovisita = cdsituacaovisita;
            this.cdvendedor    = cdvendedor;
            this.cdvisita      = cdvisita;
            this.deobservacao  = deobservacao;
            this.dtfim         = dtfim;
            this.dtinicio      = dtinicio;
            this.flexcluido    = flexcluido;
            this.flsituacao    = flsituacao;
            this.AggregateId   = guid;
            this.hrfim         = hrfim;
            this.hrinicio      = hrinicio;
            this.pedidocliguid = pedidocliguid;
            this.timestamp     = timestamp;
        }

        public int cdcliente { get; set; }
        public int? cdempresa { get; set; }
        public int? cdpedido { get; set; }
        public int cdsituacaovisita { get; set; }
        public int? cdvendedor { get; set; }
        public int cdvisita { get; set; }
        public string deobservacao { get; set; }
        public DateTime dtfim { get; set; }
        public DateTime dtinicio { get; set; }
        public int flexcluido { get; set; }
        public int flsituacao { get; set; }
        public string hrfim { get; set; }
        public string hrinicio { get; set; }
        public string? pedidocliguid { get; set; }
        public long timestamp { get; set; }

        public override bool EhValido()
        {
            return true;
        }
    }
}
