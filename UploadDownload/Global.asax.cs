using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using UploadDownload.Classes;

namespace UploadDownload
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            System.Timers.Timer timer = new System.Timers.Timer
            {
                Interval = 60000,//یک دقیقه یکبار
                Enabled = true
            };
            timer.Elapsed += timer_Elapsed;
            timer.Start();
        }
        private void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
               FileBiz.Instance.RemoveScheduler();
            }
            catch (Exception ex)
            {
                WriteTextLog(ex.Message);
            }

        }
        private void WriteTextLog(string error)
        {
            try
            {
                string fileName = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory + "Log" + DateTime.Now.ToString("yyyyddMM") + ".log");
                using (var streamWriter = new StreamWriter(fileName, true, System.Text.Encoding.Unicode))
                {
                    streamWriter.WriteLine(System.DateTime.Now.ToShortTimeString() + " " + error);
                    streamWriter.WriteLine("---------------------------------------------------");
                }

            }
            catch (Exception)
            {//
            }

        }
    }
}
