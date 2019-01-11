using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPsReview
{
    public class Die
    {
        //Data Member
        // this is the physical storage area for data values
        // these are usually private
        
        private int _Sides;
        private string _Color;
        private int _FaceValue;


        //Properties 
        // Properties are public
        // is used as an interface for the class user to access
        // a data member

        // Accessing a data member can unclude a get and a set
        // a get returns the value of the data member to the user
        // a set accepts a value and assigns the value to the data member
        // a property returns a specific data type
        // a property does NOT have a perameter list


        //Fully Implimented Property
        public int Sides
        {
            get
            {
                //returns the current value of the data member
                return _Sides;
            }
            set
            {
                //can be private
                //it accepts a value and assigns it to the data member
                //the value is stored in a keyword: value
                //the datatype of value is the return datatype of the property
                //validation can be done on the value
                if (value >= 6 && value <= 20)
                {
                    _Sides = value;
                }
                else
                {
                    throw new Exception("Die cannot have " + value.ToString() + " sides. Die can have 6-20 sides.");
                }
            }
        }
       



        //Auto Implimented Property


    }
}
