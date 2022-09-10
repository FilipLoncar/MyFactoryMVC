using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyFactoryMVC.Models
{
    public class Material
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string GoodsName { get; set; }
        public double Quantity { get; set; }
        
        public int MeasureUnitId { get; set; }
        public MeasureUnit MeasureUnit { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
