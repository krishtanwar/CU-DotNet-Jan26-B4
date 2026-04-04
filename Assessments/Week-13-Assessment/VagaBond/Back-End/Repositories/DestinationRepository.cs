using Back_End.Data;
using Back_End.Models;
using Microsoft.EntityFrameworkCore;

namespace Back_End.Repositories
{
    public class DestinationRepository : IDestinationRepository
    {
            private readonly Back_EndContext _context;

            public DestinationRepository(Back_EndContext context)
            {
                _context = context;
            }

            public async Task<IEnumerable<Destination>> GetAllAsync()
                => await _context.Destinations.ToListAsync();

            public async Task<Destination> GetByIdAsync(int id)
            {
                var data = await _context.Destinations.FindAsync(id);
                if (data == null)
                    throw new Exception("Destination not found");

                return data;
            }

            public async Task AddAsync(Destination destination)
            {
                await _context.Destinations.AddAsync(destination);
                await _context.SaveChangesAsync();
            }

            public async Task UpdateAsync(Destination destination)
            {
                _context.Destinations.Update(destination);
                await _context.SaveChangesAsync();
            }

            public async Task DeleteAsync(int id)
            {
                var data = await _context.Destinations.FindAsync(id);
                if (data == null)
                    throw new Exception("Destination not found");

                _context.Destinations.Remove(data);
                await _context.SaveChangesAsync();
            }

    }
}
