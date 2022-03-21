using System;
using System.Collections.Generic;

namespace Migrations.Entities
{
    public partial class Product
    {
        public Product()
        {
            ProductCategories = new HashSet<ProductCategory>();
            ProductInWarehouses = new HashSet<ProductInWarehouse>();
        }

        public int ProductId { get; set; }
        public string Name { get; set; } = null!;
        public int Weight { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public int Length { get; set; }

        public virtual ICollection<ProductCategory> ProductCategories { get; set; }
        public virtual ICollection<ProductInWarehouse> ProductInWarehouses { get; set; }
    }
}
