using NT.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Data;

namespace NT.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;
        public IKategoriaRepository Kategoria { get; private set; }
        public IProductsRepository Products { get; private set; }
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Kategoria = new KategorieRepository(_db);
            Products = new ProductRepository(_db);
        }


        public void Save()
        {
            _db.SaveChanges();
        }
    };
}
