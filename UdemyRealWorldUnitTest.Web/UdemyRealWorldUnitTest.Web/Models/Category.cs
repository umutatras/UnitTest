using System.Collections.Generic;
using UdemyRealWordUnitTest.Web.Models;

namespace UdemyRealWorldUnitTest.Web.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
