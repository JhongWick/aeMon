using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using System.Security.Claims;
using System.IO;
using Entities;
using System.Data.Entity;

namespace KPIAnalytics.Controllers

{
    [UserAuth]
    public class StorageController : Controller
    {
        private DBContext db = new DBContext();
        [KPIAuthorize]
        // GET: Storage
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var _data = db.Storages.Where(m => m.StorageId == id).FirstOrDefault();
            if (_data == null)
            {
                return HttpNotFound();
            }
            return View(_data);
        }


        public ActionResult Create()
        {
            Storage _data = new Storage();
            return View(_data);
        }


        [HttpPost]
        public   ActionResult Create([Bind(Include = "StorageId,PostDate,StorageStatus,UserId,VisibilityId,FileStorageId")] Storage storage)
        {

            User _user = db.Users.Find(Authentication.CurrentUser.UserId);
           
            storage.StorageId = Guid.NewGuid();
            storage.PostDate = DateTime.Now.AddDays(-1);
            storage.StorageStatus = true;
            storage.UserId = _user.UserId;
           
              db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        
        //public ActionResult Share(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    var _data =  db.Storages.FindAsync(id);
        //    if (_data == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    User _user = db.Users.Find(Authentication.CurrentUser.UserId);
        //    var claim = ((ClaimsIdentity)User.Identity).FindFirst(ClaimTypes.Sid);
        //    var claim2 = ((ClaimsIdentity)User.Identity).FindFirst(ClaimTypes.GroupSid);
        //    Account _account = new Account(_context);
        //    var selectlist = _context.Visibilities.Where(w => w.VisibilityStatus == true && (_account.IsUserAdmin(new Guid(claim.Value))) ? true : (w.PublicView == true || w.GroupId == new Guid("00000000-0000-0000-0000-000000000000") || _account.GroupChildren(new Guid(claim2.Value)).Select(x => x.GroupId).Contains(w.GroupId))).OrderByDescending(w => w.VisibilityId);
        //    ViewData["VisibilityId"] = new SelectList(selectlist, "VisibilityId", "VisibilityName", _data.VisibilityId);
        //    var url = Request.GetEncodedUrl();
        //    ViewData["ShareHash"] = url.Replace("Share", "Download") + "&key=" + Library.ComputeSha512(id.ToString());
        //    return View(_data);
        //}

        //[ServiceFilter(typeof(CustomAuthFilter))]
        //[HttpPost]
        //public async Task<IActionResult> Share([Bind("StorageId,PostDate,StorageStatus,UserId,VisibilityId,FileStorageId")] Storage storage)
        //{
        //    storage.StorageStatus = true;
        //    _context.Update(storage);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            var _data =  db.Storages.Where(m => m.StorageId == id).FirstOrDefault();
            if (_data == null)
            {
                return HttpNotFound();
            }

            return View(_data);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            var _data =  db.Storages.Find(id);
            db.Storages.Remove(_data);
             db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //[HttpPost]
        //public ActionResult LoadDataTables(bool pub)
        //{
        //    var draw = HttpContext.Request.Form["draw"].FirstOrDefault();
        //    var start = Request.Form["start"].FirstOrDefault();
        //    var length = Request.Form["length"].FirstOrDefault();
        //    var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();
        //    var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();
        //    var searchValue = Request.Form["search[value]"].FirstOrDefault();
        //    int pageSize = length != null ? Convert.ToInt32(length) : 0;
        //    int skip = start != null ? Convert.ToInt32(start) : 0;
        //    int recordsTotal = 0;
        //    var claim = ((ClaimsIdentity)User.Identity).FindFirst(ClaimTypes.Sid);
        //    var claim2 = ((ClaimsIdentity)User.Identity).FindFirst(ClaimTypes.GroupSid);
        //    Account _account = new Account(_context);
        //    IQueryable<Storage> _data;
        //    if (claim == null)
        //    {
        //        _data = _context.Storages.Where(w => (w.StorageStatus == true && w.Visibility.PublicView == true)).OrderByDescending(w => w.PostDate).Include(u => u.User).Include(pv => pv.Visibility).Include(fs => fs.FileStorage).AsQueryable().Select(w => new Storage() { PostDate = w.PostDate, StorageStatus = w.StorageStatus, StorageId = w.StorageId, User = new User() { UserName = w.User.UserName, UserStatus = w.User.UserStatus }, Visibility = w.Visibility, FileStorage = new FileStorage() { FileName = w.FileStorage.FileName, FileContentType = w.FileStorage.FileContentType } }).AsQueryable();
        //    }
        //    else
        //    {
        //        _data = _context.Storages.Where(w => (pub ? (w.StorageStatus == true) : (_account.IsUserAdmin(new Guid(claim.Value)) ? true : ((w.UserId == (new Guid(claim.Value))) || (_account.GroupChildren(new Guid(claim2.Value)).Select(x => x.GroupId).Contains(w.Visibility.GroupId)))))).OrderByDescending(w => w.PostDate).Include(u => u.User).Include(pv => pv.Visibility).Include(fs => fs.FileStorage).AsQueryable().Select(w => new Storage() { PostDate = w.PostDate, StorageStatus = w.StorageStatus, StorageId = w.StorageId, User = new User() { UserName = w.User.UserName, UserStatus = w.User.UserStatus }, Visibility = w.Visibility, FileStorage = new FileStorage() { FileName = w.FileStorage.FileName, FileContentType = w.FileStorage.FileContentType } }).AsQueryable();
        //    }
        //    var searchdata = (from tempdata in _data select tempdata);
        //    if (!(string.IsNullOrEmpty(sortColumn) || string.IsNullOrEmpty(sortColumnDirection)))
        //    {
        //        searchdata = searchdata.OrderBy(sortColumn + " " + sortColumnDirection);
        //    }
        //    if (!string.IsNullOrEmpty(searchValue))
        //    {
        //        searchdata = searchdata.Where(x => x.Visibility.VisibilityName.Contains(searchValue) ||
        //        x.User.UserName.ToString().Contains(searchValue) ||
        //        x.PostDate.ToString().Contains(searchValue) ||
        //        x.StorageId.ToString().Contains(searchValue));
        //    }
        //    recordsTotal = searchdata.Count();
        //    List<Storage> data = searchdata.Skip(skip).Take(pageSize).ToList();
        //    return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data });
        //}

        [HttpPost]
        
        public ActionResult Disable(Guid? id)
        {
            Storage updated = db.Storages.Where(w => w.StorageId == id).First();
            updated.StorageStatus = false;
            db.Entry(updated).State = EntityState.Modified;
           
             db.SaveChangesAsync();
            return Json(new { r = id });
        }

        [HttpPost]
        
        public ActionResult Enable(Guid? id)
        {
            Storage updated = db.Storages.Where(w => w.StorageId == id).First();
            updated.StorageStatus = true;
            db.Entry(updated).State = EntityState.Modified;
             db.SaveChangesAsync();
            return Json(new { r = id });
        }

        public ActionResult Download(Guid id, string key)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Storage _payl = db.Storages.Where(w => w.StorageId == id).First();
            if (_payl == null)
            {
                return HttpNotFound();
            }
            User _user = db.Users.Find(Authentication.CurrentUser.UserId);
            
            if (_user.UserId == _payl.UserId)
            {
                FileStorage item2 =  db.FileStorages.Find(_payl.FileStorageId);
                return File(item2.FileData, "application/force-download", Path.GetFileName(item2.FileName));
            }
           
            //string checkhash = Library.ComputeSha512(id.ToString());
            //if (checkhash != key)
            //{
            //    return UnauthorizedAccessException();
            //}
            //DateTime date1 = DateTime.Now;
            //int kumpara = DateTime.Compare(date1, _payl.PostDate);
            //if (kumpara > 0)
            //{
            //    _check = false;
            //}
            //if (!_check)
            //{
            //    return Unauthorized();
            //}
            FileStorage item =  db.FileStorages.Find(_payl.FileStorageId);
            return File(item.FileData, "application/force-download", Path.GetFileName(item.FileName));
        }
    }
}