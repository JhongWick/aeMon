using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Library
    {
        public static int UpdateModule(Module newModule)
        {
            using (DBContext context = new DBContext())
            {
                Module _module = context.Modules.Find(newModule.ModuleId);
                _module.Name = newModule.Name;
                _module.ModuleAction = newModule.ModuleAction;
                _module.ModuleController = newModule.ModuleController;
                context.SaveChanges();
            }
            return 1;
        }
        public static int AddModule(Module _data)
        {
            using (DBContext context = new DBContext())
            {
                context.Modules.Attach(_data);
                context.Entry(_data).State = System.Data.Entity.EntityState.Added;
                context.SaveChanges();
                foreach (Role item in Helper.GetRoleList())
                {
                    int _ModuleId = _data.ModuleId;
                    if (!context.RoleDetails.Any(w => w.ModuleId == _ModuleId && w.RoleId == item.RoleId))
                    {
                        RoleDetail newRoleDetail = new RoleDetail();
                        newRoleDetail.ModuleId = _ModuleId;
                        newRoleDetail.RoleId = item.RoleId;
                        newRoleDetail.IsAllowed = false;
                        context.RoleDetails.Attach(newRoleDetail);
                        context.Entry(newRoleDetail).State = System.Data.Entity.EntityState.Added;
                        context.SaveChanges();
                    }
                }
            }
            return 1;
        }
        public static int AddModule(Module _data, int mode)
        {
            using (DBContext context = new DBContext())
            {
                context.Modules.Add(_data);
                context.SaveChanges();
                return _data.ModuleId;

            }
        }
        public static int DeleteModule(int id)
        {
            using (DBContext context = new DBContext())
            {
                Module _data = context.Modules.Find(id);
                context.Entry(_data).State = System.Data.Entity.EntityState.Deleted;
                context.SaveChanges();
                foreach (RoleDetail item in Helper.GetRoleDetailListByModuleID(id))
                {
                    RoleDetail _RoleDetail = context.RoleDetails.Find(item.Id);
                    context.Entry(_RoleDetail).State = System.Data.Entity.EntityState.Deleted;
                    context.SaveChanges();
                }
            }
            return 1;
        }

        //public static int UpdateAgency(Agency _updatedAgency)
        //{
        //    using (eProcContext context = new eProcContext())
        //    {
        //        Agency _agency = context.Agencies.Find(_updatedAgency.AgencyId);
        //        _agency.AgencyDesc = _updatedAgency.AgencyDesc;
        //        _agency.AgencyCode = _updatedAgency.AgencyCode;
        //        _agency.LowerOperatingUnitCode = _updatedAgency.LowerOperatingUnitCode;
        //        _agency.LowerOperatingUnitDesc = _updatedAgency.LowerOperatingUnitDesc;
        //        _agency.OperatingUnitCode = _updatedAgency.OperatingUnitCode;
        //        _agency.OperatingUnitDesc = _updatedAgency.OperatingUnitDesc;
        //        context.SaveChanges();
        //    }
        //    return 1;
        //}
        //public static int AddAgency(Agency newAgency)
        //{
        //    using (eProcContext context = new eProcContext())
        //    {
        //        context.Agencies.Attach(newAgency);
        //        context.Entry(newAgency).State = System.Data.Entity.EntityState.Added;
        //        context.SaveChanges();
        //    }
        //    return 1;
        //}
        //public static int DeleteAgency(int id)
        //{
        //    using (eProcContext context = new eProcContext())
        //    {
        //        Agency _agency = context.Agencies.Find(id);
        //        context.Entry(_agency).State = System.Data.Entity.EntityState.Deleted;
        //        context.SaveChanges();
        //    }
        //    return 1;
        //}
        //public static int DisableAgency(int id)
        //{
        //    using (eProcContext context = new eProcContext())
        //    {
        //        Agency _agency = context.Agencies.Find(id);
        //        _agency.IsEnabled = false;
        //        context.SaveChanges();
        //    }
        //    return 1;
        //}

        public static string ComputeSha256(string randomString)
        {
            var crypt = new System.Security.Cryptography.SHA256Managed();
            var hash = new System.Text.StringBuilder();
            byte[] crypto = crypt.ComputeHash(System.Text.Encoding.UTF8.GetBytes(randomString));
            foreach (byte theByte in crypto)
            {
                hash.Append(theByte.ToString("x2"));
            }
            return hash.ToString();
        }
        public static string ComputeSha512(string randomString)
        {
            var crypt = new System.Security.Cryptography.SHA512Managed();
            var hash = new System.Text.StringBuilder();
            byte[] crypto = crypt.ComputeHash(System.Text.Encoding.UTF8.GetBytes(randomString));
            foreach (byte theByte in crypto)
            {
                hash.Append(theByte.ToString("x2"));
            }
            return hash.ToString();
        }
        public static DateTime ConvertFromUnixTimestamp(double timestamp)
        {
            var origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return origin.AddSeconds(timestamp);
        }
    }
}
