using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Net.Sockets;
using System.Drawing.Printing;
using System.IO;
using BloodAnalysisApplication_Client.Model.DataClasses.PacientClasses;
using BloodAnalysisApplication_Client.Model.DataClasses.AnalysisClasses;
using BloodAnalysisApplication_Client.Model.DataSetting;
using BloodAnalysisApplication_Client.Model.BloodAnalysis;
using BloodAnalysisApplication_Client.Model.ClientListener;
using BloodAnalysisApplication_Client.Model.DataClasses;

namespace BloodAnalysisApplication_Client.UserInterface
{
    public partial class LaborantWorkForm : Form
    {
        private AutorisationSystemForm autorisationForm;

        private LaborantListener listener;

        private BloodAnalyzer analysisResult;

        private PacientCatalog PacientCatalog;

        private AnalysisCatalog AnalysisCatalog;

        private Pacient selectPacient;

        public LaborantWorkForm(AutorisationSystemForm enterForm, Socket nowSocket, Laborant data)
        {
            InitializeComponent();
            listener = new LaborantListener(nowSocket, data);
            PacientCatalog = new PacientCatalog();
            AnalysisCatalog = new AnalysisCatalog();
            LaborantNameTextToolStripStatusLabel.Text = listener.FullLaborantName();
            autorisationForm = enterForm;
            EnterProbeDateDateTimePicker.Value = DateTime.Today;
            EnterDateAnaliseDateTimePicker.Value = DateTime.Today;
            GenerateAnalysisNumber(DateTime.Today);
            selectPacient = null;
            analysisResult = null;
            CustomerUserDataGridViews();
        }

        private void CustomerUserDataGridViews()
        {
            ApplicationDataGridViewCustomer pacientDataGridCustomer
                = new ApplicationDataGridViewCustomer(AllPacientDataGridView);
            pacientDataGridCustomer.AddDataGridViewColumn(new DataGridViewTextBoxColumn(),
                "№ п/п", "NumberRowColumn", 55);
            pacientDataGridCustomer.AddDataGridViewColumn(new DataGridViewTextBoxColumn(),
                "Медицинская карта", "MedicalCardColumn", 155);
            pacientDataGridCustomer.AddDataGridViewColumn(new DataGridViewTextBoxColumn(),
                "Фамилия, имя, отчество пациента", "PacientNameColumn", 290);
            pacientDataGridCustomer.AddDataGridViewColumn(new DataGridViewTextBoxColumn(),
                "Участок", "MedicalPlaceColumn", 65);
            UpdateAllPacientDataGridView(0);
            ApplicationDataGridViewCustomer analysisDataGridCustomer
                = new ApplicationDataGridViewCustomer(PacientAnalysisDataGridView);
            analysisDataGridCustomer.AddDataGridViewColumn(new DataGridViewTextBoxColumn(),
                "№", "NumberRowColumn", 38);
            analysisDataGridCustomer.AddDataGridViewColumn(new DataGridViewTextBoxColumn(),
                "№ анализа", "AnalysisNumberColumn", 86);
            analysisDataGridCustomer.AddDataGridViewColumn(new DataGridViewTextBoxColumn(),
                "Медицинская карта", "MedicalCardColumn", 134);
            analysisDataGridCustomer.AddDataGridViewColumn(new DataGridViewTextBoxColumn(),
                "Фамилия, имя, отчество пациента", "PacientNameColumn", 235);
            analysisDataGridCustomer.AddDataGridViewColumn(new DataGridViewTextBoxColumn(),
                "Дата анализа", "AnalysisDateColumn", 90);
            UpdatePacientAnalysisDataGridView(0);
        }
        
        private void GenerateAnalysisNumber(DateTime selectDate)
        {
            List<Analysis> selectDateAnalysis =
                AnalysisCatalog.AnalysisCatalogData.FindAll(
                    find => find.AnalysisData.Date == selectDate.Date);
            string analysisNumber = selectDate.Day.ToString("00") +
                selectDate.Month.ToString("00") + selectDate.Year.ToString("0000") +
                (selectDateAnalysis.Count + 1).ToString("000");
            EnterBloodAnaliseNumTextLabel.Text = analysisNumber;
        }

        private void EnterProbeDateDateTimePicker_Enter(object sender, EventArgs e)
        {
            EnterProbeDateDateTimePicker.MinDate = DateTime.Now.Subtract(new TimeSpan(21, 0, 0, 0));
            EnterProbeDateDateTimePicker.MaxDate = DateTime.Now;
        }

