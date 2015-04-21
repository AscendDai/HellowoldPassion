using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HwPassion.Model
{
    [Description("需求状态")]
    public enum DevRequirementStatus
    {
        [Description("初始")]
        Initial,
        [Description("开发中")]
        Deving,
        [Description("完成")]
        Complete
    }
}
