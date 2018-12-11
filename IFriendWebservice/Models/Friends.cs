using System;
using System.Collections.Generic;

namespace IFriendWebservice.Models
{
    public partial class Friends
    {
        //public Friends()
        //{
        //    Tasks = new HashSet<Tasks>();
        //}

        public Friends()
        {
            FriendsName = "";
            Gender = false;
            Thirst = 100;
            Hunger = 100;
            Task = 0;
            Fun = 100;
            Dress = 0;
            OwnerId = 0;
        }

        public int FriendsId { get; set; }
        public string FriendsName { get; set; }
        public bool Gender { get; set; }
        public int? Thirst { get; set; }
        public int? Hunger { get; set; }
        public int? Task { get; set; }
        public int? Fun { get; set; }
        public int? Dress { get; set; }
        public int? OwnerId { get; set; }

        public Users Owner { get; set; }
        public ICollection<Tasks> Tasks { get; set; }
    }
}
