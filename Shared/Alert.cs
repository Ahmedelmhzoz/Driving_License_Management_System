using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shared {
    public static class Alert {
        public static void ShowErrorMessage(string message, string title = "Error") {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public static void SuccessfulMessage(string message, string title = "Process done successfully") {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static void ShowGeneralMessage(string message, string title = "Process done successfully") {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static DialogResult ShowConfirmation(string message, string title = "Confirmation") {
            return MessageBox.Show(message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        }

    }

}
