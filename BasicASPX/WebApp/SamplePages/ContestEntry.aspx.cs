using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp.SamplePages
{
    public partial class ContestEntry : System.Web.UI.Page
    {
        //The only reason why we are using this List<T> 
        //    is becasue we do not have a database to store
        //    our data. We are also NOT useing ViewState, cookies
        //    or session variables
        public static List<Entry> EntryCollection;
        protected void Page_Load(object sender, EventArgs e)
        {
            Message.Text = "";

            if (!Page.IsPostBack)
            {
                //first time page is processed
                EntryCollection = new List<Entry>();
            }
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            //validate the incoming data
            if (Page.IsValid)
            {
                //validate that the terms were accepted
                if (Terms.Checked)
                {
                    //   yes: create/load entry; add to storage; display entries
                    Message.Text = "okay";
                }
                else
                {
                    //    no: rejection message
                    Message.Text = "You did not accept the terms of the contest. Entry rejected.";
                }
            }
        }

        protected void Clear_Click(object sender, EventArgs e)
        {
            FirstName.Text = "";
            LastName.Text = "";
            StreetAddress1.Text = "";
            StreetAddress2.Text = "";
            City.Text = "";
            PostalCode.Text = "";
            EmailAddress.Text = "";
            CheckAnswer.Text = "";
            Province.SelectedIndex = 0;
            Terms.Checked = false;
        }
    }
}