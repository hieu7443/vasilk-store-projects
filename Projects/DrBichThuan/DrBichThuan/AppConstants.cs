using DrBichThuan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vasilk.Store.Foundations;
using Vasilk.Store.Foundations.Models;

namespace DrBichThuan
{
    public static class AppConstants
    {
        public static int PostPerPage { get { return 9; } }
        public static ContactDetail ContactDetail { get { return Repository.GetItemByID(new Guid("4b152d25-31cd-4f72-8fb3-44c7c60ef597")).Cast<ContactDetail>(); } }
        public static MenuItem[] Menu
        {
            get
            {
                MenuItem[] result = Repository.FindItem(new ItemFilter() { ParentID = new Guid("7da25c03-5b9d-4a92-841e-1889efc09a71"), DirectTemplateID = AppTemplates.MenuItem.ID }).Select(i => i.Cast<MenuItem>()).ToArray();
                NavigationUrl currentUrl = CustomContext.Item?.NavigationUrl;
                while (currentUrl != null)
                {
                    MenuItem item = result.FirstOrDefault(i => i.Url == currentUrl.Url);
                    if (item != null)
                    {
                        item.IsActive = true;
                        break;
                    }
                    currentUrl = currentUrl.Parent;
                }
                return result;
            }
        }
        public static string BaseRequestUrl
        {
            get
            {
                if (String.IsNullOrEmpty(HttpContext.Current.Request.Url.Query))
                    return HttpContext.Current.Request.Url.AbsoluteUri;
                return HttpContext.Current.Request.Url.AbsoluteUri.Replace(HttpContext.Current.Request.Url.Query, "");
            }
        }
    }
}