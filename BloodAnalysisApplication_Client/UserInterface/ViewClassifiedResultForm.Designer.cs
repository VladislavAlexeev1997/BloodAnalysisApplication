
namespace BloodAnalysisApplication_Client.UserInterface
{
    partial class ViewClassifiedResultForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ImageGroupBox = new System.Windows.Forms.GroupBox();
            this.ImagePictureBox = new System.Windows.Forms.PictureBox();
            this.AllObjectCountLabel = new System.Windows.Forms.Label();
            this.ErythrocyteCountLabel = new System.Windows.Forms.Label();
            this.LeukocyteCountLabel = new System.Windows.Forms.Label();
            this.NonObjectCountLabel = new System.Windows.Forms.Label();
            this.AllObjectCountTextLabel = new System.Windows.Forms.Label();
            this.ErythrocyteCountTextLabel = new System.Windows.Forms.Label();
            this.LeukocyteCountTextLabel = new System.Windows.Forms.Label();
            this.NonObjectCountTextLabel = new System.Windows.Forms.Label();
            this.ViewParameterGroupBox = new System.Windows.Forms.GroupBox();
            this.ViewEveryObjectRadioButton = new System.Windows.Forms.RadioButton();
            this.ViewAllObjectRadioButton = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.AllObjectNumberLabel = new System.Windows.Forms.Label();
            this.SelectObjectNumberLabel = new System.Windows.Forms.Label();
            this.AllObjectLabel = new System.Windows.Forms.Label();
            this.NextObjectButton = new System.Windows.Forms.Button();
            this.PreviousObjectButton = new System.Windows.Forms.Button();
            this.LastObjectButton = new System.Windows.Forms.Button();
            this.FirstObjectButton = new System.Windows.Forms.Button();
            this.AllObjectDataGridView = new System.Windows.Forms.DataGridView();
            this.CloseViewFormButton = new System.Windows.Forms.Button();
            this.ImageGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImagePictureBox)).BeginInit();
            this.ViewParameterGroupBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AllObjectDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageGroupBox
            // 
            this.ImageGroupBox.Controls.Add(this.ImagePictureBox);
            this.ImageGroupBox.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ImageGroupBox.Location = new System.Drawing.Point(9, 4);
            this.ImageGroupBox.Name = "ImageGroupBox";
            this.ImageGroupBox.Size = new System.Drawing.Size(319, 333);
            this.ImageGroupBox.TabIndex = 0;
            this.ImageGroupBox.TabStop = false;
            this.ImageGroupBox.Text = "Изображение мазка крови";
            // 
            // ImagePictureBox
            // 
            this.ImagePictureBox.Location = new System.Drawing.Point(7, 19);
            this.ImagePictureBox.Name = "ImagePictureBox";
            this.ImagePictureBox.Size = new System.Drawing.Size(306, 306);
            this.ImagePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ImagePictureBox.TabIndex = 0;
            this.ImagePictureBox.TabStop = false;
            // 
            // AllObjectCountLabel
            // 
            this.AllObjectCountLabel.AutoSize = true;
            this.AllObjectCountLabel.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AllObjectCountLabel.Location = new System.Drawing.Point(27, 345);
            this.AllObjectCountLabel.Name = "AllObjectCountLabel";
            this.AllObjectCountLabel.Size = new System.Drawing.Size(238, 15);
            this.AllObjectCountLabel.TabIndex = 1;
            this.AllObjectCountLabel.Text = "Общее количество найденных объектов:";
            // 
            // ErythrocyteCountLabel
            // 
            this.ErythrocyteCountLabel.AutoSize = true;
            this.ErythrocyteCountLabel.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ErythrocyteCountLabel.Location = new System.Drawing.Point(27, 372);
            this.ErythrocyteCountLabel.Name = "ErythrocyteCountLabel";
            this.ErythrocyteCountLabel.Size = new System.Drawing.Size(150, 15);
            this.ErythrocyteCountLabel.TabIndex = 2;
            this.ErythrocyteCountLabel.Text = "Количество эритроцитов:";
            // 
            // LeukocyteCountLabel
            // 
            this.LeukocyteCountLabel.AutoSize = true;
            this.LeukocyteCountLabel.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LeukocyteCountLabel.Location = new System.Drawing.Point(27, 398);
            this.LeukocyteCountLabel.Name = "LeukocyteCountLabel";
            this.LeukocyteCountLabel.Size = new System.Drawing.Size(146, 15);
            this.LeukocyteCountLabel.TabIndex = 3;
            this.LeukocyteCountLabel.Text = "Количество лейкоцитов:";
            // 
            // NonObjectCountLabel
            // 
            this.NonObjectCountLabel.AutoSize = true;
            this.NonObjectCountLabel.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NonObjectCountLabel.Location = new System.Drawing.Point(27, 424);
            this.NonObjectCountLabel.Name = "NonObjectCountLabel";
            this.NonObjectCountLabel.Size = new System.Drawing.Size(227, 15);
            this.NonObjectCountLabel.TabIndex = 4;
            this.NonObjectCountLabel.Text = "Количество нераспознанных объектов:";
            // 
            // AllObjectCountTextLabel
            // 
            this.AllObjectCountTextLabel.BackColor = System.Drawing.SystemColors.Control;
            this.AllObjectCountTextLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AllObjectCountTextLabel.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AllObjectCountTextLabel.Location = new System.Drawing.Point(269, 342);
            this.AllObjectCountTextLabel.Name = "AllObjectCountTextLabel";
            this.AllObjectCountTextLabel.Size = new System.Drawing.Size(37, 21);
            this.AllObjectCountTextLabel.TabIndex = 12;
            this.AllObjectCountTextLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ErythrocyteCountTextLabel
            // 
            this.ErythrocyteCountTextLabel.BackColor = System.Drawing.SystemColors.Control;
            this.ErythrocyteCountTextLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ErythrocyteCountTextLabel.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ErythrocyteCountTextLabel.Location = new System.Drawing.Point(269, 369);
            this.ErythrocyteCountTextLabel.Name = "ErythrocyteCountTextLabel";
            this.ErythrocyteCountTextLabel.Size = new System.Drawing.Size(37, 21);
            this.ErythrocyteCountTextLabel.TabIndex = 13;
            this.ErythrocyteCountTextLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LeukocyteCountTextLabel
            // 
            this.LeukocyteCountTextLabel.BackColor = System.Drawing.SystemColors.Control;
            this.LeukocyteCountTextLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LeukocyteCountTextLabel.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LeukocyteCountTextLabel.Location = new System.Drawing.Point(269, 395);
            this.LeukocyteCountTextLabel.Name = "LeukocyteCountTextLabel";
            this.LeukocyteCountTextLabel.Size = new System.Drawing.Size(37, 21);
            this.LeukocyteCountTextLabel.TabIndex = 14;
            this.LeukocyteCountTextLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // NonObjectCountTextLabel
            // 
            this.NonObjectCountTextLabel.BackColor = System.Drawing.SystemColors.Control;
            this.NonObjectCountTextLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NonObjectCountTextLabel.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NonObjectCountTextLabel.Location = new System.Drawing.Point(269, 421);
            this.NonObjectCountTextLabel.Name = "NonObjectCountTextLabel";
            this.NonObjectCountTextLabel.Size = new System.Drawing.Size(37, 21);
            this.NonObjectCountTextLabel.TabIndex = 15;
            this.NonObjectCountTextLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ViewParameterGroupBox
            // 
            this.ViewParameterGroupBox.Controls.Add(this.ViewEveryObjectRadioButton);
            this.ViewParameterGroupBox.Controls.Add(this.ViewAllObjectRadioButton);
            this.ViewParameterGroupBox.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ViewParameterGroupBox.Location = new System.Drawing.Point(337, 4);
            this.ViewParameterGroupBox.Name = "ViewParameterGroupBox";
            this.ViewParameterGroupBox.Size = new System.Drawing.Size(248, 78);
            this.ViewParameterGroupBox.TabIndex = 16;
            this.ViewParameterGroupBox.TabStop = false;
            this.ViewParameterGroupBox.Text = "Параметры просмотра:";
            // 
            // ViewEveryObjectRadioButton
            // 
            this.ViewEveryObjectRadioButton.AutoSize = true;
            this.ViewEveryObjectRadioButton.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ViewEveryObjectRadioButton.Location = new System.Drawing.Point(13, 46);
            this.ViewEveryObjectRadioButton.Name = "ViewEveryObjectRadioButton";
            this.ViewEveryObjectRadioButton.Size = new System.Drawing.Size(178, 19);
            this.ViewEveryObjectRadioButton.TabIndex = 1;
            this.ViewEveryObjectRadioButton.Text = "Просмотр каждого объекта";
            this.ViewEveryObjectRadioButton.UseVisualStyleBackColor = true;
            this.ViewEveryObjectRadioButton.Click += new System.EventHandler(this.ViewEveryObjectRadioButton_Click);
            // 
            // ViewAllObjectRadioButton
            // 
            this.ViewAllObjectRadioButton.AutoSize = true;
            this.ViewAllObjectRadioButton.Checked = true;
            this.ViewAllObjectRadioButton.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ViewAllObjectRadioButton.Location = new System.Drawing.Point(13, 21);
            this.ViewAllObjectRadioButton.Name = "ViewAllObjectRadioButton";
            this.ViewAllObjectRadioButton.Size = new System.Drawing.Size(162, 19);
            this.ViewAllObjectRadioButton.TabIndex = 0;
            this.ViewAllObjectRadioButton.TabStop = true;
            this.ViewAllObjectRadioButton.Text = "Просмотр всех объектов";
            this.ViewAllObjectRadioButton.UseVisualStyleBackColor = true;
            this.ViewAllObjectRadioButton.Click += new System.EventHandler(this.ViewAllObjectRadioButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.AllObjectNumberLabel);
            this.groupBox1.Controls.Add(this.SelectObjectNumberLabel);
            this.groupBox1.Controls.Add(this.AllObjectLabel);
            this.groupBox1.Controls.Add(this.NextObjectButton);
            this.groupBox1.Controls.Add(this.PreviousObjectButton);
            this.groupBox1.Controls.Add(this.LastObjectButton);
            this.groupBox1.Controls.Add(this.FirstObjectButton);
            this.groupBox1.Controls.Add(this.AllObjectDataGridView);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(337, 85);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(248, 252);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Список найденных объектов";
            // 
            // AllObjectNumberLabel
            // 
            this.AllObjectNumberLabel.BackColor = System.Drawing.SystemColors.Control;
            this.AllObjectNumberLabel.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AllObjectNumberLabel.Location = new System.Drawing.Point(136, 222);
            this.AllObjectNumberLabel.Name = "AllObjectNumberLabel";
            this.AllObjectNumberLabel.Size = new System.Drawing.Size(34, 22);
            this.AllObjectNumberLabel.TabIndex = 61;
            this.AllObjectNumberLabel.Text = "0";
            this.AllObjectNumberLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SelectObjectNumberLabel
            // 
            this.SelectObjectNumberLabel.BackColor = System.Drawing.SystemColors.Control;
            this.SelectObjectNumberLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SelectObjectNumberLabel.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SelectObjectNumberLabel.Location = new System.Drawing.Point(79, 222);
            this.SelectObjectNumberLabel.Name = "SelectObjectNumberLabel";
            this.SelectObjectNumberLabel.Size = new System.Drawing.Size(34, 22);
            this.SelectObjectNumberLabel.TabIndex = 60;
            this.SelectObjectNumberLabel.Text = "0";
            this.SelectObjectNumberLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AllObjectLabel
            // 
            this.AllObjectLabel.AutoSize = true;
            this.AllObjectLabel.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AllObjectLabel.Location = new System.Drawing.Point(116, 226);
            this.AllObjectLabel.Name = "AllObjectLabel";
            this.AllObjectLabel.Size = new System.Drawing.Size(19, 15);
            this.AllObjectLabel.TabIndex = 59;
            this.AllObjectLabel.Text = "из";
            // 
            // NextObjectButton
            // 
            this.NextObjectButton.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NextObjectButton.Image = global::BloodAnalysisApplication_Client.Properties.Resources.next;
            this.NextObjectButton.Location = new System.Drawing.Point(176, 221);
            this.NextObjectButton.Name = "NextObjectButton";
            this.NextObjectButton.Size = new System.Drawing.Size(25, 23);
            this.NextObjectButton.TabIndex = 55;
            this.NextObjectButton.UseVisualStyleBackColor = true;
            this.NextObjectButton.Click += new System.EventHandler(this.NextObjectButton_Click);
            // 
            // PreviousObjectButton
            // 
            this.PreviousObjectButton.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PreviousObjectButton.Image = global::BloodAnalysisApplication_Client.Properties.Resources.previous;
            this.PreviousObjectButton.Location = new System.Drawing.Point(48, 221);
            this.PreviousObjectButton.Name = "PreviousObjectButton";
            this.PreviousObjectButton.Size = new System.Drawing.Size(25, 23);
            this.PreviousObjectButton.TabIndex = 56;
            this.PreviousObjectButton.UseVisualStyleBackColor = true;
            this.PreviousObjectButton.Click += new System.EventHandler(this.PreviousObjectButton_Click);
            // 
            // LastObjectButton
            // 
            this.LastObjectButton.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LastObjectButton.Image = global::BloodAnalysisApplication_Client.Properties.Resources.last;
            this.LastObjectButton.Location = new System.Drawing.Point(207, 221);
            this.LastObjectButton.Name = "LastObjectButton";
            this.LastObjectButton.Size = new System.Drawing.Size(31, 23);
            this.LastObjectButton.TabIndex = 57;
            this.LastObjectButton.UseVisualStyleBackColor = true;
            this.LastObjectButton.Click += new System.EventHandler(this.LastObjectButton_Click);
            // 
            // FirstObjectButton
            // 
            this.FirstObjectButton.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FirstObjectButton.Image = global::BloodAnalysisApplication_Client.Properties.Resources.first;
            this.FirstObjectButton.Location = new System.Drawing.Point(11, 221);
            this.FirstObjectButton.Name = "FirstObjectButton";
            this.FirstObjectButton.Size = new System.Drawing.Size(31, 23);
            this.FirstObjectButton.TabIndex = 58;
            this.FirstObjectButton.UseVisualStyleBackColor = true;
            this.FirstObjectButton.Click += new System.EventHandler(this.FirstObjectButton_Click);
            // 
            // AllObjectDataGridView
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.AllObjectDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.AllObjectDataGridView.ColumnHeadersHeight = 40;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.AllObjectDataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.AllObjectDataGridView.GridColor = System.Drawing.SystemColors.ButtonFace;
            this.AllObjectDataGridView.Location = new System.Drawing.Point(6, 21);
            this.AllObjectDataGridView.Name = "AllObjectDataGridView";
            this.AllObjectDataGridView.ReadOnly = true;
            this.AllObjectDataGridView.RowTemplate.Height = 40;
            this.AllObjectDataGridView.RowTemplate.ReadOnly = true;
            this.AllObjectDataGridView.Size = new System.Drawing.Size(236, 195);
            this.AllObjectDataGridView.TabIndex = 8;
            // 
            // CloseViewFormButton
            // 
            this.CloseViewFormButton.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CloseViewFormButton.Location = new System.Drawing.Point(432, 415);
            this.CloseViewFormButton.Name = "CloseViewFormButton";
            this.CloseViewFormButton.Size = new System.Drawing.Size(153, 24);
            this.CloseViewFormButton.TabIndex = 30;
            this.CloseViewFormButton.Text = "Завершить просмотр";
            this.CloseViewFormButton.UseVisualStyleBackColor = true;
            this.CloseViewFormButton.Click += new System.EventHandler(this.CloseViewFormButton_Click);
            // 
            // ViewClassifiedResultForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(597, 449);
            this.Controls.Add(this.CloseViewFormButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ViewParameterGroupBox);
            this.Controls.Add(this.NonObjectCountTextLabel);
            this.Controls.Add(this.LeukocyteCountTextLabel);
            this.Controls.Add(this.ErythrocyteCountTextLabel);
            this.Controls.Add(this.AllObjectCountTextLabel);
            this.Controls.Add(this.NonObjectCountLabel);
            this.Controls.Add(this.LeukocyteCountLabel);
            this.Controls.Add(this.ErythrocyteCountLabel);
            this.Controls.Add(this.AllObjectCountLabel);
            this.Controls.Add(this.ImageGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ViewClassifiedResultForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Классификация распознанных объектов на изображении мазка крови";
            this.ImageGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ImagePictureBox)).EndInit();
            this.ViewParameterGroupBox.ResumeLayout(false);
            this.ViewParameterGroupBox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AllObjectDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox ImageGroupBox;
        private System.Windows.Forms.PictureBox ImagePictureBox;
        private System.Windows.Forms.Label AllObjectCountLabel;
        private System.Windows.Forms.Label ErythrocyteCountLabel;
        private System.Windows.Forms.Label LeukocyteCountLabel;
        private System.Windows.Forms.Label NonObjectCountLabel;
        private System.Windows.Forms.Label AllObjectCountTextLabel;
        private System.Windows.Forms.Label ErythrocyteCountTextLabel;
        private System.Windows.Forms.Label LeukocyteCountTextLabel;
        private System.Windows.Forms.Label NonObjectCountTextLabel;
        private System.Windows.Forms.GroupBox ViewParameterGroupBox;
        private System.Windows.Forms.RadioButton ViewEveryObjectRadioButton;
        private System.Windows.Forms.RadioButton ViewAllObjectRadioButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView AllObjectDataGridView;
        public System.Windows.Forms.Label AllObjectNumberLabel;
        public System.Windows.Forms.Label SelectObjectNumberLabel;
        private System.Windows.Forms.Label AllObjectLabel;
        private System.Windows.Forms.Button NextObjectButton;
        private System.Windows.Forms.Button PreviousObjectButton;
        private System.Windows.Forms.Button LastObjectButton;
        private System.Windows.Forms.Button FirstObjectButton;
        private System.Windows.Forms.Button CloseViewFormButton;
    }
}