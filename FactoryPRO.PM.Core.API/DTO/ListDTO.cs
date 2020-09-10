﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FactoryPRO.PM.Core.API.DTO
{
    public class ListDTO
    {
        public string ListId { get; set; }
        public string ProjectId { get; set; }
        public string ModuleId { get; set; }
        public string ListName { get; set; }
        public int? ListOwnerId { get; set; }
        public string ListStatus { get; set; }
        public string Active { get; set; }
        public int? ListSeq { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public long? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

    }
}
