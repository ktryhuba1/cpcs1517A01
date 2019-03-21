
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

#region AdditionalNameSpaces
using NorthwindSystem.BLL; //controller class
using NorthwindSystem.Data; // to data definition (product class)

#endregion

namespace WebApp.SamplePages
{
    public partial class SimpleQueries : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //clear out old messages
            MessageLabel.Text = "";
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            //VALIDATION
            int productid = 0;

            if (string.IsNullOrEmpty(SearchArg.Text.Trim()))
            { // if bad: error message
                MessageLabel.Text = "Enter a product id to search";
            }
            else if(int.TryParse(SearchArg.Text.Trim(),out productid))
            {
                 // if good: process Database request
            //   connect to BLL controller
            
                try
                {
                    ProductController sysmgr = new ProductController();
                    //   issue request to controller
                    Product results = sysmgr.Product_Get(productid);
                   
                    //   check results: single record check is == null
                   if(results == null)
                    { //       if none: error message to user
                        MessageLabel.Text = "No data found for supplied search value";
                    }
                   else
                    { //       if found: display Data
                        ProductID.Text = results.ProductID.ToString();
                        ProductName.Text = results.ProductName;
                    }
                           
                           



                }
                catch (Exception ex)
                {
                    MessageLabel.Text = ex.Message;
                }


            }
            else
            {
                //bad:message to the user
                MessageLabel.Text = "Product ID is a number greater than 0";
            }

           
      



        }

        protected void Clear_Click(object sender, EventArgs e)
        {
            SearchArg.Text = "";
            ProductID.Text = "";
            ProductName.Text = "";
        }
    }
}