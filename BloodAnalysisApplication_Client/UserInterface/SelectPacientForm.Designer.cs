namespace BloodAnalysisApplication_Client.UserInterface
{
    partial class SelectPacientForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            this.PacientsDataGridView = new System.Windows.Forms.DataGridView();
            this.FirstPacientButton = new System.Windows.Forms.Button();
            this.LastPacientButton = new System.Windows.Forms.Button();
            this.PreviousPacientButton = new System.Windows.Forms.Button();
            this.NextPacientButton = new System.Windows.Forms.Button();
            this.SelectButton = new System.Windows.Forms.Button();
            this.CancelSelectButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PacientsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // PacientsDataGridView
            // 
            this.PacientsDataGridView.AllowUserToAddRows = false;
            this.PacientsDataGridView.AllowUserToResizeRows = false;
            this.PacientsDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle17.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle17.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle17.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.PacientsDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle17;
            this.PacientsDataGridView.ColumnHeadersHeight = 40;
            this.PacientsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle18.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.PacientsDataGridView.DefaultCellStyle = dataGridViewCellStyle18;
            this.PacientsDataGridView.GridColor = System.Drawing.SystemColors.ButtonFace;
            this.PacientsDataGridView.Location = new System.Drawing.Point(0, 0);
            this.PacientsDataGridView.Name = "PacientsDataGridView";
            this.PacientsDataGridView.ReadOnly = true;
            this.PacientsDataGridView.RowHeadersVisible = false;
            this.PacientsDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.PacientsDataGridView.RowTemplate.Height = 40;
            this.PacientsDataGridView.RowTemplate.ReadOnly = true;
            this.PacientsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.PacientsDataGridView.Size = new System.Drawing.Size(467, 151);
            this.PacientsDataGridView.TabIndex = 5;
            // 
            // FirstPacientButton
            // 
            this.FirstPacientButton.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FirstPacientButton.Image = global::BloodAnalysisApplication_Client.Properties.Resources.first;
            this.FirstPacientButton.Location = new System.Drawing.Point(12, 157);
            this.FirstPacientButton.Name = "FirstPacientButton";
            this.FirstPacientButton.Size = new System.Drawing.Size(31, 23);
            this.FirstPacientButton.TabIndex = 24;
            this.FirstPacientButton.UseVisualStyleBackColor = true;
            this.FirstPacientButton.Click += new System.EventHandler(this.FirstPacientButton_Click);
            // 
            // LastPacientButton
            // 
            this.LastPacientButton.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LastPacientButton.Image = global::BloodAnalysisApplication_Client.Properties.Resources.last;
            this.LastPacientButton.Location = new System.Drawing.Point(111, 157);
            this.LastPacientButton.Name = "LastPacientButton";
            this.LastPacientButton.Size = new System.Drawing.Size(31, 23);
            this.LastPacientButton.TabIndex = 25;
            this.LastPacientButton.UseVisualStyleBackColor = true;
            this.LastPacientButton.Click += new System.EventHandler(this.LastPacientButton_Click);
            // 
            // PreviousPacientButton
            // 
            this.PreviousPacientButton.Enabled = false;
            this.PreviousPacientButton.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PreviousPacientButton.Image = global::BloodAnalysisApplication_Client.Properties.Resources.previous;
            this.PreviousPacientButton.Location = new System.Drawing.Point(49, 157);
            this.PreviousPacientButton.Name = "PreviousPacientButton";
            this.PreviousPacientButton.Size = new System.Drawing.Size(25, 23);
            this.PreviousPacientButton.TabIndex = 26;
            this.PreviousPacientButton.UseVisualStyleBackColor = true;
            this.PreviousPacientButton.Click += new System.EventHandler(this.PreviousPacientButton_Click);
            // 
            // NextPacientButton
            // 
            this.NextPacientButton.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NextPacientButton.Image = global::BloodAnalysisApplication_Client.Properties.Resources.next;
            this.NextPacientButton.Location = new System.Drawing.Point(80, 157);
            this.NextPacientButton.Name = "NextPacientButton";
            this.NextPacientButton.Size = new System.Drawing.Size(25, 23);
            this.NextPacientButton.TabIndex = 27;
            this.NextPacientButton.UseVisualStyleBackColor = true;
            this.NextPacientButton.Click += new System.EventHandler(this.NextPacientButton_Click);
            // 
            // SelectButton
            // 
            this.SelectButton.Enabled = false;
            this.SelectButton.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SelectButton.Location = new System.Drawing.Point(243, 157);
            this.SelectButton.Name = "SelectButton";
            this.SelectButton.Size = new System.Drawing.Size(128, 23);
            this.SelectButton.TabIndex = 28;
            this.SelectButton.Text = "Выбрать пациента";
            this.SelectButton.UseVisualStyleBackColor = true;
            this.SelectButton.Click += new System.EventHandler(this.SelectButton_Click);
            // 
            // CancelSelectButton
            // 
            this.CancelSelectButton.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CancelSelectButton.Location = new System.Drawing.Point(384, 157);
            this.CancelSelectButton.Name = "CancelSelectButton";
            this.CancelSelectButton.Size = new System.Drawing.Size(71, 23);
            this.CancelSelectButton.TabIndex = 29;
            this.CancelSelectButton.Text = "Отмена";
            this.CancelSelectButton.UseVisualStyleBackColor = true;
            this.CancelSelectButton.Click += new System.EventHandler(this.CancelSelectButton_Click);
            // 
            // SelectPacientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(467, 188);
            this.Controls.Add(this.CancelSelectButton);
            this.Controls.Add(this.SelectButton);
            this.Controls.Add(this.NextPacientButton);
            this.Controls.Add(this.PreviousPacientButton);
            this.Controls.Add(this.LastPacientButton);
            this.Controls.Add(this.FirstPacientButton);
            this.Controls.Add(this.PacientsDataGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "SelectPacientForm";
            this.ShowIcon = false;
            this.Text = "Выберите пациента";
            ((System.ComponentModel.ISupportInitialize)(this.PacientsDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView PacientsDataGridView;
        private System.Windows.Forms.Button FirstPacientButton;
        private System.Windows.Forms.Button LastPacientButton;
        private System.Windows.Forms.Button PreviousPacientButton;
        private System.Windows.Forms.Button NextPacientButton;
        private System.Windows.Forms.Button SelectButton;
        private System.Windows.Forms.Button CancelSelectButton;
    }
}