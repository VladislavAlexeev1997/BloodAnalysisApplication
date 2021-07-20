using System;
using System.Windows.Forms;
using BloodAnalysisApplication_Client.Model.DataClasses.PacientClasses;
using BloodAnalysisApplication_Client.Model.DataSetting;

namespace BloodAnalysisApplication_Client.UserInterface
{
    public partial class SelectPacientForm : Form
    {
        LaborantWorkForm MainForm;

        PacientCatalog PacientCatalog;

        public SelectPacientForm(LaborantWorkForm _MainForm,
            PacientCatalog _PacientCatalog)
        {
            InitializeComponent();
            this.MainForm = _MainForm;
            this.PacientCatalog = _PacientCatalog;
            CustomerUserDataGridViews();
        }

        private void CustomerUserDataGridViews()
        {
            ApplicationDataGridViewCustomer pacientDataGridCustomer
                = new ApplicationDataGridViewCustomer(PacientsDataGridView);
            pacientDataGridCustomer.AddDataGridViewColumn(new DataGridViewTextBoxColumn(),
                "Медицинская карта", "MedicalCardColumn", 135);
            pacientDataGridCustomer.AddDataGridViewColumn(new DataGridViewTextBoxColumn(),
                "Фамилия, имя, отчество пациента", "PacientNameColumn", 250);
            pacientDataGridCustomer.AddDataGridViewColumn(new DataGridViewTextBoxColumn(),
                "Участок", "MedicalPlaceColumn", 60);
            LoadPacientData();
        }

        private void LoadPacientData()
        {
            foreach (Pacient pacient in PacientCatalog.Pacients)
            {
                PacientsDataGridView.Rows.Add(
                    pacient.MedicalCardNumber, 
                    pacient.FullPacientName(),
                    pacient.AttachmentPlace.PlaceNumber);
            }
            FirstPacientButton.Enabled = false;
            PreviousPacientButton.Enabled = false;
            NextPacientButton.Enabled = PacientsDataGridView.Rows.Count > 1;
            LastPacientButton.Enabled = PacientsDataGridView.Rows.Count > 1;
            if (PacientCatalog.Pacients.Count > 0)
            {
                PacientsDataGridView.CurrentCell = PacientsDataGridView.Rows[0].Cells[0];
                SelectButton.Enabled = true;
            }
        }

        private void FirstPacientButton_Click(object sender, EventArgs e)
        {
            PacientsDataGridView.CurrentCell = PacientsDataGridView.Rows[0].Cells[0];
            FirstPacientButton.Enabled = false;
            PreviousPacientButton.Enabled = false;
            NextPacientButton.Enabled = true;
            LastPacientButton.Enabled = true;
        }

        private void PreviousPacientButton_Click(object sender, EventArgs e)
        {
            if (PacientsDataGridView.CurrentRow.Index == 1)
            {
                FirstPacientButton.Enabled = false;
                PreviousPacientButton.Enabled = false;
            }
            if (PacientsDataGridView.CurrentRow.Index ==
                PacientsDataGridView.Rows.Count - 1)
            {
                NextPacientButton.Enabled = true;
                LastPacientButton.Enabled = true;
            }
            PacientsDataGridView.CurrentCell =
                PacientsDataGridView.Rows[PacientsDataGridView.CurrentRow.Index - 1].Cells[0];
        }

        private void NextPacientButton_Click(object sender, EventArgs e)
        {
            if (PacientsDataGridView.CurrentRow.Index == PacientsDataGridView.Rows.Count - 2)
            {
                NextPacientButton.Enabled = false;
                LastPacientButton.Enabled = false;
            }
            if (PacientsDataGridView.CurrentRow.Index == 0)
            {
                FirstPacientButton.Enabled = true;
                PreviousPacientButton.Enabled = true;
            }
            PacientsDataGridView.CurrentCell =
                PacientsDataGridView.Rows[PacientsDataGridView.CurrentRow.Index + 1].Cells[0];
        }

        private void LastPacientButton_Click(object sender, EventArgs e)
        {
            PacientsDataGridView.CurrentCell =
                PacientsDataGridView.Rows[PacientsDataGridView.Rows.Count - 1].Cells[0];
            FirstPacientButton.Enabled = true;
            PreviousPacientButton.Enabled = true;
            NextPacientButton.Enabled = false;
            LastPacientButton.Enabled = false;
        }

        private void SelectButton_Click(object sender, EventArgs e)
        {
            Pacient selectPacient =
                PacientCatalog.Pacients[PacientsDataGridView.CurrentRow.Index];
            MainForm.SelectedPacient(selectPacient);
            Close();
        }

        private void CancelSelectButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}