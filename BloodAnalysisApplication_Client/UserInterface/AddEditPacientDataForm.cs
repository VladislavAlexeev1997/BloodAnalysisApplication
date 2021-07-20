using System;
using System.Drawing;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using BloodAnalysisApplication_Client.Model.DataClasses.PacientClasses;
using BloodAnalysisApplication_Client.Model.DataSetting;

namespace BloodAnalysisApplication_Client.UserInterface
{
    public partial class AddEditPacientDataForm : Form
    {
        LaborantWorkForm MainForm;

        AddEditFormEnum control;

        PacientCatalog PacientCatalog;

        int selectPacient;

        MedicalPlaceVocabulary placeVocabulary;

        GenderVocabulary genderVocabulary;

        public AddEditPacientDataForm(LaborantWorkForm _MainForm, AddEditFormEnum _control, 
            PacientCatalog _Catalog, int _selectPacient)
        {
            InitializeComponent();
            this.MainForm = _MainForm;
            this.control = _control;
            this.PacientCatalog = _Catalog;
            this.selectPacient = _selectPacient;
            this.placeVocabulary = new MedicalPlaceVocabulary();
            this.genderVocabulary = new GenderVocabulary();
            FormControls();
        }

        private void FormControls()
        {
            UpdateMedicalPlaceList();
            UpdateGenderList();
            if (control == AddEditFormEnum.AddData)
            {
                this.Text = "Добавить данные пациента";
                EnterMedicalNumPacientTextBox.Visible = true;
                AddEditPacientButton.Text = "Добавить данные пациента";
                ClearEnterDataPacientButton.Visible = true;
            }
            else
            {
                this.Text = "Изменить данные пациента";
                ViewMedicalNumPacientLabel.Visible = true;
                AddEditPacientButton.Text = "Изменить данные пациента";
                Pacient editPacient = PacientCatalog.PacientByIndex(selectPacient);
                EnterMedicalPlaceComboBox.SelectedIndex =
                    placeVocabulary.MedicalPlaces.IndexOf(editPacient.AttachmentPlace);
                ViewMedicalNumPacientLabel.Text = editPacient.MedicalCardNumber;
                EnterSurnamePacientTextBox.ForeColor = SystemColors.WindowText;
                EnterSurnamePacientTextBox.Text = editPacient.Surname;
                EnterNamePacientTextBox.ForeColor = SystemColors.WindowText;
                EnterNamePacientTextBox.Text = editPacient.Name;
                EnterPatronimicPacientTextBox.ForeColor = SystemColors.WindowText;
                EnterPatronimicPacientTextBox.Text = editPacient.Patronimic;
                EnterBirthdayPacientDateTimePicker.Value = editPacient.BirthDate;
                EnterGenderPacientComboBox.SelectedIndex =
                    genderVocabulary.Genders.IndexOf(editPacient.Gender);
                PhoneNumberPacientMaskedTextBox.Text = editPacient.PhoneNumber;
                SNILSNumberPacientMaskedTextBox.Text = editPacient.SNILS.SNILSNumber;
                SNILSDatePacientDateTimePicker.Value = editPacient.SNILS.RegistrateDate;
                MedicalPacientLicenceNumMaskedTextBox.Text = editPacient.MedicalLicense.LicenseNumber;
                MedicalLicencePacientDateTimePicker.Value = editPacient.MedicalLicense.RegistrateDate;
            }
        }

        private void UpdateMedicalPlaceList()
        {
            foreach(MedicalPlace place in placeVocabulary.MedicalPlaces)
            {
                EnterMedicalPlaceComboBox.Items.Add(place.PlaceNumber);
            }
            EnterMedicalPlaceComboBox.SelectedIndex = 0;
        }

        private void UpdateGenderList()
        {
            foreach (Gender gender in genderVocabulary.Genders)
            {
                EnterGenderPacientComboBox.Items.Add(gender.ShortGenderName());
            }
            EnterGenderPacientComboBox.SelectedIndex = 0;
        }

        private void EnterMedicalNumPacientTextBox_Enter(object sender, EventArgs e)
        {
            string maskText = "Номер карты";
            if (EnterMedicalNumPacientTextBox.Text == maskText &&
                EnterMedicalNumPacientTextBox.ForeColor == SystemColors.ControlDark)
            {
                EnterMedicalNumPacientTextBox.Text = "";
                EnterMedicalNumPacientTextBox.ForeColor = SystemColors.WindowText;
            }
        }

        private void EnterMedicalNumPacientTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputCheckText(@"[А-Яа-яЁё]|[A-Za-z]|[0-9]|[\s\b]", sender, e);
        }

        private void EnterMedicalNumPacientTextBox_Leave(object sender, EventArgs e)
        {
            string maskText = "Номер карты";
            if (EnterMedicalNumPacientTextBox.Text == "")
            {
                EnterMedicalNumPacientTextBox.Text = maskText;
                EnterMedicalNumPacientTextBox.ForeColor = SystemColors.ControlDark;
            }
        }

