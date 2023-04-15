using BioTranan.Core.Entities;
using BioTranan.Api.Dto;

namespace BioTranan.Core.Repositories.Contracts;
public interface IShowRepository
{
    Task<Show> CreateShow(CreateShowDto createdShow);
}