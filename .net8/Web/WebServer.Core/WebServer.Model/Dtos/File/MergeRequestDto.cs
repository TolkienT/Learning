using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServer.Model.Dtos.File
{
    public class MergeRequestDto
    {
        public string FileName { get; set; }
        public string FileHash { get; set; }
    }
}
