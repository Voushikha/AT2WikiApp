namespace AT2
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ComboBox CategoryBox;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxDefn;
        private System.Windows.Forms.RadioButton LinearBtn;
        private System.Windows.Forms.RadioButton NonLinearBtn;
        private System.Windows.Forms.GroupBox StructureBox;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader NameColumn;
        private System.Windows.Forms.ColumnHeader CategoryColumn;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Button EditButton;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.Button OpenButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;

        private void InitializeComponent()
        {
            this.CategoryBox = new System.Windows.Forms.ComboBox();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxDefn = new System.Windows.Forms.TextBox();
            this.LinearBtn = new System.Windows.Forms.RadioButton();
            this.NonLinearBtn = new System.Windows.Forms.RadioButton();
            this.StructureBox = new System.Windows.Forms.GroupBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.NameColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CategoryColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AddButton = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.EditButton = new System.Windows.Forms.Button();
            this.SearchButton = new System.Windows.Forms.Button();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.OpenButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.StructureBox.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // CategoryBox
            // 
            this.CategoryBox.FormattingEnabled = true;
            this.CategoryBox.Items.AddRange(new object[] {
            "",
            "Array",
            "List",
            "Tree",
            "Graphs",
            "Abstract",
            "Hash"});
            this.CategoryBox.Location = new System.Drawing.Point(34, 78);
            this.CategoryBox.Name = "CategoryBox";
            this.CategoryBox.Size = new System.Drawing.Size(130, 21);
            this.CategoryBox.TabIndex = 0;
            this.CategoryBox.Text = "Category";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(34, 41);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(130, 20);
            this.textBoxName.TabIndex = 1;
            this.textBoxName.DoubleClick += new System.EventHandler(this.textBoxName_DoubleClick);
            // 
            // textBoxDefn
            // 
            this.textBoxDefn.Location = new System.Drawing.Point(34, 194);
            this.textBoxDefn.Multiline = true;
            this.textBoxDefn.Name = "textBoxDefn";
            this.textBoxDefn.Size = new System.Drawing.Size(236, 215);
            this.textBoxDefn.TabIndex = 2;
            // 
            // LinearBtn
            // 
            this.LinearBtn.AutoSize = true;
            this.LinearBtn.Location = new System.Drawing.Point(6, 19);
            this.LinearBtn.Name = "LinearBtn";
            this.LinearBtn.Size = new System.Drawing.Size(54, 17);
            this.LinearBtn.TabIndex = 3;
            this.LinearBtn.TabStop = true;
            this.LinearBtn.Text = "Linear";
            this.LinearBtn.UseVisualStyleBackColor = true;
            // 
            // NonLinearBtn
            // 
            this.NonLinearBtn.AutoSize = true;
            this.NonLinearBtn.Location = new System.Drawing.Point(6, 42);
            this.NonLinearBtn.Name = "NonLinearBtn";
            this.NonLinearBtn.Size = new System.Drawing.Size(77, 17);
            this.NonLinearBtn.TabIndex = 4;
            this.NonLinearBtn.TabStop = true;
            this.NonLinearBtn.Text = "Non-Linear";
            this.NonLinearBtn.UseVisualStyleBackColor = true;
            // 
            // StructureBox
            // 
            this.StructureBox.Controls.Add(this.LinearBtn);
            this.StructureBox.Controls.Add(this.NonLinearBtn);
            this.StructureBox.Location = new System.Drawing.Point(34, 105);
            this.StructureBox.Name = "StructureBox";
            this.StructureBox.Size = new System.Drawing.Size(130, 70);
            this.StructureBox.TabIndex = 5;
            this.StructureBox.TabStop = false;
            this.StructureBox.Text = "Structure";
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.NameColumn,
            this.CategoryColumn});
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(290, 55);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(250, 325);
            this.listView1.TabIndex = 6;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // NameColumn
            // 
            this.NameColumn.Text = "Name";
            this.NameColumn.Width = 120;
            // 
            // CategoryColumn
            // 
            this.CategoryColumn.Text = "Category";
            this.CategoryColumn.Width = 120;
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(195, 47);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(75, 23);
            this.AddButton.TabIndex = 7;
            this.AddButton.Text = "Add";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // DeleteButton
            // 
            this.DeleteButton.Location = new System.Drawing.Point(195, 76);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(75, 23);
            this.DeleteButton.TabIndex = 8;
            this.DeleteButton.Text = "Delete";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click_1);
            // 
            // EditButton
            // 
            this.EditButton.Location = new System.Drawing.Point(195, 105);
            this.EditButton.Name = "EditButton";
            this.EditButton.Size = new System.Drawing.Size(75, 23);
            this.EditButton.TabIndex = 9;
            this.EditButton.Text = "Edit";
            this.EditButton.UseVisualStyleBackColor = true;
            this.EditButton.Click += new System.EventHandler(this.EditButton_Click);
            // 
            // SearchButton
            // 
            this.SearchButton.Location = new System.Drawing.Point(465, 25);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(75, 23);
            this.SearchButton.TabIndex = 10;
            this.SearchButton.Text = "Search";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Location = new System.Drawing.Point(290, 25);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(160, 20);
            this.textBoxSearch.TabIndex = 11;
            // 
            // OpenButton
            // 
            this.OpenButton.Location = new System.Drawing.Point(316, 386);
            this.OpenButton.Name = "OpenButton";
            this.OpenButton.Size = new System.Drawing.Size(75, 23);
            this.OpenButton.TabIndex = 12;
            this.OpenButton.Text = "Open";
            this.OpenButton.UseVisualStyleBackColor = true;
            this.OpenButton.Click += new System.EventHandler(this.OpenButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(401, 386);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 13;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 412);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(565, 22);
            this.statusStrip.TabIndex = 14;
            this.statusStrip.Text = "statusStrip";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(39, 17);
            this.toolStripStatusLabel.Text = "Ready";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(31, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 178);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Definition";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 434);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.OpenButton);
            this.Controls.Add(this.textBoxSearch);
            this.Controls.Add(this.SearchButton);
            this.Controls.Add(this.EditButton);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.StructureBox);
            this.Controls.Add(this.textBoxDefn);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.CategoryBox);
            this.Name = "Form1";
            this.Text = "Wiki Application";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.StructureBox.ResumeLayout(false);
            this.StructureBox.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

