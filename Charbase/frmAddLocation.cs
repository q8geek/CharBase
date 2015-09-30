using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Charbase
{
    public partial class frmAddLocation : Form
    {
        public Form1 MainForm;

        public frmAddLocation()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //
            //  Creating a new class for the new character
            //
            LocationClass NewLoc = new LocationClass();
            NewLoc.Name = txtName.Text;
            NewLoc.Description = txtDescription.Text;
            NewLoc.Population = txtPopulation.Text;
            NewLoc.Type = txtType.Text;
            NewLoc.Address = txtAddress.Text;

            //
            //  Add character to main form's list
            //
            MainForm.AddNewLocation(NewLoc, pbImage.Image);

            //
            //  Show main form
            //  Enable main form
            //  Close this form
            //
            MainForm.Show();
            MainForm.Enabled = true;
            this.Close();

        }

        private void pbImage_DoubleClick(object sender, EventArgs e)
        {
            OFD.Title = "Add image to character";
            OFD.Filter = "JPG File (*.jpg)|*.jpg";
            OFD.Multiselect = false;
            if (OFD.ShowDialog() == DialogResult.OK)
            {
                ProcessImage(OFD.FileName);
            }
        }

        public void ProcessImage(string FilePath)
        {
            try
            {
                Image tmpImage = Image.FromFile(FilePath, true);
                pbImage.Image = tmpImage;
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Error opening picture!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            MainForm.Show();
            MainForm.Enabled = true;
            this.Close();

        }

        private void frmAddLocation_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainForm.Show();
            MainForm.Enabled = true;
            this.Close();

        }

        private void frmAddLocation_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainForm.Enabled = true;

        }
    }
}
