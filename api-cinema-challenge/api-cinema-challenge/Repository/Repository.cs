﻿using System.Linq.Expressions;
using api_cinema_challenge.Data;
using Microsoft.EntityFrameworkCore;

namespace api_cinema_challenge.Repository;

public class Repository<T>(CinemaContext db) : IRepository<T> where T : class
{
    public async Task<IEnumerable<T>> GetAll(params Expression<Func<T, object>>[] includes)
    {
        IQueryable<T> query = db.Set<T>();
        foreach (var expression in includes) query = query.Include(expression);

        return await query.ToListAsync();
    }

    public async Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> predicate,
        params Expression<Func<T, object>>[] includes)
    {
        IQueryable<T> query = db.Set<T>();
        foreach (var expression in includes) query = query.Include(expression);

        return await query.Where(predicate).ToListAsync();
    }

    public async Task<T?> Get(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
    {
        IQueryable<T> query = db.Set<T>();
        foreach (var expression in includes) query = query.Include(expression);

        return await query.FirstOrDefaultAsync(predicate);
    }
    
    public async Task<T?> Update(T entity)
    {
        db.Set<T>().Update(entity);
        await db.SaveChangesAsync();
        return entity;
    }
    
    public async Task<T?> Add(T entity)
    {
        await db.Set<T>().AddAsync(entity);
        await db.SaveChangesAsync();
        return entity;
    }
    
    public async Task<T?> Delete(T entity)
    {
        db.Set<T>().Remove(entity);
        await db.SaveChangesAsync();
        return entity;
    }
}