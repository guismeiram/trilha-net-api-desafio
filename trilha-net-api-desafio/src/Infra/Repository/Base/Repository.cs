using Application.Common.Interfaces;
using AutoMapper.Execution;
using Domain.Entities;
using Domain.Entitys;
using Domain.Enum;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repository.Base
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        protected readonly ApplicationDbContext _context;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<T> Get(Guid id)
            => await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);

        public async Task<IEnumerable<T>> GetAll()
            => await _context.Set<T>().ToListAsync();

        public async Task<IEnumerable<T>> GetWhere(Expression<Func<T, bool>> predicate)
            => await _context.Set<T>().Where(predicate).ToListAsync();

        public IQueryable<T> AsQueryable(Expression<Func<T, bool>> predicate = null)
            => predicate == null ? _context.Set<T>().AsQueryable() : _context.Set<T>().Where(predicate).AsQueryable();

        public async Task<T> AddAsync(T entity)
        {
            try
            {
                entity.CreatedAt = DateTime.UtcNow;
                var result = await _context.AddAsync(entity);
            }
            catch (System.Exception)
            {
                throw;
            }

            return entity;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            try
            {
                var entity = await _context.Set<T>().SingleOrDefaultAsync(x => x.Id == id);
                if (entity == null)
                    return false;

                var result = _context.Set<T>().Remove(entity);
                return true;
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public async Task<T> UpdateAsync(T entity)
        {
            try
            {
                var result = await _context.Set<T>().SingleOrDefaultAsync(x => x.Id == entity.Id);
                if (result == null)
                    return null;

                entity.UpdatedAt = DateTime.UtcNow;
                entity.CreatedAt = result.CreatedAt;

                _context.Entry(result).State = EntityState.Detached;
                _context.Set<T>().Update(entity);
            }
            catch (System.Exception)
            {
                throw;
            }

            return entity;
        }

        /*public async Task<T> getStatus(EnumStatusTarefa statusTarefa)
        {
           var tarefa = _context.Set
        }

        public Task<T> getData(DateTime date)
        {
            throw new NotImplementedException();
        }*/
    }
}
