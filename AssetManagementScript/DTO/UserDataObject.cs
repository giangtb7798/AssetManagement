using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementScript.DTO
{
    public class UserDataObject
    {
        public string UserId { get; set; }

        public string UserName { get; set; }

        public string firstName { get; set; }
        public string lastName { get; set; }
        public string gender { get; set; }
        public string location { get; set; }
        public string isFirstLogin { get; set; }
        public string staffCode { get; set; }
        public string role { get; set; }
        public string joindedDate { get; set; }
        public string dateOfBirth { get; set; }
        public string requests { get; set; }
        public string processed { get; set; }
        public string assignedBy { get; set; }
        public string assignedTo { get; set; }
    }
}
