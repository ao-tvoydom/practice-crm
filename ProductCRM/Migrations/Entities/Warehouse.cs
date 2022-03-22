using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Migrations.Entities
{
    public partial class Warehouse
    {
        public Warehouse()
        {
            ProductInWarehouses = new HashSet<ProductInWarehouse>();
        }

        public int WarehouseId { get; set; }
        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;

        [JsonIgnore]
        public virtual ICollection<ProductInWarehouse> ProductInWarehouses { get; set; }
    }
}
