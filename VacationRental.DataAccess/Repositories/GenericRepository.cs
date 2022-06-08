﻿using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using VacationRental.DataAccess.Contexts;
using VacationRental.DataAccess.Interfaces;
using VacationRental.DataAccess.Models.Entities;

namespace VacationRental.DataAccess.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly VacationRentalDbContext _dbContext;

        public GenericRepository(VacationRentalDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> AddAsync(TEntity entity)
        {
            _dbContext.Set<TEntity>().Add(entity);

            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> UpdateAsync(TEntity entity)
        {
            _dbContext.Set<TEntity>().Update(entity);

            return await _dbContext.SaveChangesAsync();
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            _dbContext.Set<TEntity>().AddRange(entities);

            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateRangeAsync(IEnumerable<TEntity> entities)
        {
            _dbContext.Set<TEntity>().UpdateRange(entities);

            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> expression)
        {
            var result = await _dbContext.Set<TEntity>().Where(expression).ToArrayAsync();

            return result;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            var result = await _dbContext.Set<TEntity>().Where(x => x.IsActive).ToArrayAsync();

            return result;
        }

        public async Task<TEntity> GetByIdAsync(int entityId)
        {
            var result = await _dbContext.Set<TEntity>().FirstOrDefaultAsync(x => x.IsActive && x.Id == entityId);

            return result!;
        }

        public async Task RemoveAsync(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);

            await _dbContext.SaveChangesAsync();
        }

        public async Task RemoveRangeAsync(IEnumerable<TEntity> entities)
        {
            _dbContext.Set<TEntity>().RemoveRange(entities);

            await _dbContext.SaveChangesAsync();
        }
    }
}
