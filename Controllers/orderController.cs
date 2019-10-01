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
    public class OrderController : ControllerBase
    {
        private DataContext context;

        public OrderController(DataContext _context)
        {
            context = _context;
        }

        [HttpGet]
        public List<order> Get()
        {
            return context.orders.ToList();
        }


        [HttpPost]
        public order Post([FromBody] order value)
        {
            context.orders.Add(value);
            context.SaveChanges();
            return value;
        }
    }
}
