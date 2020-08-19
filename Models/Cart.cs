using Recepboyvat.ECommerceMVCWeb.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Recepboyvat.ECommerceMVCWeb.Models
{
    public class Cart
    {
        private List<CartLine> _cardlines = new List<CartLine>();
        public List<CartLine> CartLines
        {
            get { return _cardlines; }
        }

        public void AddProduct(Product product,int quantity)
        {
            var line = _cardlines.FirstOrDefault(i => i.Product.Id == product.Id);
            if(line==null)
            {
                _cardlines.Add(new CartLine() { Product = product, Quantity = quantity });
            }
            else
            {
                line.Quantity += quantity;
            }
        }
        public void DeleteProduct(Product product)
        {
            _cardlines.RemoveAll(i => i.Product.Id == product.Id);
        }

        public double Total()
        {
            return _cardlines.Sum(i => i.Product.Price * i.Quantity);
        }

        public void Clear()
        {
            _cardlines.Clear();
        }


    }
    public class CartLine
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}