using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementRepo.Interfaces
{
    public interface IUnitOfWork
    {
        IGenericRepo<T> genericRepo<T>() where T : class;

        void save();
    }
}
