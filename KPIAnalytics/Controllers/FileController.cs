using DataAccessLayer;
using System;
using System.Web.Mvc;
using System.IO;
using System.Xml.Linq;
using System.Net.Http.Headers;
using Entities;
using System.Data.Entity;
using System.Web;

namespace KPIAnalytics.Controllers
{
    [UserAuth]
    public class FileController : Controller
    {
        private DBContext db = new DBContext();
        [KPIAuthorize]
        // GET: Storage
        // GET: File
        public ActionResult Index()
        {
            return View();
        }
        private string CorrectFilename(string filename)
        {
            if (filename.Contains("\\"))
            {
                filename = filename.Substring(filename.LastIndexOf("\\") + 1);
            }
            return filename;
        }

        
        [HttpPost]
        public ActionResult Process(  HttpPostedFileBase _file)
        {
            
            try
            {
                byte[] fileData = null;
                using (var binaryReader = new BinaryReader(Request.Files[0].InputStream))
                {
                    fileData = binaryReader.ReadBytes(Request.Files[0].ContentLength);
                }
                string filename = ContentDispositionHeaderValue.Parse(_file.FileName).FileName.Trim('"');

                FileStorage _newFile = new FileStorage
                {
                    FileStorageId = Guid.NewGuid(),
                    FileName = CorrectFilename(filename),
                    FileContentType = _file.ContentType,
                    FileData = fileData,
                };
                
                db.FileStorages.Add(_newFile);
                 db.SaveChanges();
                return Content(_newFile.FileStorageId.ToString());
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        private ActionResult BadRequest()
        {
            throw new NotImplementedException();
        }

        
        [HttpDelete]
        public ActionResult Revert()
        {
            try
            {
                using (var reader = new StreamReader(Request.Files[0].InputStream))
                {
                    var body = reader.ReadToEnd();
                    FileStorage item =  db.FileStorages.Find(new Guid(body));
                    db.FileStorages.Remove(item);
                     db.SaveChangesAsync();
                    return null;
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        
        [HttpGet]
        public ActionResult Restore(string id)
        {
            // NEEDS TESTING PA TO OI
            try
            {
                FileStorage item =  db.FileStorages.Find(new Guid(id));
                System.Net.Mime.ContentDisposition cd = new System.Net.Mime.ContentDisposition
                {
                    FileName = item.FileName,
                    Inline = true
                };
                Response.Headers.Add("Content-Disposition", cd.ToString());
                return File(item.FileData, item.FileContentType);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        
        [HttpGet]
        public ActionResult Load(string id)
        {
            // NEEDS TESTING PA TO OI
            try
            {
                FileStorage item =  db.FileStorages.Find(new Guid(id));
                System.Net.Mime.ContentDisposition cd = new System.Net.Mime.ContentDisposition
                {
                    FileName = item.FileName,
                    Inline = true
                };
                Response.Headers.Add("Content-Disposition", cd.ToString());
                return File(item.FileData, item.FileContentType);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        public ActionResult Download(string id)
        {
            // NEED PA I CHECK KUNG AUTHORIZED UNG USER. mag seasearch pa ung post kung saan naggmit ung image then check ung visibility ng post
            FileStorage item =  db.FileStorages.Find(new Guid(id));
            return File(item.FileData, "application/force-download", Path.GetFileName(item.FileName));
        }

        public ActionResult DisplayImage(string id)
        {
            // NEED PA I CHECK KUNG AUTHORIZED UNG USER. mag seasearch pa ung post kung saan naggmit ung image then check ung visibility ng post
            FileStorage item =  db.FileStorages.Find(new Guid(id));
            return File(item.FileData, item.FileContentType, Path.GetFileName(item.FileName));
        }

        //public ActionResult DislayResizeImage(string id, int width, int height)
        //{
        //    // NEED PA I CHECK KUNG AUTHORIZED UNG USER. mag seasearch pa ung post kung saan naggmit ung image then check ung visibility ng post
        //    FileStorage item =  db.FileStorages.Find(new Guid(id));
        //    MemoryStream outputStream = new MemoryStream();
        //    using (MemoryStream inputStream = new MemoryStream(item.FileData))
        //    {
        //        using (Image<Rgba32> image = Image.Load(inputStream))
        //        {
        //            image.Mutate(w => w.Resize(width, height));
        //            image.Save(outputStream, new PngEncoder());
        //            return File(outputStream.ToArray(), "application/octet-stream", Path.GetFileName(item.FileName));
        //        }
        //    }
        //}

        //public ActionResult DislayCompressImage(string id, int level)
        //{
        //    // NEED PA I CHECK KUNG AUTHORIZED UNG USER. mag seasearch pa ung post kung saan naggmit ung image then check ung visibility ng post
        //    FileStorage item =  db.FileStorages.Find(new Guid(id));
        //    MemoryStream outputStream = new MemoryStream();
        //    using (MemoryStream inputStream = new MemoryStream(item.FileData))
        //    {
        //        using (Image<Rgba32> image = Image.Load(inputStream))
        //        {
        //            for (int i = 1; i <= level; i++)
        //            {
        //                image.Mutate(w => w.Resize(image.Width / 2, image.Height / 2));
        //            }
        //            image.Save(outputStream, new JpegEncoder());
        //            return File(outputStream.ToArray(), "image/jpeg", Path.GetFileName(item.FileName));
        //        }
        //    }
        //}
    }
}