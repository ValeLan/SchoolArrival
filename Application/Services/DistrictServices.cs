//using Application.Interfaces;
//using Application.Models.Dtos;
//using Application.Models.Requests;
//using Domain.Entities;
//using Domain.Interfaces;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Application.Services
//{
//    public class DistrictServices : IDistrictServices
//    {
//        private readonly IDistrictRepository _districtRepository;
//        private readonly IPassengerRepository _passengerRepository;

//        public DistrictServices(IDistrictRepository repository, IPassengerRepository passengerRepository)
//        {
//            _districtRepository = repository;
//            _passengerRepository = passengerRepository;
//        }

//        public List<District> GetAll()
//        {
//            return _districtRepository.GetAll();
//        }

//        public District? GetById(int id)
//        {
//            var district = _districtRepository.Get();

//            return district.FirstOrDefault(a => a.Id == id);
//        }

//        public string CreateDistrict(DistrictSaveRequest newDistrictRequest)
//        {
//            var district = new District
//            {
//                Name = newDistrictRequest.Name,
//                Passengers = new List<Passenger>()
//            };
//            var passengers = _passengerRepository.GetByIds(newDistrictRequest.PassengersIds);
//            district.Passengers.AddRange(passengers);

//            _districtRepository.Add(district);
//            _districtRepository.SaveChanges();

//            return "Distrito creado con exito,";
//        }

//        public void UpdateDistrict(int id, District newDistrict)
//        {
//            _districtRepository.UpdateEntity(id, newDistrict);
//        }

//        public void DeleteDistrict(int id)
//        {
//            _districtRepository.Remove(id);
//        }
//    }
//}
