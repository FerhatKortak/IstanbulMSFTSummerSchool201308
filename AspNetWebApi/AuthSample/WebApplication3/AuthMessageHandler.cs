using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using WebApiDoodle.Web;
using WebApiDoodle.Web.MessageHandlers;

namespace WebApplication3 {

    public class User {

        public string Name { get; set; }
        public string Password { get; set; }
        public string[] Roles { get; set; }
    }

    public class AuthMessageHandler : BasicAuthenticationHandler {

        private static IEnumerable<User> _users = new List<User> 
        { 
            new User { Name = "Tugberk", Password = "123456", Roles = new[] { "Employee" } },
            new User { Name = "Bob", Password = "987654", Roles = new[] { "Customer" } }
        };

        protected override Task<IPrincipal> AuthenticateUserAsync(
            HttpRequestMessage request, 
            string username, 
            string password, 
            CancellationToken cancellationToken) {

            var foundUser = (from user in _users
                        where user.Name.Equals(username, StringComparison.OrdinalIgnoreCase) &&
                                user.Password.Equals(password, StringComparison.Ordinal)
                        select user).FirstOrDefault();

            if (foundUser != null) 
            {
                var identitiy = new GenericIdentity(foundUser.Name);
                var principal = new GenericPrincipal(identitiy, foundUser.Roles);

                return Task.FromResult<IPrincipal>(principal);
            }

            return Task.FromResult<IPrincipal>(null);
        }

        protected override void HandleUnauthenticatedRequest(UnauthenticatedRequestContext context) {

            // Do nothing here to keep going inside the pipeline and let the AuthorizeAttribute handle authorization.
            // Useful when you allow anonymous access for some of your endpoints.
        }
    }
}