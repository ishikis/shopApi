using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using shopApi.Models;

namespace shopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    // [Authorize]
    public class ProductController : ControllerBase
    {
        private DataContext context;

        public ProductController(DataContext _context)
        {
            context = _context;
        }

        [HttpGet]
        public List<product> Get()
        {
            return context.products.ToList();
        }
    }
}
