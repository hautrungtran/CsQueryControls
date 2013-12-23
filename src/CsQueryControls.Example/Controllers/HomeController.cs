using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using CsQueryControls.HtmlElements;

namespace CsQueryControls.Example.Controllers {
    public class HomeController : Controller {
        public ActionResult Index() {
            return View();
        }

        public ActionResult About() {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact() {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public JsonResult Get(int pageIndex, int pageSize) {
            var list = new List<MyClass>();
            for (int i = 0; i < 1000; i++) {
                list.Add(new MyClass {
                    S1 = i.ToString(),
                    S2 = "http://cdn.tutorialzine.com/wp-content/uploads/2009/09/351.jpg",
                    S3 = i % 2 == 0 ? "true" : "false",
                    S4 = "http://google.com.vn",
                    S5 = new CommonElement(HtmlTag.B) { InnerText = "Bold" }.Render(),
                });
            }
            return Json(new { items = list.Skip(pageIndex * pageSize).Take(pageSize), total = 1000 / pageSize }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Remove() {
            return Json("response message.", JsonRequestBehavior.AllowGet);
        }
    }
}