using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TaskManagerApi.Models
{
    public class LTaskGroup
    {
        [Key]
        public string TaskGroupID { get; set; }

        [DisplayName("Group Name")]
        public string Name { get; set; }
        

    }
}