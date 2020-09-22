using System;
using System.Collections.Generic;
using System.Text;

namespace JacobFrazierAssignment3
{
    class Female : Person
    {
        private FemaleTitle title;
        private int position;
        private FemaleFirstName firstName;
        
        private Random random = new Random();
        public Female() : base()
        {
            position = random.Next(0,4);
            String title = Enum.GetName(typeof(FemaleTitle), position);
            this.title = (FemaleTitle)Enum.Parse(typeof(FemaleTitle), title);

            position = random.Next(0, 19);
            String firstName = Enum.GetName(typeof(FemaleFirstName), position);
            this.firstName= (FemaleFirstName)Enum.Parse(typeof(FemaleFirstName), firstName);
           


        }

        public override int GetAge()
        {
            DateTime birthdate = GetBirthDate();
            var timespan = DateTime.Today;
            var age = timespan.ToString("yyyy");
            return timespan.Year - birthdate.Year;
        }

        public override string ToString()
        {
            var birthdate = GetBirthDate();
            
            return Convert.ToString(title) + 
              "." + " " + Convert.ToString(firstName) + " " + Convert.ToString(GetLastName())+" "+ "DOB"+":"+" "+ birthdate.ToShortDateString();
        }
    }
}
