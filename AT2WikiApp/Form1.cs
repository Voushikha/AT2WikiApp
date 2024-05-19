using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
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



namespace AT2WikiApp
{
    public partial class Form1 : Form

    {

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // Sort and display the ListView when the form is loaded
            DisplaySort();
        }


        List<Information> Wiki = new List<Information>();

        public object ListView1 { get; private set; }

        class Program
        {
            static void Main()
            {
                Trace.Listeners.Clear();
                Trace.Listeners.Add(new ConsoleTraceListener());
            }
        }





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
                // Optionally, you can clear the textbox or take other actions
            }

        }
       


        private void EditButton_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0) // Simplified condition
            {
                ListViewItem selectedItem = listView1.SelectedItems[0];
                int selectedIndex = selectedItem.Index;

                if (selectedIndex >= 0 && selectedIndex < Wiki.Count)
                {
                    Information selectedInfo = Wiki[selectedIndex];
                    textBoxName.Text = selectedInfo.GetName();
                    CategoryBox.Text = selectedInfo.GetCategory();
                    SetRadioButton(selectedIndex);
                    textBoxDefn.Text = selectedInfo.GetDefinition();

                    UpdateListViewItem(selectedItem); // Assuming you refactor this part for clarity

                    selectedInfo.SetName(textBoxName.Text.ToUpper());
                    selectedInfo.SetCategory(CategoryBox.Text);
                    selectedInfo.SetStructure(GetRadioButton());
                    selectedInfo.SetDefinition(textBoxDefn.Text);

                    DisplaySort();
                    Clear();
                    MessageBox.Show("Item updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Please select a valid item to edit.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select an item to edit.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }





        private void DeleteButton_Click_1(object sender, EventArgs e)
        {
            // Check if an item is selected in the ListView
            if (listView1.SelectedItems.Count > -1)
            {
                // Get the index of the selected item
                int selectedIndex = listView1.SelectedItems[0].Index;

                // Display a confirmation dialog box
                DialogResult result = MessageBox.Show("Are you sure you want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                // If the user confirms deletion
                if (result == DialogResult.Yes)
                {
                    // Remove the selected item from the ListView
                    listView1.Items.RemoveAt(selectedIndex);

                    // Remove the corresponding item from wiki
                    Wiki.RemoveAt(selectedIndex);

                    // Sort and display the ListView after deletion
                    DisplaySort();
                }
            }
            else
            {
                // If no item is selected, display a message to the user
                MessageBox.Show("Please select a record to delete.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }









        #endregion
        #region RadioButton
        private string GetRadioButton()
        {
            // Check which radio button is checked and return its value
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

        private void SetRadioButton(int item)
        {
            // Check if item index is within the range of the Wiki collection
            if (item >= 0 && item < Wiki.Count)
            {
                // Get the structure string from the Information object at the specified index
                string structure = Wiki[item].GetStructure();

                // Set the radio button based on the retrieved structure
                if (structure == "Linear")
                {
                    LinearBtn.Checked = true;
                }
                else if (structure == "Non-Linear")
                {
                    NonLinearBtn.Checked = true;
                }
            }
            // Handle case when item index is out of range (optional)
            else
            {
                // Optionally, you can clear the radio button selection
                LinearBtn.Checked = false;
                NonLinearBtn.Checked = false;
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
            //{
            //    // Clear the TextBoxes
            //    textBoxName.Clear();
            //    textBoxDefn.Clear();
            //    // Assuming you have more TextBoxes, clear them as well

            //    // Clear the ComboBox
            //    CategoryBox.SelectedIndex = -1; // Set to -1 to clear the selection

            //    // Clear the RadioButton
            //    // Assuming you have a group of RadioButtons, you can loop through them and uncheck them
            //    foreach (Control c in this.Controls)
            //    {
            //        if (c is RadioButton)
            //        {
            //            (c as RadioButton).Checked = false;
            //        }
            //    }
            //}

        }
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
            string searchName = textBoxSearch.Text.ToUpper(); // Get search input and convert to uppercase

            // Perform binary search
            int index = Wiki.FindIndex(info => info.GetName().ToUpper() == searchName);

            if (index != -1)
            {
                // Item found
                ListViewItem item = listView1.Items[index];

                // Highlight the item
                item.Selected = true;
                item.Focused = true;
                
                listView1.EnsureVisible(index);

                // Populate input controls with associated details
                textBoxName.Text = item.SubItems[0].Text;
                CategoryBox.Text = item.SubItems.Count > 1 ? item.SubItems[1].Text : ""; 
                                                                                         
                textBoxDefn.Text = item.SubItems.Count > 3 ? item.SubItems[3].Text : ""; 

                MessageBox.Show("Item found and highlighted.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Item not found
                MessageBox.Show("Item not found.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            // Clear search input
            textBoxSearch.Clear();
        }


        //{
        //    Information searchInfo = new Information();
        //    // set bike model from textbox
        //    searchInfo.SetName(textBoxSearch.Text);
        //    // if found return 0
        //    int found = Wiki.BinarySearch(searchInfo);
        //    if (found >= 0)
        //    {
        //        listView1.SelectedItems.Clear();
        //        listView1.Items[found].Selected = true;
        //        listView1.Focus();
        //        // Populate the textboxes with the selected information
        //        textBoxName.Text = Wiki[found].GetName();
        //        CategoryBox.Text = Wiki[found].GetCategory();
        //        SetRadioButton(found);
        //        textBoxDefn.Text = Wiki[found].GetDefinition();
        //    }
        //    else
        //    {
        //        statusStrip.Text = "cannot find item";
        //    }
        //}


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
                    // You need to implement GetRadioButton method to get the selected radio button value
                    // StructureBox.Text = selectedInformation.GetStructure(); 
                    textBoxDefn.Text = selectedInformation.GetDefinition();
                }
            }
        }

    }
}
    
