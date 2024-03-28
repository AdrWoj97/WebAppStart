using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NT.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IKategoriaRepository Kategoria{ get; }
        void Save();
    }
}
