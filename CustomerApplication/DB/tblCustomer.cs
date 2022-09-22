using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerApplication.DB
{
    public class tblCustomer
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Customer Name")]
        public string Name { get; set; }
        [Display(Name = "Customer Type")]
        public int CustomerTypeId { get; set; }
        [Display(Name = "Description")]
        public string Description { get; set; }
        [Display(Name = "Address")]
        public string Address { get; set; }
        [Display(Name = "City")]
        public string City { get; set; }
        [Display(Name = "State")]
        public string State { get; set; }
        [Display(Name = "Zip")]
        public string Zip { get; set; }
        [Display(Name = "Last Updated")]
        public DateTime LastUpdated { get; set; }
    }
}
