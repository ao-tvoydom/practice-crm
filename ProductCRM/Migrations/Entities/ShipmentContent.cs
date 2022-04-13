using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Migrations.Entities
{
    public partial class ShipmentContent
    {
        public int ShipmentContentId { get; set; }
        public int ShipmentId { get; set; }
        public int ProductInWarehouseId { get; set; }
        public int Amount { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public virtual ProductInWarehouse? ProductWarehouse { get; set; }
        
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public virtual Shipment? Shipment { get; set; }
    }
}
