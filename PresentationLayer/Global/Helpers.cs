using BusinessLayer;
using System;
using System.Windows.Forms;
using Shared;
using BusinessLayer.License_Applications;

namespace Global {  
    public static class Helpers {
        public static void ShowErrorMessage(string message, string title = "Error") {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public static void SuccessfulMessage(string message, string title = "Process done successfully") {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static void ShowGeneralMessage(string message, string title = "Process done successfully") {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static string _ConverStatusEnumToString(enApplicationStatus status) {
            switch (status) {
                case enApplicationStatus.enNew: return "New";
                case enApplicationStatus.enCanceled: return "Canceled";
                case enApplicationStatus.enCompleted: return "Completed";
                default: return "Unknown";
            }
        }
    }
}