using System.Collections.Generic;
using System.Linq;
using Avander.Helpers;
using Avander.Models;

namespace Avander.Data
{
    public class MockShopRepo : IShopRepo
    {
        public PagedList<Shop> GetAllShops(ShopParameters shopParameters)
        {
            var shops = new List<Shop>{};

            for(int i=0; i < 100; i++)
            {
                shops.Add(new Shop{ShopId=i, Name=$"Shop {i}"});
            }

            return PagedList<Shop>.ToPagedList(shops.AsQueryable(), 1, 20);
        }
    }
}