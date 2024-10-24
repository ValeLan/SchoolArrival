using Application.Interfaces;
using Application.Mapping;
using Application.Models.Dtos;
using Application.Models.Requests;
using ConsultaAlumnos.Domain.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ClientService : IClientService
    {
        private readonly IRepositoryBase<Client> _clientRepositoryBase;
        private readonly IClientRepository _clientRepository;
        private readonly ClientMapping _clientMapping;
        public ClientService(IRepositoryBase<Client> clientRepositoryBase, ClientMapping clientMapping, IClientRepository clientRepository)
        {
            _clientRepositoryBase = clientRepositoryBase;
            _clientMapping = clientMapping;
            _clientRepository = clientRepository;
        }

        public List<ClientDto> GetAll()
        {
            var response = _clientRepository.GetAll();
            var responseMapped = response.Select(e => _clientMapping.FromEntityToResponse(e)).ToList();
            return responseMapped;

        }
        public async Task CreateAsync(ClientSaveRequest request)
        {
            var client = new Client()
            {
               Name = request.Name,
               Password = request.Password,

            };

            await _clientRepositoryBase.AddAsync(client);
        }
    }
}
