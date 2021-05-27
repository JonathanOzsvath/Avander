using System.Collections.Generic;
using AutoMapper;
using Avander.Data;
using Avander.Dtos;
using Avander.Models;
using Microsoft.AspNetCore.Mvc;

namespace Avander.Controller
{
    [Route("api/vehicles")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private readonly IVehicleRepo _repository;
        private readonly IMapper _mapper;

        public VehiclesController(IVehicleRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // GET api/vehicles
        [HttpGet]
        public ActionResult<IEnumerable<VehicleReadDto>> GetAllComands()
        {
            var vehiclesItems = _repository.GetAllVehicles();

            return Ok(_mapper.Map<IEnumerable<VehicleReadDto>>(vehiclesItems));
        }
    }
}