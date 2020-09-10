using FactoryPRO.PM.Core.API.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FactoryPRO.PM.Core.API.DTO
{
    public class FullProjectDTO
    {
        public ProjectDTO   projectDTO { get; set; }
        public CustomFieldsDTO customFieldsDTO { get; set; }
    }
}
