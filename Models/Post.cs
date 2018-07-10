﻿using DataStructuresAndLINQ.DataStructures;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructuresAndLINQ
{
    public class Post
    {
        public int Id { get; set; }
        public DateTime createdAt { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public int UserId { get; set; }
        public int Likes { get; set; }
        public User User { get; set; }
        public virtual IEnumerable<Comment> Comments { get; set; }
    }
}
