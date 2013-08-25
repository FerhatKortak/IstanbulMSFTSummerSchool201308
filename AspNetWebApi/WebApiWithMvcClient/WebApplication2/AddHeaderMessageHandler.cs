using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace WebApplication2 {

    public class AddHeaderMessageHandler : DelegatingHandler {

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, System.Threading.CancellationToken cancellationToken) {
            
            var response = await base.SendAsync(request, cancellationToken);
            response.Headers.Add("X-Foo", "Bar");

            return response;
        }
    }
}