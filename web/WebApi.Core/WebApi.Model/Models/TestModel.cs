using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Model.Models
{
    public class TestModel
    {

    }


    public class TestProductModel
    {
        public string ProductName { get; set; }
        public string ProductBrand { get; set; }
        public decimal ProductPrice { get; set; }
        public double Quantity { get; set; }

    }
}
