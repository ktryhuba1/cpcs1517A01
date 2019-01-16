using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPsReview
{
    public class Die
    {
        //use the System.Random class for my RNG
        //the instance will be static so all intances of Die will use the same generator
        // the instance of rdm will be created when the first instance of Die is created
        // and be destroyed when the last instance is destroyed

        public static Random _rnd = new Random();


        //Data Member
        // this is the physical storage area for data values
        // these are usually private
        
        private int _Sides;
        private string _Color;
       // private int _FaceValue;


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
                    Roll();
                }
                else
                {
                    throw new Exception("Die cannot have " + value.ToString() + " sides. Die can have 6-20 sides.");
                }
            }
        }
       



        //Auto Implimented Property
        //there is no defined data member for this type of property
        //instead, the system creates an internal storage area of the 
        //  property datatype and manages the area for your code. 
        // typically this type of property is commomly used when no 
        // validation is required for the data
        public int FaceValue { get; private set; }

        public string Color
        {
            get
            {
                return _Color;
            }
            set
            {
                //need to check for null or just spaces
                if (String.IsNullOrWhiteSpace(value))
                {
                   throw new Exception("Die cannot have " + value.ToString() + "as a color. need a valid Color.");
                }
                else
                {
                     _Color = value;
                }
            }
        }


        //Constructors
        // optional
        // if you do not include a constructor for your class
        // then when an instance of the class is created the system
        // will assign a normal default values of that datatype to the appropriate data member

        //if you declare an constructor in your class definition then you are responsible
        // for all the constuctors for the class

        //constructors are not called directly by the user of the class
        // the constructor will be called when you ask the system to create an instance of the class

        //syntax public classname([list of perameters]) { code body }

        //default constructor
        //this is similar to having a system constructor
        //it has no perameters

        public Die()
        {
            //typically this constructor will have no code, that is use the system defaults

            //you could assign your own defaults

            _Sides = 6;
            Color = "White";
            Roll();
        }



        //greedy constructor
        //takes in values for each of your datamembers/auto-properties
        //this allows the outside "user" wants to specify values at time of creation of the instance
        public Die(int sides, string color)
        {

            Sides = sides;
            Color = color;
            Roll();

        }
        //behaviours (methods)
        //a method will allow the user to 
        // a) manupulate the data of the instance
        // b) use the data of the instance to generate some other info


        public void Roll()
        {
            //will generate a random number for facevalue
            FaceValue = _rnd.Next(1, Sides + 1);
        }


    }
}
