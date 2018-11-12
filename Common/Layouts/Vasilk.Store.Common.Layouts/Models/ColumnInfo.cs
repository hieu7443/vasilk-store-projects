using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vasilk.Store.Foundations.Models;

namespace Vasilk.Store.Common.Layouts.Models
{
    public class ColumnInfo : LayoutInfo
    {
        [CustomField("67aef6ec-70c8-43bf-aabc-e6160ff60086", CustomFieldDataType.String)]
        public string ColumnClass { get; set; }
        [CustomField("a4a909ed-9389-4ad9-ba72-fc2fb1d6fb7a", CustomFieldDataType.Number)]
        public int Index { get; set; }
    }
}