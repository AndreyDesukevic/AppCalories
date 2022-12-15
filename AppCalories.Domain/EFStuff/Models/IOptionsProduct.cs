using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCalories.Domain.EFStuff.Models
{
    public interface IOptionsProduct
    {
        decimal Calories { get; set; }
        decimal Proteins { get; set; }
        decimal Carbohydrates { get; set; }
        decimal Fats { get; set; }
    }
}
