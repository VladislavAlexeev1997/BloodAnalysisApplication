using System;
using System.Windows.Forms;
using BloodAnalysisApplication_Client.Model.BloodAnalysis;

namespace BloodAnalysisApplication_Client.UserInterface
{
    public partial class ViewClassifiedResultForm : Form
    {
        private readonly string  analysisNumber;

        private readonly ImageParameters imageParameters;

        public ViewClassifiedResultForm(string _analysisNumber)
        {
            InitializeComponent();
            analysisNumber = _analysisNumber;
            imageParameters = new ImageParameters(_analysisNumber);
            AllObjectCountTextLabel.Text = imageParameters.allCellsCount.ToString();
            AllObjectNumberLabel.Text = imageParameters.allCellsCount.ToString();
            ErythrocyteCountTextLabel.Text = imageParameters.erithrocyteCount.ToString();
            LeukocyteCountTextLabel.Text = imageParameters.leukocyteCount.ToString();
            NonObjectCountTextLabel.Text = imageParameters.nonObjectCount.ToString();
            CustomerUserDataGridViews();
            ViewAllObjectRadioButton.Checked = true;
            FirstObjectButton.Enabled = false;
            PreviousObjectButton.Enabled = false;
            NextObjectButton.Enabled = true;
            LastObjectButton.Enabled = true;
        }

        private void CustomerUserDataGridViews()
        {
            ApplicationDataGridViewCustomer allObjectDataGridCustomer
                = new ApplicationDataGridViewCustomer(AllObjectDataGridView);
            allObjectDataGridCustomer.AddDataGridViewColumn(new DataGridViewTextBoxColumn(),
                "№ п/п", "NumberRowColumn", 55);
            allObjectDataGridCustomer.AddDataGridViewColumn(new DataGridViewTextBoxColumn(),
                "Тип", "CellTypeColumn", 139);
            UpdateAllObjectDataGridView(0);
        }

        private void ViewAllObjectRadioButton_Click(object sender, EventArgs e)
        {
            ViewEveryObjectRadioButton.Checked = false;
            ViewAllObjectRadioButton.Checked = true;
            ImagePictureBox.Image = imageParameters.DrawAllObjects();
        }

        private void ViewEveryObjectRadioButton_Click(object sender, EventArgs e)
        {
            ViewAllObjectRadioButton.Checked = false;
            ViewEveryObjectRadioButton.Checked = true;
            ImagePictureBox.Image = imageParameters.DrawObject(AllObjectDataGridView.CurrentRow.Index);
        }

        private void UpdateAllObjectDataGridView(int selectRowIndex)
        {
            AllObjectDataGridView.Rows.Clear();
            int pacientDataCount = imageParameters.objects.Count;
            foreach (CellObject cell_object in imageParameters.objects)
            {
                AllObjectDataGridView.Rows.Add(AllObjectDataGridView.Rows.Count + 1,
                    cell_object.type_object);
            }
            AllObjectDataGridView.CurrentCell = AllObjectDataGridView.Rows[selectRowIndex].Cells[0];
            SelectObjectNumberLabel.Text = (selectRowIndex + 1).ToString();
        }

        private void FirstObjectButton_Click(object sender, EventArgs e)
        {
            AllObjectDataGridView.CurrentCell = AllObjectDataGridView.Rows[0].Cells[0];
            FirstObjectButton.Enabled = false;
            PreviousObjectButton.Enabled = false;
            NextObjectButton.Enabled = true;
            LastObjectButton.Enabled = true;
            SelectObjectNumberLabel.Text = (AllObjectDataGridView.CurrentRow.Index + 1).ToString();
            if (ViewEveryObjectRadioButton.Checked)
            {
                ImagePictureBox.Image = imageParameters.DrawObject(AllObjectDataGridView.CurrentRow.Index);
            }
        }

        private void PreviousObjectButton_Click(object sender, EventArgs e)
        {
            if (AllObjectDataGridView.CurrentRow.Index == 1)
            {
                FirstObjectButton.Enabled = false;
                PreviousObjectButton.Enabled = false;
            }
            if (AllObjectDataGridView.CurrentRow.Index ==
                AllObjectDataGridView.Rows.Count - 1)
            {
                NextObjectButton.Enabled = true;
                LastObjectButton.Enabled = true;
            }
            AllObjectDataGridView.CurrentCell =
                AllObjectDataGridView.Rows[AllObjectDataGridView.CurrentRow.Index - 1].Cells[0];
            SelectObjectNumberLabel.Text = (AllObjectDataGridView.CurrentRow.Index + 1).ToString();
            if (ViewEveryObjectRadioButton.Checked)
            {
                ImagePictureBox.Image = imageParameters.DrawObject(AllObjectDataGridView.CurrentRow.Index);
            }
        }

        private void NextObjectButton_Click(object sender, EventArgs e)
        {
            if (AllObjectDataGridView.CurrentRow.Index == AllObjectDataGridView.Rows.Count - 2)
            {
                NextObjectButton.Enabled = false;
                LastObjectButton.Enabled = false;
            }
            if (AllObjectDataGridView.CurrentRow.Index == 0)
            {
                FirstObjectButton.Enabled = true;
                PreviousObjectButton.Enabled = true;
            }
            AllObjectDataGridView.CurrentCell =
                AllObjectDataGridView.Rows[AllObjectDataGridView.CurrentRow.Index + 1].Cells[0];
            SelectObjectNumberLabel.Text = (AllObjectDataGridView.CurrentRow.Index + 1).ToString();
            if (ViewEveryObjectRadioButton.Checked)
            {
                ImagePictureBox.Image = imageParameters.DrawObject(AllObjectDataGridView.CurrentRow.Index);
            }
        }

        private void LastObjectButton_Click(object sender, EventArgs e)
        {
            AllObjectDataGridView.CurrentCell =
                AllObjectDataGridView.Rows[AllObjectDataGridView.Rows.Count - 1].Cells[0];
            FirstObjectButton.Enabled = true;
            PreviousObjectButton.Enabled = true;
            NextObjectButton.Enabled = false;
            LastObjectButton.Enabled = false;
            SelectObjectNumberLabel.Text = (AllObjectDataGridView.CurrentRow.Index + 1).ToString();
            if (ViewEveryObjectRadioButton.Checked)
            {
                ImagePictureBox.Image = imageParameters.DrawObject(AllObjectDataGridView.CurrentRow.Index);
            }
        }

        private void CloseViewFormButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }

    
}