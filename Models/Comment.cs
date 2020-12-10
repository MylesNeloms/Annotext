using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinalProject.Models
{
    public class Comment
    {

        [Key]
        public int CommentId{ get; set; }
        [Required]
        public string content { get; set; }
        [Required]
        public string author { get; set; }

        public int VoteVal { get; set; }



        public string AnnotationId { get; set; }
        public Annotation annotation { get; set; }
    }

}