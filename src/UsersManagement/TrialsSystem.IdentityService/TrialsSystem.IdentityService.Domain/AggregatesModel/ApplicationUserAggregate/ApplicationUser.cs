using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AspNetCore.Identity.Mongo.Model;

namespace TrialsSystem.IdentityService.Domain.AggregatesModel.ApplicationUserAggregate
{
    public class ApplicationUser : MongoUser
    {
        public ApplicationUser(string userName)
            : base(userName) { }


    }
}
