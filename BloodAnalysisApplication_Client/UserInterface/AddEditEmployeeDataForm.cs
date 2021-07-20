using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using BloodAnalysisApplication_Client.Model.LaborantData;
using BloodAnalysisApplication_Client.Model.AllData;
using BloodAnalysisApplication_Client.Model.ClientListener;

namespace BloodAnalysisApplication_Client.UserInterface
{
    public partial class AddEditEmployeeDataForm : Form
    {
        AdministrateWorkForm administratorForm;

        AddEditFormEnum control;

        Laborant enterEmployeeData;

        AdministratorListener listener;

        GenderVocabulary genderVocabulary;

        public AddEditEmployeeDataForm(AdministrateWorkForm _MaiForm, AddEditFormEnum _control,
            Laborant _enterEmployeeData, AdministratorListener _listener)
        {
            InitializeComponent();
            administratorForm = _MaiForm;
            control = _control;
            enterEmployeeData = _enterEmployeeData;
            listener = _listener;
            genderVocabulary = new GenderVocabulary();
            FormControls();
        }

        public void DistributeRequestFunction()
        {
            switch (listener.requestListener)
            {
                case AdministratorRequestEnum.ExceptNone:
                    MessageBox.Show("Связь с сервером была прервана...", "Ошибка сервера",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case AdministratorRequestEnum.AddSucsess:
                case AdministratorRequestEnum.EditSucsess:
                    administratorForm.UpdateEmployeeListRepost();
                    Close();
                    break;
                case AdministratorRequestEnum.AddCancel:
                    AddEditErrorMessage(
                        "Сотрудник не был добавлен в систему, так как он существует в системе.",
                        "Отмена добавления нового сотрудника");
                    break;
                case AdministratorRequestEnum.EditCancel:
                    AddEditErrorMessage(
                        "Данные сотрудника не изменены.",
                        "Отмена изменения данных сотрудника");
                    break;
            }
        }

        private void FormControls()
        {
            UpdateGenderList();
            if (control == AddEditFormEnum.AddData)
            {
                this.Text = "Добавить данные сотрудника";
                EmployeeProfessionalComboBox.SelectedIndex = 0;
                EditNowStatusWorkEmployeeСomboBox.SelectedIndex = 0;
                AddEditEmployeeButton.Text = "Добавить данные сотрудника";
                ClearEnterDataEmployeeButton.Visible = true;
            }
            else
            {
                this.Text = "Изменить данные сотрудника";
                AddEditEmployeeButton.Text = "Изменить данные сотрудника";
                EnterSurnameEmployeeTextBox.ForeColor = SystemColors.WindowText;
                EnterSurnameEmployeeTextBox.Text = enterEmployeeData.Surname;
                EnterNameEmployeeTextBox.ForeColor = SystemColors.WindowText;
                EnterNameEmployeeTextBox.Text = enterEmployeeData.Name;
                EnterPatronimicEmployeeTextBox.ForeColor = SystemColors.WindowText;
                EnterPatronimicEmployeeTextBox.Text = enterEmployeeData.Patronimic;
                EnterBirthdayEmployeeDateTimePicker.Value = enterEmployeeData.BirthDate;
                EnterGenderEmployeeComboBox.SelectedIndex =
                    genderVocabulary.Genders.IndexOf(enterEmployeeData.Gender);
                EditEmployeeContractNumberMaskedTextBox.Text = enterEmployeeData.EmployeeContractNumber;
                EmployeeProfessionalComboBox.SelectedIndex = 1;
                EditUserPasswordMaskedTextBox.Text = enterEmployeeData.Password;
                if (enterEmployeeData.Activity)
                {
                    EditNowStatusWorkEmployeeСomboBox.SelectedIndex = 0;
                }
                else
                {
                    EditNowStatusWorkEmployeeСomboBox.SelectedIndex = 1;
                }
            }
        }

        private void UpdateGenderList()
        {
            foreach (Gender gender in genderVocabulary.Genders)
            {
                EnterGenderEmployeeComboBox.Items.Add(gender.ShortGenderName());
            }
            EnterGenderEmployeeComboBox.SelectedIndex = 0;
        }

        private void AddEditErrorMessage(string messageText, string messageHead)
        {
            MessageBox.Show(messageText, messageHead,
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void EnterSurnameEmployeeTextBox_Enter(object sender, EventArgs e)
        {
            string maskText = "Иванов";
            if (EnterSurnameEmployeeTextBox.Text == maskText &&
                EnterSurnameEmployeeTextBox.ForeColor == SystemColors.ControlDark)
            {
                EnterSurnameEmployeeTextBox.Text = "";
                EnterSurnameEmployeeTextBox.ForeColor = SystemColors.WindowText;
            }
        }

        private void EnterSurnameEmployeeTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputCheckText(@"[А-Яа-яЁё]|[\s\b]", sender, e);
        }

        private void EnterSurnameEmployeeTextBox_Leave(object sender, EventArgs e)
        {
            string maskText = "Иванов";
            if (EnterSurnameEmployeeTextBox.Text == "")
            {
                EnterSurnameEmployeeTextBox.Text = maskText;
                EnterSurnameEmployeeTextBox.ForeColor = SystemColors.ControlDark;
            }
            else
            {
                EnterSurnameEmployeeTextBox.Text = EnterSurnameEmployeeTextBox.Text[0].ToString().ToUpper()
                    + EnterSurnameEmployeeTextBox.Text.Substring(1).ToLower();
            }
        }

        private void EnterNameEmployeeTextBox_Enter(object sender, EventArgs e)
        {
            string maskText = "Иван";
            if (EnterNameEmployeeTextBox.Text == maskText &&
                EnterNameEmployeeTextBox.ForeColor == SystemColors.ControlDark)
            {
                EnterNameEmployeeTextBox.Text = "";
                EnterNameEmployeeTextBox.ForeColor = SystemColors.WindowText;
            }
        }

        private void EnterNameEmployeeTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputCheckText(@"[А-Яа-яЁё]|[\s\b]", sender, e);
        }

        private void EnterNameEmployeeTextBox_Leave(object sender, EventArgs e)
        {
            string maskText = "Иван";
            if (EnterNameEmployeeTextBox.Text == "")
            {
                EnterNameEmployeeTextBox.Text = maskText;
                EnterNameEmployeeTextBox.ForeColor = SystemColors.ControlDark;
            }
            else
            {
                EnterNameEmployeeTextBox.Text = EnterNameEmployeeTextBox.Text[0].ToString().ToUpper()
                    + EnterNameEmployeeTextBox.Text.Substring(1).ToLower();
            }
        }

        private void EnterPatronimicEmployeeTextBox_Enter(object sender, EventArgs e)
        {
            string maskText = "Иванович";
            if (EnterPatronimicEmployeeTextBox.Text == maskText &&
                EnterPatronimicEmployeeTextBox.ForeColor == SystemColors.ControlDark)
            {
                EnterPatronimicEmployeeTextBox.Text = "";
                EnterPatronimicEmployeeTextBox.ForeColor = SystemColors.WindowText;
            }
        }

        private void EnterPatronimicEmployeeTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            InputCheckText(@"[А-Яа-яЁё]|[\s\b]", sender, e);
        }

