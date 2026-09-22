using System;
using System.Collections.Generic;
using System.Text;

namespace CarBook.Dto.CommentDtos
{
    public class ResultCommentDto
    {
        public int CommentId { get; set; }
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
        public string Description { get; set; }
        public int BlogId { get; set; }
    }
}
