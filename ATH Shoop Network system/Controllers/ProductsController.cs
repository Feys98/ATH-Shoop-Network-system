using ATH_Shoop_Network_system.Models.Product;
using ATH_Shoop_Network_system_Server.Data;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ATH_Shoop_Network_system.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly IMapper _mapper;

        public ProductsController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            IEnumerable<Product> Products = await _context.Product.ToListAsync();
            var productIndexViewModel = new ProductIndexViewModel()
            {
                Products = _mapper.Map<List<ProductViewModel>>(Products)
            };
            
            return View(productIndexViewModel);       
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Product == null)
            {
                return NotFound();
            }

            IEnumerable<Product> Products = await _context.Product.ToListAsync();

            var dbProduct = Products.FirstOrDefault(x => x.Id == id);

            if (dbProduct == null)
            {
                return NotFound();
            }

            var mappedProduct = _mapper.Map<ProductDetailsViewModel>(dbProduct);
            
            mappedProduct.Products = _mapper.Map<List<ProductViewModel>>(Products);
            
            return View(mappedProduct);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Price")] ProductCreateViewModel productCreateViewModel)
        {

            var dbAddProduct = _context;
            
            if (ModelState.IsValid)
            {
                var mappedProductToAdd = _mapper.Map<Product>(productCreateViewModel);
                dbAddProduct.Add(mappedProductToAdd);             
                await dbAddProduct.SaveChangesAsync();
                
                return RedirectToAction(nameof(Index));
            }
            
            return View(productCreateViewModel);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Product == null)
            {
                return NotFound();
            }

            var dbProduct = await _context.Product.FindAsync(id);
            var mappedProduct = _mapper.Map<ProductEditViewModel>(dbProduct);
            
            if (mappedProduct == null)
            {
                return NotFound();
            }
            return View(mappedProduct);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Price")] ProductEditViewModel productEditViewModel)
        {
            var dbEditProduct = _context;
            var mappedProduct = _mapper.Map<Product>(productEditViewModel);

            if (id != mappedProduct.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mappedProduct);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(mappedProduct.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(mappedProduct);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Product == null)
            {
                return NotFound();
            }


            var dbProduct = await _context.Product.FirstOrDefaultAsync(m => m.Id == id);
            var mappedProduct = _mapper.Map<ProductDeleteViewModel>(dbProduct);

            if (mappedProduct == null)
            {
                return NotFound();
            }

            return View(mappedProduct);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dbDeleteProduct = _context;

            if (dbDeleteProduct.Product == null)
            {
                return Problem("Entity set 'ATH_Shoop_Network_systemContext.Product'  is null.");
            }
            var dbProduct = await dbDeleteProduct.Product.FindAsync(id);

            var mappedProduct = _mapper.Map<Product>(dbProduct);

            if (mappedProduct != null)
            {
                dbDeleteProduct.Product.Remove(mappedProduct);
            }

            await dbDeleteProduct.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return (_context.Product?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
