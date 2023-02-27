using _02_Mapping.Contexts;
using Microsoft.EntityFrameworkCore;

namespace _02_Mapping.Services;

internal abstract class DataService<T> where T : class
{
    private readonly DataContext _context;

    protected DataService()
    {
        _context = new DataContext();
    }


    public virtual async Task<T> CreateAsync(T entity)
    {
        _context.Set<T>().Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    } 

    public virtual async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _context.Set<T>().ToListAsync();
    } 

    public virtual async Task<T> GetAsync(Func<T, bool> predicate) 
    {
        return await _context.Set<T>().FindAsync(predicate) ?? null!;
    }

    public virtual async Task UpdateAsync(T entity)
    {   
        _context.Update(entity);
        await _context.SaveChangesAsync();
    }

    public virtual async Task DeleteAsync(Func<T, bool> predicate)
    {
        var item = await _context.Set<T>().FindAsync(predicate);
        if (item != null)
        {
            _context.Remove(item);
            await _context.SaveChangesAsync();
        }
    }
}
