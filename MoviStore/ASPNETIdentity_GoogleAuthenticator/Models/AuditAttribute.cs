using ASPNETIdentity_GoogleAuthenticator.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPNETIdentity_GoogleAuthenticator.Models
{
    public class AuditAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //Stores the Request in an Accessible object
            var request = filterContext.HttpContext.Request;
            //Generate an audit
            Audit audit = new Audit()
            {
                //Your Audit Identifier     
                AuditID = Guid.NewGuid(),
                //Our Username (if available)
                UserName = (request.IsAuthenticated) ? filterContext.HttpContext.User.Identity.Name : "Anonymous",
                //The IP Address of the Request
                IPAddress = request.ServerVariables["HTTP_X_FORWARDED_FOR"] ?? request.UserHostAddress,
                //The URL that was accessed
                AreaAccessed = request.RawUrl,
                //Creates our Timestamp
                TimeAccessed = DateTime.UtcNow
            };

            //Stores the Audit in the Database
            AuditingContext context = new AuditingContext();
            context.AuditRecords.Add(audit);
            context.SaveChanges();

            //Finishes executing the Action as normal 
            base.OnActionExecuting(filterContext);
        }
    }
}