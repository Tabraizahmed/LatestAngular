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
    [Produces("application/json")]
    [ApiController]
    public class FeatureController : ControllerBase
    {
        private readonly AspNetCoreAndAngularContext _context;
        private readonly IMapper _mapper;

        public FeatureController(IMapper mapper, AspNetCoreAndAngularContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpGet("api/Vehicle/Features")]
        public async Task<IEnumerable<FeatureResource>> GetFeatures()
        {
            var features = await _context.Features.ToListAsync();
            return _mapper.Map<List<Feature>, List<FeatureResource>>(features);
        }
        
    }
}