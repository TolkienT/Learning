using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Model.Models
{
    public class HttpResultModel<T>
    {
        public int Status { get; set; } = 200;
        public string Message { get; set; }
        public T Data { get; set; }
        public HttpResultModel()
        {

        }
        public HttpResultModel(string message, T data)
        {
            Message = message;
            Data = data;
        }
    }
}
