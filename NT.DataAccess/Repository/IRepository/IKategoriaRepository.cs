using NT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NT.DataAccess.Repository.IRepository
{
    public interface IKategoriaRepository : IRepository<Kategorie>
    {
        void Update(Kategorie obj);
        void Save();
    }
}
