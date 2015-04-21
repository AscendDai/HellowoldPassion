using HwPassion.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HwPassion.ApplicaitonService
{
    public class DevRequirementService : IDevRequirementService
    {
        private HwPassionDbEntities db = new HwPassionDbEntities();
        public IEnumerable<DevRequirement> GetAll()
        {
            return db.DevRequirements;
        }
    }
}
