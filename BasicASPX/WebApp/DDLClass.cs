using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp
{
    public class DDLClass
    {
        //data members
        public int ValueField { get; set; }
        public string DisplayField { get; set; }
        
        //contructors
        public DDLClass()
        {
            //default
        }
        public DDLClass(int valuefield, string displayfield)
        {
            //greedy
            ValueField = valuefield;
            DisplayField = displayfield;

        }
    }
}