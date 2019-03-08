using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp
{
    public class GridViewData
    {
        public string Fullname { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string FullorPartTime { get; set; }
        public string Jobs { get; set; }
        
        public GridViewData()
        { }

        public GridViewData(string fullname, string email, string phone, string fullorpart, string jobs)
        {
            Fullname = fullname;
            EmailAddress = email;
            PhoneNumber = phone;
            FullorPartTime = fullorpart;
            Jobs = jobs;
        }
        
    }
}