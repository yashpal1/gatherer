using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BAL
{
    public class clsJsonMember
    {

        //here is my change.
        public class loginDetails
        {
            public string UserId { get; set; }
            public string Password { get; set; }
            public string Username { get; set; }
            public string ProfileId { get; set; }
        }
    }
}
