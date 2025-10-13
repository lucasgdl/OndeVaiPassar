using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OndeVaiPassar.Domain.Entities.Sports;
using OndeVaiPassar.Domain.Interfaces;

namespace OndeVaiPassar.QueryStore.Sports;

public class SportRepository : ISportRepository
{
    private readonly AppDbContext _context;

    public SportRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<SportEntity?> GetByIdAsync(Guid id) =>
        await _context.Sports.FirstOrDefaultAsync(x => x.Id == id);

    public async Task AddAsync(SportEntity sport)
    {
        await _context.Sports.AddAsync(sport);
        await _context.SaveChangesAsync();
    }
}
