
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Shared
{
    public enum enDriverFilterColumn {
        DriverID = 1,
        PersonID = 2,
        NationalNo = 3,
        FullName = 4
    }
    public enum enUserStatus { enActive = 0, enNotActive = 1, enGeneral = 2 }

    public enum enInternationalLicenseEligibility {
        Eligible = 0,                  
        NotFound = 1,              
        NotOrdinaryLicenseCLass = 2,              
        NotActive = 3,             
        HasActiveInternational = 4  
    }
    public enum enLicenseRenewalResult {
        Success,
        BasicAppNotFound,
        PersonNotFound,
        Failed
    }
   

    public enum enRenewalEligibility {  
        Eligible,
        LicenseNotEligibleActive,
        LicenseNotEligibleSuspended
    }

    
    public enum enDetainResult {
        Success,
        AlreadyDetained,
        FineOutOfRange
    }
   
    public enum enLicenseEligibility {
        Active,
        Suspended,
        Expired,
        Detained ,
        NotFound
    }
    public enum enLicenseType {
        Local = 0,
        International = 1
    }

    public enum enLocalLicenseStatus {
        All = 0,
        Active = 1,
        Suspended = 2, 
        Expired = 3
    }

    public enum enInternationalLicenseStatus {
        All = 0,
        Active = 1,
        Expired = 3
    }
    public enum enLicenseFilterBy {
        None = 0,
        InternationalLicenseID = 1,
        DriverID = 2,
        LicenseStatus = 3
    }
    public enum enDetainFilterBy {
        None,
        DetainID,
        LicenseID,
        Fullname,
        DetaintionStatus
    }
    public enum enDetaintionStatus { 
        Detained,
        Released
    }
    public enum enApplicationStatus { enNew = 1, enCanceled = 2, enCompleted = 3 }
    public enum enAppMode { addApp = 0, updateApp = 1 }
    public enum enTestType { Vision = 1, Theoretical = 2, Street = 3}
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
    public enum enLicenseClass {
        SmallMotorcycle = 1,
        HeavyMotorcycle = 2,
        Ordinary = 3,
        Commercial = 4,
        Agricultural = 5,
        SmallMediumBus = 6,
        TruckHeavyVehicle = 7
    }
    public enum enPeriod { 
        Day,
        Week,
        Month,
        Year,
        Lifetime
    }
    public enum enFinancialProceesType { 
        Applications,
        Tests,
        Licenses,
        Fine
    }

   
    
}
