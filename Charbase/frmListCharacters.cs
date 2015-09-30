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
    public partial class frmListCharacters : Form
    {
        public Form1 MainForm;
        public List<CharacterClass> lstCharacters;

        public void PopulateCharacters(List<CharacterClass> Characters)
        {
            lbCharacters.Items.Clear();
            lstCharacters = Characters;
            foreach (CharacterClass C in lstCharacters)
            {
                lbCharacters.Items.Add(C.Name);
            }
            txtAge.Text = "";
            txtDescription.Text = "";
            txtGender.Text = "";
            txtHometown.Text = "";
            txtName.Text = "";
            txtOccupation.Text = "";
            txtRace.Text = "";
            pbImage.Image = null;

        }

        public frmListCharacters()
        {
            InitializeComponent();
        }

        private void frmListCharacters_Load(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            MainForm.DeleteCharacter(GetCharacterByName(lbCharacters.SelectedItem.ToString()), this);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
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
            //MainForm.AddNewCharacter(NewChar, pbImage.Image);
            MainForm.EditCharacter(GetCharacterByName(lbCharacters.SelectedItem.ToString()), NewChar, pbImage.Image, this);
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
        private void frmListCharacters_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainForm.Enabled = true;

        }

        public CharacterClass GetCharacterByName(string Name)
        {
            CharacterClass RetC = null;

            foreach (CharacterClass C in lstCharacters)
            {
                if (C.Name == Name)
                {
                    if (RetC == null)
                        RetC = C;
                }
            }

            return RetC;
        }

        private void lbCharacters_SelectedIndexChanged(object sender, EventArgs e)
        {
            CharacterClass C = GetCharacterByName(lbCharacters.SelectedItem.ToString());
            if (C != null)
            {
                txtName.Text = C.Name;
                txtAge.Text = C.Age;
                txtGender.Text = C.Gender;
                txtOccupation.Text = C.Occupation;
                txtDescription.Text = C.Description;
                txtHometown.Text = C.Hometown;
                txtRace.Text = C.Race;
                DrawPicture(C.SavePicture);
            }
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
    }
}
