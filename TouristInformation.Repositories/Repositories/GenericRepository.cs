﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TouristInformation.Data.Models;
using TouristInformation.Repositories.Contracts;

namespace TouristInformation.Repositories.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseDomainEntity
    {
        private readonly TouristInformationContext _context;
        private readonly DbSet<TEntity> _db;

        public GenericRepository(TouristInformationContext context)
        {
            this._context = context;
            _db = _context.Set<TEntity>();
        }
        public async Task Delete(int id)
        {
            var entity = await _db.FindAsync(id);
            _db.Remove(entity);
            await SaveChanges();
        }

        public async Task<bool> Exists(int id)
        {
            return await _db.AnyAsync(e => e.Id == id);
        }

        public async Task<TEntity> Get(int id)
        {
            return await _db.FindAsync(id);
        }

        public async Task<List<TEntity>> GetAll()
        {
            return await _db.ToListAsync();
        }

        public async Task Insert(TEntity entity)
        {

            await _db.AddAsync(entity);
            foreach (var entry in _context.ChangeTracker.Entries<BaseDomainEntity>().Where(q => q.State == EntityState.Added))
            {
                entry.Entity.DateCreated = DateTime.Now;
                entry.Entity.DateUpdated = DateTime.Now;
            }

            await _context.SaveChangesAsync();
        }

        public async Task Update(TEntity entity)
        {
            _db.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;

            foreach (var entry in _context.ChangeTracker.Entries<BaseDomainEntity>().Where(q => q.State == EntityState.Modified))
            {
                entry.Entity.DateUpdated = DateTime.Now;
            }

            await _context.SaveChangesAsync();
        }

        public async Task<int> SaveChanges()
        {
            return await _context.SaveChangesAsync();
        }

        


    }
}
