using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AppCalories.Domain.EFStuff.Models
{
    public class Product: BaseModel, IOptionsProduct
    {
        public string Name { get; set; }
        public decimal Calories { get; set; }
        public decimal Proteins { get; set; }
        public decimal Carbohydrates { get; set; }
        public decimal Fats { get; set; }

    }
}
