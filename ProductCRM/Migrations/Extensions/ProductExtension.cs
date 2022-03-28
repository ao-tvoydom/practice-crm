using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Migrations.Entities;


public partial class Product
{
    public int[]? CategoryIdArray { get;  set; }
    
}