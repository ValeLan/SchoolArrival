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
//    public class PassengerServices : IPassengerService
//    {
//        private readonly IPassengerRepository _repository;
//        private readonly ISchoolRepository _schoolRepository;
//        private readonly IDistrictRepository _districtRepository;
//        private readonly ITravelRepository _travelRepository;

//        public PassengerServices(IPassengerRepository repository, ISchoolRepository schoolRepository, IDistrictRepository districtRepository, ITravelRepository travelRepository)
//        {
//            _repository = repository;
//            _schoolRepository = schoolRepository;
//            _districtRepository = districtRepository;
//            _travelRepository = travelRepository;
//        }

//        public List<PassengerDto> GetAll()
//        {
//            return _repository.GetAll();
//        }

//        public PassengerDto? GetById(int id)
//        {
//            var entity = _repository.Get().FirstOrDefault(a => a.Id == id);
//            if (entity == null)
//            {
//                return null;
//            }

//            return PassengerDto.ToDto(entity);
//        }

//        public PassengerDto CreatePassenger(PassengerSaveRequest dto)
//        {            
//            var entity = PassengerDto.ToEntity(dto);
//            entity.School = _schoolRepository.GetById(dto.SchoolId);
//            entity.District = _districtRepository.GetById(dto.DistrictId);
//            entity.Travels = _travelRepository.Get().Where(a => a.Passengers.Any(p=> p.Id == entity.Id)).ToList();
//            _repository.Add(entity);
//            return PassengerDto.ToDto(entity);
//        }

//        public void UpdatePassenger(int id, PassengerSaveRequest adminDto)
//        {
//            _repository.UpdateEntity(id, adminDto);
//        }

//        public void DeletePassenger(int id)
//        {
//            _repository.Remove(id);
//        }
//    }
//}
