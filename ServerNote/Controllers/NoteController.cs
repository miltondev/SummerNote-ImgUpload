using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using System.IO;

namespace ServerNote.Controllers
{
    public class NoteController : Controller
    {
        // GET: Note
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UpLoadImages(HttpPostedFileBase file)
        {
            if (file != null)
            {
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    var files = Request.Files[i];
                    var fileName = Path.GetFileName(file.FileName);
                    string fileType = Path.GetExtension(file.FileName);
        
                    if (fileName != "")
                    {
                        string newName = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() +
                                           DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() +
                                           DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + fileType;
                        //Ruta de Archivo
                        string Currentpath = Server.MapPath("/ImgUploads");
                    
                        CreateDirectory ImgDr = new CreateDirectory();
             
                        ImgDr.CreatePath(Currentpath);
                        var path = Currentpath + "\\" + newName;
                        files.SaveAs(path);

                        string RelativePath = "ImgUploads" + "/" + newName;

                        Uri url = System.Web.HttpContext.Current.Request.Url;

                        int port = url.Port;


                        string retPath = "http://" + "localhost:" + port + "/" + RelativePath;

                        return Content(retPath);
                    }
                }
            }
            return View();
        }
    }
}

public class CreateDirectory
{
    public void CreatePath(string path)
    {
        if (!Directory.Exists(path))
            Directory.CreateDirectory(path);
    }
}