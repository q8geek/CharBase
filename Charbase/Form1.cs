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
using Newtonsoft.Json;

namespace Charbase
{

    public partial class Form1 : Form
    {
        public bool blDataSaved;
        public bool blQuitting;
        public bool blNotSavedQuit;
        public List<CharBaseClass> CBC;

        public void CheckStatus()
        {
            lblStatus.Text = "Characters: " + CBC[0].Characters.Count;
            lblStatus.Text += "\nLocations: " + CBC[0].Locations.Count;
            lblStatus.Text += "\nEvents: " + CBC[0].Events.Count;

            int PC = 0;
            int PL = 0;
            int PE = 0;
            foreach(CharacterClass C in CBC[0].Characters)
            {
                if (C.SavePicture != "")
                    PC++;
            }
            foreach (LocationClass L in CBC[0].Locations)
            {
                if (L.SavePicture != "")
                    PL++;
            }
            foreach (EventClass E in CBC[0].Events)
            {
                if (E.SavePicture != "")
                    PE++;
            }
            lblStatus.Text += "\n\nCharacters with a picture: " + PC.ToString();
            lblStatus.Text += "\nLocations with a picture: " + PL.ToString();
            lblStatus.Text += "\nEvents with a picture: " + PE.ToString();


            if (blDataSaved)
                lblStatus.Text += "\n\nEverything is saved to file.";
            else
                lblStatus.Text += "\n\nModifications haven't been saved.";
        }

        public Form1()
        {
            InitializeComponent();
        }

