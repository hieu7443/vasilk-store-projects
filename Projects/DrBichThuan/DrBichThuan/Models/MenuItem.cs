using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vasilk.Store.Common;

namespace DrBichThuan.Models
{
    public class MenuItem
    {
        [CustomField(AppTemplates.MenuItem.Fields.Index, CustomFieldDataType.Number)]
        public int Index { get; set; }
        [CustomField(AppTemplates.MenuItem.Fields.Title, CustomFieldDataType.String)]
        public string Title { get; set; }
        [CustomField(AppTemplates.MenuItem.Fields.Url, CustomFieldDataType.String)]
        public string Url { get; set; }
        public bool IsActive { get; set; }
        public string GetUrl()
        {
            return String.IsNullOrWhiteSpace(Url) ? "#" : Url;
        }
    }
}