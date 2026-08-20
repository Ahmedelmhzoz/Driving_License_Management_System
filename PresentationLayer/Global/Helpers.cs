using System;
using System.Windows.Forms;

namespace PresentationLayer // ضمان نفس اسم الـ Namespace لمشروع الواجهات
{
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
    }
}