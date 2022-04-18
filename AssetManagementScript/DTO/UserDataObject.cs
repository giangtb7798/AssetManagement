using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementScript.DTO
{
    public class UserDataObject
    {
        public List<UserDataObject> items { get; set; }

        public string code { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string gender { get; set; }
        public string location { get; set; }
        public string userName { get; set; }
        public string fullName { get; set; }
        public object historicalAssignments { get; set; }
        public string type { get; set; }
        public string isDisabled { get; set; }
        public string doB { get; set; }
        public string joinDate { get; set; }
        public string password { get; set; }
        public string isFirstLogin { get; set; }
        public int pageIndex { get; set; }
        public int pageSize { get; set; }
        public int totalRecords { get; set; }
        public int pageCount { get; set; }
        //

        public string firstTimePassword { get; set; }

        public UserDataObject(string firstName, string lastName, string dob, string gender, string joinedDate, string type)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.doB = dob;
            this.gender = gender;
            this.joinDate = joinedDate;
            this.type = type;
            userName = firstName.ToLower() + lastName.ToLower()[0];
            firstTimePassword = userName + "@" + DateTime.ParseExact(dob,
                 "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture).ToString("ddMMyyyy");
            fullName = lastName + " " + firstName;


        }
        public UserDataObject()
        {

        }
        public UserDataObject(string dob, string gender, string joinedDate, string type)
        {
            this.doB = dob;
            this.gender = gender;
            this.joinDate = joinedDate;
            this.type = type;
        }
        public UserDataObject(string firstName, string lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            userName = firstName.ToLower() + lastName.ToLower()[0];
            firstTimePassword = userName + "@" + DateTime.ParseExact(doB,
                 "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture).ToString("ddMMyyyy");
            fullName = lastName + " " + firstName;
        }
    }
}
