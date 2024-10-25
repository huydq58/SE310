using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    internal class Products
    {
        public string ID { set; get; }
        public string Name { set; get; }
        public int Quantity { set; get; }
        public double Price { set; get; }    
        public string Origin {  set; get; }
        public DateTime Expiry {  set; get; }

        public Products(string id, string name, int quantity, double price,string origin, DateTime expiry) 
        {
            ID = id;
            Name = name;
            Quantity = quantity;
            Price = price;
            Origin = origin;
            Expiry = expiry;
        }
    }
}
