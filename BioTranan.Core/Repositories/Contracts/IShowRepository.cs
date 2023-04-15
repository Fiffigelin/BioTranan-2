using BioTranan.Core.Entities;
using BioTranan.Core.Dto;

namespace BioTranan.Core.Repositories.Contracts;
public interface IShowRepository
{
    Task<Show> CreateShow(CreateShowDto createdShow);
}