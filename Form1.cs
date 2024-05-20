using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using RadioButton = System.Windows.Forms.RadioButton;



namespace AT2WikiApp
{
    public partial class Form1 : Form

    {

        public Form1()
        {
            InitializeComponent();
            
        }

        private void textBoxName_DoubleClick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
      
        private void Form1_Load(object sender, EventArgs e)
        {
            // Sort and display the ListView when the form is loaded
            DisplaySort();
        }


        List<Information> Wiki = new List<Information>();
        private object nameTextBox;

        public object ListView1 { get; private set; }

      




                private bool ValidName(string checkCategory)
        {
            if (Wiki.Exists(dup => dup.GetCategory() == checkCategory))
                return false;
            else
                return true;
        }
        #region ADD EDIT DELETE

        private void AddButton_Click(object sender, EventArgs e)

        {
            // Check name in TextBox
            bool valid = ValidName(textBoxName.Text);
            // If name is NOT a duplicate
            if (valid)
            {
                // Add new record
                Information newInformation = new Information();
                newInformation.SetName(textBoxName.Text);
                newInformation.SetCategory(CategoryBox.Text);
                newInformation.SetStructure(GetRadioButton());
                newInformation.SetDefinition(textBoxDefn.Text);
                Wiki.Add(newInformation);

                //clear input values
                Clear();
                //set Focus
                textBoxName.Focus();
                //Display
                DisplaySort();
            }
            else
            {
                MessageBox.Show("Name already exists. Please enter a different name.");
            }
        }

        private void EditButton_Click(object sender, EventArgs e)


        //{
        //    int selectedIndex = -1;
        //    if (listView1.SelectedItems.Count > 0)
        //    {
        //        selectedIndex = listView1.SelectedIndices[0]; // Get the index of the selected item
        //    }

        //    if (selectedIndex >= 0 && selectedIndex < Wiki.Count) // Ensure the index is valid
        //    {
        //        // Create the updated item
        //        Information updatedInfo = new Information();
        //        updatedInfo.SetName(textBoxName.Text);
        //        updatedInfo.SetCategory(CategoryBox.Text);
        //        updatedInfo.SetStructure(GetRadioButton());
        //        updatedInfo.SetDefinition(textBoxDefn.Text);

        //        // Remove the old item from the list
        //        Wiki.RemoveAt(selectedIndex);

        //        // Add the updated item at the same index
        //        Wiki.Insert(selectedIndex, updatedInfo);

        //        // Refresh the ListView to reflect the changes
        //        DisplaySort();
        //        Clear();


        //    }
        //    else
        //    {
        //        MessageBox.Show("Please select an item to edit.");
        //    }
        //}

        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listView1.SelectedItems[0];
                int selectedIndex = selectedItem.Index;