        public void DeleteCharacter(CharacterClass chrDel, frmListCharacters FLC)
        {
            bool Found = false;
            if (chrDel != null)
            {
                foreach (CharacterClass CC in CBC[0].Characters)
                {
                    if (!Found)
                    {
                        if (CC == chrDel)
                            Found = true;
                    }
                }
            }
            if (Found)
            {
                CBC[0].Characters.Remove(chrDel);
                MessageBox.Show("Character has been deleted.", "Success");
            }
            else
                MessageBox.Show("Couldn't delete character.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            FLC.PopulateCharacters(CBC[0].Characters);
            blDataSaved = false;
            CheckStatus();
        }

        public void DeleteEvent(EventClass evtDel, frmListEvents  FLE)
        {
            bool Found = false;
            if (evtDel != null)
            {
                foreach (EventClass EC in CBC[0].Events)
                {
                    if (!Found)
                    {
                        if (EC == evtDel)
                            Found = true;
                    }
                }
            }
            if (Found)
            {
                CBC[0].Events.Remove(evtDel);
                MessageBox.Show("Event has been deleted.", "Success");
            }
            else
                MessageBox.Show("Couldn't delete Event.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            FLE.PopulateEvents(CBC[0].Events);
            blDataSaved = false;
            CheckStatus();
        }


        public void DeleteLocation(LocationClass locDel, frmListLocations FLL)
        {
            bool Found = false;
            if (locDel != null)
            {
                foreach (LocationClass CC in CBC[0].Locations)
                {
                    if (!Found)
                    {
                        if (CC == locDel)
                            Found = true;
                    }
                }
            }
            if (Found)
            {
                CBC[0].Locations.Remove(locDel);
                MessageBox.Show("Location has been deleted.", "Success");
            }
            else
                MessageBox.Show("Couldn't delete location.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            FLL.PopulateLocations(CBC[0].Locations);
            blDataSaved = false;
            CheckStatus();
        }

        public void EditEvent(EventClass evtOld, EventClass evtUpdate, Image Picture, frmListEvents FLE)
        {
            bool Found = false;
            if (evtOld != null)
            {
                foreach (EventClass EE in CBC[0].Events)
                {
                    if (!Found)
                    {
                        if (EE.Name == evtOld.Name)
                        {
                            EE.Name = evtUpdate.Name;
                            EE.Description = evtUpdate.Description;
                            EE.SavePicture = ImageToString(Picture);
                            EE.Date = evtUpdate.Date;
                            EE.Location = evtUpdate.Location;
                            Found = true;
                            blDataSaved = false;
                        }
                    }
                }
            }
            if (Found)
                MessageBox.Show("Event edit successful!", "Editing...");
            else
                MessageBox.Show("Failed to edit event!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        public void EditCharacter(CharacterClass chrOld, CharacterClass chrUpdate, Image Picture, frmListCharacters FLC)
        {
            bool Found = false;
            if (chrOld != null)
            {
                foreach (CharacterClass CC in CBC[0].Characters)
                {
                    if (!Found)
                    {
                        if (CC.Name == chrOld.Name)
                        {
                            CC.Name = chrUpdate.Name;
                            CC.Age = chrUpdate.Age;
                            CC.Race = chrUpdate.Race;
                            CC.Gender = chrUpdate.Gender;
                            CC.Occupation = chrUpdate.Occupation;
                            CC.Description = chrUpdate.Description;
                            CC.Hometown = chrUpdate.Hometown;
                            CC.SavePicture = ImageToString(Picture);
                            Found = true;
                            blDataSaved = false;
                        }
                    }
                }
            }
            if (Found)
                MessageBox.Show("Character edit successful!", "Editing...");
            else
                MessageBox.Show("Failed to edit character!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        public void EditLocation(LocationClass chrOld, LocationClass chrUpdate, Image Picture, frmListLocations FLL)
        {
            bool Found = false;
            if (chrOld != null)
            {
                foreach (LocationClass CC in CBC[0].Locations)
                {
                    if (!Found)
                    {
                        if (CC.Name == chrOld.Name)
                        {
                            CC.Name = chrUpdate.Name;
                            CC.Type = chrUpdate.Type;
                            CC.Address = chrUpdate.Address;
                            CC.Population = chrUpdate.Population;
                            CC.Description = chrUpdate.Description;
                            CC.SavePicture = ImageToString(Picture);
                            Found = true;
                            blDataSaved = false;
                        }
                    }
                }
            }
            if (Found)
                MessageBox.Show("Location edit successful!", "Editing...");
            else
                MessageBox.Show("Failed to edit location!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }


        public void AddNewCharacter(CharacterClass chrNew, Image Picture)
        {
            chrNew.SavePicture = ImageToString(Picture);
            CBC[0].Characters.Add(chrNew);
            blDataSaved = false;
            CheckStatus();
        }

        public void AddNewEvent(EventClass evtNew, Image Picture)
        {
            evtNew.SavePicture = ImageToString(Picture);
            CBC[0].Events.Add(evtNew);
            blDataSaved = false;
            CheckStatus();
        }

        public string ImageToString(Image I)
        {
            string RetString = "";
            if (I != null)
            {
                MemoryStream msPicture = new MemoryStream();
                I.Save(msPicture, System.Drawing.Imaging.ImageFormat.Jpeg);
                string tmpString = "";
                //tmpString = BitConverter.ToString(msPicture.ToArray(), 0).ToString();
                tmpString = Convert.ToBase64String(msPicture.ToArray());
                RetString = tmpString.Replace("-", "");
            }
            return RetString;
        }

        public void AddNewLocation(LocationClass locNew, Image Picture)
        {
            locNew.SavePicture = ImageToString(Picture);
            CBC[0].Locations.Add(locNew);
            blDataSaved = false;
            CheckStatus();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //lstCharacters = new List<CharacterClass>();
            //lstLocations = new List<LocationClass>();
            CBC = new List<CharBaseClass>();
            CBC.Add(new CharBaseClass());
            CBC[0].Characters = new List<CharacterClass>();
            CBC[0].Locations = new List<LocationClass>();
            CBC[0].Events= new List<EventClass>();
            blDataSaved = false;
            blQuitting = false;
            blNotSavedQuit = true;
            CheckStatus();
        }

        private void listToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            frmAddCharacter F = new frmAddCharacter();
            F.Show();
            F.MainForm = this;
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            frmAddLocation F = new frmAddLocation();
            F.Show();
            F.MainForm = this;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog();
        }

        public void SaveFileDialog()
        {
            SFD.Title = "Save CharBase file to:";
            SFD.Filter = "CharBase File (*.charbase)|*.charbase";
            if (SFD.ShowDialog() == DialogResult.OK)
            {
                if (SaveFile(SFD.FileName))
                {
                    MessageBox.Show("CharBase file saved.", "Success");
                    blDataSaved = true;
                    blNotSavedQuit = false;
                }
            }
            CheckStatus();
        }

        public void LoadFileDialog()
        {
            OFD.Title = "Open CharBase file";
            SFD.Filter = "CharBase File (*.charbase)|*.charbase";
            OFD.Multiselect = false;
            if (OFD.ShowDialog() == DialogResult.OK)
            {
                if (LoadFile(OFD.FileName))
                {
                    MessageBox.Show("CharBase file loaded.", "Success");
                    blDataSaved = false;
                    blNotSavedQuit = false;
                }
            }
            CheckStatus();
        }

        public bool LoadFile(string FilePath)
        {
            bool ret = false;
            try
            {
                string json = File.ReadAllText(FilePath);
                CBC.Clear();
                CBC = JsonConvert.DeserializeObject<List<CharBaseClass>>(json);
                if (CBC[0].Events == null)
                    CBC[0].Events = new List<EventClass>();
                if (CBC[0].Characters == null)
                    CBC[0].Characters = new List<CharacterClass>();
                if (CBC[0].Locations == null)
                    CBC[0].Locations = new List<LocationClass>();

                ret = true;
            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            CheckStatus();

            return ret;
        }

        public bool SaveFile(string FilePath)
        {
            bool ret = false;
            try
            {
                CharBaseClass tmpCBC = new CharBaseClass();
                tmpCBC.Characters = CBC[0].Characters;
                tmpCBC.Locations = CBC[0].Locations;
                tmpCBC.Events = CBC[0].Events;
                CBC.Clear();
                CBC.Add(tmpCBC);

                string json = JsonConvert.SerializeObject(CBC.ToArray());

                //write string to file
                System.IO.File.WriteAllText(FilePath, json);
                ret = true;
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            blDataSaved = true;
            CheckStatus();

            return ret;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!blDataSaved)
            {
                if (!blQuitting)
                {
                    DialogResult DR = MessageBox.Show("You haven't saved your CharBase changes yet.\nDo you want to save the before exiting?", "Exiting...", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    if (DR == DialogResult.Yes)
                    {
                        SaveFileDialog();
                        if (blDataSaved)
                            blQuitting = true;
                    }
                    else if (DR == DialogResult.No)
                    {
                        if (!blQuitting)
                        {
                            blQuitting = true;
                            Application.Exit();
                        }
                    }

                }
                else
                    Application.Exit();
            }
            else
                Application.Exit();
        }
       

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!blDataSaved)
            {
                if (!blQuitting)
                {
                    DialogResult DR = MessageBox.Show("You haven't saved your CharBase changes yet.\nDo you want to save the before exiting?", "Exiting...", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    if (DR == DialogResult.Yes)
                    {
                        SaveFileDialog();
                        if (blNotSavedQuit)
                            e.Cancel = true;
                        if (blDataSaved)
                            blQuitting = true;
                    }
                    else if (DR == DialogResult.No)
                    {
                        if (!blQuitting)
                            blQuitting = true;
                    }

                    else if (DR == DialogResult.Cancel)
                        e.Cancel = true;
                }
                else
                    if (blDataSaved)
                        Application.Exit();
            }
            else
                if (blDataSaved)
                    Application.Exit();
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadFileDialog();
        }

        private void listToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (CBC[0].Characters.Count > 0)
            {
                this.Enabled = false;
                frmListCharacters F = new frmListCharacters();
                F.Show();
                F.MainForm = this;

                F.PopulateCharacters(CBC[0].Characters);
            }
            else
            {
                MessageBox.Show("There are no characters. Please add characters so you can list them.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void listToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (CBC[0].Locations.Count > 0)
            {
                this.Enabled = false;
                frmListLocations F = new frmListLocations();
                F.Show();
                F.MainForm = this;

                F.PopulateLocations(CBC[0].Locations);
            }
            else
            {
                MessageBox.Show("There are no locations. Please add locations so you can list them.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About A = new About();
            A.Show();
        }

        private void addToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            frmAddEvent F = new frmAddEvent();
            F.Show();
            F.MainForm = this;
        }

        private void listToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (CBC[0].Events.Count > 0)
            {
                this.Enabled = false;
                frmListEvents F = new frmListEvents();
                F.Show();
                F.MainForm = this;

                F.PopulateEvents(CBC[0].Events);
            }
            else
            {
                MessageBox.Show("There are no events. Please add events so you can list them.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    public class CharBaseClass
    {
        public List<CharacterClass> Characters { get; set; }
        public List<LocationClass> Locations { get; set; }
        public List<EventClass> Events { get; set; }
    }

    public class CharacterClass
    {
        public string Name { get; set; }
        public string Age { get; set; }
        public string Gender { get; set; }
        public string Hometown { get; set; }
        public string Occupation { get; set; }
        public string Race { get; set; }
        public string Description { get; set; }
        public string SavePicture { get; set; }
    }
    
    public class LocationClass
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Population { get; set; }
        public string Type { get; set; }
        public string Address { get; set; }
        public string SavePicture { get; set; }
    }

    public class EventClass
    {
        public string Name { get; set; }
        public string Date { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string SavePicture { get; set; }
    }
}
