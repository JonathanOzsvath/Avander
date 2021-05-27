using System.Collections.Generic;
using AutoMapper;
using Avander.Data;
using Avander.Dtos;
using Avander.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Avander.Controller
{
    [Route("api/shops")]
    [ApiController]
    public class ShopController : ControllerBase
    {
        private readonly IShopRepo _repository;
        private readonly IMapper _mapper;

        public ShopController(IShopRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // GET api/shops
        [HttpGet]
        public ActionResult<IEnumerable<ShopReadDto>> GetAllComands([FromQuery] ShopParameters shopParameters)
        {
            var shopsItems = _repository.GetAllShops(shopParameters);

            var metadata = new 
            {
                shopsItems.TotalCount,
                shopsItems.PageSize,
                shopsItems.CurrentPage,
                shopsItems.HasNext,
                shopsItems.HasPrevious
            };

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

            return Ok(_mapper.Map<IEnumerable<ShopReadDto>>(shopsItems));
        }
    }
}