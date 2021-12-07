using System.Collections.Generic;

namespace RESTfulWebService.Models
{
    public class Category
    {
        public long CategoryId { get; set; }
        public string Name { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }
}
