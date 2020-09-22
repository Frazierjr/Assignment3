using System;
using System.Collections.Generic;
using System.Text;

namespace JacobFrazierAssignment3
{
    abstract class Person
    {






        private LastName lastName;
       private Random randomLastname = new Random();
      
        private int lastnamePositioon = 0;

        
        private DateTime birthdate;
        protected Person()
        { //Generates a random lastname / birthdate
            lastnamePositioon = randomLastname.Next(0, 39);
            String lastname = Enum.GetName(typeof(LastName),lastnamePositioon);
            lastName = (LastName)Enum.Parse(typeof(LastName),lastname);
  
            birthdate = CalculateBirth();
           
        }
        private static DateTime CalculateBirth()
        { //Calculates a nirthday
            var random = new Random();

            var month = random.Next(1, 12);
            var year = random.Next(1940, 2002);
            var day = 1;
            if (month == 1)
                day = random.Next(1, 31);
            else if (month == 2)
              day = random.Next(1, 28);
            else if (month == 2 && DateTime.IsLeapYear(year))
               day= random.Next(1, 29);
            if (month == 3)
                day = random.Next(1, 31);
            if (month == 4)
                day = random.Next(1, 30);
            if (month == 5)
                day = random.Next(1, 31);
            if (month == 6)
                day = random.Next(1, 30);
            if (month == 7)
                day = random.Next(1, 31);
            if (month == 8)
                day = random.Next(1, 31);
            if (month == 9)
                day = random.Next(1, 30);
            if (month == 10)
                day = random.Next(1, 31);
            if (month == 11)
                day = random.Next(1, 30);
            if (month == 12)
                day = random.Next(1, 31);
            var now = DateTime.Now;
           
            if(year==2002&& month>=now.Month&& day> now.Day)
            {
                day = now.Day;
                
                return new DateTime(year,month,day);
            }

            return new DateTime(year, month, day);

        }
        public LastName GetLastName()//Gets LastName
        {
            return lastName;
           
        }
        public void SetLastName(LastName lastName)//Set Lastname
        { 
            this.lastName = lastName;
        }




        public void SetBirth(DateTime birthDate)// sets birthday
        {
            this.birthdate = birthDate;
        }

        

        public DateTime GetBirthDate()// Returns the persons birthday
        {
            return birthdate;
        }



        public abstract int GetAge();//Returns the age of the person
        
        public abstract String ToString();
            
    }
}
