using System.Collections.Generic;
using AutoMapper;
using Avander.Data;
using Avander.Dtos;
using Avander.Models;
using Microsoft.AspNetCore.Mvc;

namespace Avander.Controller
{
    [Route("api/measurementpoints")]
    [ApiController]
    public class MeasurementPointController : ControllerBase
    {
        private readonly IMeasurementPointRepo _repository;
        private readonly IMapper _mapper;

        public MeasurementPointController(IMeasurementPointRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // GET api/measurementpoints
        [HttpGet]
        public ActionResult<IEnumerable<MeasurementPointReadDto>> GetAllComands()
        {
            var measurementPointItems = _repository.GetAllMeasurementPoints();

            return Ok(_mapper.Map<IEnumerable<MeasurementPointReadDto>>(measurementPointItems));
        }
    }
}