using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class SemesterValidation : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value != null)
            {
                string semester = value.ToString();
                if (semester == "1" || semester =="1 2" || semester =="2" )
                    return true;
                else
                    this.ErrorMessage = "Семестр может иметь значения 1 или 2";
            }
            return false;
        }
    }
}
