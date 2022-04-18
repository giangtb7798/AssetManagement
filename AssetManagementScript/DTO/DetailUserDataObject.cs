using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementScript.DTO
{
    public class DetailUserDataObject
    {
        public string code { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string gender { get; set; }
        public string location { get; set; }
        public string userName { get; set; }
        public string fullName { get; set; }
        public List<DetailUserDataObject> historicalAssignments { get; set; }
        public string id { get; set; }
        public string relatedUsers { get; set; }
        public string assignedDate { get; set; }
        public string note { get; set; }
        public string assignmentState { get; set; }
        public string assigneeCode { get; set; }
        public string assignerCode { get; set; }
        public string requesterCode { get; set; }
        public string verifierCode { get; set; }
        public string returnDate { get; set; }
        public string returnState { get; set; }
        public string type { get; set; }
        public string isDisabled { get; set; }
        public string doB { get; set; }
        public string joinDate { get; set; }
        public string password { get; set; }
        public string isFirstLogin { get; set; }

        //

        public string firstTimePassword { get; set; }

        public DetailUserDataObject(string firstName, string lastName, string doB, string gender, string joinDate, string type)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.doB = doB;
            this.gender = gender;
            this.joinDate = joinDate;
            this.type = type;
            userName = firstName.ToLower() + lastName.ToLower()[0];
            firstTimePassword = userName + "@" + DateTime.ParseExact(doB,
                 "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture).ToString("ddMMyyyy");
            fullName = lastName + " " + firstName;


        }
        public DetailUserDataObject()
        {

        }
        public DetailUserDataObject(string doB, string gender, string joinDate, string type)
        {
            this.doB = doB;
            this.gender = gender;
            this.joinDate = joinDate;
            this.type = type;
        }
        public DetailUserDataObject(string firstName, string lastName)
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
