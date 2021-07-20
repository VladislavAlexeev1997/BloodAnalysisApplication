using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Net.Sockets;
using BloodAnalysisApplication_Client.Model.LaborantData;
using BloodAnalysisApplication_Client.Model.ClientListener;

namespace BloodAnalysisApplication_Client.UserInterface
{
    public partial class AdministrateWorkForm : Form
    {
        private AutorisationSystemForm autorisationForm;

        public AdministratorListener listener;

        private List<Laborant> LaborantList;

        private delegate void UpdateLaborantVocabulary();

        UpdateLaborantVocabulary UpdateEmployeeList;

        int currentEmployeeIndex;

        public AdministrateWorkForm(AutorisationSystemForm enterForm, Socket nowSocket)
        {
            InitializeComponent();
            listener = new AdministratorListener(nowSocket, this);
            autorisationForm = enterForm;
            UpdateEmployeeList = new UpdateLaborantVocabulary(UpdateEmployeeDataList);
            CustomerUserDataGridViews();
            currentEmployeeIndex = 0;
            UpdateEmployeeListRepost();
        }

        public void DistributeRequestFunction()
        {
            switch (listener.requestListener)
            {
                case AdministratorRequestEnum.ExceptNone:
                    MessageBox.Show("Связь с сервером была прервана...", "Ошибка сервера",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case AdministratorRequestEnum.EmployeeList:
                    UpdateEmployeeDataList();
                    break;
            }
        }

        public void UpdateEmployeeListRepost()
        {
            listener.EmployeeListRepost();
        }
        
        private void CustomerUserDataGridViews()
        {
            ApplicationDataGridViewCustomer customer
                = new ApplicationDataGridViewCustomer(EmployeeDataGridView);
            customer.AddDataGridViewColumn(new DataGridViewTextBoxColumn(), "№ п/п",
                                               "NumberRowColumn", 45);
            customer.AddDataGridViewColumn(new DataGridViewTextBoxColumn(),
                                               "Фамилия, имя, отчество сотрудника",
                                               "EmployeeNameColumn", 245);
            customer.AddDataGridViewColumn(new DataGridViewTextBoxColumn(), "Должность",
                                               "ProfessionNameColumn", 140);
            customer.AddDataGridViewColumn(new DataGridViewImageColumn(), "Активность",
                                               "ActiveEmployeeColumn", 75);
        }

        private void FirstDataButton_Click(object sender, EventArgs e)
        {
            EmployeeDataGridView.CurrentCell = EmployeeDataGridView.Rows[0].Cells[0];
            FirstEmployeeDataButton.Enabled = false;
            PreviousEmployeeDataButton.Enabled = false;
            NextEmployeeDataButton.Enabled = true;
            LastEmployeeDataButton.Enabled = true;
        }

        private void PreviousDataButton_Click(object sender, EventArgs e)
        {
            if (EmployeeDataGridView.CurrentRow.Index == 1)
            {
                FirstEmployeeDataButton.Enabled = false;
                PreviousEmployeeDataButton.Enabled = false;
            }
            if (EmployeeDataGridView.CurrentRow.Index == EmployeeDataGridView.Rows.Count - 1)
            {
                NextEmployeeDataButton.Enabled = true;
                LastEmployeeDataButton.Enabled = true;
            }
            EmployeeDataGridView.CurrentCell = EmployeeDataGridView.Rows[EmployeeDataGridView.CurrentRow.Index - 1].Cells[0];

        }

        private void NextDataButton_Click(object sender, EventArgs e)
        {
            if (EmployeeDataGridView.CurrentRow.Index == EmployeeDataGridView.Rows.Count - 2)
            {
                NextEmployeeDataButton.Enabled = false;
                LastEmployeeDataButton.Enabled = false;
            }
            if (EmployeeDataGridView.CurrentRow.Index == 0)
            {
                FirstEmployeeDataButton.Enabled = true;
                PreviousEmployeeDataButton.Enabled = true;
            }
            EmployeeDataGridView.CurrentCell = EmployeeDataGridView.Rows[EmployeeDataGridView.CurrentRow.Index + 1].Cells[0];
        }

        private void LastDataButton_Click(object sender, EventArgs e)
        {
            EmployeeDataGridView.CurrentCell = EmployeeDataGridView.Rows[EmployeeDataGridView.Rows.Count - 1].Cells[0];
            FirstEmployeeDataButton.Enabled = true;
            PreviousEmployeeDataButton.Enabled = true;
            NextEmployeeDataButton.Enabled = false;
            LastEmployeeDataButton.Enabled = false;
        }

        private void EmployeeDataGridView_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (EmployeeDataGridView.Rows.Count != 0)
            {
                SelectEmployeeDataNumberLabel.Text = Convert.ToString(EmployeeDataGridView.CurrentCell.RowIndex + 1);
                AllEmployeeDataNumberLabel.Text = Convert.ToString(EmployeeDataGridView.Rows.Count);
            }
        }

