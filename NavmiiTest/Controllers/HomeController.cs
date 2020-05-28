using NavmiiTest.BussinessLogic;
using NavmiiTest.Enums;
using NavmiiTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NavmiiTest.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            FileTransfer tf = new FileTransfer();
            return View(tf);
        }

        [HttpPost]
        public ActionResult FileTransfer(FileTransfer vModel)
        {
            try
            {
                FilesTransferProcess ftl = new FilesTransferProcess();
                var fileTransferProcess = ftl.FileTransferLogic(vModel);

                 return Json(fileTransferProcess, JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex)
            {
                return Json(ex.Message + "¬" + (int)MessageType.Error, JsonRequestBehavior.AllowGet);
            }
        }
    }
}