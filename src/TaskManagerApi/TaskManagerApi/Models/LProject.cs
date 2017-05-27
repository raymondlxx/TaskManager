using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TaskManagerApi.Models
{
    public class LProject
    {
        [Key]
        public string ProjectID { get; set; }

        [DisplayName("Project Name")]
        public string Name { get; set; }

        public List<LTransaction> LTransactions { get; set; }


    }
}