using Application.Models.Dtos;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IPassengerService
    {
        Task SignToTravel(int idUser, int idTravel);
    }
}
