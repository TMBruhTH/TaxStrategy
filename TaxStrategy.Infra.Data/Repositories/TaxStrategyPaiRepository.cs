using Microsoft.EntityFrameworkCore;
using TaxStrategy.Domain.Entities;
using TaxStrategy.Domain.Interfaces;
using TaxStrategy.Infra.Data.Context;

namespace TaxStrategy.Infra.Data.Repositories
{
    public class TaxStrategyPaiRepository : ITaxStrategyPaiRepository
    {
        private readonly AppDbContext _context;

        public TaxStrategyPaiRepository(AppDbContext context)
        {
            _context = context;
        }

        #region [GetAll]
        public IEnumerable<TaxStrategyPai> GetAll()
        {
            return _context.DbTaxStrategyPai.ToList();
        }
        #endregion

        #region [GetByEstado]
        public IEnumerable<TaxStrategyPai> GetByEstado(string estado)
        {
            return _context.DbTaxStrategyPai.Where(x => x.Estado == estado).ToList();
        }
        #endregion

        #region [GetById]
        public TaxStrategyPai GetById(int id)
        {
            return _context.DbTaxStrategyPai.Where(x => x.Id == id).First();
        }
        #endregion

        #region [Add]
        public TaxStrategyPai Add(TaxStrategyPai model)
        {
            try
            {
                _context.DbTaxStrategyPai.Add(model);
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
        public TaxStrategyPai Update(TaxStrategyPai model)
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

        #region [Delete]
        public bool Delete(TaxStrategyPai model)
        {
            try
            {
                _context.DbTaxStrategyPai.Remove(model);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }

            return true;
        }
        #endregion

    }
}
