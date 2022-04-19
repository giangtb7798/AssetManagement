using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementScript.DTO
{
    public class AssetDataObject
    {

        public string search { get; set; }
        public string sort { get; set; }
        public string sortField { get; set; }
        public string CategoryPrefix { get; set; }
        public string State { get; set; }
        public List<AssetDataObject> items { get; set; }
        public string assetCode { get; set; }
        public string assetName { get; set; }
        public string categoryName { get; set; }
        public string categoryPrefix { get; set; }
        public Category category { get; set; }
        public string specification { get; set; }
        public string installedDate { get; set; }
        public string state { get; set; }
        public List<AssetDataObject> historicalAssignments { get; set; }

        public string pageIndex { get; set; }
        public string pageSize { get; set; }
        public string totalRecords { get; set; }
        public string pageCount { get; set; }
        public AssetDataObject()
        {

        }
        public AssetDataObject(string assetname, string category, string specification, string installDate, string state)
        {
            this.assetName = assetname;
            this.categoryName = category;
            this.specification = specification;
            this.installedDate = installDate;
            this.state = state;
        }
        public AssetDataObject(string assetname, string specification, string installDate, string state)
        {
            this.assetName = assetname;
            this.specification = specification;
            this.installedDate = installDate;
            this.state = state;
        }
    }
    public class Category
    {
        public string id { get; set; }
        public string categoryName { get; set; }

        public string categoryPrefix { get; set; }
    }
}
