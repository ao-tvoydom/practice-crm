using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Migrations.Entities
{
    public partial class Supply
    {
        public int SupplyId { get; set; }
        public int ProductInWarehouseId { get; set; }
        public string SupplierName { get; set; } = null!;
        public int Amount { get; set; }
        public DateTime Date { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public virtual ProductInWarehouse? ProductInWarehouse { get; set; }
    }
}
