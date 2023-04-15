using BioTranan.Core.Entities;
using BioTranan.Api.Dto;

namespace BioTranan.Core.Repositories.Contracts;
public interface ISalonRepository
{
    Task<Salon> CreateSalon(CreateSalonDto createdSalon);
    Task<Salon> GetSalon(int id);
    Task<Salon> UpdateSalon(int id, CreateSalonDto updatedSalon);
}