namespace WinterWood.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Invoice")]
    public partial class Invoice
    {
        public int InvoiceId { get; set; }

        public int AccountId { get; set; }

        public DateTime TaxPointDate { get; set; }

        public string Reference { get; set; }

        public decimal TotalNet { get; set; }

        public decimal TotalVat { get; set; }

        public decimal TotalGross { get; set; }

        public virtual Account Account { get; set; }
    }
}
