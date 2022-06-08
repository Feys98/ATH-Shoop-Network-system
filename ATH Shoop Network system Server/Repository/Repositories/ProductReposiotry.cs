using ATH_Shoop_Network_system_Server.Data;
using ATH_Shoop_Network_system_Server.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATH_Shoop_Network_system_Server.Repository.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext context) : base(context)
        {

        }

        public override async Task<IEnumerable<Product>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public override async Task<Product> GetById(int id)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
        }

        public override async Task<Product> Create(Product entity)
        {
            _dbSet.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public override async Task<Product> Update(Product entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public override async Task<Product> Delete(int id)
        {
            var entity = await GetById(id);
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
