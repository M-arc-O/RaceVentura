﻿using RaceVenturaWebApp.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace RaceVenturaWebApp.Infrastructure.Repositories;
public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
{
    protected readonly RaceVenturaWebAppDbContext _Context;
    protected readonly DbSet<TEntity> dbSet;

    public GenericRepository(RaceVenturaWebAppDbContext context)
    {
        _Context = context;
        dbSet = context.Set<TEntity>();
    }

    public virtual Task<List<TEntity>> GetAsync(
        Expression<Func<TEntity, bool>>? filter = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        string includeProperties = "")
    {
        IQueryable<TEntity> query = dbSet;

        if (filter != null)
        {
            query = query.Where(filter);
        }

        foreach (var includeProperty in includeProperties.Split
            (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
        {
            query = query.Include(includeProperty);
        }

        if (orderBy != null)
        {
            return orderBy(query).ToListAsync();
        }
        else
        {
            return query.ToListAsync();
        }
    }

    public virtual Task<TEntity?> GetByIdAsync(object id) => dbSet.FindAsync(id).AsTask();

    public virtual Task InsertAsync(TEntity entity) => dbSet.AddAsync(entity).AsTask();

    public virtual void Delete(object id)
    {
        TEntity entityToDelete = dbSet.Find(id)!;
        Delete(entityToDelete!);
    }

    public virtual void Delete(TEntity entityToDelete)
    {
        if (_Context.Entry(entityToDelete).State == EntityState.Detached)
        {
            dbSet.Attach(entityToDelete);
        }
        dbSet.Remove(entityToDelete);
    }

    public virtual void Update(TEntity entityToUpdate)
    {
        dbSet.Attach(entityToUpdate);
        _Context.Entry(entityToUpdate).State = EntityState.Modified;
    }
}
