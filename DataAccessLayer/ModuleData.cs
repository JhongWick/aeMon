using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{

    public class ModuleData
    {

        public static Module GetById(int ModuleId)
        {
            using (DBContext Context = new DBContext())
            {
                return Context.Modules.Where(o => o.ModuleId == ModuleId).SingleOrDefault();
            }
        }
        public static List<Module> ListAll()
        {
            using (DBContext Context = new DBContext())
            {
                return Context.Modules.Where(o => o.IsDeleted == false).ToList();
                //return Context.Modules.ToList();
            }
        }
        //public static bool Add(Module obj)
        //{
        //    using (eProcContext context = new eProcContext())
        //    {

        //        context.Modules.Add(obj);
        //        try
        //        {
        //            context.SaveChanges();
        //        }
        //        catch
        //        { return false; }

        //        return true;
        //    }
        //}

        ///////////////////  ADD IN/////////////////////////////////////
        ///////////////////  ADD IN/////////////////////////////////////
        ///////////////////  ADD IN/////////////////////////////////////
        ///////////////////  ADD IN/////////////////////////////////////
        public static int[] FindRoles(int ModuleId)
        {
            using (DBContext context = new DBContext())
            {
                List<RoleDetail> details = context.RoleDetails.Where(o => o.ModuleId == ModuleId).ToList();
                int[] roleids = new int[details.Count]; int ctr = 0;
                foreach (RoleDetail detail in details)
                {
                    roleids[ctr] = detail.RoleId;
                    ctr++;
                }
                return roleids;
            }
        }
        public static List<Module> GetList()
        {
            using (DBContext context = new DBContext())
            {
                return context.Modules.ToList();
            }
        }
        //public static List<ModuleModel> GetChildren(int ParentId, List<ModuleModel> models, int RoleId, int branch)
        //{
        //    using (eProcContext context = new eProcContext())
        //    {
        //        List<Module> modules = context.Modules.ToList();
        //        List<RoleDetail> details = context.RoleDetails.Where(o => o.RoleId == RoleId).ToList();
        //        foreach (Module module in modules)
        //        {
        //            bool found = false;
        //            foreach (RoleDetail detail in details)
        //            {
        //                if (module.Id == detail.ModuleId && detail.IsAllowed == true)
        //                {
        //                    found = true;
        //                }
        //            }
        //            if (module.BelongsTo == ParentId)
        //            {
        //                models.Add(new ModuleModel
        //                { ModuleId = module.Id, Name = module.Name, RoleId = RoleId, BelongsTo = module.BelongsTo, IsAllowed = found, Branch = branch + 1 });
        //                models = ModuleData.GetChildren(module.Id, models, RoleId, branch + 1);
        //            }
        //        }

        //        return models;
        //    }
        //}
        public static List<ModuleModel> GetModel(int RoleId)
        {

            using (DBContext context = new DBContext())
            {
                List<ModuleModel> models = new List<ModuleModel>();
                List<Module> modules = context.Modules.ToList();
                List<RoleDetail> details = context.RoleDetails.Where(o => o.RoleId == RoleId).ToList();
                foreach (Module module in modules)
                {
                    bool found = false;
                    foreach (RoleDetail detail in details)
                    {
                        if (module.ModuleId == detail.ModuleId && detail.IsAllowed == true)
                        {
                            found = true;
                        }
                    }
                    models.Add(new ModuleModel
                    {
                        ModuleId = module.ModuleId,
                        Name = module.Name,
                        RoleId = RoleId,
                        IsAllowed = found
                    ,
                        Branch = 0
                    });


                }
                return models;


            }

        }
        //public static Module GetByName(string Name, string Parent)
        //{
        //    using (eProcContext context = new eProcContext())
        //    {
        //        return context.Modules.Where(o => o.Name == Name && o.BelongsTo == GetByName(Parent).Id).SingleOrDefault();
        //    }
        //}
        public static Module GetByName(string Name)
        {
            using (DBContext context = new DBContext())
            {
                return context.Modules.Where(o => o.Name.ToLower() == Name.ToLower()).SingleOrDefault();
            }
        }
        //public static List<Module> ListAll()
        //{
        //    using (eProcContext Context = new eProcContext())
        //    {
        //        //return Context.Modules.Where(o => o.IsDeleted == false).ToList();
        //        return Context.Modules.ToList();
        //    }
        //}

        public static Module Fetch(int id)
        {
            using (DBContext context = new DBContext())
            {
                return context.Modules.Where(w => w.ModuleId == id).SingleOrDefault();
            }
        }
        public static Module Fetch(string action, string controller)
        {
            using (DBContext context = new DBContext())
            {
                return context.Modules.Where(w => w.ModuleAction == action && w.ModuleController == controller).SingleOrDefault();
            }
        }

        public static bool Add(Module obj)
        {
            using (DBContext Context = new DBContext())
            {
                obj.UniqueId = Guid.NewGuid();
                Context.Modules.Add(obj);
                try
                { Context.SaveChanges(); }
                catch
                { return false; }
                return true;
            }
        }

        public static bool Delete(Module obj)
        {
            bool result = false;
            using (DBContext context = new DBContext())
            {

                Module module = context.Modules.SingleOrDefault(o => o.IsDeleted == false && o.ModuleId == obj.ModuleId);
                if (module != null)
                {
                    module.IsDeleted = true;
                    context.SaveChanges();
                    result = true;
                }
            }
            return result;
        }

        public static bool Edit(Module obj)
        {
            using (DBContext context = new DBContext())
            {
                Module module = context.Modules.Where(o => o.ModuleId == obj.ModuleId).SingleOrDefault();
                module.Name = obj.Name;
                module.ModuleController = obj.ModuleController;
                module.ModuleAction = obj.ModuleAction;
                module.IsDeleted = obj.IsDeleted;
                try
                { context.SaveChanges(); }
                catch
                { return false; }
                return true;
            }
        }

    }


}
