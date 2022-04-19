using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementScript.DTO
{
    public class AssignmentDataObject
    {
        public int assignmentId { get; set; }
        public string assetCode { get; set; }
        public string assetName { get; set; }
        public string assignedToId { get; set; }
        public string assignedToName { get; set; }
        public string assignedById { get; set; }
        public string assignedByName { get; set; }
        public string assignmentDate { get; set; }
        public int stateId { get; set; }
        public string note { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }

        public int pageNumber { get; set; }
        public int pageSize { get; set; }
        public int firstPage { get; set; }
        public int lastPage { get; set; }
        public int totalPages { get; set; }
        public int totalRecords { get; set; }
        public int nextPage { get; set; }
        public int previousPage { get; set; }
        public string sortType { get; set; }
        public string sortBy { get; set; }
        public string searchBy { get; set; }
        public string searchValue { get; set; }
        public List<AssignmentDataObject> data { get; set; }
        public bool succeeded { get; set; }
        public object errors { get; set; }
        public object message { get; set; }

        public AssignmentDataObject()
        {

        }
        public AssignmentDataObject(string staffcode, string assetcode, string assigmentDate, string note)
        {
            this.assignedToId = staffcode;
            this.assetCode = assetcode;
            this.assignmentDate = assigmentDate;
            this.note = note;
        }

    }
}
