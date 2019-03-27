using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

#region Additional Namespaces
using NorthwindSystem.BLL;  //controller class
using NorthwindSystem.Data; //data definition class
#endregion

namespace WebApp.SamplePages
{
    public partial class SqlProcQueries : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //clear out old messages
            MessageLabel.Text = "";

            //load the dropdownlist (ddl) with a sorted list
            //   of categories
            //thiis load will be done once when the page 1st is
            //   processed
            if (!Page.IsPostBack)
            {
                //use user friendly error handling
                try
                {
                    //the data collection will come from the database
                    //create and connect to the appropriate BLL class
                    CategoryController sysmgr = new CategoryController();
                    //issue a request for data via the appropriate BLL class method
                    List<Category> datainfo = sysmgr.Category_List();
                    //optionally: Sort the collection
                    datainfo.Sort((x, y) => x.CategoryName.CompareTo(y.CategoryName));
                    //attach the data to the ddl control
                    CategoryList.DataSource = datainfo;
                    //indicate the data properties for DataTextField and DataValueField
                    CategoryList.DataTextField = nameof(Category.CategoryName);
                    CategoryList.DataValueField = nameof(Category.CategoryID);
                    //physically bind the data to the ddl
                    CategoryList.DataBind();
                    //optionally: place a prompt on the ddl
                    CategoryList.Items.Insert(0, "select ...");
                }
                catch(Exception ex)
                {
                    MessageLabel.Text = ex.Message;
                }
            }
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            //ensure a selection was made
            if (CategoryList.SelectedIndex == 0)
            {
                //   no selection: message to user
                MessageLabel.Text = "Select a category to view category products.";
            }
            else
            {
                //   yes selection: process request for lookup
                //        user friendly error handling
                try
                {
                    //        create and connect to the appropriate BLL class
                    ProductController sysmgr = new ProductController();
                    //        issue the lookup request using the appropriate
                    //             BLL class method and capture results
                    List<Product> results = sysmgr.Product_GetByCategories(int.Parse(CategoryList.SelectedValue));
                    //        test the results ( .Count() == 0)
                    if (results.Count() == 0)
                    {
                        //        no results: bad, not found message
                        MessageLabel.Text = "No products found for request category";
                        //optionally: clear the previous successful data display
                        CategoryProductList.DataSource = null;
                        CategoryProductList.DataBind();
                    }
                    else
                    {
                        //        yes results: display returned data
                        CategoryProductList.DataSource = results;
                        CategoryProductList.DataBind();
                    }
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

        protected void CategoryProductList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //we must understand whats happening
            //the gridview uses the PageIndex to calc which row out of your data set to display
            // all other rows are ignored
            // when switching pages you MUST set the pageIndex prop
            // data for the new pag Index will come from the 'e' perameter of this method

            CategoryProductList.PageIndex = e.NewPageIndex;

            //the second step is to refresh the dataset of the control
            // this can be done by re-assigning the data set to the control
            // since our data collection is comming from a database
            // depending on the selected category we need to issue another call to the database
            // then bind that data to the control


            Submit_Click(sender,new EventArgs());

        }

        protected void CategoryProductList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //accessing DATA on a GridView cell is dependant on the Web control Data type
            //syntax for access (gvcontrolpointer.FindControl("CellcontrolID") as cellcontroltype).controlaccesstype

            //gvcontrolpointer isreference to the gridview row
            // cellcontrolID ID of teh control in the cell
            // cellcontroltype type of web control in the cell
            // controllaccesstype how is the web control accessed
            GridViewRow agvrow = CategoryProductList.Rows[CategoryProductList.SelectedIndex];


            string productid = (CategoryProductList.Rows[CategoryProductList.SelectedIndex].FindControl("ProductID") as Label).Text;
            string productname = (CategoryProductList.Rows[CategoryProductList.SelectedIndex].FindControl("ProductName") as Label).Text;
            string discontinued = "";
            if((agvrow.FindControl("Discontinued") as CheckBox).Checked)
            {
                discontinued = "discontinued";
            }
            else
            {
                discontinued = "available";
            }
            MessageLabel.Text = productname + " (" + productid + ") is " + discontinued;
        }
    }
}