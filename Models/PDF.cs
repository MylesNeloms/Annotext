﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinalProject.Models
{
    public class PDF
    {
        [Key]
        public int PDFid { get; set; }
        public string filename { get; set; }
        

        public List<Annotation> annotations { get; set; }

        public int CategoryId { get; set; }
        public Category category { get; set; }
    }
}
