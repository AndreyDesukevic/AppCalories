using AppCalories.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCalories.Domain.Response
{
    public interface IBaseResponse<T>
    {
        T Data { get; }
        StatusCode StatusCode { get; set; }
        string Description { get; set; }

    }
}
