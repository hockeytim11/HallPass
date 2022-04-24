namespace HallPass
{
    partial class HallPassForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HallPassForm));
            this.morningRadio = new System.Windows.Forms.RadioButton();
            this.afternoonRadio = new System.Windows.Forms.RadioButton();
            this.PrintButton = new System.Windows.Forms.Button();
            this.labelPreview = new System.Windows.Forms.Label();
            this.studentsSearch = new System.Windows.Forms.DataGridView();
            this.gradeSelect = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.nameSearch = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.homeroom = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.studentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.studentsSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.studentBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // morningRadio
            // 
            this.morningRadio.Appearance = System.Windows.Forms.Appearance.Button;
            this.morningRadio.AutoSize = true;
            this.morningRadio.Checked = true;
            this.morningRadio.Location = new System.Drawing.Point(522, 22);
            this.morningRadio.Name = "morningRadio";
            this.morningRadio.Size = new System.Drawing.Size(69, 23);
            this.morningRadio.TabIndex = 0;
            this.morningRadio.TabStop = true;
            this.morningRadio.Text = "MORNING";
            this.morningRadio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.morningRadio.UseVisualStyleBackColor = true;
            // 
            // afternoonRadio
            // 
            this.afternoonRadio.Appearance = System.Windows.Forms.Appearance.Button;
            this.afternoonRadio.AutoSize = true;
            this.afternoonRadio.BackColor = System.Drawing.SystemColors.Control;
            this.afternoonRadio.Location = new System.Drawing.Point(597, 22);
            this.afternoonRadio.Name = "afternoonRadio";
            this.afternoonRadio.Size = new System.Drawing.Size(115, 23);
            this.afternoonRadio.TabIndex = 1;
            this.afternoonRadio.Text = "PASSING PERIODS";
            this.afternoonRadio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.afternoonRadio.UseVisualStyleBackColor = false;
            // 
            // PrintButton
            // 
            this.PrintButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PrintButton.Location = new System.Drawing.Point(870, 9);
            this.PrintButton.Name = "PrintButton";
            this.PrintButton.Size = new System.Drawing.Size(75, 23);
            this.PrintButton.TabIndex = 4;
            this.PrintButton.Text = "LOG/PRINT";
            this.PrintButton.UseVisualStyleBackColor = true;
            this.PrintButton.Click += new System.EventHandler(this.PrintButton_Click);
            // 
            // labelPreview
            // 
            this.labelPreview.AutoSize = true;
            this.labelPreview.Font = new System.Drawing.Font("Noto Mono", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPreview.Location = new System.Drawing.Point(731, 51);
            this.labelPreview.Name = "labelPreview";
            this.labelPreview.Size = new System.Drawing.Size(0, 13);
            this.labelPreview.TabIndex = 7;
            // 
            // studentsSearch
            // 
            this.studentsSearch.AllowDrop = true;
            this.studentsSearch.AllowUserToAddRows = false;
            this.studentsSearch.AllowUserToDeleteRows = false;
            this.studentsSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.studentsSearch.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.studentsSearch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.studentsSearch.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.studentsSearch.Location = new System.Drawing.Point(12, 51);
            this.studentsSearch.Name = "studentsSearch";
            this.studentsSearch.ReadOnly = true;
            this.studentsSearch.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.studentsSearch.Size = new System.Drawing.Size(700, 534);
            this.studentsSearch.TabIndex = 8;
            // 
            // gradeSelect
            // 
            this.gradeSelect.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.gradeSelect.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.gradeSelect.FormattingEnabled = true;
            this.gradeSelect.Items.AddRange(new object[] {
            "*ANY"});
            this.gradeSelect.Location = new System.Drawing.Point(225, 25);
            this.gradeSelect.Name = "gradeSelect";
            this.gradeSelect.Size = new System.Drawing.Size(64, 21);
            this.gradeSelect.Sorted = true;
            this.gradeSelect.TabIndex = 9;
            this.gradeSelect.Text = "(Grade)";
            this.gradeSelect.SelectedIndexChanged += new System.EventHandler(this.gradeSelect_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Student Name";
            // 
            // nameSearch
            // 
            this.nameSearch.Location = new System.Drawing.Point(12, 25);
            this.nameSearch.Name = "nameSearch";
            this.nameSearch.Size = new System.Drawing.Size(207, 20);
            this.nameSearch.TabIndex = 11;
            this.nameSearch.TextChanged += new System.EventHandler(this.nameSearch_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(222, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Grade";
            // 
            // homeroom
            // 
            this.homeroom.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.homeroom.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.homeroom.FormattingEnabled = true;
            this.homeroom.Items.AddRange(new object[] {
            "*ANY"});
            this.homeroom.Location = new System.Drawing.Point(295, 25);
            this.homeroom.Name = "homeroom";
            this.homeroom.Size = new System.Drawing.Size(121, 21);
            this.homeroom.Sorted = true;
            this.homeroom.TabIndex = 13;
            this.homeroom.Text = "(Homeroom)";
            this.homeroom.SelectedIndexChanged += new System.EventHandler(this.homeroom_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(292, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Homeroom";
            // 
            // studentBindingSource
            // 
            this.studentBindingSource.DataSource = typeof(HallPass.Student);
            // 
            // HallPassForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(957, 597);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.homeroom);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nameSearch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gradeSelect);
            this.Controls.Add(this.studentsSearch);
            this.Controls.Add(this.labelPreview);
            this.Controls.Add(this.PrintButton);
            this.Controls.Add(this.afternoonRadio);
            this.Controls.Add(this.morningRadio);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "HallPassForm";
            this.Text = "Farrell B. Howell ECE-8 School Tardy Pass System";
            this.Load += new System.EventHandler(this.HallPassForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.studentsSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.studentBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton morningRadio;
        private System.Windows.Forms.RadioButton afternoonRadio;
        private System.Windows.Forms.Button PrintButton;
        private System.Windows.Forms.Label labelPreview;
        private System.Windows.Forms.DataGridView studentsSearch;
        private System.Windows.Forms.BindingSource studentBindingSource;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox nameSearch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox homeroom;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox gradeSelect;
    }
}

