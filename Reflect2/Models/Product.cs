using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reflect2.Models

{
    [Table("Product", Schema = "Production")]
    public class Product
    {
        [NotMapped]
        public int PageNo { get; set; }
        public int ProductID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(25)]
        public string ProductNumber { get; set; }

        [Required]
        public bool? MakeFlag { get; set; }
        [Required]
        public bool? FinishedGoodsFlag { get; set; }
        [StringLength(15)]
        public string Color { get; set; }
        public short SafetyStockLevel { get; set; }
        public short ReorderPoint { get; set; }
        [Column(TypeName = "money")]
        public decimal StandardCost { get; set; }
        [Column(TypeName = "money")]
        public decimal ListPrice { get; set; }
        [StringLength(5)]
        public string Size { get; set; }
        [StringLength(3)]
        public string SizeUnitMeasureCode { get; set; }
        [StringLength(3)]
        public string WeightUnitMeasureCode { get; set; }

        [DataType("decimal(8,2)")]
        public decimal? Weight { get; set; }

        public int DaysToManufacture { get; set; }
        [StringLength(2)]
        public string ProductLine { get; set; }
        [StringLength(2)]
        public string Class { get; set; }
        [StringLength(2)]
        public string Style { get; set; }
        public int? ProductSubcategoryID { get; set; }
        public int? ProductModelID { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime SellStartDate { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? SellEndDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DiscontinuedDate { get; set; }
        public Guid rowguid { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; }
    }
}