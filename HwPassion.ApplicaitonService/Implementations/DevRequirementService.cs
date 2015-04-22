using HwPassion.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HwPassion.ApplicaitonService
{
    public class DevRequirementService : BaseServiceImpl<DevRequirement>, IDevRequirementService
    {
        public DevRequirementService(IRepository<DevRequirement, int> repository)
            : base(repository)
        {
        }
    }
}
