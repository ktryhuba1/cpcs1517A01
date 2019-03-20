using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region AdditionalNamespaces
using NorthwindSystem.Data; //access to <t> definitions
using System.Data.Entity; // access to EntityFramework ADO.net stuff
#endregion



//this class need to have access to ADO.net framework
// the nuget package EntityFramework has already been added to this proj
// this proj also needs the assembly System.Entity
// this proj also will need Using clauses to point to 
//    a) System.Entity namespace
//    b) your data proj namespace

namespace NorthwindSystem.DAL
{
    // the class access is restricted to request from within the 
    // library  by using internal
    // the class inherits (ties into EntityFrameWork) the class DbContext


    internal class NorthwindContext:DbContext
    {
       //setup your class default constructor to supply
       // your connection string name to the DbContext
       // inherited (base) class

        public NorthwindContext() : base("NWDB")
        {


        }

        //create an EntityFramework DbSet<t> for each mapped
        // sql table
        // <t> is your class in the .Data proj
        //this is a property
        public DbSet<Product> Products { get; set; }



    }
}
