﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TaskManagerApi.Models
{
    public class LTransaction
    {
        [Key]
        public string TransationID { get; set; }

        [DisplayName("Transaction Name")]
        public string Name { get; set; }

        public List<LTaskGroup> LGroups { get; set; }



    }
}