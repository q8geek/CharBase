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
    public partial class frmListEvents : Form
    {
        public Form1 MainForm;
        public List<EventClass> lstEvents;

        public void PopulateEvents(List<EventClass> Events)
        {
            lbEvents.Items.Clear();
            lstEvents = Events;
            foreach (EventClass E in lstEvents)
            {
                lbEvents.Items.Add(E.Name);
            }
            txtName.Text = "";
            txtDescription.Text = "";
            txtDate.Text = "";
            txtLocation.Text = "";
            pbImage.Image = null;

        }

        public frmListEvents()
        {
            InitializeComponent();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            EventClass EditEvent= new EventClass();
            EditEvent.Date = txtDate.Text;
            EditEvent.Description = txtDescription.Text;
            EditEvent.Name = txtName.Text;
            EditEvent.Location= txtLocation.Text;
            MainForm.EditEvent(GetEventByName(lbEvents.SelectedItem.ToString()), EditEvent, pbImage.Image, this);

        }

        public EventClass GetEventByName(string Name)
        {
            EventClass RetE = null;

            foreach (EventClass E in lstEvents)
            {
                if (E.Name == Name)
                {
                    if (RetE == null)
                        RetE = E;
                }
            }

            return RetE;
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


        private void lstEvents_SelectedIndexChanged(object sender, EventArgs e)
        {
            EventClass E = GetEventByName(lbEvents.SelectedItem.ToString());
            if (E != null)
            {
                txtName.Text = E.Name;
                txtDescription.Text = E.Description;
                txtDate.Text = E.Date;
                txtLocation.Text = E.Location;
                DrawPicture(E.SavePicture);
            }


        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            MainForm.DeleteEvent(GetEventByName(lbEvents.SelectedItem.ToString()), this);

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
        
        private void frmListEvents_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainForm.Enabled = true;

        }
    }
}
