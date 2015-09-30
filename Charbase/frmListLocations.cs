using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Charbase
{
    public partial class frmListLocations : Form
    {

        public Form1 MainForm;
        public List<LocationClass> lstLocations;

        public void PopulateLocations(List<LocationClass> Locations)
        {
            lbLocations.Items.Clear();
            lstLocations = Locations;
            foreach (LocationClass C in lstLocations)
            {
                lbLocations.Items.Add(C.Name);
            }
            txtName.Text = "";
            txtDescription.Text = "";
            txtPopulation.Text = "";
            txtAddress.Text = "";
            txtType.Text = "";
            pbImage.Image = null;

        }
        public frmListLocations()
        {
            InitializeComponent();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            LocationClass EditLoc = new LocationClass();
            EditLoc.Address = txtAddress.Text;
            EditLoc.Description = txtDescription.Text;
            EditLoc.Name = txtName.Text;
            EditLoc.Population = txtPopulation.Text;
            EditLoc.Type = txtType.Text;
            MainForm.EditLocation(GetLocationByName(lbLocations.SelectedItem.ToString()), EditLoc, pbImage.Image, this);


        }

        public LocationClass GetLocationByName(string Name)
        {
            LocationClass RetL = null;

            foreach (LocationClass L in lstLocations)
            {
                if (L.Name == Name)
                {
                    if (RetL == null)
                        RetL = L;
                }
            }

            return RetL;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            MainForm.DeleteLocation(GetLocationByName(lbLocations.SelectedItem.ToString()), this);

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

        private void frmListLocations_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainForm.Enabled = true;
        }

        public void DrawPicture(string strPicture)
        {
            if (strPicture != "")
            {
                try
                {
                    byte[] bPicture = Convert.FromBase64String(strPicture);
                    MemoryStream MS = new MemoryStream(bPicture, 0, bPicture.Length);
                    pbImage.Image = Image.FromStream(MS, true, true);
                    //pbImage.Image = Image.FromStream(MS, true, true);
                }
                catch (Exception EX)
                {
                    MessageBox.Show(EX.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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

        private void lbLocations_SelectedIndexChanged(object sender, EventArgs e)
        {
            LocationClass C = GetLocationByName(lbLocations.SelectedItem.ToString());
            if (C != null)
            {
                txtName.Text = C.Name;
                txtDescription.Text = C.Description;
                txtAddress.Text = C.Address;
                txtType.Text = C.Type;
                txtPopulation.Text = C.Population;
                DrawPicture(C.SavePicture);
            }

        }
    }
}
