using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LatestAngular.Data;
using LatestAngular.Models;
using LatestAngular.Resources;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LatestAngular.Controllers
{
    
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly AspNetCoreAndAngularContext _context;


        public VehiclesController(IMapper mapper, AspNetCoreAndAngularContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpPost("api/Vehicle/CreateVehicle")]
        public async Task<IActionResult> CreateVehicle([FromBody] VehicleResource vehicleResource)
        {
            var vehicle = Mapper.Map<VehicleResource, Vehicle>(vehicleResource);
            vehicle.LastUpdate=DateTime.Now;
            _context.Vehicle.Add(vehicle);
           await _context.SaveChangesAsync();
            var result = Mapper.Map<Vehicle, VehicleResource>(vehicle);
            return Ok(result);
        }
    }
}