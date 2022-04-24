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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HallPassForm));
            this.morningRadio = new System.Windows.Forms.RadioButton();
            this.afternoonRadio = new System.Windows.Forms.RadioButton();
            this.studentSearch = new System.Windows.Forms.TextBox();
            this.studentList = new System.Windows.Forms.ListBox();
            this.PrintButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.labelPreview = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // morningRadio
            // 
            this.morningRadio.AutoSize = true;
            this.morningRadio.Location = new System.Drawing.Point(377, 25);
            this.morningRadio.Name = "morningRadio";
            this.morningRadio.Size = new System.Drawing.Size(63, 17);
            this.morningRadio.TabIndex = 0;
            this.morningRadio.TabStop = true;
            this.morningRadio.Text = "Morning";
            this.morningRadio.UseVisualStyleBackColor = true;
            // 
            // afternoonRadio
            // 
            this.afternoonRadio.AutoSize = true;
            this.afternoonRadio.Location = new System.Drawing.Point(446, 25);
            this.afternoonRadio.Name = "afternoonRadio";
            this.afternoonRadio.Size = new System.Drawing.Size(71, 17);
            this.afternoonRadio.TabIndex = 1;
            this.afternoonRadio.TabStop = true;
            this.afternoonRadio.Text = "Afternoon";
            this.afternoonRadio.UseVisualStyleBackColor = true;
            // 
            // studentSearch
            // 
            this.studentSearch.Location = new System.Drawing.Point(12, 25);
            this.studentSearch.Name = "studentSearch";
            this.studentSearch.Size = new System.Drawing.Size(326, 20);
            this.studentSearch.TabIndex = 2;
            this.studentSearch.TextChanged += new System.EventHandler(this.studentSearch_TextChanged);
            // 
            // studentList
            // 
            this.studentList.FormattingEnabled = true;
            this.studentList.Location = new System.Drawing.Point(12, 51);
            this.studentList.Name = "studentList";
            this.studentList.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.studentList.Size = new System.Drawing.Size(326, 368);
            this.studentList.TabIndex = 3;
            // 
            // PrintButton
            // 
            this.PrintButton.Location = new System.Drawing.Point(713, 400);
            this.PrintButton.Name = "PrintButton";
            this.PrintButton.Size = new System.Drawing.Size(75, 23);
            this.PrintButton.TabIndex = 4;
            this.PrintButton.Text = "Print";
            this.PrintButton.UseVisualStyleBackColor = true;
            this.PrintButton.Click += new System.EventHandler(this.PrintButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Search";
            // 
            // labelPreview
            // 
            this.labelPreview.AutoSize = true;
            this.labelPreview.Location = new System.Drawing.Point(385, 72);
            this.labelPreview.Name = "labelPreview";
            this.labelPreview.Size = new System.Drawing.Size(35, 13);
            this.labelPreview.TabIndex = 7;
            this.labelPreview.Text = "label2";
            // 
            // HallPassForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 435);
            this.Controls.Add(this.labelPreview);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PrintButton);
            this.Controls.Add(this.studentList);
            this.Controls.Add(this.studentSearch);
            this.Controls.Add(this.afternoonRadio);
            this.Controls.Add(this.morningRadio);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "HallPassForm";
            this.Text = "Hall Pass";
            this.Load += new System.EventHandler(this.HallPassForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton morningRadio;
        private System.Windows.Forms.RadioButton afternoonRadio;
        private System.Windows.Forms.TextBox studentSearch;
        private System.Windows.Forms.ListBox studentList;
        private System.Windows.Forms.Button PrintButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelPreview;
    }
}

