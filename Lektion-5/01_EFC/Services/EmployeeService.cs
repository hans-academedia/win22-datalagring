using _01_EFC.Contexts;
using _01_EFC.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace _01_EFC.Services
{
    internal class EmployeeService
    {
        DataContext _context = new DataContext();

        public async Task<EmployeeEntity> SaveAsync(EmployeeEntity employeeEntity)
        {
            _context.Add(employeeEntity);
            await _context.SaveChangesAsync();

            return employeeEntity;
        }

        public async Task<IEnumerable<EmployeeEntity>> GetAllAsync()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<EmployeeEntity> GetAsync(Func<EmployeeEntity, bool> predicate)
        {
            var _employeeEntity = await _context.Employees.FindAsync(predicate);
            if (_employeeEntity != null)
                return _employeeEntity;

            return null!;
        }

        public async Task<EmployeeEntity> UpdateAsync(EmployeeEntity employeeEntity)
        {
            _context.Entry(employeeEntity).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return employeeEntity;
        }

        public async Task DeleteAsync(Func<EmployeeEntity, bool> predicate)
        {
            var _employeeEntity = await _context.Employees.FindAsync(predicate);
            if (_employeeEntity != null)
            {
                _context.Remove(_employeeEntity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
