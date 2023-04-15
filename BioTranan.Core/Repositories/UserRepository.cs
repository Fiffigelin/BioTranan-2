using BioTranan.Core.Data;
using BioTranan.Core.Entities;
using BioTranan.Core.Repositories.Contracts;

namespace BioTranan.Api.Repositories;

public class UserRepository : IUserRepository
{
    private readonly BioTrananDbContext _context;

    public UserRepository(BioTrananDbContext context)
    {
        _context = context;
    }

    public async Task<User> CreateUser(string userEmail)
    {
        var result = new User { Email = userEmail };
        await _context.Users.AddAsync(result);
        await _context.SaveChangesAsync();

        return result;
    }
}