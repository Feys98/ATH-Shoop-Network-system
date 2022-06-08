using ATH_Shoop_Network_system_Server.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATH_Shoop_Network_system_Server.Repository.Interfaces
{
    public interface IGenericRepository<T> where T : IEntity<int>
    {
        IQueryable<T> GetAll();
        T GetById(int id);
        ServiceResult Create(T entity);
        ServiceResult Update(T entity);
        ServiceResult Delete(T entity);       
    }
}
