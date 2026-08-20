using BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer {
    public partial class FrmPersonDetails : Form {
        public FrmPersonDetails(Person person) {
            InitializeComponent();
            ucPersonDetails1.loadData(person);
        }
    }
}