        private void EnterSurnamePacientTextBox_Enter(object sender, EventArgs e)
        {
            string maskText = "Иванов";
            if (EnterSurnamePacientTextBox.Text == maskText &&
                EnterSurnamePacientTextBox.ForeColor == SystemColors.ControlDark)
            {
                EnterSurnamePacientTextBox.Text = "";
                EnterSurnamePacientTextBox.ForeColor = SystemColors.WindowText;
            }
        }

        private void EnterSurnamePacientTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputCheckText(@"[А-Яа-яЁё]|[\s\b]", sender, e);
        }

        private void EnterSurnamePacientTextBox_Leave(object sender, EventArgs e)
        {
            string maskText = "Иванов";
            if (EnterSurnamePacientTextBox.Text == "")
            {
                EnterSurnamePacientTextBox.Text = maskText;
                EnterSurnamePacientTextBox.ForeColor = SystemColors.ControlDark;
            }
            else
            {
                EnterSurnamePacientTextBox.Text = EnterSurnamePacientTextBox.Text[0].ToString().ToUpper()
                    + EnterSurnamePacientTextBox.Text.Substring(1).ToLower();
            }
        }

        private void EnterNamePacientTextBox_Enter(object sender, EventArgs e)
        {
            string maskText = "Иван";
            if (EnterNamePacientTextBox.Text == maskText &&
                EnterNamePacientTextBox.ForeColor == SystemColors.ControlDark)
            {
                EnterNamePacientTextBox.Text = "";
                EnterNamePacientTextBox.ForeColor = SystemColors.WindowText;
            }
        }

        private void EnterNamePacientTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputCheckText(@"[А-Яа-яЁё]|[\s\b]", sender, e);
        }

        private void EnterNamePacientTextBox_Leave(object sender, EventArgs e)
        {
            string maskText = "Иван";
            if (EnterNamePacientTextBox.Text == "")
            {
                EnterNamePacientTextBox.Text = maskText;
                EnterNamePacientTextBox.ForeColor = SystemColors.ControlDark;
            }
            else
            {
                EnterNamePacientTextBox.Text = EnterNamePacientTextBox.Text[0].ToString().ToUpper()
                    + EnterNamePacientTextBox.Text.Substring(1).ToLower();
            }
        }

        private void EnterPatronimicPacientTextBox_Enter(object sender, EventArgs e)
        {
            string maskText = "Иванович";
            if (EnterPatronimicPacientTextBox.Text == maskText &&
                EnterPatronimicPacientTextBox.ForeColor == SystemColors.ControlDark)
            {
                EnterPatronimicPacientTextBox.Text = "";
                EnterPatronimicPacientTextBox.ForeColor = SystemColors.WindowText;
            }
        }

        private void EnterPatronimicPacientTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputCheckText(@"[А-Яа-яЁё]|[\s\b]", sender, e);
        }

        private void EnterPatronimicPacientTextBox_Leave(object sender, EventArgs e)
        {
            string maskText = "Иванович";
            if (EnterPatronimicPacientTextBox.Text == "")
            {
                EnterPatronimicPacientTextBox.Text = maskText;
                EnterPatronimicPacientTextBox.ForeColor = SystemColors.ControlDark;
            }
            else
            {
                EnterPatronimicPacientTextBox.Text = EnterPatronimicPacientTextBox.Text[0].ToString().ToUpper()
                    + EnterPatronimicPacientTextBox.Text.Substring(1).ToLower();
            }
        }

        private void EnterBirthdayPacientDateTimePicker_Enter(object sender, EventArgs e)
        {
            EnterBirthdayPacientDateTimePicker.MaxDate = DateTime.Now;
        }

        private void SNILSDatePacientDateTimePicker_Enter(object sender, EventArgs e)
        {
            SNILSDatePacientDateTimePicker.MaxDate = DateTime.Now;
        }

        private void MedicalLicencePacientDateTimePicker_Enter(object sender, EventArgs e)
        {
            MedicalLicencePacientDateTimePicker.MaxDate = DateTime.Now;
        }

        private void InputCheckText(string pattern, object sender, KeyPressEventArgs e)
        {
            if (!(Regex.Match(e.KeyChar.ToString(), pattern).Success))
            {
                e.Handled = true;
            }
        }

        private void AddEditPacientButton_Click(object sender, EventArgs e)
        {
            if (EnterSurnamePacientTextBox.ForeColor == SystemColors.WindowText &&
                EnterNamePacientTextBox.ForeColor == SystemColors.WindowText &&
                EnterPatronimicPacientTextBox.ForeColor == SystemColors.WindowText)
            {
                if (EnterMedicalNumPacientTextBox.Text.Length > 0 && 
                    control == AddEditFormEnum.AddData ||
                    control == AddEditFormEnum.EditData)
                {
                    if (PhoneNumberPacientMaskedTextBox.Text.Length == 17)
                    {
                        if (SNILSNumberPacientMaskedTextBox.Text.Length == 14)
                        {
                            if (MedicalPacientLicenceNumMaskedTextBox.Text.Length == 19)
                            {
                                MedicalPlace attachmentPlace = 
                                    placeVocabulary.MedicalPlaces[EnterMedicalPlaceComboBox.SelectedIndex];
                                Gender pacientGender = 
                                    genderVocabulary.Genders[EnterGenderPacientComboBox.SelectedIndex];
                                SNILS pacientSNILS = new SNILS(SNILSNumberPacientMaskedTextBox.Text,
                                    SNILSDatePacientDateTimePicker.Value);
                                MedicalLicense pacientMedLicense = new MedicalLicense(
                                    MedicalPacientLicenceNumMaskedTextBox.Text,
                                    MedicalLicencePacientDateTimePicker.Value);
                                bool addEditDataResult;
                                Pacient pacientData;
                                if (control == AddEditFormEnum.AddData)
                                {
                                    pacientData = new Pacient(EnterMedicalNumPacientTextBox.Text,
                                        EnterSurnamePacientTextBox.Text, EnterNamePacientTextBox.Text,
                                        EnterPatronimicPacientTextBox.Text, EnterBirthdayPacientDateTimePicker.Value,
                                        PhoneNumberPacientMaskedTextBox.Text, attachmentPlace, pacientGender,
                                        pacientSNILS, pacientMedLicense);
                                    addEditDataResult = PacientCatalog.AddNewPacient(pacientData);
                                    selectPacient = PacientCatalog.Pacients.Count - 1;
                                }
                                else
                                {
                                    Pacient editPacient = PacientCatalog.PacientByIndex(selectPacient);
                                    pacientData = new Pacient(editPacient.MedicalCardNumber,
                                        EnterSurnamePacientTextBox.Text, EnterNamePacientTextBox.Text,
                                        EnterPatronimicPacientTextBox.Text, EnterBirthdayPacientDateTimePicker.Value,
                                        PhoneNumberPacientMaskedTextBox.Text, attachmentPlace, pacientGender,
                                        pacientSNILS, pacientMedLicense);
                                    addEditDataResult = PacientCatalog.UpdatePacientData(
                                        editPacient.MedicalCardNumber, pacientData);
                                }
                                if (addEditDataResult)
                                {
                                    MessageBox.Show("Данные о пациенте в базе данных успешно обновлены", 
                                        "Сообщение об обновлении данных", MessageBoxButtons.OK, 
                                        MessageBoxIcon.Information);
                                    this.Close();
                                }
                                else
                                {
                                    MessageBox.Show("Введенные данные пациента уже существуют в базе данных",
                                        "Сообщение об обновлении данных", MessageBoxButtons.OK, 
                                        MessageBoxIcon.Asterisk);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Введите корректный номер медицинского полиса пациента", 
                                    "Неверный ввод данных пациента", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Введите корректный номер СНИЛС пациента", 
                                "Неверный ввод данных пациента", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Введите корректный номер телефона пациента", 
                            "Неверный ввод данных пациента", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                }
                else
                {
                    MessageBox.Show("Введите номер медицинской карты",
                        "Неверный ввод данных пациента", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            else
            {
                MessageBox.Show("Поля имени пациента частично или полностью не заполнены", 
                    "Неверный ввод данных пациента", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void ClearEnterDataPacientButton_Click(object sender, EventArgs e)
        {
            EnterMedicalNumPacientTextBox.Text = "";
            EnterMedicalNumPacientTextBox_Leave((object)EnterMedicalNumPacientTextBox, e);
            EnterMedicalPlaceComboBox.SelectedIndex = 0;
            EnterSurnamePacientTextBox.Text = "";
            EnterSurnamePacientTextBox_Leave((object)EnterSurnamePacientTextBox, e);
            EnterNamePacientTextBox.Text = "";
            EnterNamePacientTextBox_Leave((object)EnterNamePacientTextBox, e);
            EnterPatronimicPacientTextBox.Text = "";
            EnterPatronimicPacientTextBox_Leave((object)EnterPatronimicPacientTextBox, e);
            EnterBirthdayPacientDateTimePicker.Value = DateTime.Now.Date;
            EnterGenderPacientComboBox.SelectedIndex = 0;
            PhoneNumberPacientMaskedTextBox.Text = "";
            SNILSNumberPacientMaskedTextBox.Text = "";
            SNILSDatePacientDateTimePicker.Value = DateTime.Now.Date;
            MedicalPacientLicenceNumMaskedTextBox.Text = "";
            MedicalLicencePacientDateTimePicker.Value = DateTime.Now.Date;
        }

        private void CancelAddEditButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddEditPacientDataForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainForm.UpdateAllPacientDataGridView(selectPacient);
        }
    }
}