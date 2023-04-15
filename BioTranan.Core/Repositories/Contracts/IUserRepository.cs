using BioTranan.Core.Entities;

namespace BioTranan.Core.Repositories.Contracts;

public interface IUserRepository
{
    Task<User> CreateUser(string userEmail);
}