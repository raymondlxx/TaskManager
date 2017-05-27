using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TaskManagerApi.Models
{
    public class LTaskGroup
    {
        [Key]
        public string TaskGroupID { get; set; }
        public string Name { get; set; }
        

    }
}