        private void EnterPatronimicEmployeeTextBox_Leave(object sender, EventArgs e)
        {
            string maskText = "Иванович";
            if (EnterPatronimicEmployeeTextBox.Text == "")
            {
                EnterPatronimicEmployeeTextBox.Text = maskText;
                EnterPatronimicEmployeeTextBox.ForeColor = SystemColors.ControlDark;
            }
            else
            {
                EnterPatronimicEmployeeTextBox.Text = EnterPatronimicEmployeeTextBox.Text[0].ToString().ToUpper()
                    + EnterPatronimicEmployeeTextBox.Text.Substring(1).ToLower();
            }
        }

        private void InputCheckText(string pattern, object sender, KeyPressEventArgs e)
        {
            if (!(Regex.Match(e.KeyChar.ToString(), pattern).Success))
            {
                e.Handled = true;
            }
        }

        private void EnterBirthdayEmployeeDateTimePicker_Enter(object sender, EventArgs e)
        {
            EnterBirthdayEmployeeDateTimePicker.MaxDate = DateTime.Now;
        }

        private void UserPasswordButtonPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            EditUserPasswordMaskedTextBox.UseSystemPasswordChar = false;
        }

        private void UserPasswordButtonPictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            EditUserPasswordMaskedTextBox.UseSystemPasswordChar = true;
        }

        private void AddEditEmployeeButton_Click(object sender, EventArgs e)
        {
            if (EnterSurnameEmployeeTextBox.ForeColor == SystemColors.WindowText &&
                EnterNameEmployeeTextBox.ForeColor == SystemColors.WindowText &&
                EnterPatronimicEmployeeTextBox.ForeColor == SystemColors.WindowText)
            {
                if (EditEmployeeContractNumberMaskedTextBox.Text.Length == 14)
                {
                    if (EmployeeProfessionalComboBox.SelectedIndex != 0)
                    {
                        if (EditUserPasswordMaskedTextBox.Text.Length > 0)
                        {
                            string userIdentificator = "";
                            if (enterEmployeeData != null)
                            {
                                userIdentificator = enterEmployeeData.UserIdentificator;
                            }
                            Laborant laborantData = new Laborant(userIdentificator,
                                EditUserPasswordMaskedTextBox.Text, EnterSurnameEmployeeTextBox.Text,
                                EnterNameEmployeeTextBox.Text, EnterPatronimicEmployeeTextBox.Text,
                                EnterBirthdayEmployeeDateTimePicker.Value,
                                genderVocabulary.GenderById(EnterGenderEmployeeComboBox.SelectedIndex + 1),
                                EditEmployeeContractNumberMaskedTextBox.Text,
                                (EditNowStatusWorkEmployeeСomboBox.SelectedIndex == 0));
                            if (control == AddEditFormEnum.AddData)
                            {
                                listener.AddEmployeeData(laborantData, this);
                            }
                            else
                            {
                                listener.EditEmployeeData(laborantData, this);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Введите пароль сотрудника",
                                "Неверный ввод данных сотрудника", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Выберите должность сотрудника",
                            "Неверный ввод данных сотрудника", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                }
                else
                {
                    MessageBox.Show("Введите корректный номер трудового договора",
                        "Неверный ввод данных сотрудника", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            else
            {
                MessageBox.Show("Поля имени сотрудника частично или полностью не заполнены",
                    "Неверный ввод данных сотрудника", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void ClearEnterDataEmployeeButton_Click(object sender, EventArgs e)
        {
            EnterSurnameEmployeeTextBox.Text = "";
            EnterSurnameEmployeeTextBox_Leave((object)EnterSurnameEmployeeTextBox, e);
            EnterNameEmployeeTextBox.Text = "";
            EnterNameEmployeeTextBox_Leave((object)EnterNameEmployeeTextBox, e);
            EnterPatronimicEmployeeTextBox.Text = "";
            EnterPatronimicEmployeeTextBox_Leave((object)EnterPatronimicEmployeeTextBox, e);
            EnterBirthdayEmployeeDateTimePicker.Value = DateTime.Now.Date;
            EnterGenderEmployeeComboBox.SelectedIndex = 0;
            EditEmployeeContractNumberMaskedTextBox.Text = "";
            EmployeeProfessionalComboBox.SelectedIndex = 0;
            EditUserPasswordMaskedTextBox.Text = "";
            EditNowStatusWorkEmployeeСomboBox.SelectedIndex = 0;
        }

        private void CancelAddEditButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}