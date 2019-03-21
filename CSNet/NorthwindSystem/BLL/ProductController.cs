
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


#region AdditionalNamespaces
using NorthwindSystem.Data; // the .Data class
using NorthwindSystem.DAL; // the DAL context class

#endregion

namespace NorthwindSystem.BLL
{

    // the classes within the dLL are referred to as your interface
    // these classes will be called by your WebAPP
    // for ease of maintenance, each class will represent a specific data class, eg. product

    public class ProductController
    {
        //create a method to find a specific record on the sql table
        // this will be done by the primary key
        // input: search arg value
        // output: results of the search - a single product record
        // this method must be public

        public Product Product_Get(int productid)
        {
            //connect to the appropriate context class to access the database
            //create an instance of the appropriate context class
            //accessing the appropriate DbSet<T>, issue a request for execution
            //  against thee SQL table
            // the appropriate request return data will be received 
            // return the results
            // the request will be done in a transaction

            // this is a look-up by PRIMARY KEY
            using (var context = new NorthwindContext())
            {
                return context.Products.Find(productid);
            }
        }

        // another search is to get all table records
        //input: none
        // output: List<T> where T is the appropriate Data class (Product)
        public List<Product> Product_list()
        {
            using (var context = new NorthwindContext())
            {
                return context.Products.ToList();
            }

        }


    }
}
