using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiProduto.Models
{
    public class Product
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string Name { get; set; }
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
        public int Stock { get; set; }

        // Construtor vazio para o EF
        protected Product() { }
        public Product(string name, decimal price, int stock)
        {
            Name = name;
            Price = price;
            Stock = stock;
        }
    }
}
