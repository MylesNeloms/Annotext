using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinalProject.Models
{
    public class Annotation
    {
        
        public int id { get; set; }
        [Required]
        public String content { get; set; }

        public String author { get; set; }

        public int VoteVal { get; set; }

        [Range(0, 50)]
        public int pageNum { get; set; }
        
        [Range(0, 50)]
        public int paragraph { get; set; }
        //[Key]
        //public int id { get; set; }


        public string filename { get; set; }
        public PDF pdf { get; set; }

       
    }
}