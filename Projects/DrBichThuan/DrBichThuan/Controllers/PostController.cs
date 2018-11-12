using DrBichThuan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vasilk.Store.Common;
using Vasilk.Store.Foundations;
using Vasilk.Store.Foundations.Models;
using Vasilk.Store.Website.Controllers;

namespace DrBichThuan.Controllers
{
    public class PostController : VasilkBaseController
    {
        public ActionResult Featured(int page = 0)
        {
            QuerySettings qs = new QuerySettings(page * AppConstants.PostPerPage, AppConstants.PostPerPage);
            ItemFilter filter = new ItemFilter() {
                DirectTemplateID = AppTemplates.Post.ID,
                Fields = new FieldFilter[] { new FieldFilter(new Guid(AppTemplates.Post.Fields.Featured), true, CustomFieldDataType.Bool, FilterType.Equal) },
                Published = true,
                BaseFieldOrders = new BaseFieldOrder[] { new BaseFieldOrder(BaseFieldType.Updated, true) },
                QuerySettings = qs
            };
            return View("List", new PostListModel() {
                Data = Repository.FindItem<Post>(filter)?.OrderByDescending(i => i.Base.Updated).ToArray(),
                QuerySettings = qs,
                Page = page
            });
        }
        public ActionResult List(int page = 0)
        {
            PostListModel model = new PostListModel();
            if (CustomContext.Item != null && CustomContext.Item.ID != Guid.Empty)
            {
                QuerySettings qs = new QuerySettings(page * AppConstants.PostPerPage, AppConstants.PostPerPage);
                ItemFilter filter = new ItemFilter()
                {
                    DirectTemplateID = AppTemplates.Post.ID,
                    ParentID = CustomContext.Item.ID,
                    Published = true,
                    BaseFieldOrders = new BaseFieldOrder[] { new BaseFieldOrder(BaseFieldType.Updated, true) },
                    QuerySettings = qs
                };
                model.Data = Repository.FindItem<Post>(filter)?.OrderByDescending(i => i.Base.Updated).ToArray();
                model.Page = page;
                model.QuerySettings = filter.QuerySettings;
            }
            return View("List", model);
        }
        public ActionResult Detail()
        {
            return View(CustomContext.Item?.Cast<Post>());
        }
    }
}