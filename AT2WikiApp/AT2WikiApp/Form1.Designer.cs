namespace AT2WikiApp
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.CategoryBox = new System.Windows.Forms.ComboBox();
            this.LinearBtn = new System.Windows.Forms.RadioButton();
            this.NonLinearBtn = new System.Windows.Forms.RadioButton();
            this.labelCategory = new System.Windows.Forms.Label();
            this.AddButton = new System.Windows.Forms.Button();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.NameLabel = new System.Windows.Forms.Label();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.SearchButton = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.Name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Category = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.textBoxDefn = new System.Windows.Forms.TextBox();
            this.labelDefn = new System.Windows.Forms.Label();
            this.SaveButton = new System.Windows.Forms.Button();
            this.EditButton = new System.Windows.Forms.Button();
            this.OpenButton = new System.Windows.Forms.Button();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.labelStructure = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // CategoryBox
            // 
            this.CategoryBox.ForeColor = System.Drawing.Color.DarkOrange;
            this.CategoryBox.FormattingEnabled = true;
            this.CategoryBox.Items.AddRange(new object[] {
            "",
            "Array",
            "List",
            "Tree",
            "Graphs",
            "Abstract",
            "Hash"});
            this.CategoryBox.Location = new System.Drawing.Point(29, 145);
            this.CategoryBox.Name = "CategoryBox";
            this.CategoryBox.Size = new System.Drawing.Size(130, 21);
            this.CategoryBox.TabIndex = 0;
            this.CategoryBox.Text = "Category";
            // 
            // LinearBtn
            // 
            this.LinearBtn.AutoSize = true;
            this.LinearBtn.Location = new System.Drawing.Point(29, 77);
            this.LinearBtn.Name = "LinearBtn";
            this.LinearBtn.Size = new System.Drawing.Size(54, 17);
            this.LinearBtn.TabIndex = 1;
            this.LinearBtn.TabStop = true;
            this.LinearBtn.Text = "Linear";
            this.LinearBtn.UseVisualStyleBackColor = true;
            // 
            // NonLinearBtn
            // 
            this.NonLinearBtn.AutoSize = true;
            this.NonLinearBtn.Location = new System.Drawing.Point(29, 100);
            this.NonLinearBtn.Name = "NonLinearBtn";
            this.NonLinearBtn.Size = new System.Drawing.Size(77, 17);
            this.NonLinearBtn.TabIndex = 2;
            this.NonLinearBtn.TabStop = true;
            this.NonLinearBtn.Text = "Non-Linear";
            this.NonLinearBtn.UseVisualStyleBackColor = true;
            // 
            // labelCategory
            // 
            this.labelCategory.AutoSize = true;
            this.labelCategory.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.labelCategory.Location = new System.Drawing.Point(26, 125);
            this.labelCategory.Name = "labelCategory";
            this.labelCategory.Size = new System.Drawing.Size(49, 13);
            this.labelCategory.TabIndex = 3;
            this.labelCategory.Text = "Category";
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(187, 39);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(66, 23);
            this.AddButton.TabIndex = 4;
            this.AddButton.Text = "ADD";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(29, 34);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(137, 20);
            this.textBoxName.TabIndex = 5;
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Location = new System.Drawing.Point(30, 17);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(35, 13);
            this.NameLabel.TabIndex = 6;
            this.NameLabel.Text = "Name";
            // 
            // DeleteButton
            // 
            this.DeleteButton.Location = new System.Drawing.Point(186, 68);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(66, 23);
            this.DeleteButton.TabIndex = 7;
            this.DeleteButton.Text = "DELETE";
            this.DeleteButton.UseVisualStyleBackColor = true;
            // 
            // SearchButton
            // 
            this.SearchButton.Location = new System.Drawing.Point(478, 34);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(66, 23);
            this.SearchButton.TabIndex = 8;
            this.SearchButton.Text = "Search";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Name,
            this.Category});
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(282, 68);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(262, 326);
            this.listView1.TabIndex = 9;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // Name
            // 
            this.Name.Text = "Name";
            this.Name.Width = 123;
            // 
            // Category
            // 
            this.Category.Text = "Category";
            this.Category.Width = 135;
            // 
            // textBoxDefn
            // 
            this.textBoxDefn.Location = new System.Drawing.Point(26, 234);
            this.textBoxDefn.Multiline = true;
            this.textBoxDefn.Name = "textBoxDefn";
            this.textBoxDefn.Size = new System.Drawing.Size(227, 204);
            this.textBoxDefn.TabIndex = 10;
            // 
            // labelDefn
            // 
            this.labelDefn.AutoSize = true;
            this.labelDefn.Location = new System.Drawing.Point(26, 218);
            this.labelDefn.Name = "labelDefn";
            this.labelDefn.Size = new System.Drawing.Size(51, 13);
            this.labelDefn.TabIndex = 11;
            this.labelDefn.Text = "Definition";
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(452, 400);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(92, 38);
            this.SaveButton.TabIndex = 12;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            // 
            // EditButton
            // 
            this.EditButton.Location = new System.Drawing.Point(187, 95);
            this.EditButton.Name = "EditButton";
            this.EditButton.Size = new System.Drawing.Size(65, 27);
            this.EditButton.TabIndex = 13;
            this.EditButton.Text = "EDIT";
            this.EditButton.UseVisualStyleBackColor = true;
            // 
            // OpenButton
            // 
            this.OpenButton.Location = new System.Drawing.Point(282, 401);
            this.OpenButton.Name = "OpenButton";
            this.OpenButton.Size = new System.Drawing.Size(105, 37);
            this.OpenButton.TabIndex = 14;
            this.OpenButton.Text = "Open";
            this.OpenButton.UseVisualStyleBackColor = true;
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Location = new System.Drawing.Point(282, 36);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(165, 20);
            this.textBoxSearch.TabIndex = 15;
            // 
            // labelStructure
            // 
            this.labelStructure.AutoSize = true;
            this.labelStructure.Location = new System.Drawing.Point(30, 57);
            this.labelStructure.Name = "labelStructure";
            this.labelStructure.Size = new System.Drawing.Size(0, 13);
            this.labelStructure.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Structure:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 474);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelStructure);
            this.Controls.Add(this.textBoxSearch);
            this.Controls.Add(this.OpenButton);
            this.Controls.Add(this.EditButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.labelDefn);
            this.Controls.Add(this.textBoxDefn);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.SearchButton);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.NameLabel);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.labelCategory);
            this.Controls.Add(this.NonLinearBtn);
            this.Controls.Add(this.LinearBtn);
            this.Controls.Add(this.CategoryBox);
            this.Name = "Form1";
            this.Text = "WikiApp";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox CategoryBox;
        private System.Windows.Forms.RadioButton LinearBtn;
        private System.Windows.Forms.RadioButton NonLinearBtn;
        private System.Windows.Forms.Label labelCategory;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader Name;
        private System.Windows.Forms.ColumnHeader Category;
        private System.Windows.Forms.TextBox textBoxDefn;
        private System.Windows.Forms.Label labelDefn;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button EditButton;
        private System.Windows.Forms.Button OpenButton;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.Label labelStructure;
        private System.Windows.Forms.Label label1;
    }
}

