using System;
using System.Collections.Generic;
using System.Text;

namespace UserAuthenticationService.ClassObjects
{
    public class UserModel
    {
        public long UserId { get; set; } = 0;
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
