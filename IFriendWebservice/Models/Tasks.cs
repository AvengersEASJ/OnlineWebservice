using System;
using System.Collections.Generic;

namespace IFriendWebservice.Models
{
    public partial class Tasks
    {
        public int TaskId { get; set; }
        public int? FriendId { get; set; }
        public string TaskName { get; set; }
        public string TaskDesc { get; set; }

        public Friends Friend { get; set; }

        public Tasks()
        {
            FriendId = 0;
            TaskName = "";
            TaskDesc = "";
        }
    }
}
