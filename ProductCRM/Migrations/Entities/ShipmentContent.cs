using System;
using System.Collections.Generic;

namespace Migrations.Entities
{
    public partial class ShipmentContent
    {
        public int ShipmentContentId { get; set; }
        public int ShipmentId { get; set; }
        public int ProductWarehouseId { get; set; }
        public int Amount { get; set; }

        public virtual ProductInWarehouse ProductWarehouse { get; set; } = null!;
        public virtual Shipment Shipment { get; set; } = null!;
    }
}
