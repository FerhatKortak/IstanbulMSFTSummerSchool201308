using HelloWorldOwin;
using Microsoft.Owin;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[assembly: OwinStartup(typeof(Startup))]
namespace HelloWorldOwin
{
    using System.Globalization;
    using System.IO;
    using AppFunc = Func<IDictionary<string, object>, Task>;

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.Use(new Func<AppFunc, AppFunc>(ignoreNextApp => (AppFunc)Invoke));
        }

        public Task Invoke(IDictionary<string, object> environment)
        {
            string message = string.Format("Serviced request on {0} at {1}", DateTime.Now.ToLongDateString(), DateTime.Now.ToLongTimeString());
            var responseBytes = ASCIIEncoding.UTF8.GetBytes(message);
            Stream responseStream = (Stream)environment["owin.ResponseBody"];

            IDictionary<string, string[]> responseHeaders = (IDictionary<string, string[]>)environment["owin.ResponseHeaders"];
            responseHeaders["Content-Length"] = new string[] { responseBytes.Length.ToString(CultureInfo.InvariantCulture) };
            responseHeaders["Content-Type"] = new string[] { "text/plain" };

            return responseStream.WriteAsync(responseBytes, 0, responseBytes.Length);
        }
    }
}
