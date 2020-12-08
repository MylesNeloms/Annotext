using FinalProject.DataContexts;
using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProject.MigrationCommands
{

    public class MakePDFs
    {

        //public static System.Collections.Generic.List<PDF> getPdfs()
        //{

        //    List<PDF> pdf = new List<PDF>()
        //    {
        //        new PDF()
        //        { filename = "Chapter03_SG.pdf"},
        //        new PDF()
        //        { filename = "Chapter04_SG.pdf"},
        //        new PDF()
        //        { filename = "ICMP.pdf"},
        //        new PDF()
        //        { filename = "Network Layer Security.pdf"},
        //        new PDF()
        //        { filename = "STP Attacks.pdf"},
        //        new PDF()
        //        { filename = "The Internet Protocol.pdf"},
        //        new PDF()
        //        { filename = "Transport Layer Protocol.pdf"},
        //        new PDF()
        //        { filename = "VLAN Hopping.pdf"},
        //    };
        //    return pdf;
        //}


        public static System.Collections.Generic.List<Annotation> getAnno(AnnoContext context)
        {
            List<Annotation> an = new List<Annotation>(){


                new Annotation()
                { content = "Chapter03_SG.pdf",
                 author = "Myles Neloms",
                 pageNum = 1,
                 paragraph = 1,
                 filename = context.PDFs.Find("Chapter03_SG.pdf").filename,
                 VoteVal = 1,

                },
                 new Annotation()
                { content = "Chapter03_SG.pdf",
                 author = "Patrick Crump",
                 pageNum = 1,
                 paragraph = 1,
                 filename = context.PDFs.Find("Chapter03_SG.pdf").filename,
                 VoteVal = 2,
                },
                  new Annotation()
                { content = "Chapter03_SG.pdf",
                 author = "Tiara Bell",
                 pageNum = 1,
                 paragraph = 1,
                 filename = context.PDFs.Find("Chapter03_SG.pdf").filename,
                 VoteVal = 3,
                },


                new Annotation()
                { content = "Chapter03_SG.pdf",
                 author = "Myles Neloms",
                 pageNum = 1,
                 paragraph = 1,
                 filename = context.PDFs.Find("Chapter04_SG.pdf").filename,
                 VoteVal = 1,
                },
                 new Annotation()
                { content = "Chapter03_SG.pdf",
                 author = "Patrick Crump",
                 pageNum = 1,
                 paragraph = 1,
                 filename = context.PDFs.Find("Chapter04_SG.pdf").filename,
                 VoteVal = 2,
                },
                  new Annotation()
                { content = "Chapter03_SG.pdf",
                 author = "Tiara Bell",
                 pageNum = 1,
                 paragraph = 1,
                 filename = context.PDFs.Find("Chapter04_SG.pdf").filename,
                 VoteVal = 3,
                },


                  new Annotation()
                { content = "Chapter03_SG.pdf",
                 author = "Myles Neloms",
                 pageNum = 1,
                 paragraph = 1,
                 filename = context.PDFs.Find("ICMP.pdf").filename,
                 VoteVal = 1,
                },
                 new Annotation()
                { content = "Chapter03_SG.pdf",
                 author = "Patrick Crump",
                 pageNum = 1,
                 paragraph = 1,
                 filename = context.PDFs.Find("ICMP.pdf").filename,
                 VoteVal = 2,
                },
                  new Annotation()
                { content = "Chapter03_SG.pdf",
                 author = "Tiara Bell",
                 pageNum = 1,
                 paragraph = 1,
                 filename = context.PDFs.Find("ICMP.pdf").filename,
                 VoteVal = 3,
                },


                new Annotation()
                { content = "Chapter03_SG.pdf",
                 author = "Myles Neloms",
                 pageNum = 1,
                 paragraph = 1,
                 filename = context.PDFs.Find("Network Layer Security.pdf").filename,
                 VoteVal = 1,
                },
                 new Annotation()
                { content = "Chapter03_SG.pdf",
                 author = "Patrick Crump",
                 pageNum = 1,
                 paragraph = 1,
                 filename = context.PDFs.Find("Network Layer Security.pdf").filename,
                 VoteVal = 2,
                },
                  new Annotation()
                { content = "Chapter03_SG.pdf",
                 author = "Tiara Bell",
                 pageNum = 1,
                 paragraph = 1,
                 filename = context.PDFs.Find("Network Layer Security.pdf").filename,
                 VoteVal = 3,
                },



                  new Annotation()
                { content = "Chapter03_SG.pdf",
                 author = "Myles Neloms",
                 pageNum = 1,
                 paragraph = 1,
                 filename = context.PDFs.Find("STP.pdf").filename,
                 VoteVal = 1,
                },
                 new Annotation()
                { content = "Chapter03_SG.pdf",
                 author = "Patrick Crump",
                 pageNum = 1,
                 paragraph = 1,
                 filename = context.PDFs.Find("STP.pdf").filename,
                 VoteVal = 2,
                },
                  new Annotation()
                { content = "Chapter03_SG.pdf",
                 author = "Tiara Bell",
                 pageNum = 1,
                 paragraph = 1,
                 filename = context.PDFs.Find("STP.pdf").filename,
                 VoteVal = 3,
                },


                  new Annotation()
                { content = "Chapter03_SG.pdf",
                 author = "Myles Neloms",
                 pageNum = 1,
                 paragraph = 1,
                 filename = context.PDFs.Find("The Internet Protocol.pdf").filename,
                 VoteVal = 1,
                },
                 new Annotation()
                { content = "Chapter03_SG.pdf",
                 author = "Patrick Crump",
                 pageNum = 1,
                 paragraph = 1,
                 filename = context.PDFs.Find("The Internet Protocol.pdf").filename,
                 VoteVal = 2,
                },
                  new Annotation()
                { content = "Chapter03_SG.pdf",
                 author = "Tiara Bell",
                 pageNum = 1,
                 paragraph = 1,
                 filename = context.PDFs.Find("The Internet Protocol.pdf").filename,
                 VoteVal = 3,
                },


                  new Annotation()
                { content = "Chapter03_SG.pdf",
                 author = "Myles Neloms",
                 pageNum = 1,
                 paragraph = 1,
                 filename = context.PDFs.Find("Transport Layer Protocol.pdf").filename,
                 VoteVal = 1,
                },
                 new Annotation()
                { content = "Chapter03_SG.pdf",
                 author = "Patrick Crump",
                 pageNum = 1,
                 paragraph = 1,
                 filename = context.PDFs.Find("Transport Layer Protocol.pdf").filename,
                 VoteVal = 2,
                },
                  new Annotation()
                { content = "Chapter03_SG.pdf",
                 author = "Tiara Bell",
                 pageNum = 1,
                 paragraph = 1,
                 filename = context.PDFs.Find("Transport Layer Protocol.pdf").filename,
                 VoteVal = 3,
                },


                  new Annotation()
                { content = "Chapter03_SG.pdf",
                 author = "Myles Neloms",
                 pageNum = 1,
                 paragraph = 1,
                 filename = context.PDFs.Find("VLAN Hopping.pdf").filename,
                 VoteVal = 1,
                },
                 new Annotation()
                { content = "Chapter03_SG.pdf",
                 author = "Patrick Crump",
                 pageNum = 1,
                 paragraph = 1,
                 filename = context.PDFs.Find("VLAN Hopping.pdf").filename,
                 VoteVal = 2,
                },
                 new Annotation()
                { content = "Chapter03_SG.pdf",
                 author = "Tiara Bell",
                 pageNum = 1,
                 paragraph = 1,
                 filename = context.PDFs.Find("VLAN Hopping.pdf").filename,
                 VoteVal = 3,
                },




            };

            return an;
        }

    }
}
