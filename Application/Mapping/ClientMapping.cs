using Application.Models.Dtos;
using Application.Models.Requests;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mapping
{
    public class ClientMapping
    {
        public ClientDto FromEntityToResponse(Client client)
        {
            var dto = new ClientDto
            {
                Id = client.Id,
                Name = client.Name,
            };

            return dto;
        }

        public Client FromRequestToEntity(ClientSaveRequest request)
        {
            var client = new Client
            {
                Name = request.Name,
                Password = request.Password,
            };

            return client;
        }
    }
}
