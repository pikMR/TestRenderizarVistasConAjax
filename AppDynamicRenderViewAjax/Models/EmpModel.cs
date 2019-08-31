using System.ComponentModel.DataAnnotations;

namespace AppDynamicRenderViewAjax.Models
{
    public class EmpModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Address { get; set; }
        
        public string CODIGO_POSTAL { get; set; }
    }
}