                if (selectedIndex >= 0 && selectedIndex < Wiki.Count)
                {
                    try
                    {
                        // Create the updated item
                        Information updatedInfo = new Information();
                        updatedInfo.SetName(textBoxName.Text);
                        updatedInfo.SetCategory(CategoryBox.Text);
                        updatedInfo.SetStructure(GetRadioButton());
                        updatedInfo.SetDefinition(textBoxDefn.Text);

                        // Update the corresponding item in the Wiki list
                        Wiki[selectedIndex] = updatedInfo;

                        // Refresh the ListView to reflect the changes
                        Clear();
                        DisplaySort();
                       
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred while updating the item: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Please select an item to edit.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void DeleteButton_Click_1(object sender, EventArgs e)



        {
            if (listView1.SelectedItems.Count > 0) // Corrected condition
            {
                int selectedIndex = listView1.SelectedItems[0].Index;

                DialogResult result = MessageBox.Show("Are you sure you want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    listView1.Items.RemoveAt(selectedIndex);
                    Wiki.RemoveAt(selectedIndex);
                    DisplaySort();
                }
            }
            else
            {
                MessageBox.Show("Please select a record to delete.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }





        #endregion
        #region RadioButton
        private string GetRadioButton()
       
        {
            if (LinearBtn.Checked)
            {
                return "Linear";
            }
            else if (NonLinearBtn.Checked)
            {
                return "Non-Linear";
            }
            else
            {
                return ""; // No radio button is checked
            }
        }



        // Highlight radio button based on index
        private void HighlightRadioButton(int index)
        {
            // Check the radio button at the specified index
            if (index == 0)
            {
                LinearBtn.Checked = true;
            }
            else if (index == 1)
            {
                NonLinearBtn.Checked = true;
            }
            // If index is out of range, do nothing
        }



        #endregion
        #region Clear DoubleClick-Clear
        private void Clear()
        
        {
            textBoxName.Clear();
            CategoryBox.SelectedIndex = 0;
            LinearBtn.Checked = false;
            NonLinearBtn.Checked = false;
            textBoxDefn.Clear();
        }

        //Double clICK cLEAR
        private void textBoxName_DoubleClick(object sender, MouseEventArgs e)
        {
            Clear();
        }
            //    // Clear the TextBboxes
            //    textBoxName.Clear();
            //    textBoxDefn.Clear();



            //    // Clear the ComboBox
            //    CategoryBox.Items.Clear();

            //// Clear the Radio button
            //// Assuming LinearBtn and NonLinearBtn are your RadioButton controls
            //LinearBtn.Checked = false;
            //NonLinearBtn.Checked = false;




            #endregion
            #region Display Sort
            private void DisplaySort()
   
    {
        // Sort the Wiki information by Name in alphabetical order
        var sortedWiki = Wiki.OrderBy(info => info.GetName()).ToList();

        // Clear the ListView before repopulating it
        listView1.Items.Clear();

        // Add items to the ListView
        foreach (var item in sortedWiki)
        {
            ListViewItem listViewItem = new ListViewItem(item.GetName());
            listViewItem.SubItems.Add(item.GetStructure());
            listViewItem.SubItems.Add(item.GetCategory());
            listView1.Items.Add(listViewItem);
        } 
    }
        #endregion
        #region Search



      
    private void SearchButton_Click(object sender, EventArgs e)
    {
        if (textBoxSearch.Text.Length > 0)
        {
            string searchName = textBoxSearch.Text.Trim();

            Information searchInfo = new Information();
            searchInfo.SetName(searchName);

            DisplaySort();

            var sortedWiki = Wiki.OrderBy(info => info.GetName()).ToList();

            int found = sortedWiki.BinarySearch(searchInfo, new InformationNameComparer());

            if (found >= 0)
            {
                listView1.SelectedItems.Clear();
                listView1.Items[found].Selected = true;
                listView1.Items[found].Focused = true;
                listView1.EnsureVisible(found);
                listView1.Focus();

                textBoxName.Text = sortedWiki[found].GetName();
                CategoryBox.Text = sortedWiki[found].GetCategory();
                SetRadioButton(found);
                textBoxDefn.Text = sortedWiki[found].GetDefinition();

                toolStripStatusLabel1.Text = "Search found...";
            }
            else
            {
                toolStripStatusLabel1.Text = "Cannot find item.";
            }

            textBoxSearch.Clear();
        }
    }
        private void SetRadioButton(int index)
        {
            if (index >= 0 && index < Wiki.Count)
            {
                string structure = Wiki[index].GetStructure();
                if (structure == "Linear")
                {
                    LinearBtn.Checked = true;
                }
                else if (structure == "Non-Linear")
                {
                    NonLinearBtn.Checked = true;
                }
            }
            else
            {
                LinearBtn.Checked = false;
                NonLinearBtn.Checked = false;
            }
        }

        public class InformationNameComparer : IComparer<Information>
        {
            public int Compare(Information x, Information y)
            {
                return string.Compare(x.GetName(), y.GetName(), StringComparison.OrdinalIgnoreCase);
            }
        }


        #endregion


        #region Open Save
        //Open button
        private void OpenButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Binary Files (*.dat)|*.dat";
            openFileDialog.Title = "Open Wiki Definitions";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (var stream = File.Open(openFileDialog.FileName, FileMode.Open))
                    {
                        using (var reader = new BinaryReader(stream, Encoding.UTF8, false))
                        {
                            Wiki.Clear();
                            while (stream.Position < stream.Length)
                            {
                                Information readInfo = new Information();
                                readInfo.SetName(reader.ReadString());
                                readInfo.SetCategory(reader.ReadString());
                                readInfo.SetStructure(reader.ReadString());
                                readInfo.SetDefinition(reader.ReadString());
                                Wiki.Add(readInfo);
                            }
                        }
                    }
                    Clear();
                    DisplaySort();
                }
                catch (IOException ex)
                {
                    MessageBox.Show("An error occurred while opening the file: " + ex.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An unexpected error occurred: " + ex.Message);
                }
            }
        }
        //Save Button
        private void SaveButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Binary Files (*.dat)|*.dat";
            saveFileDialog.Title = "Save Wiki Definitions";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (var stream = File.Open(saveFileDialog.FileName, FileMode.Create))
                    {
                        using (var writer = new BinaryWriter(stream, Encoding.UTF8, false))
                        {
                            foreach (var x in Wiki)
                            {
                                writer.Write(x.GetName());
                                writer.Write(x.GetCategory());
                                writer.Write(x.GetStructure());
                                writer.Write(x.GetDefinition());
                            }
                        }
                    }
                }
                catch (IOException ex)
                {
                    MessageBox.Show("An error occurred while saving the file: " + ex.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An unexpected error occurred: " + ex.Message);
                }
            }
        }




        #endregion

        // mouse click needs to be fixed

        //display textboxes
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                // Get the selected item
                ListViewItem selectedItem = listView1.SelectedItems[0];

                // Find the corresponding Information object in the Wiki collection
                string selectedName = selectedItem.SubItems[0].Text;
                Information selectedInformation = Wiki.FirstOrDefault(info => info.GetName() == selectedName);

                if (selectedInformation != null)
                {
                    // Display the information in appropriate textboxes and combo
                    textBoxName.Text = selectedInformation.GetName();
                    CategoryBox.Text = selectedInformation.GetCategory();
                    // Assuming GetRadioButtonValue() returns the selected radio button value
                    string radioButtonValue = GetRadioButtonValue(selectedInformation.GetStructure());
                    RadioButton rb = new RadioButton();
                    rb.Text = radioButtonValue;
                    StructureBox.Controls.Add(rb);
                    textBoxDefn.Text = selectedInformation.GetDefinition();
                }
            }
        }


        private string GetRadioButtonValue(string v)
        {
            throw new NotImplementedException();
        }
    }
}

