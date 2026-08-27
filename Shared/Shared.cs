using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public enum enApplicationStatus { enNew = 1, enCanceled = 2, enCompleted = 3 }
    public enum enAppMode { addApp = 0, updateApp = 1 }

    public enum enIssueReason {
        enFirstTime = 1,
        enRenew = 2,
        enReplacementForDamaged = 3,
        enReplacementForLost = 4
    }
    public static class Shared { 
        

    }
}
