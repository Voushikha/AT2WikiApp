using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AT2WikiApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
       
       List<Information> Wiki = new List<Information>();

        private void Form1_Load(object sender, EventArgs e)
        {
             
        }
       
        private void SearchButton_Click(object sender, EventArgs e)
        {

        }
        private bool ValidName(string checkCategory)
        {
            if (Wiki.Exists(dup => dup.GetCategory() == checkCategory))
                return false;
            else
                return true;
        }
        #region 
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
               
            }
            //private void SetRadioButton(int item)
            //{
            //    if (Wiki[item].GetBikeType() == "Linear")
            //        LinearBtn.Checked = true;
            //    if (Wiki[item].GetBikeType() == "Non-Linear")
            //        NonLinearBtn.Checked = true;
            }

        private string GetRadioButton()
        {
            string radioText = "";
            if (LinearBtn.Checked)
                radioText = LinearBtn.Text;
            else if (NonLinearBtn.Checked)
                radioText = NonLinearBtn.Text;

            return radioText;
        }
        #endregion
    }
}
