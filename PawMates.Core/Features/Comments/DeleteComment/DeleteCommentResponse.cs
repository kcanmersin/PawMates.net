﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawMates.Core.Features.Comments.DeleteComment
{
    public class DeleteCommentResponse
    {
        public bool Success { get; set; } 
        public string Message { get; set; } = string.Empty;
    }
}