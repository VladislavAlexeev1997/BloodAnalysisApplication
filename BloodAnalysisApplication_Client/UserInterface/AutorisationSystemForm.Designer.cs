namespace BloodAnalysisApplication_Client.UserInterface
{
    partial class AutorisationSystemForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.EnterAttentionLabel = new System.Windows.Forms.Label();
            this.ExitButton = new System.Windows.Forms.Button();
            this.ClearButton = new System.Windows.Forms.Button();
            this.AutorisationButton = new System.Windows.Forms.Button();
            this.UserPasswordButtonPictureBox = new System.Windows.Forms.PictureBox();
            this.UserPasswordMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.UserPasswordLabel = new System.Windows.Forms.Label();
            this.UserNameСomboBox = new System.Windows.Forms.ComboBox();
            this.UserNameLabel = new System.Windows.Forms.Label();
            this.UserTypeComboBox = new System.Windows.Forms.ComboBox();
            this.UserTypeLabel = new System.Windows.Forms.Label();
            this.InformationPictureBox = new System.Windows.Forms.PictureBox();
            this.InfoAutorisationLabel = new System.Windows.Forms.Label();
            this.InformationToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.EnterPasswordInfoToolTip = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.UserPasswordButtonPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InformationPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // EnterAttentionLabel
            // 
            this.EnterAttentionLabel.AutoSize = true;
            this.EnterAttentionLabel.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EnterAttentionLabel.ForeColor = System.Drawing.Color.Red;
            this.EnterAttentionLabel.Location = new System.Drawing.Point(11, 133);
            this.EnterAttentionLabel.Name = "EnterAttentionLabel";
            this.EnterAttentionLabel.Size = new System.Drawing.Size(56, 15);
            this.EnterAttentionLabel.TabIndex = 25;
            this.EnterAttentionLabel.Text = "Ошибка!";
            this.EnterAttentionLabel.Visible = false;
            // 
            // ExitButton
            // 
            this.ExitButton.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ExitButton.Location = new System.Drawing.Point(319, 157);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(75, 23);
            this.ExitButton.TabIndex = 24;
            this.ExitButton.Text = "Выйти";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // ClearButton
            // 
            this.ClearButton.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ClearButton.Location = new System.Drawing.Point(89, 157);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(151, 23);
            this.ClearButton.TabIndex = 23;
            this.ClearButton.Text = "Очистить поля ввода";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // AutorisationButton
            // 
            this.AutorisationButton.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AutorisationButton.Location = new System.Drawing.Point(8, 157);
            this.AutorisationButton.Name = "AutorisationButton";
            this.AutorisationButton.Size = new System.Drawing.Size(75, 23);
            this.AutorisationButton.TabIndex = 22;
            this.AutorisationButton.Text = "Войти";
            this.AutorisationButton.UseVisualStyleBackColor = true;
            this.AutorisationButton.Click += new System.EventHandler(this.AutorisationButton_Click);
            // 
            // UserPasswordButtonPictureBox
            // 
            this.UserPasswordButtonPictureBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.UserPasswordButtonPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.UserPasswordButtonPictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.UserPasswordButtonPictureBox.Image = global::BloodAnalysisApplication_Client.Properties.Resources.visible_eye;
            this.UserPasswordButtonPictureBox.Location = new System.Drawing.Point(371, 103);
            this.UserPasswordButtonPictureBox.Name = "UserPasswordButtonPictureBox";
            this.UserPasswordButtonPictureBox.Size = new System.Drawing.Size(23, 23);
            this.UserPasswordButtonPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.UserPasswordButtonPictureBox.TabIndex = 21;
            this.UserPasswordButtonPictureBox.TabStop = false;
            this.EnterPasswordInfoToolTip.SetToolTip(this.UserPasswordButtonPictureBox, "Для просмотра введенного пароля нужно\r\nзажать эту кнопку левой кнопкой мыши");
            this.UserPasswordButtonPictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.UserPasswordButtonPictureBox_MouseDown);
            this.UserPasswordButtonPictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.UserPasswordButtonPictureBox_MouseUp);
            // 
            // UserPasswordMaskedTextBox
            // 
            this.UserPasswordMaskedTextBox.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.UserPasswordMaskedTextBox.Location = new System.Drawing.Point(186, 103);
            this.UserPasswordMaskedTextBox.Name = "UserPasswordMaskedTextBox";
            this.UserPasswordMaskedTextBox.Size = new System.Drawing.Size(186, 23);
            this.UserPasswordMaskedTextBox.TabIndex = 20;
            this.UserPasswordMaskedTextBox.UseSystemPasswordChar = true;
            // 
            // UserPasswordLabel
            // 
            this.UserPasswordLabel.AutoSize = true;
            this.UserPasswordLabel.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.UserPasswordLabel.Location = new System.Drawing.Point(5, 106);
            this.UserPasswordLabel.Name = "UserPasswordLabel";
            this.UserPasswordLabel.Size = new System.Drawing.Size(144, 17);
            this.UserPasswordLabel.TabIndex = 19;
            this.UserPasswordLabel.Text = "Пароль пользователя:";
            // 
            // UserNameСomboBox
            // 
            this.UserNameСomboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.UserNameСomboBox.Enabled = false;
            this.UserNameСomboBox.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.UserNameСomboBox.FormattingEnabled = true;
            this.UserNameСomboBox.Location = new System.Drawing.Point(186, 74);
            this.UserNameСomboBox.Name = "UserNameСomboBox";
            this.UserNameСomboBox.Size = new System.Drawing.Size(208, 23);
            this.UserNameСomboBox.TabIndex = 18;
            // 
            // UserNameLabel
            // 
            this.UserNameLabel.AutoSize = true;
            this.UserNameLabel.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.UserNameLabel.Location = new System.Drawing.Point(5, 76);
            this.UserNameLabel.Name = "UserNameLabel";
            this.UserNameLabel.Size = new System.Drawing.Size(98, 17);
            this.UserNameLabel.TabIndex = 17;
            this.UserNameLabel.Text = "Пользователь:";
            // 
            // UserTypeComboBox
            // 
            this.UserTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.UserTypeComboBox.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.UserTypeComboBox.FormattingEnabled = true;
            this.UserTypeComboBox.Location = new System.Drawing.Point(186, 44);
            this.UserTypeComboBox.Name = "UserTypeComboBox";
            this.UserTypeComboBox.Size = new System.Drawing.Size(208, 23);
            this.UserTypeComboBox.TabIndex = 16;
            this.UserTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.UserTypeComboBox_SelectedIndexChanged);
            // 
            // UserTypeLabel
            // 
            this.UserTypeLabel.AutoSize = true;
            this.UserTypeLabel.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.UserTypeLabel.Location = new System.Drawing.Point(5, 46);
            this.UserTypeLabel.Name = "UserTypeLabel";
            this.UserTypeLabel.Size = new System.Drawing.Size(180, 17);
            this.UserTypeLabel.TabIndex = 15;
            this.UserTypeLabel.Text = "Тип пользователя системы:";
            // 
            // InformationPictureBox
            // 
            this.InformationPictureBox.Cursor = System.Windows.Forms.Cursors.Help;
            this.InformationPictureBox.Image = global::BloodAnalysisApplication_Client.Properties.Resources.information;
            this.InformationPictureBox.Location = new System.Drawing.Point(369, 8);
            this.InformationPictureBox.Name = "InformationPictureBox";
            this.InformationPictureBox.Size = new System.Drawing.Size(20, 20);
            this.InformationPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.InformationPictureBox.TabIndex = 14;
            this.InformationPictureBox.TabStop = false;
            this.InformationToolTip.SetToolTip(this.InformationPictureBox, "Для авторизации необходимо выбрать тип пользователя, \r\nимя пользователя и ввести " +
        "его собственный пароль.");
            // 
            // InfoAutorisationLabel
            // 
            this.InfoAutorisationLabel.AutoSize = true;
            this.InfoAutorisationLabel.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.InfoAutorisationLabel.Location = new System.Drawing.Point(12, 9);
            this.InfoAutorisationLabel.Name = "InfoAutorisationLabel";
            this.InfoAutorisationLabel.Size = new System.Drawing.Size(356, 17);
            this.InfoAutorisationLabel.TabIndex = 13;
            this.InfoAutorisationLabel.Text = "Для входа в систему необходимо в ней авторизоваться.";
            // 
            // InformationToolTip
            // 
            this.InformationToolTip.AutoPopDelay = 10000;
            this.InformationToolTip.InitialDelay = 200;
            this.InformationToolTip.ReshowDelay = 100;
            this.InformationToolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.InformationToolTip.ToolTipTitle = "Информация по авторизации в систему";
            // 
            // EnterPasswordInfoToolTip
            // 
            this.EnterPasswordInfoToolTip.AutoPopDelay = 10000;
            this.EnterPasswordInfoToolTip.InitialDelay = 300;
            this.EnterPasswordInfoToolTip.ReshowDelay = 100;
            this.EnterPasswordInfoToolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.EnterPasswordInfoToolTip.ToolTipTitle = "Просмотр пароля";
            // 
            // AutorisationSystemForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(405, 191);
            this.Controls.Add(this.EnterAttentionLabel);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.AutorisationButton);
            this.Controls.Add(this.UserPasswordButtonPictureBox);
            this.Controls.Add(this.UserPasswordMaskedTextBox);
            this.Controls.Add(this.UserPasswordLabel);
            this.Controls.Add(this.UserNameСomboBox);
            this.Controls.Add(this.UserNameLabel);
            this.Controls.Add(this.UserTypeComboBox);
            this.Controls.Add(this.UserTypeLabel);
            this.Controls.Add(this.InformationPictureBox);
            this.Controls.Add(this.InfoAutorisationLabel);
            this.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AutorisationSystemForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Авторизация в систему";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AutorisationSystemForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.UserPasswordButtonPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InformationPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label EnterAttentionLabel;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.Button AutorisationButton;
        private System.Windows.Forms.PictureBox UserPasswordButtonPictureBox;
        private System.Windows.Forms.MaskedTextBox UserPasswordMaskedTextBox;
        private System.Windows.Forms.Label UserPasswordLabel;
        private System.Windows.Forms.ComboBox UserNameСomboBox;
        private System.Windows.Forms.Label UserNameLabel;
        private System.Windows.Forms.ComboBox UserTypeComboBox;
        private System.Windows.Forms.Label UserTypeLabel;
        private System.Windows.Forms.PictureBox InformationPictureBox;
        private System.Windows.Forms.Label InfoAutorisationLabel;
        private System.Windows.Forms.ToolTip InformationToolTip;
        private System.Windows.Forms.ToolTip EnterPasswordInfoToolTip;
    }
}

