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
    public partial class frmAddCharacter : Form
    {
        public Form1 MainForm;

        public frmAddCharacter()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //
            //  Creating a new class for the new character
            //
            CharacterClass NewChar = new CharacterClass();
            NewChar.Name = txtName.Text;
            NewChar.Age = txtAge.Text;
            NewChar.Gender = txtGender.Text;
            NewChar.Occupation = txtOccupation.Text;
            NewChar.Description = txtDescription.Text;
            NewChar.Hometown = txtHometown.Text;
            NewChar.Race = txtRace.Text;

            //
            //  Add character to main form's list
            //
            MainForm.AddNewCharacter(NewChar, pbImage.Image);

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

        private void frmAddCharacter_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainForm.Enabled = true;

        }
    }
}
