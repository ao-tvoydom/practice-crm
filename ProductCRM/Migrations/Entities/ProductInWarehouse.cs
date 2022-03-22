using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Migrations.Entities
{
    public partial class ProductInWarehouse
    {
        public ProductInWarehouse()
        {
            ShipmentContents = new HashSet<ShipmentContent>();
            Supplies = new HashSet<Supply>();
        }

        public int ProductInWarehouseId { get; set; }
        public int ProductId { get; set; }
        public int WarehouseId { get; set; }
        public int Amount { get; set; }

        public virtual Product Product { get; set; } = null!;
        public virtual Warehouse Warehouse { get; set; } = null!;
        
        [JsonIgnore]
        public virtual ICollection<ShipmentContent> ShipmentContents { get; set; }
        [JsonIgnore]
        public virtual ICollection<Supply> Supplies { get; set; }
    }
}
