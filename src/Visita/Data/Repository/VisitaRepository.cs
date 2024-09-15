using Core.Domain;
using Microsoft.EntityFrameworkCore;
using Visita.Domain;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace Visita.Data.Repository
{
    public class VisitaRepository : IVisitaRepository
    {
        private readonly VisitaContext _context;

        public VisitaRepository(VisitaContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public void Adicionar(Domain.Visita visita)
        {
            _context.Visita.Add(visita);
        }

        public void Atualizar(Domain.Visita visita)
        {
            _context.Visita.Update(visita);
        }

        public void Dispose()
        {
        }

        public void Excluir(Domain.Visita visita)
        {
            throw new NotImplementedException();
        }

        public void ExcluirSoft(Domain.Visita visita)
        {
            throw new NotImplementedException();
        }

        public DbConnection ObterConexao()
        {
            throw new NotImplementedException();
        }

        public Domain.Visita ObterPorCodigo(int codigo)
        {
            throw new NotImplementedException();
        }

        public Domain.Visita ObterPorId(string id)
        {
            try
            {
                return _context.Visita.AsNoTracking().Where(w => w.guid.ToUpper() == id.ToUpper()).FirstOrDefault();
            }
            catch
            {
                return null;
            }
        }

        public Domain.Visita ObterPorNome(string nome)
        {
            throw new NotImplementedException();
        }

        public int ObterProximoCodigo()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Domain.Visita>> ObterTodos()
        {
            throw new NotImplementedException();
        }
    }
}
