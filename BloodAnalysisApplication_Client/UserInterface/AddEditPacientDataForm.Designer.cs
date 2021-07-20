namespace BloodAnalysisApplication_Client.UserInterface
{
    partial class AddEditPacientDataForm
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
            this.MedicalLicencePacientGroupBox = new System.Windows.Forms.GroupBox();
            this.MedicalPacientLicenceNumMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.MedicalLicencePacientDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label18 = new System.Windows.Forms.Label();
            this.SNILSPacientGroupBox = new System.Windows.Forms.GroupBox();
            this.SNILSNumberPacientMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.SNILSDatePacientDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label13 = new System.Windows.Forms.Label();
            this.PersonalDataPacientGroupBox = new System.Windows.Forms.GroupBox();
            this.PhoneNumberPacientMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.EnterBirthdayPacientDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.EnterGenderPacientComboBox = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.EnterPatronimicPacientTextBox = new System.Windows.Forms.TextBox();
            this.EnterNamePacientTextBox = new System.Windows.Forms.TextBox();
            this.EnterSurnamePacientTextBox = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.EnterMedicalPlaceComboBox = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.ViewMedicalNumPacientLabel = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.EnterMedicalNumPacientTextBox = new System.Windows.Forms.TextBox();
            this.AddEditPacientButton = new System.Windows.Forms.Button();
            this.ClearEnterDataPacientButton = new System.Windows.Forms.Button();
            this.CancelAddEditButton = new System.Windows.Forms.Button();
            this.MedicalLicencePacientGroupBox.SuspendLayout();
            this.SNILSPacientGroupBox.SuspendLayout();
            this.PersonalDataPacientGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // MedicalLicencePacientGroupBox
            // 
            this.MedicalLicencePacientGroupBox.Controls.Add(this.MedicalPacientLicenceNumMaskedTextBox);
            this.MedicalLicencePacientGroupBox.Controls.Add(this.label17);
            this.MedicalLicencePacientGroupBox.Controls.Add(this.MedicalLicencePacientDateTimePicker);
            this.MedicalLicencePacientGroupBox.Controls.Add(this.label18);
            this.MedicalLicencePacientGroupBox.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MedicalLicencePacientGroupBox.Location = new System.Drawing.Point(325, 137);
            this.MedicalLicencePacientGroupBox.Name = "MedicalLicencePacientGroupBox";
            this.MedicalLicencePacientGroupBox.Size = new System.Drawing.Size(247, 81);
            this.MedicalLicencePacientGroupBox.TabIndex = 26;
            this.MedicalLicencePacientGroupBox.TabStop = false;
            this.MedicalLicencePacientGroupBox.Text = "Медицинский полис";
            // 
            // MedicalPacientLicenceNumMaskedTextBox
            // 
            this.MedicalPacientLicenceNumMaskedTextBox.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MedicalPacientLicenceNumMaskedTextBox.Location = new System.Drawing.Point(116, 24);
            this.MedicalPacientLicenceNumMaskedTextBox.Mask = "9999 9999 9999 9999";
            this.MedicalPacientLicenceNumMaskedTextBox.Name = "MedicalPacientLicenceNumMaskedTextBox";
            this.MedicalPacientLicenceNumMaskedTextBox.Size = new System.Drawing.Size(127, 22);
            this.MedicalPacientLicenceNumMaskedTextBox.TabIndex = 23;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label17.Location = new System.Drawing.Point(26, 27);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(87, 15);
            this.label17.TabIndex = 22;
            this.label17.Text = "Номер полиса";
            // 
            // MedicalLicencePacientDateTimePicker
            // 
            this.MedicalLicencePacientDateTimePicker.CalendarFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MedicalLicencePacientDateTimePicker.Checked = false;
            this.MedicalLicencePacientDateTimePicker.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MedicalLicencePacientDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.MedicalLicencePacientDateTimePicker.Location = new System.Drawing.Point(116, 49);
            this.MedicalLicencePacientDateTimePicker.MinDate = new System.DateTime(1993, 1, 1, 0, 0, 0, 0);
            this.MedicalLicencePacientDateTimePicker.Name = "MedicalLicencePacientDateTimePicker";
            this.MedicalLicencePacientDateTimePicker.Size = new System.Drawing.Size(94, 22);
            this.MedicalLicencePacientDateTimePicker.TabIndex = 21;
            this.MedicalLicencePacientDateTimePicker.Value = new System.DateTime(2019, 4, 2, 0, 0, 0, 0);
            this.MedicalLicencePacientDateTimePicker.Enter += new System.EventHandler(this.MedicalLicencePacientDateTimePicker_Enter);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label18.Location = new System.Drawing.Point(7, 53);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(106, 15);
            this.label18.TabIndex = 20;
            this.label18.Text = "Дата регистрации";
            // 
            // SNILSPacientGroupBox
            // 
            this.SNILSPacientGroupBox.Controls.Add(this.SNILSNumberPacientMaskedTextBox);
            this.SNILSPacientGroupBox.Controls.Add(this.label12);
            this.SNILSPacientGroupBox.Controls.Add(this.SNILSDatePacientDateTimePicker);
            this.SNILSPacientGroupBox.Controls.Add(this.label13);
            this.SNILSPacientGroupBox.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SNILSPacientGroupBox.Location = new System.Drawing.Point(325, 48);
            this.SNILSPacientGroupBox.Name = "SNILSPacientGroupBox";
            this.SNILSPacientGroupBox.Size = new System.Drawing.Size(247, 81);
            this.SNILSPacientGroupBox.TabIndex = 25;
            this.SNILSPacientGroupBox.TabStop = false;
            this.SNILSPacientGroupBox.Text = "СНИЛС";
            // 
            // SNILSNumberPacientMaskedTextBox
            // 
            this.SNILSNumberPacientMaskedTextBox.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SNILSNumberPacientMaskedTextBox.Location = new System.Drawing.Point(131, 23);
            this.SNILSNumberPacientMaskedTextBox.Mask = "999-999-999 99";
            this.SNILSNumberPacientMaskedTextBox.Name = "SNILSNumberPacientMaskedTextBox";
            this.SNILSNumberPacientMaskedTextBox.Size = new System.Drawing.Size(94, 22);
            this.SNILSNumberPacientMaskedTextBox.TabIndex = 23;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label12.Location = new System.Drawing.Point(38, 26);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(91, 15);
            this.label12.TabIndex = 22;
            this.label12.Text = "Номер СНИЛС";
            // 
            // SNILSDatePacientDateTimePicker
            // 
            this.SNILSDatePacientDateTimePicker.CalendarFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SNILSDatePacientDateTimePicker.Checked = false;
            this.SNILSDatePacientDateTimePicker.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SNILSDatePacientDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.SNILSDatePacientDateTimePicker.Location = new System.Drawing.Point(131, 49);
            this.SNILSDatePacientDateTimePicker.MinDate = new System.DateTime(2003, 1, 1, 0, 0, 0, 0);
            this.SNILSDatePacientDateTimePicker.Name = "SNILSDatePacientDateTimePicker";
            this.SNILSDatePacientDateTimePicker.Size = new System.Drawing.Size(94, 22);
            this.SNILSDatePacientDateTimePicker.TabIndex = 21;
            this.SNILSDatePacientDateTimePicker.Value = new System.DateTime(2019, 4, 2, 0, 0, 0, 0);
            this.SNILSDatePacientDateTimePicker.Enter += new System.EventHandler(this.SNILSDatePacientDateTimePicker_Enter);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label13.Location = new System.Drawing.Point(23, 52);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(106, 15);
            this.label13.TabIndex = 20;
            this.label13.Text = "Дата регистрации";
            // 
            // PersonalDataPacientGroupBox
            // 
            this.PersonalDataPacientGroupBox.Controls.Add(this.PhoneNumberPacientMaskedTextBox);
            this.PersonalDataPacientGroupBox.Controls.Add(this.label11);
            this.PersonalDataPacientGroupBox.Controls.Add(this.EnterBirthdayPacientDateTimePicker);
            this.PersonalDataPacientGroupBox.Controls.Add(this.label10);
            this.PersonalDataPacientGroupBox.Controls.Add(this.EnterGenderPacientComboBox);
            this.PersonalDataPacientGroupBox.Controls.Add(this.label7);
            this.PersonalDataPacientGroupBox.Controls.Add(this.EnterPatronimicPacientTextBox);
            this.PersonalDataPacientGroupBox.Controls.Add(this.EnterNamePacientTextBox);
            this.PersonalDataPacientGroupBox.Controls.Add(this.EnterSurnamePacientTextBox);
            this.PersonalDataPacientGroupBox.Controls.Add(this.label14);
            this.PersonalDataPacientGroupBox.Controls.Add(this.label15);
            this.PersonalDataPacientGroupBox.Controls.Add(this.label16);
            this.PersonalDataPacientGroupBox.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PersonalDataPacientGroupBox.Location = new System.Drawing.Point(11, 48);
            this.PersonalDataPacientGroupBox.Name = "PersonalDataPacientGroupBox";
            this.PersonalDataPacientGroupBox.Size = new System.Drawing.Size(295, 170);
            this.PersonalDataPacientGroupBox.TabIndex = 24;
            this.PersonalDataPacientGroupBox.TabStop = false;
            this.PersonalDataPacientGroupBox.Text = "Персональные данные пациента";
            // 
            // PhoneNumberPacientMaskedTextBox
            // 
            this.PhoneNumberPacientMaskedTextBox.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PhoneNumberPacientMaskedTextBox.Location = new System.Drawing.Point(129, 136);
            this.PhoneNumberPacientMaskedTextBox.Mask = "+7 (\\999) 000-0000";
            this.PhoneNumberPacientMaskedTextBox.Name = "PhoneNumberPacientMaskedTextBox";
            this.PhoneNumberPacientMaskedTextBox.Size = new System.Drawing.Size(100, 22);
            this.PhoneNumberPacientMaskedTextBox.TabIndex = 23;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.Location = new System.Drawing.Point(71, 139);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(56, 15);
            this.label11.TabIndex = 22;
            this.label11.Text = "Телефон";
            // 
            // EnterBirthdayPacientDateTimePicker
            // 
            this.EnterBirthdayPacientDateTimePicker.CalendarFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EnterBirthdayPacientDateTimePicker.Checked = false;
            this.EnterBirthdayPacientDateTimePicker.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EnterBirthdayPacientDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.EnterBirthdayPacientDateTimePicker.Location = new System.Drawing.Point(102, 107);
            this.EnterBirthdayPacientDateTimePicker.MinDate = new System.DateTime(1920, 1, 1, 0, 0, 0, 0);
            this.EnterBirthdayPacientDateTimePicker.Name = "EnterBirthdayPacientDateTimePicker";
            this.EnterBirthdayPacientDateTimePicker.Size = new System.Drawing.Size(92, 22);
            this.EnterBirthdayPacientDateTimePicker.TabIndex = 21;
            this.EnterBirthdayPacientDateTimePicker.Value = new System.DateTime(2019, 4, 2, 0, 0, 0, 0);
            this.EnterBirthdayPacientDateTimePicker.Enter += new System.EventHandler(this.EnterBirthdayPacientDateTimePicker_Enter);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(8, 111);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(91, 15);
            this.label10.TabIndex = 20;
            this.label10.Text = "Дата рождения";
            // 
            // EnterGenderPacientComboBox
            // 
            this.EnterGenderPacientComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.EnterGenderPacientComboBox.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EnterGenderPacientComboBox.FormattingEnabled = true;
            this.EnterGenderPacientComboBox.Location = new System.Drawing.Point(237, 106);
            this.EnterGenderPacientComboBox.Name = "EnterGenderPacientComboBox";
            this.EnterGenderPacientComboBox.Size = new System.Drawing.Size(41, 23);
            this.EnterGenderPacientComboBox.TabIndex = 19;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(205, 110);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 15);
            this.label7.TabIndex = 18;
            this.label7.Text = "Пол";
            // 
            // EnterPatronimicPacientTextBox
            // 
            this.EnterPatronimicPacientTextBox.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EnterPatronimicPacientTextBox.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.EnterPatronimicPacientTextBox.Location = new System.Drawing.Point(117, 77);
            this.EnterPatronimicPacientTextBox.Name = "EnterPatronimicPacientTextBox";
            this.EnterPatronimicPacientTextBox.Size = new System.Drawing.Size(115, 22);
            this.EnterPatronimicPacientTextBox.TabIndex = 17;
            this.EnterPatronimicPacientTextBox.Text = "Иванович";
            this.EnterPatronimicPacientTextBox.Enter += new System.EventHandler(this.EnterPatronimicPacientTextBox_Enter);
            this.EnterPatronimicPacientTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.EnterPatronimicPacientTextBox_KeyPress);
            this.EnterPatronimicPacientTextBox.Leave += new System.EventHandler(this.EnterPatronimicPacientTextBox_Leave);
            // 
            // EnterNamePacientTextBox
            // 
            this.EnterNamePacientTextBox.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EnterNamePacientTextBox.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.EnterNamePacientTextBox.Location = new System.Drawing.Point(117, 50);
            this.EnterNamePacientTextBox.Name = "EnterNamePacientTextBox";
            this.EnterNamePacientTextBox.Size = new System.Drawing.Size(115, 22);
            this.EnterNamePacientTextBox.TabIndex = 16;
            this.EnterNamePacientTextBox.Text = "Иван";
            this.EnterNamePacientTextBox.Enter += new System.EventHandler(this.EnterNamePacientTextBox_Enter);
            this.EnterNamePacientTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.EnterNamePacientTextBox_KeyPress);
            this.EnterNamePacientTextBox.Leave += new System.EventHandler(this.EnterNamePacientTextBox_Leave);
            // 
            // EnterSurnamePacientTextBox
            // 
            this.EnterSurnamePacientTextBox.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EnterSurnamePacientTextBox.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.EnterSurnamePacientTextBox.Location = new System.Drawing.Point(117, 24);
            this.EnterSurnamePacientTextBox.Name = "EnterSurnamePacientTextBox";
            this.EnterSurnamePacientTextBox.Size = new System.Drawing.Size(115, 22);
            this.EnterSurnamePacientTextBox.TabIndex = 15;
            this.EnterSurnamePacientTextBox.Text = "Иванов";
            this.EnterSurnamePacientTextBox.Enter += new System.EventHandler(this.EnterSurnamePacientTextBox_Enter);
            this.EnterSurnamePacientTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.EnterSurnamePacientTextBox_KeyPress);
            this.EnterSurnamePacientTextBox.Leave += new System.EventHandler(this.EnterSurnamePacientTextBox_Leave);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label14.Location = new System.Drawing.Point(57, 80);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(58, 15);
            this.label14.TabIndex = 8;
            this.label14.Text = "Отчество";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label15.Location = new System.Drawing.Point(84, 54);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(31, 15);
            this.label15.TabIndex = 6;
            this.label15.Text = "Имя";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label16.Location = new System.Drawing.Point(57, 27);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(58, 15);
            this.label16.TabIndex = 4;
            this.label16.Text = "Фамилия";
            // 
            // EnterMedicalPlaceComboBox
            // 
            this.EnterMedicalPlaceComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.EnterMedicalPlaceComboBox.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EnterMedicalPlaceComboBox.FormattingEnabled = true;
            this.EnterMedicalPlaceComboBox.Location = new System.Drawing.Point(507, 13);
            this.EnterMedicalPlaceComboBox.Name = "EnterMedicalPlaceComboBox";
            this.EnterMedicalPlaceComboBox.Size = new System.Drawing.Size(41, 23);
            this.EnterMedicalPlaceComboBox.TabIndex = 23;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(390, 15);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(111, 17);
            this.label9.TabIndex = 22;
            this.label9.Text = "Номер участка";
            // 
            // ViewMedicalNumPacientLabel
            // 
            this.ViewMedicalNumPacientLabel.BackColor = System.Drawing.SystemColors.Control;
            this.ViewMedicalNumPacientLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ViewMedicalNumPacientLabel.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ViewMedicalNumPacientLabel.Location = new System.Drawing.Point(231, 14);
            this.ViewMedicalNumPacientLabel.Name = "ViewMedicalNumPacientLabel";
            this.ViewMedicalNumPacientLabel.Size = new System.Drawing.Size(106, 21);
            this.ViewMedicalNumPacientLabel.TabIndex = 21;
            this.ViewMedicalNumPacientLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ViewMedicalNumPacientLabel.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(24, 15);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(201, 17);
            this.label8.TabIndex = 20;
            this.label8.Text = "Номер медицинской карты";
            // 
            // EnterMedicalNumPacientTextBox
            // 
            this.EnterMedicalNumPacientTextBox.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EnterMedicalNumPacientTextBox.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.EnterMedicalNumPacientTextBox.Location = new System.Drawing.Point(231, 14);
            this.EnterMedicalNumPacientTextBox.Name = "EnterMedicalNumPacientTextBox";
            this.EnterMedicalNumPacientTextBox.Size = new System.Drawing.Size(106, 22);
            this.EnterMedicalNumPacientTextBox.TabIndex = 27;
            this.EnterMedicalNumPacientTextBox.Text = "Номер карты";
            this.EnterMedicalNumPacientTextBox.Visible = false;
            this.EnterMedicalNumPacientTextBox.Enter += new System.EventHandler(this.EnterMedicalNumPacientTextBox_Enter);
            this.EnterMedicalNumPacientTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.EnterMedicalNumPacientTextBox_KeyPress);
            this.EnterMedicalNumPacientTextBox.Leave += new System.EventHandler(this.EnterMedicalNumPacientTextBox_Leave);
            // 
            // AddEditPacientButton
            // 
            this.AddEditPacientButton.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AddEditPacientButton.Location = new System.Drawing.Point(11, 227);
            this.AddEditPacientButton.Name = "AddEditPacientButton";
            this.AddEditPacientButton.Size = new System.Drawing.Size(189, 26);
            this.AddEditPacientButton.TabIndex = 28;
            this.AddEditPacientButton.Text = "Добавить данные пациента";
            this.AddEditPacientButton.UseVisualStyleBackColor = true;
            this.AddEditPacientButton.Click += new System.EventHandler(this.AddEditPacientButton_Click);
            // 
            // ClearEnterDataPacientButton
            // 
            this.ClearEnterDataPacientButton.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ClearEnterDataPacientButton.Location = new System.Drawing.Point(206, 227);
            this.ClearEnterDataPacientButton.Name = "ClearEnterDataPacientButton";
            this.ClearEnterDataPacientButton.Size = new System.Drawing.Size(153, 26);
            this.ClearEnterDataPacientButton.TabIndex = 29;
            this.ClearEnterDataPacientButton.Text = "Очистить поля ввода";
            this.ClearEnterDataPacientButton.UseVisualStyleBackColor = true;
            this.ClearEnterDataPacientButton.Visible = false;
            this.ClearEnterDataPacientButton.Click += new System.EventHandler(this.ClearEnterDataPacientButton_Click);
            // 
            // CancelAddEditButton
            // 
            this.CancelAddEditButton.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CancelAddEditButton.Location = new System.Drawing.Point(507, 227);
            this.CancelAddEditButton.Name = "CancelAddEditButton";
            this.CancelAddEditButton.Size = new System.Drawing.Size(66, 26);
            this.CancelAddEditButton.TabIndex = 30;
            this.CancelAddEditButton.Text = "Отмена";
            this.CancelAddEditButton.UseVisualStyleBackColor = true;
            this.CancelAddEditButton.Click += new System.EventHandler(this.CancelAddEditButton_Click);
            // 
            // AddEditPacientDataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(585, 262);
            this.Controls.Add(this.CancelAddEditButton);
            this.Controls.Add(this.ClearEnterDataPacientButton);
            this.Controls.Add(this.AddEditPacientButton);
            this.Controls.Add(this.EnterMedicalNumPacientTextBox);
            this.Controls.Add(this.MedicalLicencePacientGroupBox);
            this.Controls.Add(this.SNILSPacientGroupBox);
            this.Controls.Add(this.PersonalDataPacientGroupBox);
            this.Controls.Add(this.EnterMedicalPlaceComboBox);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.ViewMedicalNumPacientLabel);
            this.Controls.Add(this.label8);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "AddEditPacientDataForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Добавить/изменить данные пациента";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AddEditPacientDataForm_FormClosing);
            this.MedicalLicencePacientGroupBox.ResumeLayout(false);
            this.MedicalLicencePacientGroupBox.PerformLayout();
            this.SNILSPacientGroupBox.ResumeLayout(false);
            this.SNILSPacientGroupBox.PerformLayout();
            this.PersonalDataPacientGroupBox.ResumeLayout(false);
            this.PersonalDataPacientGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox MedicalLicencePacientGroupBox;
        private System.Windows.Forms.MaskedTextBox MedicalPacientLicenceNumMaskedTextBox;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.DateTimePicker MedicalLicencePacientDateTimePicker;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.GroupBox SNILSPacientGroupBox;
        private System.Windows.Forms.MaskedTextBox SNILSNumberPacientMaskedTextBox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DateTimePicker SNILSDatePacientDateTimePicker;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.GroupBox PersonalDataPacientGroupBox;
        private System.Windows.Forms.MaskedTextBox PhoneNumberPacientMaskedTextBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DateTimePicker EnterBirthdayPacientDateTimePicker;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox EnterGenderPacientComboBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox EnterPatronimicPacientTextBox;
        private System.Windows.Forms.TextBox EnterNamePacientTextBox;
        private System.Windows.Forms.TextBox EnterSurnamePacientTextBox;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox EnterMedicalPlaceComboBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label ViewMedicalNumPacientLabel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox EnterMedicalNumPacientTextBox;
        private System.Windows.Forms.Button AddEditPacientButton;
        private System.Windows.Forms.Button ClearEnterDataPacientButton;
        private System.Windows.Forms.Button CancelAddEditButton;
    }
}