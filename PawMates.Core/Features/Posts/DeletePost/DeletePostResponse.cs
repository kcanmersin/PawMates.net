﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawMates.Core.Features.Posts.DeletePost
{
    public class DeletePostResponse
    {
        public bool Success { get; set; } 
        public string Message { get; set; } = string.Empty;  
    }
}
