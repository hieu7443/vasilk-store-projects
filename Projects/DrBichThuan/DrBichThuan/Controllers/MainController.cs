using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vasilk.Store.Foundations;
using Vasilk.Store.Foundations.Models;
using Vasilk.Store.Website.Controllers;

namespace DrBichThuan.Controllers
{
    public class MainController : VasilkBaseController
    {
        public ActionResult Header()
        {
            return View();
        }
        public ActionResult Footer()
        {
            return View();
        }
        public ActionResult Menu()
        {
            return SharedView("_Menu");
        }
        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult AjaxLoad()
        {
            return View();
        }
        [HttpPost]
        public JsonResult AjaxRender(string key)
        {
            List<IHtmlString> htmls = new List<IHtmlString>();
            Guid id;
            if (Guid.TryParse(key, out id))
            {
                Item item = Repository.GetItemByID(id, true);
                if (item?.Presentation?.Renderings != null)
                {
                    CustomContext.ProcessedPlaceholders = new List<string>();
                    htmls.AddRange(item.Presentation.Renderings.Select(i => i.Render()));
                }
            }
            return Json(String.Join("", htmls), JsonRequestBehavior.DenyGet);
        }
    }
}