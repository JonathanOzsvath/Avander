using System.Collections.Generic;
using Avander.Helpers;
using Avander.Models;

namespace Avander.Data
{
    public interface IShopRepo
    {
        PagedList<Shop> GetAllShops(ShopParameters shopParameters);
    }
}