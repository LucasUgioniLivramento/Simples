using Core.Domain;
using System.Collections.Generic;
using System.Data.Common;
using System.Threading.Tasks;

namespace Visita.Domain
{
    public interface IVisitaRepository : IRepository<Visita>
    {
        Task<IEnumerable<Visita>> ObterTodos();
        Visita ObterPorId(string id);
        Visita ObterPorCodigo(int codigo);
        Visita ObterPorNome(string nome);
        int ObterProximoCodigo();
        DbConnection ObterConexao();
        void Adicionar(Visita visita);
        void Atualizar(Visita visita);
        void Excluir(Visita visita);
        void ExcluirSoft(Visita visita);
    }
}