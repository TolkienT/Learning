using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Model.Enums;

namespace WebApi.Model.Models
{
    public class HttpResultModel<T>
    {
        public HttpResultStatus Status { get; set; } = HttpResultStatus.OK;
        public string Message { get; set; }
        public T Data { get; set; }
        public HttpResultModel()
        {

        }

        public HttpResultModel(T data, string message = "Success", HttpResultStatus status = HttpResultStatus.OK)
        {
            Status = status;
            Message = message;
            Data = data;
        }

    }
}
