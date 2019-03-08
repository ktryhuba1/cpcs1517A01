using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp.SamplePages
{
    public partial class JobApplication : System.Web.UI.Page
    {
        public static List<GridViewData> gvcollection;

        protected void Page_Load(object sender, EventArgs e)
        {
            Message.Text = "";
            if (!Page.IsPostBack)
            {
                gvcollection = new List<GridViewData>();

            }


        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            //assuming all data is valid 
            //the class level list<t> will hold the collection of data for the page
            //we have no database.... yet!
            //the data collection will be displayed in a table-like grid-control called GridView

            string fullname = FullName.Text;
            string email = EmailAddress.Text;
            string phone = PhoneNumber.Text;
            string fullorparttime = FullOrPartTime.SelectedValue;

            //the check box list can have several options selected,each option needs to be recorded..
            // we have to traverse the options of the control and record each selected option
            //CheckBoxList options are a collection of rows
            //foreach will loop through a colection of rows

            string jobs = "";
            foreach(ListItem jobrow in Jobs.Items)
            {
                if(jobrow.Selected)
                {
                    jobs += jobrow.Text + " ";
                
                }

            }

            gvcollection.Add(new GridViewData(fullname, email, phone, fullorparttime, jobs));

            //display the data collection to an appropriate control that will display multiple items
            JobApplicantList.DataSource = gvcollection;

            JobApplicantList.DataBind();



        }

        protected void Clear_Click(object sender, EventArgs e)
        {
            FullName.Text = "";
            EmailAddress.Text = "";
            PhoneNumber.Text = "";
            FullOrPartTime.SelectedIndex = -1;
            // or FullOrPartTime.ClearSelection();
            // Jobs.SelectedIndex = -1;
            Jobs.ClearSelection();

            JobApplicantList.DataSource = null;
            JobApplicantList.DataBind();

        }
    }
}