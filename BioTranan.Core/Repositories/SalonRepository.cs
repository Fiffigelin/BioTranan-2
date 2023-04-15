using BioTranan.Core.Data;
using BioTranan.Core.Entities;
using BioTranan.Core.Repositories.Contracts;
using BioTranan.Core.Dto;

namespace BioTranan.Core.Repositories;

public class SalonRepository : ISalonRepository
{
    private readonly BioTrananDbContext _context;

    public SalonRepository(BioTrananDbContext context)
    {
        _context = context;
    }

    public async Task<Salon> CreateSalon(CreateSalonDto createSalon)
    {
        var result = new Salon
        {
            Name = createSalon.Name,
            MaxSeats = createSalon.MaxSeats,
        };

        await _context.Salons.AddAsync(result);
        await _context.SaveChangesAsync();
        return result;
    }

    public async Task<Salon> GetSalon(int id)
    {
        return await _context.Salons.FindAsync(id);
    }

    public async Task<Salon> UpdateSalon(int id, CreateSalonDto updatedSalon)
    {
        var result = await _context.Salons.FindAsync(id);

        if (result == null) return null!;

        result.MaxSeats = updatedSalon.MaxSeats;
        result.Name = updatedSalon.Name;
        await _context.SaveChangesAsync();

        return result;
    }
}