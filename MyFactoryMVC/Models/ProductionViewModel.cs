using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFactoryMVC.Models
{
    public static class Mappers
    {
        public static MaterialVM MapToVM(this Material mat)
        {
            return new MaterialVM { MaterialId = mat.Id, Name = mat.GoodsName };
        }

        public static ProductVM MapToVM(this Product pro)
        {
            return new ProductVM { ProductId = pro.Id,
                                   PruductName = pro.Name,
                                   MaterialsNeeded = pro.Materials.Select(x => x?.MapToVM()).ToList() };
        }
    }

    public class ProductionViewModel
    {
        public List<ProductVM> Products { get; set; }
        public List<MaterialVM> Materials { get; set; }
    }



    public class MaterialVM
    {
        public int MaterialId { get; set; }
        public string Name { get; set; }           
    }

    public class ProductVM
    {
        public int ProductId { get; set; }
        public string PruductName { get; set; }
        public List<MaterialVM>? MaterialsNeeded { get; set; }
    }


}
