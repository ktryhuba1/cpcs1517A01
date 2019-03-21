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
    public partial class SqlProcQueries : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //clear out old messages
            MessageLabel.Text = "";



            //load the dropdownlist DDL with a sorted list of the categories
            //this load will be done once when the page 1st is loaded

            if (Page.IsPostBack)
            {
                //user friendly errror handling
                try
                {
                    //the data collection will come from the database
                    //create and connect to the appropriate BLL class
                    CategoryController sysmgr = new CategoryController();
                    // the issue a request for data from the appropriate BLL class method
                    List<Category> datainfo = sysmgr.Category_List();
                    //sort the collection(List<t>) 
                    datainfo.Sort((x, y) => x.CategoryName.Compareto(y.CategoryName));
                    //attach the daata to the DDL control
                    CategoryList.DataSource = datainfo;
                    // indicate the data properties for the datatextfield and the DataValueField
                    CategoryList.DataTextField = nameof(CategoryList.CategoryName);
                    CategoryList.DataValueField = nameof(CategoryList.CategoryID);

                    //physically bind the data to the DDL
                    CategoryList.DataBind();
                    // optionally place a  promt on the DDL
                    CategoryList.Items.Insert(0, "select...");
                }
                catch(Exception ex)
                {
                    MessageLabel.Text = ex.Message;
                }


            }
            

        }

        protected void Clear_Click(object sender, EventArgs e)
        {
            CategoryList.ClearSelection();
            CategoryProductList.DataSource = null;
            CategoryProductList.DataBind();
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            //ensure a selection was made
            if (CategoryList.SelectedIndex == 0)
            { // no selection: message to user
                MessageLabel.Text = "Select a Category to view Products";
            }
            else
            { // yes selection: process request for look-up
                // user friendly error handling
                try
                {// create and connect to the appropriate BLL class
                    ProductController sysmgr = new ProductController();

                    // issue the lookup request using the apprpriate BLL class method and capture Results
                    List<Product> results = sysmgr.Product_GetByCategories(int.Parse(CategoryList.SelectedValue));
                     // test the results (.count()==0)
                     if(results.Count() == 0)
                    {
                        MessageLabel.Text = "No products found for requested category";
                    }
                     else
                    {//
                        CategoryProductList.DataSource = results;
                        CategoryProductList.DataBind();
                    }

                }
                catch(Exception es)
                {
                    MessageLabel.Text = es.Message;
                }
               
               
                
               


            }
        }
    }
}