using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelTest
{
    //public class StudentModel
    //{
    //    /// <summary>
    //    /// 序号
    //    /// </summary>
    //    public string Order { get; set; }

    //    public string Name { get; set; }

    //    public string Class { get; set; }
    //    public string Remark { get; set; }
    //}

    public class GradeModel
    {
        public string Class { get; set;}
        public string Name { get; set;}

        public string ChineseGrade { get; set; }
        public string ChineseOrder { get; set; }
        public string ChineseOrderInSchool { get; set; }

        public string MathGrade { get; set; }
        public string MathOrder { get; set; }
        public string MathOrderInSchool { get; set; }

        public string EnglishGrade { get; set; }
        public string EnglishOrder { get; set; }
        public string EnglishOrderInSchool { get; set; }

        public string TotalGrade { get; set; }
        public string TotalOrder { get; set; }
        public string TotalOrderInSchool { get; set; }

    }

    public class StudentModel
    {
        /// <summary>
        /// 序号
        /// </summary>
        public string Order { get; set; }

        public string Name { get; set; }

        public string Class { get; set; }
        public string Remark { get; set; }
        public string ChineseGrade { get; set; }
        public string ChineseOrder { get; set; }
        public string ChineseOrderInSchool { get; set; }

        public string MathGrade { get; set; }
        public string MathOrder { get; set; }
        public string MathOrderInSchool { get; set; }

        public string EnglishGrade { get; set; }
        public string EnglishOrder { get; set; }
        public string EnglishOrderInSchool { get; set; }

        public string TotalGrade { get; set; }
        public string TotalOrder { get; set; }
        public string TotalOrderInSchool { get; set; }
    }
}
