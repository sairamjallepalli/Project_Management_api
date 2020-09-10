﻿using System;
using System.Collections.Generic;

namespace FactoryPRO.PM.Core.DAL.Models
{
    public partial class TblSpace
    {
        public TblSpace()
        {
            TblProjects = new HashSet<TblProjects>();
        }

        public int Sid { get; set; }
        public string SpaceId { get; set; }
        public string SpaceName { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }

        public virtual ICollection<TblProjects> TblProjects { get; set; }
    }
}
