using NT.DataAccess.Repository.IRepository;
using NT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebApp.Data;

namespace NT.DataAccess.Repository
{
    public class KategorieRepository : Repository<Kategorie>, IKategoriaRepository
    {
        private ApplicationDbContext _db;
        public KategorieRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Kategorie obj)
        {
            _db.Kategorie.Update(obj);
        }
    }
}
