using MazadMarket.Resourses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
//percentage_increase
namespace MazadMarket.Models
{
    public class ProductsAuction
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "productName", ResourceType = typeof(layout))]
        public int ProductsId { get; set; }

        [Display(Name = "userId", ResourceType = typeof(layout))]
        public string userId { get; set; }

        [Required]
        [Display(Name = "riseAmount", ResourceType = typeof(layout))]
        public double riseAmount { get; set; }

        [Display(Name = "dateOfRise", ResourceType = typeof(layout))]
        public DateTime dateOfRise { get; set; }


        [Display(Name = "Remarks", ResourceType = typeof(layout))]
        public string Remarks { get; set; }

        [Display(Name = "ValueUp", ResourceType = typeof(layout))]
        public double valueUP { get; set; }

        [Display(Name = "limitPrice", ResourceType = typeof(layout))]
        public double limitPrice { get; set; }

        public virtual Products Products { get; set; }
        public virtual ICollection<paymentConfirmation> paymentConfirmation { get; set; }

    }

}