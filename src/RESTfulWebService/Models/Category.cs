using System;
using System.Collections.Generic;
using System.Linq;
namespace RESTfulWebService.Models
{
    public class Category
    {
        public long CategoryId { get; set; }
        public string Name { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }
}
