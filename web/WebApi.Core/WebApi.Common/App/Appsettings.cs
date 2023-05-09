using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace WebApi.Common.App
{
    public class Appsettings
    {
        public Appsettings(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public static IConfiguration Configuration { get; set; }

        public static string GetValue(string section)
        {
            try
            {
                return Configuration[section];
            }
            catch
            {

            }
            return string.Empty;
        }

        public static string GetApp(params string[] sections)
        {
            try
            {

                if (sections.Any())
                {
                    return Configuration[string.Join(":", sections)];
                }
            }
            catch (Exception) { }

            return "";
        }

        public static List<T> GetApp<T>(params string[] sections)
        {
            try
            {
                List<T> list = new List<T>();
                // 引用 Microsoft.Extensions.Configuration.Binder 包
                Configuration.Bind(string.Join(":", sections), list);
                return list;
            }
            catch
            {

            }
            return null;
        }
    }
}
