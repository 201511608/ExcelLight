namespace ReoGrid_1
{
    partial class Form3_AddGrid
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
            this.label1_Batch = new System.Windows.Forms.Label();
            this.comboBox1_batch = new System.Windows.Forms.ComboBox();
            this.label1_Branch = new System.Windows.Forms.Label();
            this.comboBox1_branch = new System.Windows.Forms.ComboBox();
            this.label1_Sem = new System.Windows.Forms.Label();
            this.comboBox1_sem = new System.Windows.Forms.ComboBox();
            this.label1_Subject = new System.Windows.Forms.Label();
            this.comboBox1_Subject = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1_Batch
            // 
            this.label1_Batch.AutoSize = true;
            this.label1_Batch.Location = new System.Drawing.Point(12, 9);
            this.label1_Batch.Name = "label1_Batch";
            this.label1_Batch.Size = new System.Drawing.Size(69, 13);
            this.label1_Batch.TabIndex = 0;
            this.label1_Batch.Text = "label1_Batch";
            // 
            // comboBox1_batch
            // 
            this.comboBox1_batch.FormattingEnabled = true;
            this.comboBox1_batch.Location = new System.Drawing.Point(12, 28);
            this.comboBox1_batch.Name = "comboBox1_batch";
            this.comboBox1_batch.Size = new System.Drawing.Size(146, 21);
            this.comboBox1_batch.TabIndex = 1;
            this.comboBox1_batch.SelectedIndexChanged += new System.EventHandler(this.comboBox1_batch_SelectedIndexChanged);
            // 
            // label1_Branch
            // 
            this.label1_Branch.AutoSize = true;
            this.label1_Branch.Location = new System.Drawing.Point(168, 9);
            this.label1_Branch.Name = "label1_Branch";
            this.label1_Branch.Size = new System.Drawing.Size(75, 13);
            this.label1_Branch.TabIndex = 0;
            this.label1_Branch.Text = "label1_Branch";
            // 
            // comboBox1_branch
            // 
            this.comboBox1_branch.FormattingEnabled = true;
            this.comboBox1_branch.Location = new System.Drawing.Point(168, 28);
            this.comboBox1_branch.Name = "comboBox1_branch";
            this.comboBox1_branch.Size = new System.Drawing.Size(146, 21);
            this.comboBox1_branch.TabIndex = 1;
            // 
            // label1_Sem
            // 
            this.label1_Sem.AutoSize = true;
            this.label1_Sem.Location = new System.Drawing.Point(320, 9);
            this.label1_Sem.Name = "label1_Sem";
            this.label1_Sem.Size = new System.Drawing.Size(62, 13);
            this.label1_Sem.TabIndex = 0;
            this.label1_Sem.Text = "label1_Sem";
            // 
            // comboBox1_sem
            // 
            this.comboBox1_sem.FormattingEnabled = true;
            this.comboBox1_sem.Location = new System.Drawing.Point(320, 28);
            this.comboBox1_sem.Name = "comboBox1_sem";
            this.comboBox1_sem.Size = new System.Drawing.Size(146, 21);
            this.comboBox1_sem.TabIndex = 1;
            // 
            // label1_Subject
            // 
            this.label1_Subject.AutoSize = true;
            this.label1_Subject.Location = new System.Drawing.Point(472, 9);
            this.label1_Subject.Name = "label1_Subject";
            this.label1_Subject.Size = new System.Drawing.Size(77, 13);
            this.label1_Subject.TabIndex = 0;
            this.label1_Subject.Text = "label1_Subject";
            // 
            // comboBox1_Subject
            // 
            this.comboBox1_Subject.FormattingEnabled = true;
            this.comboBox1_Subject.Location = new System.Drawing.Point(472, 28);
            this.comboBox1_Subject.Name = "comboBox1_Subject";
            this.comboBox1_Subject.Size = new System.Drawing.Size(146, 21);
            this.comboBox1_Subject.TabIndex = 1;
            // 
            // Form3_AddGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(630, 61);
            this.Controls.Add(this.comboBox1_Subject);
            this.Controls.Add(this.label1_Subject);
            this.Controls.Add(this.comboBox1_sem);
            this.Controls.Add(this.label1_Sem);
            this.Controls.Add(this.comboBox1_branch);
            this.Controls.Add(this.label1_Branch);
            this.Controls.Add(this.comboBox1_batch);
            this.Controls.Add(this.label1_Batch);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "Form3_AddGrid";
            this.Text = "Form3_AddGrid";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1_Batch;
        private System.Windows.Forms.ComboBox comboBox1_batch;
        private System.Windows.Forms.Label label1_Branch;
        private System.Windows.Forms.ComboBox comboBox1_branch;
        private System.Windows.Forms.Label label1_Sem;
        private System.Windows.Forms.ComboBox comboBox1_sem;
        private System.Windows.Forms.Label label1_Subject;
        private System.Windows.Forms.ComboBox comboBox1_Subject;
    }
}