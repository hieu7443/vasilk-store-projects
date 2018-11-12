using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vasilk.Store.Common.Layouts.Models;
using Vasilk.Store.Foundations;
using Vasilk.Store.Website.Controllers;

namespace Vasilk.Store.Common.Layouts.Controllers
{
    public class LayoutController : VasilkBaseController
    {
        public ActionResult Section()
        {
            if (CustomContext.Rendering.Source == null || CustomContext.Rendering.Source.ID == Guid.Empty)
                return null;
            return View(CustomContext.Rendering.Source.Cast<SectionInfo>());
        }
        public ActionResult Container()
        {
            if (CustomContext.Rendering.Source == null || CustomContext.Rendering.Source.ID == Guid.Empty)
                return null;
            return View(CustomContext.Rendering.Source.Cast<ContainerInfo>());
        }
        public ActionResult Row()
        {
            if (CustomContext.Rendering.Source == null || CustomContext.Rendering.Source.ID == Guid.Empty)
                return null;
            return View(CustomContext.Rendering.Source.Cast<RowInfo>());
        }
        public ActionResult Column()
        {
            if (CustomContext.Rendering.Source == null || CustomContext.Rendering.Source.ID == Guid.Empty)
                return null;
            return View(CustomContext.Rendering.Source.Cast<ColumnInfo>());
        }
    }
}