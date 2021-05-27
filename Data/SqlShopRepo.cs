using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Avander.Helpers;
using Avander.Models;

namespace Avander.Data
{
    public class SqlShopeRepo : IShopRepo
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public SqlShopeRepo(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public PagedList<Shop> GetAllShops(ShopParameters shopParameters)
        {
            var shops = _context.Shops.AsQueryable();

            if (shopParameters.Name != null)
            {
                shops = shops.Where(s => s.Name.Contains(shopParameters.Name));
            }
            return PagedList<Shop>.ToPagedList(shops, shopParameters.PageNumber, shopParameters.PageSize);
        }
    }
}