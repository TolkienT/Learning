using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiDemo.Model
{
    public class ResponseModel<T>
    {
        public int Status { get; set; } = 200;
        public string Message { get; set; }
        public T Data { get; set; }
        public ResponseModel()
        {

        }
        public ResponseModel(string message,T data)
        {
            Message=message;
            Data = data;
        }
    }
}
