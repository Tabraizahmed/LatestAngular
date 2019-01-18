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
using Microsoft.EntityFrameworkCore;

namespace LatestAngular.Controllers
{
    [Route("/api/vehicles")]
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

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVehicle(int id,[FromBody] VehicleResource vehicleResource)
        {
            if (!ModelState.IsValid)
                return BadRequest();


            var vehicle = await _context.Vehicle.Include(v => v.Features).SingleOrDefaultAsync(v => v.Id == id);

            if (vehicle == null)
                return NotFound();

            Mapper.Map<VehicleResource, Vehicle>(vehicleResource,vehicle);
            vehicle.LastUpdate = DateTime.Now;

           
            await _context.SaveChangesAsync();

            var result = Mapper.Map<Vehicle, VehicleResource>(vehicle);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicle(int id)
        {
            var vehicle = await _context.Vehicle.FindAsync(id);
            if (vehicle==null)
            {
                return NotFound();
            }

            _context.Remove(vehicle);
            await _context.SaveChangesAsync();

            return Ok(id);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetVehicle(int id)
        {
            var vehicle = await _context.Vehicle.Include(v => v.Features).SingleOrDefaultAsync(v => v.Id == id);
            if (vehicle==null)
            {
                return NotFound();
            }

          var vehicleResource=  Mapper.Map<Vehicle, VehicleResource>(vehicle);

            return Ok(vehicleResource);

        }
    }
}