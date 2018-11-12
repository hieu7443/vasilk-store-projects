using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vasilk.Store.Common;

namespace DrBichThuan.Models
{
    public class WorkHour
    {
        [CustomField(AppTemplates.WorkHour.Fields.Day, CustomFieldDataType.String)]
        public string Day { get; set; }
        [CustomField(AppTemplates.WorkHour.Fields.Time, CustomFieldDataType.String)]
        public string Time { get; set; }
        [CustomField(AppTemplates.WorkHour.Fields.Index, CustomFieldDataType.Number)]
        public int Index { get; set; }
        public string[] GetTimes()
        {
            return Time?.Split(',') ?? new string[] { };
        }
    }
}