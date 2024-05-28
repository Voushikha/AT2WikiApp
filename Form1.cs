using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace AT2
{
    public partial class Form1 : Form
    {
        private List<Information> Wiki = new List<Information>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadCategories();
            RefreshListView();
        }

        private void LoadCategories()
        {
            try
            {
                string[] categories = File.ReadAllLines("categories.txt");
                CategoryBox.Items.AddRange(categories);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading categories: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidName(string name)
        {
            return !Wiki.Exists(info => info.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        private string GetSelectedStructure()
        {
            if (LinearBtn.Checked)
                return "Linear";
            else if (NonLinearBtn.Checked)
                return "Non-Linear";
            else
                return string.Empty;
        }

        private void SetSelectedStructure(string structure)
        {
            if (structure.Equals("Linear", StringComparison.OrdinalIgnoreCase))
                LinearBtn.Checked = true;
            else if (structure.Equals("Non-Linear", StringComparison.OrdinalIgnoreCase))
                NonLinearBtn.Checked = true;
        }
        #region ADD DELETE EDIT
        private void AddButton_Click(object sender, EventArgs e)
        {
            bool valid = ValidName(textBoxName.Text);
            if (valid)
            {
                Information newInformation = new Information
                {
                    Name = textBoxName.Text,
                    Category = CategoryBox.Text,
                    Structure = GetSelectedStructure(),
                    Definition = textBoxDefn.Text
                };
                Wiki.Add(newInformation);

                RefreshListView();
                textBoxName.Focus();
                
            }
            else
            {
                MessageBox.Show("Name already exists. Please enter a different name.");
            }
        }

        private void RefreshListView()
        {
            listView1.Items.Clear();
            foreach (var info in Wiki)
            {
                ListViewItem item = new ListViewItem(info.Name);
                item.SubItems.Add(info.Category);
                listView1.Items.Add(item);
            }
        }

        private void DeleteButton_Click_1(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                int selectedIndex = listView1.SelectedItems[0].Index;

                DialogResult result = MessageBox.Show(
                    "Are you sure you want to delete this record?",
                    "Confirmation",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.Yes)
                {
                    Wiki.RemoveAt(selectedIndex);
                    RefreshListView();
                }
            }
            else
            {
                MessageBox.Show("Please select a record to delete.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            Trace.WriteLine("Edit button clicked.");

            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listView1.SelectedItems[0];
                int selectedIndex = selectedItem.Index;

                Trace.WriteLine("Selected index: " + selectedIndex);

                if (selectedIndex >= 0 && selectedIndex < Wiki.Count)
                {
                    Trace.WriteLine("Valid index. Updating item.");

                    try
                    {
                        Information updatedInfo = new Information
                        {
                            Name = textBoxName.Text,
                            Category = CategoryBox.Text,
                            Structure = GetSelectedStructure(),
                            Definition = textBoxDefn.Text
                        };

                        Wiki[selectedIndex] = updatedInfo;

                        Trace.WriteLine("Item updated successfully.");

                        RefreshListView();
                    }
                    catch (Exception ex)
                    {
                        Trace.WriteLine("An error occurred while updating the item: " + ex.Message);
                        MessageBox.Show("An error occurred while updating the item: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a record to edit.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion
        #region Search DoubleClickClear

        private void SearchButton_Click(object sender, EventArgs e)
        {
            string searchName = textBoxSearch.Text.Trim();

            var foundItem = Wiki.FirstOrDefault(info => info.Name.Equals(searchName, StringComparison.OrdinalIgnoreCase));
            if (foundItem != null)
            {
                textBoxName.Text = foundItem.Name;
                CategoryBox.SelectedItem = foundItem.Category;
                SetSelectedStructure(foundItem.Structure);
                textBoxDefn.Text = foundItem.Definition;

                var listViewItem = listView1.Items.Cast<ListViewItem>().FirstOrDefault(item => item.Text.Equals(foundItem.Name, StringComparison.OrdinalIgnoreCase));
                if (listViewItem != null)
                {
                    listViewItem.Selected = true;
                    listViewItem.Focused = true;
                }
            }
            else
            {
                MessageBox.Show("Data Structure not found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            textBoxSearch.Clear();
            textBoxName.Focus();
        }

        private void textBoxName_DoubleClick(object sender, EventArgs e)
        {
            textBoxName.Clear();
            CategoryBox.SelectedIndex = -1;
            LinearBtn.Checked = false;
            NonLinearBtn.Checked = false;
            textBoxDefn.Clear();
        }
        #endregion
        #region OPEN SAVE

        private void OpenButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Binary files (*.bin)|*.bin|All files (*.*)|*.*";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (FileStream fs = new FileStream(openFileDialog.FileName, FileMode.Open))
                    using (BinaryReader br = new BinaryReader(fs))
                    {
                        Wiki.Clear();
                        while (fs.Position < fs.Length)
                        {
                            string name = br.ReadString();
                            string category = br.ReadString();
                            string structure = br.ReadString();
                            string definition = br.ReadString();
                            Wiki.Add(new Information { Name = name, Category = category, Structure = structure, Definition = definition });
                        }
                        RefreshListView();
                    }
                }
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Binary files (*.bin)|*.bin|All files (*.*)|*.*";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (FileStream fs = new FileStream(saveFileDialog.FileName, FileMode.Create))
                    using (BinaryWriter bw = new BinaryWriter(fs))
                    {
                        foreach (var info in Wiki)
                        {
                            bw.Write(info.Name);
                            bw.Write(info.Category);
                            bw.Write(info.Structure);
                            bw.Write(info.Definition);
                        }
                    }
                }
            }
        }
       
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveButton_Click(sender, e);
        }
        #endregion
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                int selectedIndex = listView1.SelectedItems[0].Index;
                var info = Wiki[selectedIndex];

                textBoxName.Text = info.Name;
                CategoryBox.SelectedItem = info.Category;
                SetSelectedStructure(info.Structure);
                textBoxDefn.Text = info.Definition;
            }
        }
    }
}
