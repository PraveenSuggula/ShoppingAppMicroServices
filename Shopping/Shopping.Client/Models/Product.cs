using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping.Client.Models
{
    public class Product
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string ImageFile { get; set; }
        public decimal Price { get; set; }
    }
    public class coindesk
    {
        public bpi bpi { get; set; }
    }

    public class bpi
    {
        public bpiResponse USD { get; set; }
        public bpiResponse GBP { get; set; }
        public bpiResponse EUR { get; set; }
    }
    public class bpiResponse
    {
        public string code { get; set; }
        public string symbol { get; set; }
        public string rate { get; set; }
        public string description { get; set; }
        public double rate_float { get; set; }
    }
}
