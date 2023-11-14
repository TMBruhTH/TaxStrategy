using Microsoft.EntityFrameworkCore;
using TaxStrategy.Domain.Entities;
using TaxStrategy.Domain.Interfaces;
using TaxStrategy.Infra.Data.Context;

namespace TaxStrategy.Infra.Data.Repositories
{
    public class TaxStrategyFilhoRepository : ITaxStrategyFilhoRepository
    {
        private readonly AppDbContext _context;

        public TaxStrategyFilhoRepository(AppDbContext context)
        {
            _context = context;
        }

        #region [GetAll]
        public IEnumerable<TaxStrategyFilho> GetAll()
        {
            return _context.DbTaxStrategyFilho.ToList();
        }
        #endregion

        #region [GetByEstado]
        public IEnumerable<TaxStrategyFilho> GetByEstado(string estado)
        {
            return _context.DbTaxStrategyFilho.Where(x => x.Estado == estado).ToList();
        }
        #endregion

        #region [GetById]
        public TaxStrategyFilho GetById(int id)
        {
            return _context.DbTaxStrategyFilho.Where(x => x.Id == id).First();
        }
        #endregion

        #region [GetByIdPai]
        public IEnumerable<TaxStrategyFilho> GetByIdPai(int idPai)
        {
            return _context.DbTaxStrategyFilho.Where(x => x.IdTaxStrategyPai == idPai).ToList();
        }
        #endregion

        #region [Add]
        public TaxStrategyFilho Add(TaxStrategyFilho model)
        {
            try
            {
                _context.DbTaxStrategyFilho.Add(model);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return model;
        }
        #endregion

        #region [Update]
        public TaxStrategyFilho Update(TaxStrategyFilho model)
        {
            try
            {
                _context.Entry(model).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return model;
        }
        #endregion
    }
}
