using MessagePack;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace CustomerApplication.DB
{
    public class CustomerType
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int Id { get; set; }
        [Display(Name = "Customer Type")]
        public string Name { get; set; }
    }
}
