using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using LatestAngular.Data;
using LatestAngular.Models;
using LatestAngular.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LatestAngular.Controllers
{
    [Produces("application/json")]
    [ApiController]
    public class MakesController : ControllerBase
    {
        private readonly AspNetCoreAndAngularContext _context;
        private readonly IMapper _mapper;

        public MakesController(AspNetCoreAndAngularContext context, IMapper mapper)
        {
            this._mapper = mapper;
            _context = context;
        }
        [HttpGet("api/Vehicle/Makes")]
        public async Task<IEnumerable<MakeResource>> GetMakes()
        {
            var makes = await _context.Makes.Include(m => m.Models).ToListAsync();
            return _mapper.Map<List<Make>, List<MakeResource>>(makes);
        }
    }
}