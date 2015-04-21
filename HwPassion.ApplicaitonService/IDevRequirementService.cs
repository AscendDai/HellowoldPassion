using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HwPassion.ApplicaitonService
{
    public interface IDevRequirementService
    {
        IEnumerable<Model.DevRequirement> GetAll();
    }
}
