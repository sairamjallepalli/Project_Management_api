using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FactoryPRO.PM.Core.API.DTO
{
    public class CustomFieldsDTO
    {
        public int Cid { get; set; }
        public string ProjectId { get; set; }
        public string ModuleId { get; set; }
        public string DieCode { get; set; }
        public string MfgPart { get; set; }
        public string Fgpart { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }

    }
}
