using System;
using System.Collections.Generic;

namespace Migrations.Entities
{
    public partial class Category
    {
        public Category()
        {
            ProductCategories = new HashSet<ProductCategory>();
        }

        public int CategoryId { get; set; }
        public string Name { get; set; } = null!;
        public string? ColorHex { get; set; }

        public virtual ICollection<ProductCategory> ProductCategories { get; set; }
    }
}
