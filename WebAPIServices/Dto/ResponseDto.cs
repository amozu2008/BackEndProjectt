using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIServices.Dto
{
    public class ResponseDto<T>
    {
        public bool IsSuccess { get; set; }
        public T Result { get; set; }
        public string DisplayMessages { get; set; }
        public List<string> ErrorMessages { get; set; }
    }
}
