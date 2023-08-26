using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Common.Helpers
{
    public class ConvertHelper
    {
        /// <summary>
        /// 将泛类型集合List类转换成DataTable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list">泛类型集合</param>
        /// <returns></returns>
        public static DataTable ListToDataTable<T>(IList<T> list)
        {
            Type entityType = typeof(T);
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(entityType);

            DataTable table = new DataTable(entityType.Name);
            foreach (PropertyDescriptor prop in properties)
            {
                if (prop.PropertyType.Name.IndexOf("Nullable", StringComparison.OrdinalIgnoreCase) >= 0)
                    table.Columns.Add(prop.Name, Type.GetType("System.String"));
                else
                    table.Columns.Add(prop.Name, prop.PropertyType);
            }

            foreach (T item in list)
            {
                DataRow row = table.NewRow();

                foreach (PropertyDescriptor prop in properties)
                {
                    row[prop.Name] = prop.GetValue(item);
                }

                table.Rows.Add(row);
            }

            return table;
        }


    }
}