        private void EmployeeDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            SelectEmployeeDataNumberLabel.Text = Convert.ToString(EmployeeDataGridView.CurrentRow.Index + 1);
            AllEmployeeDataNumberLabel.Text = Convert.ToString(EmployeeDataGridView.Rows.Count);
        }

        private void AdministrateWorkForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult exitResult =
                MessageBox.Show(
                    "Вы действительно хотите выйти?",
                    "Выход из системы",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (exitResult == DialogResult.Yes)
            {
                listener.AdministratorExitRepost();
                ClientListener newListener = listener.AdministratorExitRequest(autorisationForm);
                listener.AbortThread();
                autorisationForm.UpdateClientSocket(newListener);
                autorisationForm.Show();
            }
            else
                e.Cancel = true;
        }

        private void UpdateEmployeeDataList()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(UpdateEmployeeList);
                return;
            }
            EmployeeDataGridView.Rows.Clear();
            LaborantList = listener.LaborantListRequest();
            foreach (Laborant laborant in LaborantList)
            {
                Bitmap Activites;
                if (laborant.Activity)
                {
                    Activites = Properties.Resources.yes;
                }
                else
                {
                    Activites = Properties.Resources.no;
                }
                EmployeeDataGridView.Rows.Add(EmployeeDataGridView.Rows.Count + 1,
                    laborant.FullName(), "лаборант", Activites);
            }
            int employeeDataCount = LaborantList.Count;
            FirstEmployeeDataButton.Enabled = currentEmployeeIndex > 0 && employeeDataCount > 1;
            PreviousEmployeeDataButton.Enabled = currentEmployeeIndex > 0 && employeeDataCount > 1;
            NextEmployeeDataButton.Enabled =
                currentEmployeeIndex < EmployeeDataGridView.Rows.Count - 1 &&
                employeeDataCount > 1;
            LastEmployeeDataButton.Enabled =
                currentEmployeeIndex < EmployeeDataGridView.Rows.Count - 1 &&
                employeeDataCount > 1;
            AddEmployeeDataButton.Enabled = true;
            EditEmployeeDataButton.Enabled = employeeDataCount > 0;
            DeleteEmployeeDataButton.Enabled = employeeDataCount > 0;
            if (employeeDataCount > 0)
            {
                SelectEmployeeDataNumberLabel.Text = Convert.ToString(currentEmployeeIndex + 1);
                AllEmployeeDataNumberLabel.Text = Convert.ToString(employeeDataCount);
                EmployeeDataGridView.CurrentCell =
                    EmployeeDataGridView.Rows[currentEmployeeIndex].Cells[0];
                ViewLaborantData();
            }
            else
            {
                SelectEmployeeDataNumberLabel.Text = "0";
                AllEmployeeDataNumberLabel.Text = Convert.ToString(employeeDataCount);
            }
        }

        private void ViewLaborantData()
        {
            currentEmployeeIndex = EmployeeDataGridView.CurrentCell.RowIndex;
            Laborant currentLaborant = LaborantList[currentEmployeeIndex];
            ViewEmployeeSurnameLabel.Text = currentLaborant.Surname;
            ViewEmployeeNameLabel.Text = currentLaborant.Name;
            ViewEmployeePatronimicLabel.Text = currentLaborant.Patronimic;
            ViewEmployeeBirthdayLabel.Text = currentLaborant.BirthDate.ToString("dd.MM.yyyy");
            ViewEmployeeGenderLabel.Text = currentLaborant.Gender.ShortGenderName();
            ViewEmployeeContractNumberLabel.Text = currentLaborant.EmployeeContractNumber;
            ViewEmployeeProfessionalLabel.Text = "лаборант";
            ViewEmployeePasswordLabel.Text = currentLaborant.Password;
            if (currentLaborant.Activity)
            {
                NowStatusWorkEmployeePictureBox.Image = Properties.Resources.yes;
            }
            else
            {
                NowStatusWorkEmployeePictureBox.Image = Properties.Resources.no;
            }
            SelectEmployeeDataNumberLabel.Text = (currentEmployeeIndex + 1).ToString();
        }

        private void FirstEmployeeDataButton_Click(object sender, EventArgs e)
        {
            EmployeeDataGridView.CurrentCell = EmployeeDataGridView.Rows[0].Cells[0];
            FirstEmployeeDataButton.Enabled = false;
            PreviousEmployeeDataButton.Enabled = false;
            NextEmployeeDataButton.Enabled = true;
            LastEmployeeDataButton.Enabled = true;
            ViewLaborantData();
        }

        private void PreviousEmployeeDataButton_Click(object sender, EventArgs e)
        {
            if (EmployeeDataGridView.CurrentRow.Index == 1)
            {
                FirstEmployeeDataButton.Enabled = false;
                PreviousEmployeeDataButton.Enabled = false;
            }
            if (EmployeeDataGridView.CurrentRow.Index ==
                EmployeeDataGridView.Rows.Count - 1)
            {
                NextEmployeeDataButton.Enabled = true;
                LastEmployeeDataButton.Enabled = true;
            }
            EmployeeDataGridView.CurrentCell =
                EmployeeDataGridView.Rows[EmployeeDataGridView.CurrentRow.Index - 1].Cells[0];
            ViewLaborantData();
        }

        private void NextEmployeeDataButton_Click(object sender, EventArgs e)
        {
            if (EmployeeDataGridView.CurrentRow.Index == EmployeeDataGridView.Rows.Count - 2)
            {
                NextEmployeeDataButton.Enabled = false;
                LastEmployeeDataButton.Enabled = false;
            }
            if (EmployeeDataGridView.CurrentRow.Index == 0)
            {
                FirstEmployeeDataButton.Enabled = true;
                PreviousEmployeeDataButton.Enabled = true;
            }
            EmployeeDataGridView.CurrentCell =
                EmployeeDataGridView.Rows[EmployeeDataGridView.CurrentRow.Index + 1].Cells[0];
            ViewLaborantData();
        }

        private void LastEmployeeDataButton_Click(object sender, EventArgs e)
        {
            EmployeeDataGridView.CurrentCell =
                EmployeeDataGridView.Rows[EmployeeDataGridView.Rows.Count - 1].Cells[0];
            FirstEmployeeDataButton.Enabled = true;
            PreviousEmployeeDataButton.Enabled = true;
            NextEmployeeDataButton.Enabled = false;
            LastEmployeeDataButton.Enabled = false;
            ViewLaborantData();
        }

        private void AddEmployeeDataButton_Click(object sender, EventArgs e)
        {
            AddEditEmployeeDataForm addEmployeeDataForm = new AddEditEmployeeDataForm(this,
                AddEditFormEnum.AddData, null, listener);
            addEmployeeDataForm.Show();
        }

        private void EditEmployeeDataButton_Click(object sender, EventArgs e)
        {
            AddEditEmployeeDataForm editEmployeeDataForm = new AddEditEmployeeDataForm(this,
                AddEditFormEnum.EditData, LaborantList[EmployeeDataGridView.CurrentRow.Index], listener);
            editEmployeeDataForm.Show();
        }
    }
}