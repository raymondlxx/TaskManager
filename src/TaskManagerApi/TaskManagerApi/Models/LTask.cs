using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TaskManagerApi.Models
{
    public class LTask
    {
        [Key]
        public string TaskID { get; set; }
        public string Name { get; set; }

        public string TaskGroupID { get; set; }


    }
}