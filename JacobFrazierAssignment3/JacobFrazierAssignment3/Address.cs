using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace JacobFrazierAssignment3
{
   class Address: Person
    {
        private uint houseNumber;
        private String streetName;
        private StreetType streetType;
        private String city;


        private String state;
        private string zipCode;
        //Dictionary for both state Abbr and ZipCodes
        private Dictionary<string, string> stateDictionary = new Dictionary<string, string>();
        private Dictionary<string, string> zipCodeDictionary = new Dictionary<string, string>();
        public uint GetHouseNumber()
        {
            return houseNumber;
        }
        public void SetHouseNumber(uint houseNumber) { this.houseNumber = houseNumber; } 

        //Gets and sets. I made the seters private for security
          public string GetStreetName() { return streetName; }
        private void SetStreetName(string streetName) { this.streetName = streetName; }
        public StreetType GetStreettType() { return streetType; }
        private void SetStreetType(StreetType streetType) { this.streetType = streetType;  }
        public string GetCity() { return city; }
       private void SetCity(string city) { this.city = city; }
        public string GetState() { return state; }
        public string GetZipCode() { return zipCode; }
        public Address()
        { //Constructor, creates an object
            var random = new Random();
            houseNumber = (uint)random.Next(1, 5000);
            AddToDictionary(ref stateDictionary);
            AddZipCode(ref zipCodeDictionary);
          state = AssignStateName();
           zipCode = AssignZipCode();
            city = AssignCity();
            streetName = AssignStreet();
            streetType = AssignStreetType();
        }
     public string GetStateAbbr()//returns an abbr of the state.
        {
            string abbr = string.Empty;
            for (int i = 0; i < 49; i++)
           
            {
                if (stateDictionary.ElementAt(i).Value.Contains(state))
                    abbr = stateDictionary.ElementAt(i).Key;
                        
            }
            return abbr;
            
        }
        private string AssignStateName()//Assigns a state
        {
            var random = new Random();
            return stateDictionary.ElementAt(random.Next(0, 49)).Value;
           
        }
        private StreetType AssignStreetType()//Assigns StreetType
        {
            var random = new Random();
             var position = random.Next(0, 12);
            String streetType = Enum.GetName(typeof(StreetType), position);
           return this.streetType = (StreetType)Enum.Parse(typeof(StreetType), streetType);
       
        
        }


        private String AssignZipCode()//Assigns ZipCode
        { var random = new Random();
           

            var state = GetStateAbbr();
            string[] token;
            var region = 0;
            var lastDigits = 0;
            
            var stringZip = string.Empty;
            var regionMin = string.Empty;
            var regionMax = string.Empty;
            for (int i = 0; i < 49; i++)
            { if (zipCodeDictionary.ElementAt(i).Key.Equals(state) && zipCodeDictionary.ElementAt(i).Value.Contains('-'))
                {
                    token = zipCodeDictionary.ElementAt(i).Value.Split('-');
                    regionMin = token[0];
                    regionMax = token[1];
                    
                   
                }
                if (zipCodeDictionary.ElementAt(i).Key.Equals(state) && !zipCodeDictionary.ElementAt(i).Value.Contains('-'))
                {
                    regionMin = zipCodeDictionary.ElementAt(i).Value;
                    regionMax= zipCodeDictionary.ElementAt(i).Value;
                }
                if(regionMin.Length==3)
                {
                    region = random.Next(int.Parse(regionMin), int.Parse(regionMax));
                    lastDigits = random.Next(10, 99);
                    stringZip = Convert.ToString(region) + Convert.ToString(lastDigits);
                }
                if (regionMin.Length == 2)
                {
                    region = random.Next(int.Parse(regionMin), int.Parse(regionMax));
                    lastDigits = random.Next(100, 999);
                    stringZip = Convert.ToString(region) + Convert.ToString(lastDigits);
                }
                if (stringZip.Length == 4)
                    return "0" + stringZip;

            } return stringZip;


            

            
           
        }
        private string AssignStreet()
        { List<string> street = new List<string>() { "1st", "2nd", "third", "fourth", "fifth", "99", "sixth", "seventh", "main", "Brookview" };
            var rand = new Random();
            return street[rand.Next(0, 9)];

        }
        private void AddToDictionary(ref Dictionary<string, string> states)
        {

            states.Add("AL", "Alabama");
            states.Add("AK", "Alaska");
            states.Add("AZ", "Arizona");
            states.Add("AR", "Arkansas");
            states.Add("CA", "California");
            states.Add("CO", "Colorado");
            states.Add("CT", "Connecticut");
            states.Add("DE", "Delaware");
            states.Add("FL", "Florida");
            states.Add("GA", "Georgia");
            states.Add("HI", "Hawaii");
            states.Add("ID", "Idaho");
            states.Add("IL", "Illinois");
            states.Add("IN", "Indiana");
            states.Add("IA", "Iowa");
            states.Add("KS", "Kansas");
            states.Add("KY", "Kentucky");
            states.Add("LA", "Louisiana");
            states.Add("ME", "Maine");
            states.Add("MD", "Maryland");
            states.Add("MA", "Massachusetts");
            states.Add("MI", "Michigan");
            states.Add("MN", "Minnesota");
            states.Add("MS", "Mississippi");
            states.Add("MO", "Missouri");
            states.Add("MT", "Montana");
            states.Add("NE", "Nebraska");
            states.Add("NV", "Nevada");
            states.Add("NH", "New Hampshire");
            states.Add("NJ", "New Jersey");
            states.Add("NM", "New Mexico");
            states.Add("NY", "New York");
            states.Add("NC", "North Carolina");
            states.Add("ND", "North Dakota");
            states.Add("OH", "Ohio");
            states.Add("OK", "Oklahoma");
            states.Add("OR", "Oregon");
            states.Add("PA", "Pennsylvania");
            states.Add("RI", "Rhode Island");
            states.Add("SC", "South Carolina");
            states.Add("SD", "South Dakota");
            states.Add("TN", "Tennessee");
            states.Add("TX", "Texas");
            states.Add("UT", "Utah");
            states.Add("VT", "Vermont");
            states.Add("VA", "Virginia");
            states.Add("WA", "Washington");
            states.Add("WV", "West Virginia");
            states.Add("WI", "Wisconsin");
            states.Add("WY", "Wyoming");
        }
        private void AddZipCode(ref Dictionary<string, string> zip)
        {
            zip.Add("AL", "35-36");
            zip.Add("AK", "995-999");
            zip.Add("AZ", "85-86");
            zip.Add("AR", "716-729");
            zip.Add("CA", "900-961");
            zip.Add("CO", "80-81");
            zip.Add("CT", "06");
            zip.Add("DE", "197-199");
            zip.Add("FL", "32-34");
            zip.Add("GA", "30-31");
            zip.Add("HI", "967-968");
            zip.Add("ID", "832-839");
            zip.Add("IL", "60-62");
            zip.Add("IN", "46-47");
            zip.Add("IA", "50-52");
            zip.Add("KS", "66-67");
            zip.Add("KY", "40-42");
            zip.Add("LA", "700-715");
            zip.Add("ME", "039-049");
            zip.Add("MD", "206-219");
            zip.Add("MA", "010-027");
            zip.Add("MI", "48-49");
            zip.Add("MN", "550-567");
            zip.Add("MS", "386-397");
            zip.Add("MO", "63-65");
            zip.Add("MT", "59");
            zip.Add("NE", "68-69");
            zip.Add("NV", "889-899");
            zip.Add("NH", "030-039");
            zip.Add("NJ", "07-08");
            zip.Add("NM", "870-884");
            zip.Add("NY", "10-14");
            zip.Add("NC", "27-28");
            zip.Add("ND", "58");
            zip.Add("OH", "43-45");
            zip.Add("OK", "73-74");
            zip.Add("OR", "97");
            zip.Add("PA", "150-196");
            zip.Add("RI", "028-029");
            zip.Add("SC", "29");
            zip.Add("SD", "57");
            zip.Add("TN", "370-385");
            zip.Add("TX", "75-79");
            zip.Add("UT", "84");
            zip.Add("VT", "05");
            zip.Add("VA", "220-246");
            zip.Add("WA", "980-994");
            zip.Add("WV", "247-269");
            zip.Add("WI", "53-54");
            zip.Add("WY", "820-831");
        }
        private string AssignCity()
        { var r = new Random();
         List<string> cities = new List<string> {"Washington", "Franklin", "Arlington", "Centerville", "Lebanon", "Clinton", "Springfield", "Georgetown"," Fairview","Greenville", "Bristol", "Chester" };
            return cities[r.Next(0, 10)];
        
        }



        public override string ToString()
        {
            return "Address: "
                  + GetHouseNumber() + " " + GetStreetName() + " " + streetType+ "." + " " + GetCity()
          + "," + " " + GetStateAbbr() + " " + GetZipCode();
                }

        public override int GetAge()
        {
            var birthdate = GetBirthDate();
            var timespan = DateTime.Today;
            var age = timespan.ToString("yyyy");
            return timespan.Year - birthdate.Year;
        }
    }
}
