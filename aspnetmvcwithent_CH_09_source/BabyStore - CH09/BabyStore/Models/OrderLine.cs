using System.ComponentModel.DataAnnotations;

namespace BabyStore.Models
{
    public class OrderLine
    {
        public int ID { get; set; }
        public int OrderID { get; set; }
        public int? ProductID { get; set; }
        public int Quantity { get; set; }
        public string ProductName { get; set; }
        [Display(Name = "Unit Price")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public decimal UnitPrice { get; set; }
        public virtual Product Product { get; set; }
        public virtual Order Order { get; set; }
    }
}