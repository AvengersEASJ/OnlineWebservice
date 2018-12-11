using System;
using System.Collections.Generic;

namespace IFriendWebservice.Models
{
    public partial class Users
    {
        public Users()
        {
            Friends = new HashSet<Friends>();
        }

        public Users(string username, string userPassword)
        {
            Username = username;
            UserPassword = userPassword;
        }

        public int? UserId { get; set; }
        public string Username { get; set; }
        public string UserPassword { get; set; }

        public ICollection<Friends> Friends { get; set; }
    }
}
