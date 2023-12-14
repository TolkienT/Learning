using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebServer.Model.Enums;

namespace WebServer.Model.Models
{
    public class HttpResultModel
    {
        public HttpResultModel()
        {

        }
        public HttpResultModel(object data)
        {
            Success = true;
            Status = HttpResultStatus.OK;
            Data = data;
        }

        public HttpResultStatus Status { get; set; } = HttpResultStatus.OK;
        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}
