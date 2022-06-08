using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATH_Shoop_Network_system_Server.Repository.Interfaces
{
    public interface IUnitOfWork
    {
        IProductRepository Products { get; }
        Task CompleteAsync();
    }
}
