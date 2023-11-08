using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Common.Helpers
{
    public class FileHelper
    {
        public static string GetFileType(string imageName)
        {
            string typeStr = "application/octet-stream";
            if (imageName.EndsWith("png"))
            {
                typeStr = "image/png";
            }
            else if (imageName.EndsWith("jpg") || imageName.EndsWith("jpeg"))
            {
                typeStr = "image/jpeg";
            }
            else if (imageName.EndsWith("gif"))
            {
                typeStr = "image/gif";
            }
            return typeStr;
        }



    }
}
