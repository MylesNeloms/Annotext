using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinalProject.Models
{
    public class PDF
    {
        public PDF()
        {

        }
        [Key]
        public int id { get; set; }
        public string filename { get; set; }
        

        public List<Annotation> annotations { get; set; }
    }
}
