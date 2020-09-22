using System;
using System.Collections.Generic;
using System.Text;

namespace JacobFrazierAssignment3
{
    class Male : Person
    {
        private MaleTitle title;
        private int position;
        private MaleFirstName firstName;
        private Random random = new Random();
        public Male() : base()
          {//Grabs a random Male Title
            position = random.Next(0, 2);
            String title = Enum.GetName(typeof(MaleTitle), position);
            this.title = (MaleTitle)Enum.Parse(typeof(MaleTitle), title);
            //returns a random male Firstname
            position = random.Next(0, 19);
            String firstName = Enum.GetName(typeof(MaleFirstName), position);
            this.firstName = (MaleFirstName)Enum.Parse(typeof(MaleFirstName), firstName);


        }

        public override int GetAge()
        {
            DateTime birthdate = GetBirthDate();
            var timespan = DateTime.Today;
            var age = timespan.ToString("yyyy");
            return timespan.Year - birthdate.Year;
        }

        public override string ToString()
        { //returns a string of all properties
            var birthdate = GetBirthDate();

            return Convert.ToString(title) +
              "." + " " + Convert.ToString(firstName) + " " + Convert.ToString(GetLastName()) + " " + "DOB" + ":" + " "+ birthdate.ToShortDateString();
        }
    
    }
}

