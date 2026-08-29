using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shared
{
    public enum enApplicationStatus { enNew = 1, enCanceled = 2, enCompleted = 3 }
    public enum enAppMode { addApp = 0, updateApp = 1 }
    public enum enTestType { enVision = 1, enWritten = 2, enStreet = 3}
    public enum enIssueReason {
        enFirstTime = 1,
        enRenew = 2,
        enReplacementForDamaged = 3,
        enReplacementForLost = 4
    }
    public enum enApplicationType {
        NewLocalDrivingLicense = 1,
        RenewDrivingLicense = 2,
        ReplaceLostDrivingLicense = 3,
        ReplaceDamagedDrivingLicense = 4,
        ReleaseDetainedDrivingLicense = 5,
        NewInternationalLicense = 6,
        RetakeTest = 8 // its ID in database = 8
    }
    public static class Utilities {

        public static int convertTestTypeToID(enTestType testType) {
            switch (testType) {
                case enTestType.enVision: return 1;
                case enTestType.enWritten: return 2;
                case enTestType.enStreet: return 3;
                default: return 1;
            }
        }
        public static string convertTestTypeToString(enTestType testType) {
            switch (testType) {
                case enTestType.enVision: return "Vision Test";
                case enTestType.enWritten: return "Written Test";
                case enTestType.enStreet: return "Street Test";
                default: return "Vision Test";
            }
        }

    }
}
