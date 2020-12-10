using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinalProject.Models
{
    public class Annotation
    {

        [Key]
        public int AnnotationId { get; set; }
        [Required]
        public String content { get; set; }

        [Required]
        public String filename { get; set; }

        [Required]
        public String author { get; set; }

        public int VoteVal { get; set; }

        [Range(0, 50)]
        public int pageNum { get; set; }
        
        [Range(0, 50)]
        public int paragraph { get; set; }

        
        


        public List<Comment> comments { get; set; }

        
        public PDF pdf { get; set; }
        public string PDFId { get; set; }
       

       
    }
}