using System;
using System.Windows.Forms;
using System.Collections.Generic;
using BloodAnalysisApplication_Client.Model.DataClasses;
using BloodAnalysisApplication_Client.Model.ClientListener;

namespace BloodAnalysisApplication_Client.UserInterface
{
    public partial class AutorisationSystemForm : Form
    {
        private const string DEFAULT_USER_TYPE = "-- тип пользователя --";

        private const string ADMIN_USER_TYPE = "администратор";

        private const string LABORANT_USER_TYPE = "лаборант";

        private const string DEFAULT_USER_NAME = "-- имя пользователя системы --";

        private delegate void Information(string info_msg);

        private delegate void Connection();

        private delegate void LaborantNames();

        private Information Message;

        private Connection EnterClient;

        private LaborantNames UpdateLaborantNames;

        private ClientListener listener;

        public AutorisationSystemForm()
        {
            InitializeComponent();
            listener = new ClientListener(this);
            Message = new Information(ShowAttentionMessage);
            EnterClient = new Connection(EnterUser);
            UpdateLaborantNames = new LaborantNames(UpdateUserNameList);
            UpdateUserTypeList();
            UpdateUserNameList();
        }

        public void UpdateClientSocket(ClientListener newListener)
        {
            listener = newListener;
            listener.UpdateThreadRequest();
        }

        public void DistributeRequestFunction()
        {
            switch(listener.requestListener)
            {
                case ClientRequestEnum.ExceptNone:
                    ShowAttentionMessage("Нет подключения к серверу");
                    break;
                case ClientRequestEnum.EnterUser:
                    EnterUser();
                    break;
                case ClientRequestEnum.NotEnterUser:
                    ShowAttentionMessage("Неверно введен пароль для входа в систему");
                    break;
                case ClientRequestEnum.LaborantNames:
                    UpdateLaborantNames();
                    break;
                case ClientRequestEnum.ExitLastUser:
                    listener.UpdateThreadRequest();
                    break;
            }
            listener.requestListener = ClientRequestEnum.None;
        }

        private void UserTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (UserTypeComboBox.SelectedIndex == 2)
                listener.LaborantNamesRepost();
            else
                UpdateUserNameList();
            UserNameСomboBox.Enabled = UserTypeComboBox.SelectedIndex == 2;
        }

        private void UserPasswordButtonPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            UserPasswordMaskedTextBox.UseSystemPasswordChar = false;
        }

        private void UserPasswordButtonPictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            UserPasswordMaskedTextBox.UseSystemPasswordChar = true;
        }

        private void AutorisationButton_Click(object sender, EventArgs e)
        {
            if ((string)UserTypeComboBox.SelectedItem == DEFAULT_USER_TYPE)
            {
                ShowAttentionMessage("Выберите тип пользователя системы");
            }
            else if (UserNameСomboBox.Enabled &&
                    (string)UserNameСomboBox.SelectedItem == DEFAULT_USER_NAME)
            {
                ShowAttentionMessage("Выберите пользователя системы");
            }
            else if (UserPasswordMaskedTextBox.Text == "")
            {
                ShowAttentionMessage("Введите пароль для входа в систему");
            }
            else
            {
                try
                {
                    listener.ConectUserRepost(UserTypeComboBox.SelectedIndex.ToString(),
                        (UserNameСomboBox.SelectedIndex - 1).ToString(),
                        UserPasswordMaskedTextBox.Text);
                }
                catch
                {
                    ShowAttentionMessage("На данный момент невозможно связаться с сервером");
                }
            }
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            UserTypeComboBox.SelectedIndex = 0;
            UserPasswordMaskedTextBox.Text = "";
            EnterAttentionLabel.Visible = false;
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AutorisationSystemForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult exitResult =
                MessageBox.Show(
                    "Вы действительно хотите выйти?",
                    "Выход из системы",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (exitResult == DialogResult.Yes)
                Application.ExitThread();
            else
                e.Cancel = true;
        }

        private void UpdateUserTypeList()
        {
            UserTypeComboBox.Items.Clear();
            UserTypeComboBox.Items.AddRange(new string[] {DEFAULT_USER_TYPE,
                ADMIN_USER_TYPE, LABORANT_USER_TYPE});
            UserTypeComboBox.SelectedIndex = 0;
        }

        private void UpdateUserNameList()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(UpdateLaborantNames);
                return;
            }
            UserNameСomboBox.Items.Clear();
            UserNameСomboBox.Items.Add(DEFAULT_USER_NAME);
            List<string> laborantNames = listener.LaborantListRequest();
            foreach (string name in laborantNames)
            {
                UserNameСomboBox.Items.Add(name);
            }
            UserNameСomboBox.SelectedIndex = 0;
        }

        private void ShowAttentionMessage(string message)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(Message, message);
                return;
            }
            EnterAttentionLabel.Text = message;
            EnterAttentionLabel.Visible = true;
        }

        private void EnterUser()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(EnterClient);
                return;
            }
            if (UserTypeComboBox.SelectedItem.ToString() == ADMIN_USER_TYPE)
            {
                AdministrateWorkForm administrationForm = new AdministrateWorkForm(this, listener.serverSocket);
                administrationForm.Show();
                ClearButton_Click(null, null);
            }
            else
            {
                string[] laborantName = UserNameСomboBox.Items[UserNameСomboBox.SelectedIndex].ToString().Split(' ');
                LaborantWorkForm laborantForm = new LaborantWorkForm(this, listener.serverSocket, 
                    new Laborant(laborantName[0], laborantName[1], laborantName[2]));
                laborantForm.Show();
                ClearButton_Click(null, null);
            }
            listener.AbortThread();
            Hide();
        }
    }
}