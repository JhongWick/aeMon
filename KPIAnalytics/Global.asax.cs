using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace KPIAnalytics
{
    public class MvcApplication : System.Web.HttpApplication
    {

        public void Application_Start()
        {
            var migrator = new DbMigrator(new DataAccessLayer.Migrations.Configuration());
            migrator.Configuration.AutomaticMigrationDataLossAllowed = true;
            migrator.Update();

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

    }
}
