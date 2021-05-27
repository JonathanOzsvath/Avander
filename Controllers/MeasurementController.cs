using System.Collections.Generic;
using AutoMapper;
using Avander.Data;
using Avander.Dtos;
using Avander.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Avander.Controller
{
    [Route("api/measurements")]
    [ApiController]
    public class MeasurementController : ControllerBase
    {
        private readonly IMeasurementRepo _repository;
        private readonly IMapper _mapper;

        public MeasurementController(IMeasurementRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // GET api/measurements
        [HttpGet]
        public ActionResult<IEnumerable<MeasurementReadDto>> GetAllMeasurements([FromQuery] MeasurementParameters measurementParameters)
        {
            var measurementItems = _repository.GetAllMeasurements(measurementParameters);

            var metadata = new
            {
                measurementItems.TotalCount,
                measurementItems.PageSize,
                measurementItems.CurrentPage,
                measurementItems.HasNext,
                measurementItems.HasPrevious
            };

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

            return Ok(_mapper.Map<IEnumerable<MeasurementReadDto>>(measurementItems));
        }

        // GET api/measurements/{id}
        [HttpGet("{id}", Name = "GetMeasurementById")]
        public ActionResult<MeasurementReadDto> GetMeasurementById(int id)
        {
            var measurementItem = _repository.GetMeasurementById(id);

            if (measurementItem != null)
            {
                return Ok(_mapper.Map<MeasurementReadDto>(measurementItem));
            }
            return NotFound();
        }

        // POST api/measurements
        [HttpPost]
        public ActionResult<MeasurementReadDto> CreateMeasurement(MeasurementCreateDto measurementCreateDto)
        {
            var measurementModel = _mapper.Map<Measurement>(measurementCreateDto);
            _repository.CreateMeasurement(measurementModel);
            _repository.SaveChanges();

            var measurementReadDto = _mapper.Map<MeasurementReadDto>(measurementModel);

            return CreatedAtRoute(nameof(GetMeasurementById), new { Id = measurementReadDto.Id }, measurementReadDto);
        }

        //PUT api/measurements/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateMeasurement(int id, MeasurementUpdateDto measurementUpdateDto)
        {
            var measurementModelFromRepo = _repository.GetMeasurementById(id);

            if (measurementModelFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(measurementUpdateDto, measurementModelFromRepo);

            _repository.UpdateMeasurement(measurementModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

        //DELETE api/measurements/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteMeasurement(int id)
        {
            var measurementModelFromRepo = _repository.GetMeasurementById(id);

            if (measurementModelFromRepo == null)
            {
                return NotFound();
            }

            _repository.DeleteMeasurement(measurementModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}