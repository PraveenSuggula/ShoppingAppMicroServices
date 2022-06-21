using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using Shopping.API.Data;
using Shopping.API.Models;
using Newtonsoft.Json;
using System;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Shopping.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController
    {
        private readonly ILogger<ProductController> _logger;
        private readonly ProductContext _context;
        private readonly HttpClient _httpClient;
        public ProductController(ProductContext context, ILogger<ProductController> logger, IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClient = httpClientFactory.CreateClient("coindeskAPI");
            _context = context;
            _logger = logger;
        }
       
        [HttpGet]
        public async Task<IEnumerable<Product>> Get()
        {
            return await _context.Products.Find(prop=>true).ToListAsync();
        }
        [Route("test")]
        [HttpGet]
        public async Task<coindesk> CoinGet()
        {
            var res = await _httpClient.GetAsync("");
            var content = await res.Content.ReadAsStringAsync();
            var coinList = JsonConvert.DeserializeObject<coindesk>(content);
            return coinList;
        }

    }
}
