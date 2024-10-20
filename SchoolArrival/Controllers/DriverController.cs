﻿using Application.Interfaces;
using Application.Models.Requests;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace SchoolArrival.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriverController : Controller
    {
        private readonly IDriverServices _driverServices;

        public DriverController(IDriverServices driverServices) 
        {
            _driverServices = driverServices;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_driverServices.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get([FromRoute] int id)
        {
            return Ok(_driverServices.GetById(id));
        }

        [HttpPost]
        public IActionResult Create(DriverSaveRequest request)
        {
            _driverServices.CreateDriver(request);
            return Ok();
        }

        [HttpPut]
        public IActionResult Update([FromQuery] int id, DriverSaveRequest request)
        {
            _driverServices.UpdateDriver(id, request);
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _driverServices.DeleteDriver(id);
            return Ok();
        }

    }
}
