using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vasilk.Store.Common;
using Vasilk.Store.Foundations.Models;

namespace DrBichThuan.Models
{
    public class ContactDetail
    {
        [CustomField(AppTemplates.ContactDetail.Fields.Address, CustomFieldDataType.String)]
        public string Address { get; set; }
        [CustomField(AppTemplates.ContactDetail.Fields.Description, CustomFieldDataType.String)]
        public string Description { get; set; }
        [CustomField(AppTemplates.ContactDetail.Fields.Logo, CustomFieldDataType.Image)]
        public string Logo { get; set; }
        [CustomField(AppTemplates.ContactDetail.Fields.MapLocation, CustomFieldDataType.String)]
        public string MapLocation { get; set; }
        [CustomField(AppTemplates.ContactDetail.Fields.Name, CustomFieldDataType.String)]
        public string Name { get; set; }
        [CustomField(AppTemplates.ContactDetail.Fields.Phone, CustomFieldDataType.String)]
        public string Phone { get; set; }
        [CustomField(AppTemplates.ContactDetail.Fields.SubTitle, CustomFieldDataType.String)]
        public string SubTitle { get; set; }
        [CustomField(AppTemplates.ContactDetail.Fields.Title, CustomFieldDataType.String)]
        public string Title { get; set; }
        [CustomField(AppTemplates.ContactDetail.Fields.WorkHours, CustomFieldDataType.Item)]
        public Item WorkHours { get; set; }
        [CustomField(AppTemplates.ContactDetail.Fields.Thumbnail, CustomFieldDataType.Image)]
        public string Thumbnail { get; set; }
        [CustomField(AppTemplates.ContactDetail.Fields.Url, CustomFieldDataType.String)]
        public string Url { get; set; }
        public string[] GetMapLocation()
        {
            string[] parts = MapLocation?.Split(',');
            if (parts == null || parts.Length != 2)
                return new string[] { "10.660566", "106.465448" };
            return parts;
        }
        public string[] GetPhones()
        {
            return Phone?.Split(',') ?? new string[] { };
        }
        public WorkHour[] GetWorkHours()
        {
            return WorkHours?.GetChilds<WorkHour>(AppTemplates.WorkHour.ID) ?? new WorkHour[] { };
        }
    }
}