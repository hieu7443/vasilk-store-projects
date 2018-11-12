using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vasilk.Store.Common;
using Vasilk.Store.Foundations.Models;

namespace DrBichThuan.Models
{
    public class PageContent
    {
        [CustomField(AppTemplates.Page.Fields.Icon, CustomFieldDataType.Image)]
        public string Icon { get; set; }
        [CustomField(AppTemplates.Page.Fields.MetaData, CustomFieldDataType.Item)]
        public Item MetaData { get; set; }
        [CustomField(AppTemplates.Page.Fields.HideMapOnMobile, CustomFieldDataType.Bool)]
        public bool HideMapOnMobile { get; set; }
        public MetaData[] GetMetaData()
        {
            if (MetaData != null)
            {
                return Repository.FindItem(new ItemFilter()
                {
                    ParentID = MetaData.ID,
                    DirectTemplateID = Templates._Meta.ID
                })?.Select(i => i.Cast<MetaData>()).ToArray();
            }
            return null;
        }
    }
}