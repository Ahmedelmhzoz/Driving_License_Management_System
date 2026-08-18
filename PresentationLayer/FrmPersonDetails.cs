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

        private void FrmPersonDetails_Load(object sender, EventArgs e) {
            if (ucPersonDetails1.isThereImage()) {
                linkLabel1.Text = "Update image";
            } else {
                linkLabel1.Text = "Set image";
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            openFileDialog1.InitialDirectory = @"C:/";
            openFileDialog1.DefaultExt = "png";
            openFileDialog1.Title = "Choose image";
            openFileDialog1.Filter = "PNG images (*.png)|*.png";
            if (openFileDialog1.ShowDialog() == DialogResult.OK) { 
                if (!string.IsNullOrEmpty(openFileDialog1.FileName)) {
                    ucPersonDetails1.setImage(openFileDialog1.FileName);
                    linkLabel1.Text = "Update image";
                }
            }
        }
    }
}
