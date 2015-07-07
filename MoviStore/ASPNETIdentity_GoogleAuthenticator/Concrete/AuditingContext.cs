using ASPNETIdentity_GoogleAuthenticator.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ASPNETIdentity_GoogleAuthenticator.Concrete
{
    public class AuditingContext : DbContext
    {
        public DbSet<Audit> AuditRecords { get; set; }
    }
}