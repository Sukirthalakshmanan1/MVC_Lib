using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_Lib.Models
{
    public class LibMember
    {
        [Required()]
        public int Member_Id { get; set; }
        public string Member_Name { get; set; }

    }

    public class Book
    {
        public int Book_Id { get; set; }
        public string Book_Name { get; set; }
        public int Cost { get; set; }
    }

    public class IssueBook
    {
        public int Issue_Id { get; set; }
        public int Member_Id { get; set; }

        public DateTime Issuedate { get; set; }
        public DateTime returndate { get; set; }

    }

}