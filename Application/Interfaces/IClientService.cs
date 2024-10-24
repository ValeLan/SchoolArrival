using Application.Models.Dtos;
using Application.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IClientService
    {
        List<ClientDto> GetAll();
        Task CreateAsync(ClientSaveRequest request);
    }
}
