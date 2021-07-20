namespace BloodAnalysisApplication_Client.UserInterface
{
    partial class AdministrateWorkForm
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
            this.InformationToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.AddEmployeeDataButton = new System.Windows.Forms.Button();
            this.EditEmployeeDataButton = new System.Windows.Forms.Button();
            this.DeleteEmployeeDataButton = new System.Windows.Forms.Button();
            this.NextEmployeeDataButton = new System.Windows.Forms.Button();
            this.PreviousEmployeeDataButton = new System.Windows.Forms.Button();
            this.LastEmployeeDataButton = new System.Windows.Forms.Button();
            this.FirstEmployeeDataButton = new System.Windows.Forms.Button();
            this.AdministrateWorkMenuStrip = new System.Windows.Forms.MenuStrip();
            this.DataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EditDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SettingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EditPasswordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ThirdToolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.SystemExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ViewEmployeeDataGroupBox = new System.Windows.Forms.GroupBox();
            this.ViewEmployeeStaffDataGroupBox = new System.Windows.Forms.GroupBox();
            this.NowStatusWorkEmployeePictureBox = new System.Windows.Forms.PictureBox();
            this.NowStatusWorkEmployeeLabel = new System.Windows.Forms.Label();
            this.ViewEmployeePasswordLabel = new System.Windows.Forms.Label();
            this.ViewEmployeeProfessionalLabel = new System.Windows.Forms.Label();
            this.EmployeePasswordLabel = new System.Windows.Forms.Label();
            this.ViewEmployeeContractNumberLabel = new System.Windows.Forms.Label();
            this.EmployeeProfessionalLabel = new System.Windows.Forms.Label();
            this.EmployeeContractNumberLabel = new System.Windows.Forms.Label();
            this.ViewPersonalEmployeeDataGroupBox = new System.Windows.Forms.GroupBox();
            this.ViewEmployeeGenderLabel = new System.Windows.Forms.Label();
            this.EmployeeGenderLabel = new System.Windows.Forms.Label();
            this.ViewEmployeeBirthdayLabel = new System.Windows.Forms.Label();
            this.EmployeeBirthdayLabel = new System.Windows.Forms.Label();
            this.ViewEmployeePatronimicLabel = new System.Windows.Forms.Label();
            this.ViewEmployeeNameLabel = new System.Windows.Forms.Label();
            this.ViewEmployeeSurnameLabel = new System.Windows.Forms.Label();
            this.EmployeePatronimicLabel = new System.Windows.Forms.Label();
            this.EmployeeNameLabel = new System.Windows.Forms.Label();
            this.EmployeeSurnameLabel = new System.Windows.Forms.Label();
            this.EmployeeDataTableGroupBox = new System.Windows.Forms.GroupBox();
            this.AllEmployeeDataNumberLabel = new System.Windows.Forms.Label();
            this.SelectEmployeeDataNumberLabel = new System.Windows.Forms.Label();
            this.AllEmployeeDataLabel = new System.Windows.Forms.Label();
            this.EmployeeDataGridView = new System.Windows.Forms.DataGridView();
            this.AdministrateWorkMenuStrip.SuspendLayout();
            this.ViewEmployeeDataGroupBox.SuspendLayout();
            this.ViewEmployeeStaffDataGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NowStatusWorkEmployeePictureBox)).BeginInit();
            this.ViewPersonalEmployeeDataGroupBox.SuspendLayout();
            this.EmployeeDataTableGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EmployeeDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // InformationToolTip
            // 
            this.InformationToolTip.AutoPopDelay = 10000;
            this.InformationToolTip.InitialDelay = 200;
            this.InformationToolTip.ReshowDelay = 100;
            // 
            // AddEmployeeDataButton
            // 
            this.AddEmployeeDataButton.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AddEmployeeDataButton.Image = global::BloodAnalysisApplication_Client.Properties.Resources.add;
            this.AddEmployeeDataButton.Location = new System.Drawing.Point(440, 185);
            this.AddEmployeeDataButton.Name = "AddEmployeeDataButton";
            this.AddEmployeeDataButton.Size = new System.Drawing.Size(25, 23);
            this.AddEmployeeDataButton.TabIndex = 0;
            this.InformationToolTip.SetToolTip(this.AddEmployeeDataButton, "Добавить нового сотрудника");
            this.AddEmployeeDataButton.UseVisualStyleBackColor = true;
            this.AddEmployeeDataButton.Click += new System.EventHandler(this.AddEmployeeDataButton_Click);
            // 
            // EditEmployeeDataButton
            // 
            this.EditEmployeeDataButton.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EditEmployeeDataButton.Image = global::BloodAnalysisApplication_Client.Properties.Resources.edit;
            this.EditEmployeeDataButton.Location = new System.Drawing.Point(471, 185);
            this.EditEmployeeDataButton.Name = "EditEmployeeDataButton";
            this.EditEmployeeDataButton.Size = new System.Drawing.Size(25, 23);
            this.EditEmployeeDataButton.TabIndex = 0;
            this.InformationToolTip.SetToolTip(this.EditEmployeeDataButton, "Изменить данные сотрудника");
            this.EditEmployeeDataButton.UseVisualStyleBackColor = true;
            this.EditEmployeeDataButton.Click += new System.EventHandler(this.EditEmployeeDataButton_Click);
            // 
            // DeleteEmployeeDataButton
            // 
            this.DeleteEmployeeDataButton.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DeleteEmployeeDataButton.Image = global::BloodAnalysisApplication_Client.Properties.Resources.delete;
            this.DeleteEmployeeDataButton.Location = new System.Drawing.Point(502, 185);
            this.DeleteEmployeeDataButton.Name = "DeleteEmployeeDataButton";
            this.DeleteEmployeeDataButton.Size = new System.Drawing.Size(25, 23);
            this.DeleteEmployeeDataButton.TabIndex = 0;
            this.InformationToolTip.SetToolTip(this.DeleteEmployeeDataButton, "Удалить данные сотрудника");
            this.DeleteEmployeeDataButton.UseVisualStyleBackColor = true;
            // 
            // NextEmployeeDataButton
            // 
            this.NextEmployeeDataButton.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NextEmployeeDataButton.Image = global::BloodAnalysisApplication_Client.Properties.Resources.next;
            this.NextEmployeeDataButton.Location = new System.Drawing.Point(182, 185);
            this.NextEmployeeDataButton.Name = "NextEmployeeDataButton";
            this.NextEmployeeDataButton.Size = new System.Drawing.Size(25, 23);
            this.NextEmployeeDataButton.TabIndex = 0;
            this.InformationToolTip.SetToolTip(this.NextEmployeeDataButton, "Следующая запись");
            this.NextEmployeeDataButton.UseVisualStyleBackColor = true;
            this.NextEmployeeDataButton.Click += new System.EventHandler(this.NextEmployeeDataButton_Click);
            // 
            // PreviousEmployeeDataButton
            // 
            this.PreviousEmployeeDataButton.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PreviousEmployeeDataButton.Image = global::BloodAnalysisApplication_Client.Properties.Resources.previous;
            this.PreviousEmployeeDataButton.Location = new System.Drawing.Point(54, 185);
            this.PreviousEmployeeDataButton.Name = "PreviousEmployeeDataButton";
            this.PreviousEmployeeDataButton.Size = new System.Drawing.Size(25, 23);
            this.PreviousEmployeeDataButton.TabIndex = 0;
            this.InformationToolTip.SetToolTip(this.PreviousEmployeeDataButton, "Предыдущая запись");
            this.PreviousEmployeeDataButton.UseVisualStyleBackColor = true;
            this.PreviousEmployeeDataButton.Click += new System.EventHandler(this.PreviousEmployeeDataButton_Click);
            // 
            // LastEmployeeDataButton
            // 
            this.LastEmployeeDataButton.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LastEmployeeDataButton.Image = global::BloodAnalysisApplication_Client.Properties.Resources.last;
            this.LastEmployeeDataButton.Location = new System.Drawing.Point(213, 185);
            this.LastEmployeeDataButton.Name = "LastEmployeeDataButton";
            this.LastEmployeeDataButton.Size = new System.Drawing.Size(31, 23);
            this.LastEmployeeDataButton.TabIndex = 0;
            this.InformationToolTip.SetToolTip(this.LastEmployeeDataButton, "Последняя запись");
            this.LastEmployeeDataButton.UseVisualStyleBackColor = true;
            this.LastEmployeeDataButton.Click += new System.EventHandler(this.LastEmployeeDataButton_Click);
            // 
            // FirstEmployeeDataButton
            // 
            this.FirstEmployeeDataButton.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FirstEmployeeDataButton.Image = global::BloodAnalysisApplication_Client.Properties.Resources.first;
            this.FirstEmployeeDataButton.Location = new System.Drawing.Point(17, 185);
            this.FirstEmployeeDataButton.Name = "FirstEmployeeDataButton";
            this.FirstEmployeeDataButton.Size = new System.Drawing.Size(31, 23);
            this.FirstEmployeeDataButton.TabIndex = 0;
            this.InformationToolTip.SetToolTip(this.FirstEmployeeDataButton, "Первая запись");
            this.FirstEmployeeDataButton.UseVisualStyleBackColor = true;
            this.FirstEmployeeDataButton.Click += new System.EventHandler(this.FirstEmployeeDataButton_Click);
            // 
            // AdministrateWorkMenuStrip
            // 
            this.AdministrateWorkMenuStrip.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AdministrateWorkMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DataToolStripMenuItem,
            this.SettingToolStripMenuItem});
            this.AdministrateWorkMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.AdministrateWorkMenuStrip.Name = "AdministrateWorkMenuStrip";
            this.AdministrateWorkMenuStrip.Size = new System.Drawing.Size(569, 25);
            this.AdministrateWorkMenuStrip.TabIndex = 1;
            // 
            // DataToolStripMenuItem
            // 
            this.DataToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddDataToolStripMenuItem,
            this.EditDataToolStripMenuItem,
            this.DeleteDataToolStripMenuItem});
            this.DataToolStripMenuItem.Name = "DataToolStripMenuItem";
            this.DataToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.DataToolStripMenuItem.Text = "Данные";
            // 
            // AddDataToolStripMenuItem
            // 
            this.AddDataToolStripMenuItem.Name = "AddDataToolStripMenuItem";
            this.AddDataToolStripMenuItem.Size = new System.Drawing.Size(262, 22);
            this.AddDataToolStripMenuItem.Text = "Добавить нового сотрудника";
            // 
            // EditDataToolStripMenuItem
            // 
            this.EditDataToolStripMenuItem.Name = "EditDataToolStripMenuItem";
            this.EditDataToolStripMenuItem.Size = new System.Drawing.Size(262, 22);
            this.EditDataToolStripMenuItem.Text = "Изменить данные сотрудника";
            // 
            // DeleteDataToolStripMenuItem
            // 
            this.DeleteDataToolStripMenuItem.Name = "DeleteDataToolStripMenuItem";
            this.DeleteDataToolStripMenuItem.Size = new System.Drawing.Size(262, 22);
            this.DeleteDataToolStripMenuItem.Text = "Удалить данные сотрудника";
            // 
            // SettingToolStripMenuItem
            // 
            this.SettingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.EditPasswordToolStripMenuItem,
            this.ThirdToolStripSeparator,
            this.SystemExitToolStripMenuItem});
            this.SettingToolStripMenuItem.Name = "SettingToolStripMenuItem";
            this.SettingToolStripMenuItem.Size = new System.Drawing.Size(87, 21);
            this.SettingToolStripMenuItem.Text = "Настройки";
            // 
            // EditPasswordToolStripMenuItem
            // 
            this.EditPasswordToolStripMenuItem.Name = "EditPasswordToolStripMenuItem";
            this.EditPasswordToolStripMenuItem.Size = new System.Drawing.Size(242, 22);
            this.EditPasswordToolStripMenuItem.Text = "Изменить пароль";
            // 
            // ThirdToolStripSeparator
            // 
            this.ThirdToolStripSeparator.Name = "ThirdToolStripSeparator";
            this.ThirdToolStripSeparator.Size = new System.Drawing.Size(239, 6);
            // 
            // SystemExitToolStripMenuItem
            // 
            this.SystemExitToolStripMenuItem.Name = "SystemExitToolStripMenuItem";
            this.SystemExitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.SystemExitToolStripMenuItem.Size = new System.Drawing.Size(242, 22);
            this.SystemExitToolStripMenuItem.Text = "Выйти из системы";
            // 
            // ViewEmployeeDataGroupBox
            // 
            this.ViewEmployeeDataGroupBox.Controls.Add(this.ViewEmployeeStaffDataGroupBox);
            this.ViewEmployeeDataGroupBox.Controls.Add(this.ViewPersonalEmployeeDataGroupBox);
            this.ViewEmployeeDataGroupBox.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ViewEmployeeDataGroupBox.Location = new System.Drawing.Point(12, 244);
            this.ViewEmployeeDataGroupBox.Name = "ViewEmployeeDataGroupBox";
            this.ViewEmployeeDataGroupBox.Size = new System.Drawing.Size(545, 170);
            this.ViewEmployeeDataGroupBox.TabIndex = 11;
            this.ViewEmployeeDataGroupBox.TabStop = false;
            this.ViewEmployeeDataGroupBox.Text = "Данные выбранного сотрудника";
            // 
            // ViewEmployeeStaffDataGroupBox
            // 
            this.ViewEmployeeStaffDataGroupBox.Controls.Add(this.NowStatusWorkEmployeePictureBox);
            this.ViewEmployeeStaffDataGroupBox.Controls.Add(this.NowStatusWorkEmployeeLabel);
            this.ViewEmployeeStaffDataGroupBox.Controls.Add(this.ViewEmployeePasswordLabel);
            this.ViewEmployeeStaffDataGroupBox.Controls.Add(this.ViewEmployeeProfessionalLabel);
            this.ViewEmployeeStaffDataGroupBox.Controls.Add(this.EmployeePasswordLabel);
            this.ViewEmployeeStaffDataGroupBox.Controls.Add(this.ViewEmployeeContractNumberLabel);
            this.ViewEmployeeStaffDataGroupBox.Controls.Add(this.EmployeeProfessionalLabel);
            this.ViewEmployeeStaffDataGroupBox.Controls.Add(this.EmployeeContractNumberLabel);
            this.ViewEmployeeStaffDataGroupBox.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ViewEmployeeStaffDataGroupBox.Location = new System.Drawing.Point(251, 18);
            this.ViewEmployeeStaffDataGroupBox.Name = "ViewEmployeeStaffDataGroupBox";
            this.ViewEmployeeStaffDataGroupBox.Size = new System.Drawing.Size(285, 146);
            this.ViewEmployeeStaffDataGroupBox.TabIndex = 42;
            this.ViewEmployeeStaffDataGroupBox.TabStop = false;
            this.ViewEmployeeStaffDataGroupBox.Text = "Штатные данные сотрудника";
            // 
            // NowStatusWorkEmployeePictureBox
            // 
            this.NowStatusWorkEmployeePictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NowStatusWorkEmployeePictureBox.Image = global::BloodAnalysisApplication_Client.Properties.Resources.yes;
            this.NowStatusWorkEmployeePictureBox.Location = new System.Drawing.Point(214, 117);
            this.NowStatusWorkEmployeePictureBox.Name = "NowStatusWorkEmployeePictureBox";
            this.NowStatusWorkEmployeePictureBox.Size = new System.Drawing.Size(19, 19);
            this.NowStatusWorkEmployeePictureBox.TabIndex = 36;
            this.NowStatusWorkEmployeePictureBox.TabStop = false;
            // 
            // NowStatusWorkEmployeeLabel
            // 
            this.NowStatusWorkEmployeeLabel.AutoSize = true;
            this.NowStatusWorkEmployeeLabel.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NowStatusWorkEmployeeLabel.Location = new System.Drawing.Point(43, 121);
            this.NowStatusWorkEmployeeLabel.Name = "NowStatusWorkEmployeeLabel";
            this.NowStatusWorkEmployeeLabel.Size = new System.Drawing.Size(163, 15);
            this.NowStatusWorkEmployeeLabel.TabIndex = 35;
            this.NowStatusWorkEmployeeLabel.Text = "Работает на данный момент";
            // 
            // ViewEmployeePasswordLabel
            // 
            this.ViewEmployeePasswordLabel.BackColor = System.Drawing.SystemColors.Control;
            this.ViewEmployeePasswordLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ViewEmployeePasswordLabel.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ViewEmployeePasswordLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ViewEmployeePasswordLabel.Location = new System.Drawing.Point(148, 91);
            this.ViewEmployeePasswordLabel.Name = "ViewEmployeePasswordLabel";
            this.ViewEmployeePasswordLabel.Size = new System.Drawing.Size(129, 21);
            this.ViewEmployeePasswordLabel.TabIndex = 30;
            this.ViewEmployeePasswordLabel.Text = "пароль";
            this.ViewEmployeePasswordLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ViewEmployeeProfessionalLabel
            // 
            this.ViewEmployeeProfessionalLabel.BackColor = System.Drawing.SystemColors.Control;
            this.ViewEmployeeProfessionalLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ViewEmployeeProfessionalLabel.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ViewEmployeeProfessionalLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ViewEmployeeProfessionalLabel.Location = new System.Drawing.Point(148, 48);
            this.ViewEmployeeProfessionalLabel.Name = "ViewEmployeeProfessionalLabel";
            this.ViewEmployeeProfessionalLabel.Size = new System.Drawing.Size(130, 36);
            this.ViewEmployeeProfessionalLabel.TabIndex = 31;
            this.ViewEmployeeProfessionalLabel.Text = "должность";
            this.ViewEmployeeProfessionalLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // EmployeePasswordLabel
            // 
            this.EmployeePasswordLabel.AutoSize = true;
            this.EmployeePasswordLabel.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EmployeePasswordLabel.Location = new System.Drawing.Point(7, 94);
            this.EmployeePasswordLabel.Name = "EmployeePasswordLabel";
            this.EmployeePasswordLabel.Size = new System.Drawing.Size(114, 15);
            this.EmployeePasswordLabel.TabIndex = 27;
            this.EmployeePasswordLabel.Text = "Пароль сотрудника";
            this.EmployeePasswordLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ViewEmployeeContractNumberLabel
            // 
            this.ViewEmployeeContractNumberLabel.BackColor = System.Drawing.SystemColors.Control;
            this.ViewEmployeeContractNumberLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ViewEmployeeContractNumberLabel.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ViewEmployeeContractNumberLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ViewEmployeeContractNumberLabel.Location = new System.Drawing.Point(148, 21);
            this.ViewEmployeeContractNumberLabel.Name = "ViewEmployeeContractNumberLabel";
            this.ViewEmployeeContractNumberLabel.Size = new System.Drawing.Size(129, 21);
            this.ViewEmployeeContractNumberLabel.TabIndex = 30;
            this.ViewEmployeeContractNumberLabel.Text = "ТД-00/00000000";
            this.ViewEmployeeContractNumberLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // EmployeeProfessionalLabel
            // 
            this.EmployeeProfessionalLabel.AutoSize = true;
            this.EmployeeProfessionalLabel.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EmployeeProfessionalLabel.Location = new System.Drawing.Point(7, 59);
            this.EmployeeProfessionalLabel.Name = "EmployeeProfessionalLabel";
            this.EmployeeProfessionalLabel.Size = new System.Drawing.Size(135, 15);
            this.EmployeeProfessionalLabel.TabIndex = 28;
            this.EmployeeProfessionalLabel.Text = "Должность сотрудника";
            // 
            // EmployeeContractNumberLabel
            // 
            this.EmployeeContractNumberLabel.AutoSize = true;
            this.EmployeeContractNumberLabel.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EmployeeContractNumberLabel.Location = new System.Drawing.Point(7, 24);
            this.EmployeeContractNumberLabel.Name = "EmployeeContractNumberLabel";
            this.EmployeeContractNumberLabel.Size = new System.Drawing.Size(132, 15);
            this.EmployeeContractNumberLabel.TabIndex = 27;
            this.EmployeeContractNumberLabel.Text = "№ трудового договора";
            this.EmployeeContractNumberLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ViewPersonalEmployeeDataGroupBox
            // 
            this.ViewPersonalEmployeeDataGroupBox.Controls.Add(this.ViewEmployeeGenderLabel);
            this.ViewPersonalEmployeeDataGroupBox.Controls.Add(this.EmployeeGenderLabel);
            this.ViewPersonalEmployeeDataGroupBox.Controls.Add(this.ViewEmployeeBirthdayLabel);
            this.ViewPersonalEmployeeDataGroupBox.Controls.Add(this.EmployeeBirthdayLabel);
            this.ViewPersonalEmployeeDataGroupBox.Controls.Add(this.ViewEmployeePatronimicLabel);
            this.ViewPersonalEmployeeDataGroupBox.Controls.Add(this.ViewEmployeeNameLabel);
            this.ViewPersonalEmployeeDataGroupBox.Controls.Add(this.ViewEmployeeSurnameLabel);
            this.ViewPersonalEmployeeDataGroupBox.Controls.Add(this.EmployeePatronimicLabel);
            this.ViewPersonalEmployeeDataGroupBox.Controls.Add(this.EmployeeNameLabel);
            this.ViewPersonalEmployeeDataGroupBox.Controls.Add(this.EmployeeSurnameLabel);
            this.ViewPersonalEmployeeDataGroupBox.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ViewPersonalEmployeeDataGroupBox.Location = new System.Drawing.Point(7, 18);
            this.ViewPersonalEmployeeDataGroupBox.Name = "ViewPersonalEmployeeDataGroupBox";
            this.ViewPersonalEmployeeDataGroupBox.Size = new System.Drawing.Size(238, 146);
            this.ViewPersonalEmployeeDataGroupBox.TabIndex = 41;
            this.ViewPersonalEmployeeDataGroupBox.TabStop = false;
            this.ViewPersonalEmployeeDataGroupBox.Text = "Персональные данные сотрудника";
            // 
            // ViewEmployeeGenderLabel
            // 
            this.ViewEmployeeGenderLabel.BackColor = System.Drawing.SystemColors.Control;
            this.ViewEmployeeGenderLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ViewEmployeeGenderLabel.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ViewEmployeeGenderLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ViewEmployeeGenderLabel.Location = new System.Drawing.Point(203, 113);
            this.ViewEmployeeGenderLabel.Name = "ViewEmployeeGenderLabel";
            this.ViewEmployeeGenderLabel.Size = new System.Drawing.Size(25, 21);
            this.ViewEmployeeGenderLabel.TabIndex = 37;
            this.ViewEmployeeGenderLabel.Text = "П";
            this.ViewEmployeeGenderLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // EmployeeGenderLabel
            // 
            this.EmployeeGenderLabel.AutoSize = true;
            this.EmployeeGenderLabel.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EmployeeGenderLabel.Location = new System.Drawing.Point(172, 116);
            this.EmployeeGenderLabel.Name = "EmployeeGenderLabel";
            this.EmployeeGenderLabel.Size = new System.Drawing.Size(29, 15);
            this.EmployeeGenderLabel.TabIndex = 36;
            this.EmployeeGenderLabel.Text = "Пол";
            // 
            // ViewEmployeeBirthdayLabel
            // 
            this.ViewEmployeeBirthdayLabel.BackColor = System.Drawing.SystemColors.Control;
            this.ViewEmployeeBirthdayLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ViewEmployeeBirthdayLabel.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ViewEmployeeBirthdayLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ViewEmployeeBirthdayLabel.Location = new System.Drawing.Point(98, 113);
            this.ViewEmployeeBirthdayLabel.Name = "ViewEmployeeBirthdayLabel";
            this.ViewEmployeeBirthdayLabel.Size = new System.Drawing.Size(67, 21);
            this.ViewEmployeeBirthdayLabel.TabIndex = 34;
            this.ViewEmployeeBirthdayLabel.Text = "00.00.0000";
            this.ViewEmployeeBirthdayLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // EmployeeBirthdayLabel
            // 
            this.EmployeeBirthdayLabel.AutoSize = true;
            this.EmployeeBirthdayLabel.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EmployeeBirthdayLabel.Location = new System.Drawing.Point(5, 116);
            this.EmployeeBirthdayLabel.Name = "EmployeeBirthdayLabel";
            this.EmployeeBirthdayLabel.Size = new System.Drawing.Size(91, 15);
            this.EmployeeBirthdayLabel.TabIndex = 33;
            this.EmployeeBirthdayLabel.Text = "Дата рождения";
            // 
            // ViewEmployeePatronimicLabel
            // 
            this.ViewEmployeePatronimicLabel.BackColor = System.Drawing.SystemColors.Control;
            this.ViewEmployeePatronimicLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ViewEmployeePatronimicLabel.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ViewEmployeePatronimicLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ViewEmployeePatronimicLabel.Location = new System.Drawing.Point(98, 84);
            this.ViewEmployeePatronimicLabel.Name = "ViewEmployeePatronimicLabel";
            this.ViewEmployeePatronimicLabel.Size = new System.Drawing.Size(130, 21);
            this.ViewEmployeePatronimicLabel.TabIndex = 32;
            this.ViewEmployeePatronimicLabel.Text = "Отчество";
            this.ViewEmployeePatronimicLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ViewEmployeeNameLabel
            // 
            this.ViewEmployeeNameLabel.BackColor = System.Drawing.SystemColors.Control;
            this.ViewEmployeeNameLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ViewEmployeeNameLabel.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ViewEmployeeNameLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ViewEmployeeNameLabel.Location = new System.Drawing.Point(98, 53);
            this.ViewEmployeeNameLabel.Name = "ViewEmployeeNameLabel";
            this.ViewEmployeeNameLabel.Size = new System.Drawing.Size(130, 21);
            this.ViewEmployeeNameLabel.TabIndex = 31;
            this.ViewEmployeeNameLabel.Text = "Имя";
            this.ViewEmployeeNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ViewEmployeeSurnameLabel
            // 
            this.ViewEmployeeSurnameLabel.BackColor = System.Drawing.SystemColors.Control;
            this.ViewEmployeeSurnameLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ViewEmployeeSurnameLabel.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ViewEmployeeSurnameLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ViewEmployeeSurnameLabel.Location = new System.Drawing.Point(98, 23);
            this.ViewEmployeeSurnameLabel.Name = "ViewEmployeeSurnameLabel";
            this.ViewEmployeeSurnameLabel.Size = new System.Drawing.Size(130, 21);
            this.ViewEmployeeSurnameLabel.TabIndex = 30;
            this.ViewEmployeeSurnameLabel.Text = "Фамилия";
            this.ViewEmployeeSurnameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // EmployeePatronimicLabel
            // 
            this.EmployeePatronimicLabel.AutoSize = true;
            this.EmployeePatronimicLabel.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EmployeePatronimicLabel.Location = new System.Drawing.Point(5, 87);
            this.EmployeePatronimicLabel.Name = "EmployeePatronimicLabel";
            this.EmployeePatronimicLabel.Size = new System.Drawing.Size(58, 15);
            this.EmployeePatronimicLabel.TabIndex = 29;
            this.EmployeePatronimicLabel.Text = "Отчество";
            // 
            // EmployeeNameLabel
            // 
            this.EmployeeNameLabel.AutoSize = true;
            this.EmployeeNameLabel.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EmployeeNameLabel.Location = new System.Drawing.Point(5, 57);
            this.EmployeeNameLabel.Name = "EmployeeNameLabel";
            this.EmployeeNameLabel.Size = new System.Drawing.Size(31, 15);
            this.EmployeeNameLabel.TabIndex = 28;
            this.EmployeeNameLabel.Text = "Имя";
            // 
            // EmployeeSurnameLabel
            // 
            this.EmployeeSurnameLabel.AutoSize = true;
            this.EmployeeSurnameLabel.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EmployeeSurnameLabel.Location = new System.Drawing.Point(5, 26);
            this.EmployeeSurnameLabel.Name = "EmployeeSurnameLabel";
            this.EmployeeSurnameLabel.Size = new System.Drawing.Size(58, 15);
            this.EmployeeSurnameLabel.TabIndex = 27;
            this.EmployeeSurnameLabel.Text = "Фамилия";
            // 
            // EmployeeDataTableGroupBox
            // 
            this.EmployeeDataTableGroupBox.Controls.Add(this.AllEmployeeDataNumberLabel);
            this.EmployeeDataTableGroupBox.Controls.Add(this.SelectEmployeeDataNumberLabel);
            this.EmployeeDataTableGroupBox.Controls.Add(this.AddEmployeeDataButton);
            this.EmployeeDataTableGroupBox.Controls.Add(this.EditEmployeeDataButton);
            this.EmployeeDataTableGroupBox.Controls.Add(this.DeleteEmployeeDataButton);
            this.EmployeeDataTableGroupBox.Controls.Add(this.AllEmployeeDataLabel);
            this.EmployeeDataTableGroupBox.Controls.Add(this.NextEmployeeDataButton);
            this.EmployeeDataTableGroupBox.Controls.Add(this.PreviousEmployeeDataButton);
            this.EmployeeDataTableGroupBox.Controls.Add(this.LastEmployeeDataButton);
            this.EmployeeDataTableGroupBox.Controls.Add(this.FirstEmployeeDataButton);
            this.EmployeeDataTableGroupBox.Controls.Add(this.EmployeeDataGridView);
            this.EmployeeDataTableGroupBox.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EmployeeDataTableGroupBox.Location = new System.Drawing.Point(12, 28);
            this.EmployeeDataTableGroupBox.Name = "EmployeeDataTableGroupBox";
            this.EmployeeDataTableGroupBox.Size = new System.Drawing.Size(545, 215);
            this.EmployeeDataTableGroupBox.TabIndex = 10;
            this.EmployeeDataTableGroupBox.TabStop = false;
            this.EmployeeDataTableGroupBox.Text = "Таблица с данными сотрудников лаборатории";
            // 
            // AllEmployeeDataNumberLabel
            // 
            this.AllEmployeeDataNumberLabel.BackColor = System.Drawing.SystemColors.Control;
            this.AllEmployeeDataNumberLabel.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AllEmployeeDataNumberLabel.Location = new System.Drawing.Point(142, 186);
            this.AllEmployeeDataNumberLabel.Name = "AllEmployeeDataNumberLabel";
            this.AllEmployeeDataNumberLabel.Size = new System.Drawing.Size(34, 22);
            this.AllEmployeeDataNumberLabel.TabIndex = 43;
            this.AllEmployeeDataNumberLabel.Text = "0";
            this.AllEmployeeDataNumberLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SelectEmployeeDataNumberLabel
            // 
            this.SelectEmployeeDataNumberLabel.BackColor = System.Drawing.SystemColors.Control;
            this.SelectEmployeeDataNumberLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SelectEmployeeDataNumberLabel.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SelectEmployeeDataNumberLabel.Location = new System.Drawing.Point(85, 186);
            this.SelectEmployeeDataNumberLabel.Name = "SelectEmployeeDataNumberLabel";
            this.SelectEmployeeDataNumberLabel.Size = new System.Drawing.Size(34, 22);
            this.SelectEmployeeDataNumberLabel.TabIndex = 42;
            this.SelectEmployeeDataNumberLabel.Text = "0";
            this.SelectEmployeeDataNumberLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AllEmployeeDataLabel
            // 
            this.AllEmployeeDataLabel.AutoSize = true;
            this.AllEmployeeDataLabel.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AllEmployeeDataLabel.Location = new System.Drawing.Point(122, 190);
            this.AllEmployeeDataLabel.Name = "AllEmployeeDataLabel";
            this.AllEmployeeDataLabel.Size = new System.Drawing.Size(19, 15);
            this.AllEmployeeDataLabel.TabIndex = 37;
            this.AllEmployeeDataLabel.Text = "из";
            // 
            // EmployeeDataGridView
            // 
            this.EmployeeDataGridView.Location = new System.Drawing.Point(18, 24);
            this.EmployeeDataGridView.Name = "EmployeeDataGridView";
            this.EmployeeDataGridView.Size = new System.Drawing.Size(508, 158);
            this.EmployeeDataGridView.TabIndex = 7;
            // 
            // AdministrateWorkForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 424);
            this.Controls.Add(this.ViewEmployeeDataGroupBox);
            this.Controls.Add(this.EmployeeDataTableGroupBox);
            this.Controls.Add(this.AdministrateWorkMenuStrip);
            this.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.AdministrateWorkMenuStrip;
            this.MaximizeBox = false;
            this.Name = "AdministrateWorkForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Система для проведения общего анализа крови: Администратор";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AdministrateWorkForm_FormClosing);
            this.AdministrateWorkMenuStrip.ResumeLayout(false);
            this.AdministrateWorkMenuStrip.PerformLayout();
            this.ViewEmployeeDataGroupBox.ResumeLayout(false);
            this.ViewEmployeeStaffDataGroupBox.ResumeLayout(false);
            this.ViewEmployeeStaffDataGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NowStatusWorkEmployeePictureBox)).EndInit();
            this.ViewPersonalEmployeeDataGroupBox.ResumeLayout(false);
            this.ViewPersonalEmployeeDataGroupBox.PerformLayout();
            this.EmployeeDataTableGroupBox.ResumeLayout(false);
            this.EmployeeDataTableGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EmployeeDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolTip InformationToolTip;
        private System.Windows.Forms.MenuStrip AdministrateWorkMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem DataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AddDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem EditDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DeleteDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SettingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem EditPasswordToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator ThirdToolStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem SystemExitToolStripMenuItem;
        private System.Windows.Forms.GroupBox ViewEmployeeDataGroupBox;
        public System.Windows.Forms.Label ViewEmployeePasswordLabel;
        private System.Windows.Forms.Label EmployeePasswordLabel;
        private System.Windows.Forms.GroupBox ViewEmployeeStaffDataGroupBox;
        private System.Windows.Forms.PictureBox NowStatusWorkEmployeePictureBox;
        private System.Windows.Forms.Label NowStatusWorkEmployeeLabel;
        public System.Windows.Forms.Label ViewEmployeeProfessionalLabel;
        public System.Windows.Forms.Label ViewEmployeeContractNumberLabel;
        private System.Windows.Forms.Label EmployeeProfessionalLabel;
        private System.Windows.Forms.Label EmployeeContractNumberLabel;
        private System.Windows.Forms.GroupBox ViewPersonalEmployeeDataGroupBox;
        public System.Windows.Forms.Label ViewEmployeeGenderLabel;
        private System.Windows.Forms.Label EmployeeGenderLabel;
        private System.Windows.Forms.Label ViewEmployeeBirthdayLabel;
        private System.Windows.Forms.Label EmployeeBirthdayLabel;
        public System.Windows.Forms.Label ViewEmployeePatronimicLabel;
        public System.Windows.Forms.Label ViewEmployeeNameLabel;
        public System.Windows.Forms.Label ViewEmployeeSurnameLabel;
        private System.Windows.Forms.Label EmployeePatronimicLabel;
        private System.Windows.Forms.Label EmployeeNameLabel;
        private System.Windows.Forms.Label EmployeeSurnameLabel;
        private System.Windows.Forms.GroupBox EmployeeDataTableGroupBox;
        public System.Windows.Forms.Label AllEmployeeDataNumberLabel;
        public System.Windows.Forms.Label SelectEmployeeDataNumberLabel;
        private System.Windows.Forms.Button AddEmployeeDataButton;
        private System.Windows.Forms.Button EditEmployeeDataButton;
        private System.Windows.Forms.Button DeleteEmployeeDataButton;
        private System.Windows.Forms.Label AllEmployeeDataLabel;
        private System.Windows.Forms.Button NextEmployeeDataButton;
        private System.Windows.Forms.Button PreviousEmployeeDataButton;
        private System.Windows.Forms.Button LastEmployeeDataButton;
        private System.Windows.Forms.Button FirstEmployeeDataButton;
        private System.Windows.Forms.DataGridView EmployeeDataGridView;
    }
}