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
