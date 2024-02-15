using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Runtime.InteropServices;
using System.Text;

namespace BuildWolf.Modules.UserModules
{
    public class Users
    {
       public string UserId { get; set; }
       public string UserName { get; set; }
       public string EmailAddress { get; set; }
       public string MobileNo { get; set; }
       public string WebsiteUrl { get; set; }
       public int UserTypeId { get; set; }
       public string Charges { get; set; }
       public string Experience { get; set; }
       public bool IsActive { get; set; }
       public DateTime CreatedDate { get; set; }
       public DateTime ModifiedDate { get; set; }
       public string CreatedBy { get; set; }
       public string ModifiedBy { get; set; }

    }
}