        private void EnterDateAnaliseDateTimePicker_Enter(object sender, EventArgs e)
        {
            EnterDateAnaliseDateTimePicker.MinDate = DateTime.Now.Subtract(new TimeSpan(14, 0, 0, 0));
            EnterDateAnaliseDateTimePicker.MaxDate = DateTime.Now;
        }

        private void EnterDateAnaliseDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            GenerateAnalysisNumber(EnterDateAnaliseDateTimePicker.Value);
        }

        private void LoadImageButton_Click(object sender, EventArgs e)
        {
            DialogResult resultOpen = OpenImageOpenFileDialog.ShowDialog();
            if (resultOpen == DialogResult.OK)
            {
                EnterBloodImagePictureBox.Image = Image.FromFile(OpenImageOpenFileDialog.FileName);
            }
        }

        private void CheckPacientButton_Click(object sender, EventArgs e)
        {
            SelectPacientForm SelectPacientForm = new SelectPacientForm(this, PacientCatalog);
            SelectPacientForm.Show();
        }

        public void SelectedPacient(Pacient _selectPacient)
        {
            selectPacient = _selectPacient;
            EnterAnaliseNumMedicalCardTextLabel.Text = selectPacient.MedicalCardNumber;
            EnterAnaliseMedicalPlaceTextLabel.Text = 
                Convert.ToString(selectPacient.AttachmentPlace.PlaceNumber);
            EnterAnaliseSurnamePacientTextLabel.Text = selectPacient.Surname;
            EnterAnaliseNamePacientTextLabel.Text = selectPacient.Name;
            EnterAnalisePatronimicPacientTextLabel.Text = selectPacient.Patronimic;
        }

        private void StartAnalysisDataButton_Click(object sender, EventArgs e)
        {
            if (selectPacient != null)
            {
                if (EnterBloodImagePictureBox.Image != null)
                {
                    analysisResult = 
                        new BloodAnalyzer((Bitmap)EnterBloodImagePictureBox.Image, EnterBloodAnaliseNumTextLabel.Text);
                    analysisResult.RunAnalysis();
                    ErythrocyteCountAnalysisLabel.Text =
                        analysisResult.ErythrocyteCountImage().ToString();
                    LeukocytesCountAnalysisLabel.Text =
                        analysisResult.LeukocyteCountImage().ToString();
                    ResultAnalysisControlComponent(true);
                }
                else
                {
                    MessageBox.Show("Необходимо загрузить изображение мазка крови для анализа", 
                        "Неверный ввод данных анализа", MessageBoxButtons.OK, 
                        MessageBoxIcon.Asterisk);
                }
            }
            else
            {
                MessageBox.Show("Данные пациента не были выбраны", 
                    "Неверный ввод данных анализа", MessageBoxButtons.OK, 
                    MessageBoxIcon.Asterisk);
            }
        }

        private void ClearEnterAnalysisDataButton_Click(object sender, EventArgs e)
        {
            GenerateAnalysisNumber(DateTime.Today);
            EnterProbeDateDateTimePicker.Value = DateTime.Now.Date;
            EnterDateAnaliseDateTimePicker.Value = DateTime.Now.Date;
            EnterBloodImagePictureBox.Image = null;
            EnterAnaliseNumMedicalCardTextLabel.Text = "";
            selectPacient = null;
            EnterAnaliseMedicalPlaceTextLabel.Text = "";
            EnterAnaliseSurnamePacientTextLabel.Text = "";
            EnterAnaliseNamePacientTextLabel.Text = "";
            EnterAnalisePatronimicPacientTextLabel.Text = "";
        }

        private void EnterResultAnaliseRichTextBox_Enter(object sender, EventArgs e)
        {
            string maskText = "Введите результат анализа";
            if (EnterResultAnaliseRichTextBox.Text == maskText)
            {
                EnterResultAnaliseRichTextBox.Text = "";
                EnterResultAnaliseRichTextBox.ForeColor = SystemColors.WindowText;
            }
        }

        private void EnterResultAnaliseRichTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Regex.Match(e.KeyChar.ToString(), 
                @"[0-9]|[A-Za-z]|[А-Яа-я]|[-/(),.%\s\b\n]").Success))
            {
                e.Handled = true;
            }
        }

        private void EnterResultAnaliseRichTextBox_Leave(object sender, EventArgs e)
        {
            string maskText = "Введите результат анализа";
            if (EnterResultAnaliseRichTextBox.Text == maskText || 
                EnterResultAnaliseRichTextBox.Text == "")
            {
                EnterResultAnaliseRichTextBox.Text = maskText;
                EnterResultAnaliseRichTextBox.ForeColor = SystemColors.ControlDark;
            }
        }

        private void AnalisePatternButton_Click(object sender, EventArgs e)
        {
            string resultText = "" + "Количество эритроцитов (RBC) на 1 мкл мазка - " +
                analysisResult.CalculateSmearErythrocytes().ToString() + " млн клеток/мкл,\n"  +
                "Количество лейкоцитов (WBC) на 1 мкл мазка - " +
                analysisResult.CalculateSmearLeukocytes().ToString() + " тыс клеток/мкл.\n" +
                "Патологии в крови не обнаружено.";
            EnterResultAnaliseRichTextBox.Text = resultText;
            EnterResultAnaliseRichTextBox.ForeColor = SystemColors.WindowText;
        }

        private void SaveAnalysisButton_Click(object sender, EventArgs e)
        {
            if (EnterResultAnaliseRichTextBox.ForeColor != SystemColors.ControlDark ||
                EnterResultAnaliseRichTextBox.Text != "")
            {
                string bloodImageFileName = @"Database\Images\" +
                    EnterBloodAnaliseNumTextLabel.Text + @"\Исходное изображение.jpg";
                BloodImage analysisImage = new BloodImage(bloodImageFileName,
                    EnterProbeDateDateTimePicker.Value);
                ErythrocyteResult erythrocytes = new ErythrocyteResult(
                    Convert.ToInt32(ErythrocyteCountAnalysisLabel.Text), "file");
                LeukocyteResult leukocytes = new LeukocyteResult(
                    Convert.ToInt32(LeukocytesCountAnalysisLabel.Text), "file");
                Result result = new Result(erythrocytes, leukocytes,
                    EnterResultAnaliseRichTextBox.Text);
                Analysis analysis = new Analysis(EnterBloodAnaliseNumTextLabel.Text,
                    selectPacient.MedicalCardNumber, EnterDateAnaliseDateTimePicker.Value,
                    analysisImage, 1, result);
                if (AnalysisCatalog.AddNewAnalysis(analysis))
                {
                    analysisResult.SaveResultAnalysisImage();
                    analysisResult = null;
                    CancelAnalysisButton_Click(sender, e);
                    ClearEnterAnalysisDataButton_Click(sender, e);
                    UpdatePacientAnalysisDataGridView(0);
                    MessageBox.Show("Результаты анализа добавлены в базу данных", 
                        "Сообщение о сохранении анализа", MessageBoxButtons.OK, 
                        MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Анализ был ранее сохранен в базе данных", 
                        "Ошибка сохранения анализа", MessageBoxButtons.OK, 
                        MessageBoxIcon.Asterisk);
                }
            }
            else
            {
                MessageBox.Show("Необходимо ввести результат анализа пациента",
                    "Неверный ввод данных анализа", MessageBoxButtons.OK, 
                    MessageBoxIcon.Asterisk);
            }
        }

        private void CancelAnalysisButton_Click(object sender, EventArgs e)
        {
            analysisResult = null;
            EnterResultAnaliseRichTextBox.Text = "";
            EnterResultAnaliseRichTextBox_Leave(sender, e);
            ErythrocyteCountAnalysisLabel.Text = "";
            LeukocytesCountAnalysisLabel.Text = "";
            ResultAnalysisControlComponent(false);
        }

        private void ResultAnalysisControlComponent(bool isResult)
        {
            EnterProbeDateDateTimePicker.Enabled = !isResult;
            EnterDateAnaliseDateTimePicker.Enabled = !isResult;
            LoadImageButton.Enabled = !isResult;
            EnterCheckPacientButton.Enabled = !isResult;
            StartAnalysisDataButton.Enabled = !isResult;
            ClearEnterAnalysisDataButton.Enabled = !isResult;
            EnterResultAnaliseRichTextBox.Enabled = isResult;
            ViewClassifiedResultButton.Enabled = isResult;
            SaveAnalysisButton.Enabled = isResult;
            CancelAnalysisButton.Enabled = isResult;
            AnalisePatternButton.Enabled = isResult;
        }
        
        public void UpdateAllPacientDataGridView(int selectRowIndex)
        {
            AllPacientDataGridView.Rows.Clear();
            int pacientDataCount = PacientCatalog.Pacients.Count;
            foreach (Pacient pacient in PacientCatalog.Pacients)
            {
                AllPacientDataGridView.Rows.Add(AllPacientDataGridView.Rows.Count + 1,
                    pacient.MedicalCardNumber, pacient.FullPacientName(),
                    pacient.AttachmentPlace.PlaceNumber);
            }
            FirstPacientDataButton.Enabled = selectRowIndex > 0 && pacientDataCount > 1;
            PreviousPacientDataButton.Enabled = selectRowIndex > 0 && pacientDataCount > 1;
            NextPacientDataButton.Enabled =
                selectRowIndex < AllPacientDataGridView.Rows.Count - 1 &&
                pacientDataCount > 1;
            LastPacientDataButton.Enabled =
                selectRowIndex < AllPacientDataGridView.Rows.Count - 1 &&
                pacientDataCount > 1;
            AddPacientDataButton.Enabled = true;
            EditPacientDataButton.Enabled = pacientDataCount > 0;
            DeletePacientDataButton.Enabled = pacientDataCount > 0;
            if (pacientDataCount > 0)
            {
                SelectPacientDataNumberLabel.Text = Convert.ToString(selectRowIndex + 1);
                AllPacientDataNumberLabel.Text = Convert.ToString(pacientDataCount);
                AllPacientDataGridView.CurrentCell =
                    AllPacientDataGridView.Rows[selectRowIndex].Cells[0];
                ViewPacientData();
            }
            else
            {
                SelectPacientDataNumberLabel.Text = "0";
                AllPacientDataNumberLabel.Text = Convert.ToString(pacientDataCount);
                ViewPacientMedicalCardNumLabel.Text = "";
                ViewPacientMedicalPlaceNumLabel.Text = "";
                ViewPacientSurnameLabel.Text = "";
                ViewPacientNameLabel.Text = "";
                ViewPacientPatronimicLabel.Text = "";
                ViewPacientBirthdayLabel.Text = "";
                ViewPacientGenderLabel.Text = "";
                ViewPacientPhoneLabel.Text = "";
                ViewPacientSNILSNumberLabel.Text = "";
                ViewPacientRegistrateDateSNILSLabel.Text = "";
                ViewPacientMedicalLicenseNumberLabel.Text = "";
                ViewPacientRegistrateDateMedicalLicenseLabel.Text = "";
            }
        }

        private void FirstPacientDataButton_Click(object sender, EventArgs e)
        {
            AllPacientDataGridView.CurrentCell = AllPacientDataGridView.Rows[0].Cells[0];
            FirstPacientDataButton.Enabled = false;
            PreviousPacientDataButton.Enabled = false;
            NextPacientDataButton.Enabled = true;
            LastPacientDataButton.Enabled = true;
            ViewPacientData();
        }

        private void PreviousPacientDataButton_Click(object sender, EventArgs e)
        {
            if (AllPacientDataGridView.CurrentRow.Index == 1)
            {
                FirstPacientDataButton.Enabled = false;
                PreviousPacientDataButton.Enabled = false;
            }
            if (AllPacientDataGridView.CurrentRow.Index == 
                AllPacientDataGridView.Rows.Count - 1)
            {
                NextPacientDataButton.Enabled = true;
                LastPacientDataButton.Enabled = true;
            }
            AllPacientDataGridView.CurrentCell = 
                AllPacientDataGridView.Rows[AllPacientDataGridView.CurrentRow.Index - 1].Cells[0];
            ViewPacientData();
        }

        private void NextPacientDataButton_Click(object sender, EventArgs e)
        {
            if (AllPacientDataGridView.CurrentRow.Index == AllPacientDataGridView.Rows.Count - 2)
            {
                NextPacientDataButton.Enabled = false;
                LastPacientDataButton.Enabled = false;
            }
            if (AllPacientDataGridView.CurrentRow.Index == 0)
            {
                FirstPacientDataButton.Enabled = true;
                PreviousPacientDataButton.Enabled = true;
            }
            AllPacientDataGridView.CurrentCell = 
                AllPacientDataGridView.Rows[AllPacientDataGridView.CurrentRow.Index + 1].Cells[0];
            ViewPacientData();
        }

        private void LastPacientDataButton_Click(object sender, EventArgs e)
        {
            AllPacientDataGridView.CurrentCell = 
                AllPacientDataGridView.Rows[AllPacientDataGridView.Rows.Count - 1].Cells[0];
            FirstPacientDataButton.Enabled = true;
            PreviousPacientDataButton.Enabled = true;
            NextPacientDataButton.Enabled = false;
            LastPacientDataButton.Enabled = false;
            ViewPacientData();
        }

        private void AddPacientDataButton_Click(object sender, EventArgs e)
        {
            FirstPacientDataButton.Enabled = false;
            PreviousPacientDataButton.Enabled = false;
            NextPacientDataButton.Enabled = false;
            LastPacientDataButton.Enabled = false;
            AddPacientDataButton.Enabled = false;
            EditPacientDataButton.Enabled = false;
            DeletePacientDataButton.Enabled = false;
            AddEditPacientDataForm AddPacientForm = new AddEditPacientDataForm(
                this, AddEditFormEnum.AddData, PacientCatalog, 0);
            AddPacientForm.Show();
        }

        private void EditPacientDataButton_Click(object sender, EventArgs e)
        {
            FirstPacientDataButton.Enabled = false;
            PreviousPacientDataButton.Enabled = false;
            NextPacientDataButton.Enabled = false;
            LastPacientDataButton.Enabled = false;
            AddPacientDataButton.Enabled = false;
            EditPacientDataButton.Enabled = false;
            DeletePacientDataButton.Enabled = false;
            AddEditPacientDataForm EditPacientForm = new AddEditPacientDataForm(
                this, AddEditFormEnum.EditData, PacientCatalog,
                AllPacientDataGridView.CurrentCell.RowIndex);
            EditPacientForm.Show();
        }

        private void DeletePacientDataButton_Click(object sender, EventArgs e)
        {
            bool isDeletePacientData =
                PacientCatalog.DeletePacient(AllPacientDataGridView.CurrentCell.RowIndex);
            if (isDeletePacientData)
            {
                MessageBox.Show("Запись успешно удалена из базы данных",
                    "Удаление данных пациента", MessageBoxButtons.OK, MessageBoxIcon.Information);
                UpdateAllPacientDataGridView(0);
            }
            else
            {
                MessageBox.Show("Удаление записи невозможно из базы данных",
                    "Ошибка удаления данных пациента", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ViewPacientData()
        {
            int currentPacientIndex = AllPacientDataGridView.CurrentCell.RowIndex;
            Pacient currentPacient = PacientCatalog.PacientByIndex(currentPacientIndex);
            ViewPacientMedicalCardNumLabel.Text = currentPacient.MedicalCardNumber;
            ViewPacientMedicalPlaceNumLabel.Text =
                Convert.ToString(currentPacient.AttachmentPlace.PlaceNumber);
            ViewPacientSurnameLabel.Text = currentPacient.Surname;
            ViewPacientNameLabel.Text = currentPacient.Name;
            ViewPacientPatronimicLabel.Text = currentPacient.Patronimic;
            ViewPacientBirthdayLabel.Text = currentPacient.BirthDate.ToString("dd.MM.yyyy");
            ViewPacientGenderLabel.Text = currentPacient.Gender.ShortGenderName();
            ViewPacientPhoneLabel.Text = currentPacient.PhoneNumber;
            ViewPacientSNILSNumberLabel.Text = currentPacient.SNILS.SNILSNumber;
            ViewPacientRegistrateDateSNILSLabel.Text =
                currentPacient.SNILS.RegistrateDate.ToString("dd.MM.yyyy");
            ViewPacientMedicalLicenseNumberLabel.Text = currentPacient.MedicalLicense.LicenseNumber;
            ViewPacientRegistrateDateMedicalLicenseLabel.Text =
                currentPacient.MedicalLicense.RegistrateDate.ToString("dd.MM.yyyy");
            SelectPacientDataNumberLabel.Text = (currentPacientIndex + 1).ToString();
        }
        
        private void UpdatePacientAnalysisDataGridView(int selectRowIndex)
        {
            PacientAnalysisDataGridView.Rows.Clear();
            int analysisDataCount = AnalysisCatalog.AnalysisCatalogData.Count;
            foreach (Analysis analysis in AnalysisCatalog.AnalysisCatalogData)
            {
                Pacient selectPacient = 
                    PacientCatalog.PacientByMedicalCard(analysis.MedicalCardNumber);
                PacientAnalysisDataGridView.Rows.Add(PacientAnalysisDataGridView.Rows.Count + 1,
                    analysis.AnalysisNumber, analysis.MedicalCardNumber,
                    selectPacient.FullPacientName(), analysis.AnalysisData.ToShortDateString());
            }
            FirstAnalysisDataButton.Enabled = selectRowIndex > 0 && analysisDataCount > 1;
            PreviousAnalysisDataButton.Enabled = selectRowIndex > 0 && analysisDataCount > 1;
            NextAnalysisDataButton.Enabled =
                selectRowIndex < PacientAnalysisDataGridView.Rows.Count - 1 &&
                analysisDataCount > 1;
            LastAnalysisDataButton.Enabled =
                selectRowIndex < PacientAnalysisDataGridView.Rows.Count - 1 &&
                analysisDataCount > 1;
            PrintPreviewResultAnalysisButton.Enabled = analysisDataCount > 0;
            DeleteAnalysisDataButton.Enabled = analysisDataCount > 0;
            PrintToolStripMenuItem.Enabled = analysisDataCount > 0 && 
                ProjectTabControl.SelectedIndex == 2;
            if (analysisDataCount > 0)
            {
                SelectAnalysisDataNumberLabel.Text = Convert.ToString(selectRowIndex + 1);
                AllAnalysisDataNumberLabel.Text = Convert.ToString(analysisDataCount);
                PacientAnalysisDataGridView.CurrentCell =
                    PacientAnalysisDataGridView.Rows[selectRowIndex].Cells[0];
                ViewAnalysisData();
            }
            else
            {
                SelectAnalysisDataNumberLabel.Text = "0";
                AllAnalysisDataNumberLabel.Text = Convert.ToString(analysisDataCount);
                ViewAnalysisNumberLabel.Text = "";
                ViewProbeDateLabel.Text = "";
                ViewAnalysisDateLabel.Text = "";
                ViewErythrocyteCountLabel.Text = "";
                ViewLeukocyteCoumtLabel.Text = "";
                ViewResultAnalysisRichTextBox.Text = "";
                ViewBloodImagePictureBox.Image = null;
                ViewAnalysisPacientMedicalCardNumLabel.Text = "";
                ViewAnalysisPacientMedicalPlaceNumLabel.Text = "";
                ViewAnalysisPacientSurnameLabel.Text = "";
                ViewAnalysisPacientNameLabel.Text = "";
                ViewAnalysisPacientPatronimicLabel.Name = "";
                ViewAnalysisPacientBirthdayLabel.Text = "";
                ViewAnalysisPacientGenderLabel.Text = "";
                ViewAnalysisPacientPhoneLabel.Text = "";
                ViewAnalysisPacientSNILSNumberLabel.Text = "";
                ViewAnalysisPacientRegistrateDateSNILSLabel.Text = "";
                ViewAnalysisPacientMedicalLicenseNumberLabel.Text = "";
                ViewAnalysisPacientRegistrateDateMedicalLicenseLabel.Text = "";
            }
        }

        private void FirstAnalysisDataButton_Click(object sender, EventArgs e)
        {
            PacientAnalysisDataGridView.CurrentCell = 
                PacientAnalysisDataGridView.Rows[0].Cells[0];
            FirstAnalysisDataButton.Enabled = false;
            PreviousAnalysisDataButton.Enabled = false;
            NextAnalysisDataButton.Enabled = true;
            LastAnalysisDataButton.Enabled = true;
            ViewAnalysisData();
        }

        private void PreviousAnalysisDataButton_Click(object sender, EventArgs e)
        {
            if (PacientAnalysisDataGridView.CurrentRow.Index == 1)
            {
                FirstAnalysisDataButton.Enabled = false;
                PreviousAnalysisDataButton.Enabled = false;
            }
            if (PacientAnalysisDataGridView.CurrentRow.Index ==
                PacientAnalysisDataGridView.Rows.Count - 1)
            {
                NextAnalysisDataButton.Enabled = true;
                LastAnalysisDataButton.Enabled = true;
            }
            PacientAnalysisDataGridView.CurrentCell =
                PacientAnalysisDataGridView.Rows[PacientAnalysisDataGridView.CurrentRow.Index - 1].Cells[0];
            ViewAnalysisData();
        }

        private void NextAnalysisDataButton_Click(object sender, EventArgs e)
        {
            if (PacientAnalysisDataGridView.CurrentRow.Index == PacientAnalysisDataGridView.Rows.Count - 2)
            {
                NextAnalysisDataButton.Enabled = false;
                LastAnalysisDataButton.Enabled = false;
            }
            if (PacientAnalysisDataGridView.CurrentRow.Index == 0)
            {
                FirstAnalysisDataButton.Enabled = true;
                PreviousAnalysisDataButton.Enabled = true;
            }
            PacientAnalysisDataGridView.CurrentCell =
                PacientAnalysisDataGridView.Rows[PacientAnalysisDataGridView.CurrentRow.Index + 1].Cells[0];
            ViewAnalysisData();
        }

        private void LastAnalysisDataButton_Click(object sender, EventArgs e)
        {
            PacientAnalysisDataGridView.CurrentCell =
                PacientAnalysisDataGridView.Rows[PacientAnalysisDataGridView.Rows.Count - 1].Cells[0];
            FirstAnalysisDataButton.Enabled = true;
            PreviousAnalysisDataButton.Enabled = true;
            NextAnalysisDataButton.Enabled = false;
            LastAnalysisDataButton.Enabled = false;
            ViewAnalysisData();
        }

        private void PrintPreviewButton_Click(object sender, EventArgs e)
        {
            PrintDocument document = new PrintDocument();
            document.PrintPage += new PrintPageEventHandler(NewPrintDocument);
            document.DocumentName = "Бланк анализа";
            PrintPreviewDialog printDialog = new PrintPreviewDialog
            {
                WindowState = FormWindowState.Maximized,
                Document = document
            };
            printDialog.ShowDialog();
        }

        void NewPrintDocument(object sender, PrintPageEventArgs e)
        {
            Analysis printAnalysis = 
                AnalysisCatalog.AnalysisByIndex(PacientAnalysisDataGridView.CurrentCell.RowIndex);
            Pacient pacient = PacientCatalog.PacientByMedicalCard(printAnalysis.MedicalCardNumber);
            Graphics graphicDocument = e.Graphics;
            Font boldText = new Font("Times New Roman", 15, FontStyle.Bold);
            Font underText = new Font("Times New Roman", 15, FontStyle.Underline);
            SolidBrush brush = new SolidBrush(Color.Black);
            graphicDocument.DrawString("АНАЛИЗ КРОВИ №", new Font("Times New Roman", 18, FontStyle.Bold), brush, 230, 60);
            graphicDocument.DrawString(printAnalysis.AnalysisNumber, new Font("Times New Roman", 16, FontStyle.Underline), brush, 465, 62);
            graphicDocument.DrawString("Пациент", boldText, brush, 80, 150);
            graphicDocument.DrawString(pacient.FullPacientName(), underText, brush, 170, 150);
            graphicDocument.DrawString("Дата рождения пациента", boldText, brush, 80, 180);
            graphicDocument.DrawString(pacient.BirthDate.ToShortDateString(), underText, brush, 330, 180);
            graphicDocument.DrawString("№ медицинской карты", boldText, brush, 80, 210);
            graphicDocument.DrawString(printAnalysis.MedicalCardNumber, underText, brush, 310, 210);
            graphicDocument.DrawString("СНИЛС", boldText, brush, 80, 240);
            graphicDocument.DrawString(pacient.SNILS.SNILSNumber, underText, brush, 160, 240);
            graphicDocument.DrawString("Полис ОМС", boldText, brush, 80, 270);
            graphicDocument.DrawString(pacient.MedicalLicense.LicenseNumber, underText, brush, 200, 270);
            graphicDocument.DrawString("Дата взятия пробы", boldText, brush, 80, 340);
            graphicDocument.DrawString(printAnalysis.BloodImage.BloodImageDate.ToShortDateString(), underText, brush, 270, 340);
            graphicDocument.DrawString("Дата проведения анализа", boldText, brush, 80, 370);
            graphicDocument.DrawString(printAnalysis.AnalysisData.ToShortDateString(), underText, brush, 330, 370);
            graphicDocument.DrawString("Результаты анализа:", boldText, brush, 80, 440);
            graphicDocument.DrawString(printAnalysis.AnalysisResult.ResultText, new Font("Times New Roman", 15), brush, 120, 480);
            graphicDocument.DrawString("Изображение мазка крови:", boldText, brush, 520, 150);
            graphicDocument.DrawImage(ViewBloodImagePictureBox.Image, 550, 180, 190, 190);
            graphicDocument.DrawString("Дата печати бланка анализа", boldText, brush, 80, 690);
            graphicDocument.DrawString(DateTime.Now.ToShortDateString(), underText, brush, 360, 690);
            graphicDocument.DrawString("Лаборант", boldText, brush, 80, 720);
            graphicDocument.DrawString(listener.ShortLaborantName(), underText, brush, 180, 720);
        }

        private void DeleteAnalysisDataButton_Click(object sender, EventArgs e)
        {
            int deleteAnalysisIndex = PacientAnalysisDataGridView.CurrentCell.RowIndex;
            bool isDeleteAnalysisData =
                AnalysisCatalog.DeleteAnalysis(deleteAnalysisIndex);
            if (isDeleteAnalysisData)
            {
                MessageBox.Show("Запись успешно удалена из базы данных",
                    "Удаление данных анализа", MessageBoxButtons.OK, MessageBoxIcon.Information);
                UpdatePacientAnalysisDataGridView(0);
                GenerateAnalysisNumber(DateTime.Today);
            }
            else
            {
                MessageBox.Show("Удаление записи невозможно из базы данных",
                    "Ошибка удаления данных анализа", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ViewAnalysisData()
        {
            int currentAnalysisIndex = PacientAnalysisDataGridView.CurrentCell.RowIndex;
            Analysis currentAnalysis = AnalysisCatalog.AnalysisByIndex(currentAnalysisIndex);
            Pacient currentPacient = 
                PacientCatalog.PacientByMedicalCard(currentAnalysis.MedicalCardNumber);
            ViewAnalysisNumberLabel.Text = currentAnalysis.AnalysisNumber;
            ViewProbeDateLabel.Text = 
                currentAnalysis.BloodImage.BloodImageDate.ToShortDateString();
            ViewAnalysisDateLabel.Text = currentAnalysis.AnalysisData.ToShortDateString();
            ViewErythrocyteCountLabel.Text = 
                currentAnalysis.AnalysisResult.Erythrocytes.CellCount.ToString();
            ViewLeukocyteCoumtLabel.Text = 
                currentAnalysis.AnalysisResult.Leukocytes.CellCount.ToString();
            ViewResultAnalysisRichTextBox.Text = currentAnalysis.AnalysisResult.ResultText;
            ViewBloodImagePictureBox.Image = 
                Image.FromFile(Directory.GetCurrentDirectory() + @"\" 
                    + currentAnalysis.BloodImage.FileName);
            ViewAnalysisPacientMedicalCardNumLabel.Text = currentPacient.MedicalCardNumber;
            ViewAnalysisPacientMedicalPlaceNumLabel.Text = 
                currentPacient.AttachmentPlace.PlaceNumber.ToString();
            ViewAnalysisPacientSurnameLabel.Text = currentPacient.Surname;
            ViewAnalysisPacientNameLabel.Text = currentPacient.Name;
            ViewAnalysisPacientPatronimicLabel.Text = currentPacient.Patronimic;
            ViewAnalysisPacientBirthdayLabel.Text = currentPacient.BirthDate.ToShortDateString();
            ViewAnalysisPacientGenderLabel.Text = currentPacient.Gender.ShortGenderName();
            ViewAnalysisPacientPhoneLabel.Text = currentPacient.PhoneNumber;
            ViewAnalysisPacientSNILSNumberLabel.Text = currentPacient.SNILS.SNILSNumber;
            ViewAnalysisPacientRegistrateDateSNILSLabel.Text =
                currentPacient.SNILS.RegistrateDate.ToShortDateString();
            ViewAnalysisPacientMedicalLicenseNumberLabel.Text = 
                currentPacient.MedicalLicense.LicenseNumber;
            ViewAnalysisPacientRegistrateDateMedicalLicenseLabel.Text = 
                currentPacient.MedicalLicense.RegistrateDate.ToShortDateString();
        }

        private void ProjectTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (ProjectTabControl.SelectedIndex)
            {
                case 0:
                    PrintToolStripMenuItem.Enabled = false;
                    StartAnalysisToolStripMenuItem.Enabled = false;
                    ViewPacientDataToolStripMenuItem.Enabled = true;
                    ViewAnalysisToolStripMenuItem.Enabled = true;
                    break;
                case 1:
                    PrintToolStripMenuItem.Enabled = false;
                    StartAnalysisToolStripMenuItem.Enabled = true;
                    ViewPacientDataToolStripMenuItem.Enabled = false;
                    ViewAnalysisToolStripMenuItem.Enabled = true;
                    break;
                case 2:
                    PrintToolStripMenuItem.Enabled =
                        AnalysisCatalog.AnalysisCatalogData.Count > 0;
                    StartAnalysisToolStripMenuItem.Enabled = true;
                    ViewPacientDataToolStripMenuItem.Enabled = true;
                    ViewAnalysisToolStripMenuItem.Enabled = false;
                    break;
            }
        }

        private void PreviewPrintToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintPreviewButton_Click(sender, e);
        }

        private void PrintAnalizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DocumentAnalisePrintDialog.ShowDialog();
            PrintDocument document = new PrintDocument();
            document.PrintPage += new PrintPageEventHandler(NewPrintDocument);
            document.DocumentName = "Бланк анализа";
            document.PrinterSettings = DocumentAnalisePrintDialog.PrinterSettings;
            document.Print();
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void StartAnalysisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProjectTabControl.SelectedIndex = 0;
        }

        private void ViewPacientDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProjectTabControl.SelectedIndex = 1;
        }

        private void ViewAnalysisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProjectTabControl.SelectedIndex = 2;
        }

        private void LaborantWorkForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult exitResult =
                MessageBox.Show(
                    "Вы действительно хотите выйти?",
                    "Выход из системы",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (exitResult == DialogResult.Yes)
            {
                listener.LaborantExitRepost();
                ClientListener newListener = listener.LaboratExitRequest(autorisationForm);
                listener.AbortThread();
                autorisationForm.UpdateClientSocket(newListener);
                autorisationForm.Show();
            }
            else
                e.Cancel = true;
        }

        private void ViewClassifiedResultButton_Click(object sender, EventArgs e)
        {
            ViewClassifiedResultForm viewClassifieResult = new ViewClassifiedResultForm(EnterBloodAnaliseNumTextLabel.Text);
            viewClassifieResult.Show();
        }
    }
}