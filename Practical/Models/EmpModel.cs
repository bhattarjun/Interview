﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Practical.Models
{
    public class EmpModel
    {

        //id emp_name joining_date salary dep_id

        [Key]
        public int c_id { get; set; }

        public string c_emp_name { get; set; }

        [DataType(DataType.Date)]
        public DateTime c_joining_date { get; set; }

        public int c_salary { get; set; }
        
        public int c_dep_id { get; set; }

        public string c_dep_name { get; set; }

        public string c_dep_location { get; set; }




    }
 

}