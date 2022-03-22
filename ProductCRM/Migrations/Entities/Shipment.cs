using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Migrations.Entities
{
    public partial class Shipment
    {
        public Shipment()
        {
            ShipmentContents = new HashSet<ShipmentContent>();
        }

        public int ShipmentId { get; set; }
        public string TargetAddress { get; set; } = null!;
        public DateTime ShipmentStartDate { get; set; }
        public DateTime ShipmentEndDate { get; set; }
        public string ContactPhone { get; set; } = null!;

        [JsonIgnore]
        public virtual ICollection<ShipmentContent> ShipmentContents { get; set; }
    }
}
