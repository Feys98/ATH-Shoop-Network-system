using ATH_Shoop_Network_system.Models;
using Microsoft.AspNetCore.Mvc;

namespace ATH_Shoop_Network_system.Controllers
{
    public class ShopsController : Controller
    {
        private List<ShopViewModel> shops = new List<ShopViewModel>()
        {
            new ShopViewModel()
            {
                Id = 1,
                Name = "Shop 1",
                Address = "Address 1",
                Phone = "Phone 1",
            },
            new ShopViewModel()
            {
                Id = 2,
                Name = "Shop 2",
                Address = "Address 2",
                Phone = "Phone 2",
            },
            new ShopViewModel()
            {
                Id = 3,
                Name = "Shop 3",
                Address = "Address 3",
                Phone = "Phone 3",
            },
            new ShopViewModel()
            {
                Id = 4,
                Name = "Shop 4",
                Address = "Address 4",
                Phone = "Phone 4",
            }
        };

        public IActionResult Index()
        {
            var shopItemsViewModel = new ShopItemsViewModel()
            {
                Shops = shops
            };
            return View(shopItemsViewModel);
        }

        public IActionResult ShopsList(int id)
        {
            var shopViewModel = shops.Find(x => x.Id == id);

            return View(shopViewModel);
        }
    }
}
