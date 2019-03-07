using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp.SamplePages
{
    public partial class BasicControls : System.Web.UI.Page
    {
        
        //we could retrieve data from a stored variable that is part of the webpage
        //  saved under the ViewState
        
        //  instead we will use a static list<t> for this example. normally your data would come from a database
        public static List<DDLClass> DataCollection;

        protected void Page_Load(object sender, EventArgs e)
        {
            //this method is excuted automatically on each and every pass of the page (~kinda like IsPost)
            //this method is executed BEFORE any event method on this page

            //clear any old messages
            OutputMessage.Text = "";

            //this method is an excellant place to do page initialization
            //you can test to post back on the page (IsPost)
            // by checking Page.IsPostBack property

            if(!Page.IsPostBack)
            {
                //the first time the page is processed 

                //create an intance of out list<t> 
                DataCollection = new List<DDLClass>();

                //load the collection with a series of DDLCLASS instances
                //create the instances using the greedy constuctor

                DataCollection.Add(new DDLClass(1, "COMP1008"));
                DataCollection.Add(new DDLClass(2, "CPSC1517"));
                DataCollection.Add(new DDLClass(3, "DMIT2018"));
                DataCollection.Add(new DDLClass(4, "DMIT1508"));

                //use the list<t> method called .Sort to sort the contents of the list
                // (x,y) the x and y represent two instances at any time in your collection
                // x.field compared to y.field (ascending)
                // y.field compared to x.field (decending)
                DataCollection.Sort((x,y) => x.DisplayField.CompareTo(y.DisplayField));

                //load the datacollection to the asp control you are interested in
                // we are using the DropDownList
                //a) assign you DataCollection to the control
                CollectionList.DataSource = DataCollection;

                //b) setup any necessary properties on your ASP control that are required to work
                //the dropdown list will generate the html select tag code
                // thus we need two properties to be set
                // i)the value property DataValueField
                // ii)the display property DataTextField
                // the properties are set up by assigning the dataCollection field name to teh control property
                CollectionList.DataValueField = "ValueField";
                CollectionList.DataTextField = nameof(DDLClass.DisplayField);

                // C) BIND your data to the control
                CollectionList.DataBind();

                // what about prompts?
                // manually place a line item at the beginning of your control
                CollectionList.Items.Insert(0, "select...");
            }

        }

        protected void SubmitChoice_Click(object sender, EventArgs e)
        {
            //how does one retrieve/assign data to an ASP control?
            //Retrieving or assigning data to a control is dependent on the specific control
            //for textbox, Label, literal use .Text
            //for checkbox (boolean) use .Checked
            //for  a list control like our dropdownlist RadiobuttonList, CheckboxList
            // A) .SelectedValue  for the data value
            // B) .SelectedIndex  for the physicall index location in the List
            // C) .SelectedItem   for the display text

            //most of the data from the controls will be in strings except for Booleans
            string submitchoice = TextBoxNumericChoice.Text;

            //any validation you want
            if (string.IsNullOrEmpty(submitchoice))
            {
                OutputMessage.Text = "Enter a Choice please (between 1 and 4)";
            }
            else
            {
                //for the radiobuttonlist we could use .SelectedIndex, .SelectedValue, or .Selecteditem
                // we want to use the associated value for the button
                RadioButtonListChoice.SelectedValue = submitchoice;
                OutputMessage.Text = "you selected " + submitchoice;


                if (submitchoice.Equals("2") || submitchoice.Equals("3"))
                {
                    CheckBoxChoice.Checked = true;
                }
                else
                {
                    CheckBoxChoice.Checked = false;
                }

                //position in the dropdownlist using the value in submitchoice
                //remember selectedIndex is the physical index location of an item in the list
                // it is NOT the associated Value

                CollectionList.SelectedValue = submitchoice;

                //use the three preoperties for list control as a demo
                DisplayDataReadOnly.Text = " " + CollectionList.SelectedItem.Text
                    + " at index " + CollectionList.SelectedIndex
                    + " has the value of " + CollectionList.SelectedValue;
                



            }


        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
            string submitchoice = CollectionList.SelectedValue;

            

            //any validation you want
            if (string.IsNullOrEmpty(submitchoice)  || submitchoice == "0")
            {
                OutputMessage.Text = "Enter a Choice please (between 1 and 4)";
            }
            else
            {
                //for the radiobuttonlist we could use .SelectedIndex, .SelectedValue, or .Selecteditem
                // we want to use the associated value for the button
                RadioButtonListChoice.SelectedValue = submitchoice;
                OutputMessage.Text = "you selected " + CollectionList.SelectedItem.Text;
                TextBoxNumericChoice.Text = CollectionList.SelectedItem.Text;    

                if (submitchoice.Equals("2") || submitchoice.Equals("3"))
                {
                    CheckBoxChoice.Checked = true;
                }
                else
                {
                    CheckBoxChoice.Checked = false;
                }

                //position in the dropdownlist using the value in submitchoice
                //remember selectedIndex is the physical index location of an item in the list
                // it is NOT the associated Value

                //CollectionList.SelectedValue = submitchoice;

                //use the three preoperties for list control as a demo
                DisplayDataReadOnly.Text = " " + CollectionList.SelectedItem.Text
                    + " at index " + CollectionList.SelectedIndex
                    + " has the value of " + CollectionList.SelectedValue;




            }


        }
    }
}