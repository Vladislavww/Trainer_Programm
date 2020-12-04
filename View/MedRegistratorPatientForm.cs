using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Presenter;
using Entity;

namespace View
{
    public partial class MedRegistratorPatientForm : Form, IMedRegistratorPatientForm
    {
        MedRegistratorPatientPresenter _presenter;

        public MedRegistratorPatientForm()
        {
            InitializeComponent();
            _presenter = new MedRegistratorPatientPresenter(this);
            _presenter.initView();

        }

        public MedRegistratorPatientForm(int id)
        {
            InitializeComponent();
            _presenter = new MedRegistratorPatientPresenter(this, id);
            _presenter.initView();
        }

        public void fillViewInformation(patientFull data)
        {
            surnameTextBox.Text = data.surname;
            nameTextBox.Text = data.name;
            middlenameTextBox.Text = data.middlename;
            fillSurveysDataGridView(data);

        }

        private void fillSurveysDataGridView(patientFull data)
        {
            surveysDataGridView.Columns.Add("column0", "ID");
            surveysDataGridView.Columns.Add("column1", "Survey");
            surveysDataGridView.Columns.Add("column2", "Date");
            int arrayLength = data.surveys.Count<patientFull.Survey>();
            DataGridViewRow[] rows = new DataGridViewRow[arrayLength];
            for (int j = 0; j < arrayLength; j++)
            {
                DataGridViewRow row = new DataGridViewRow();
                rows[j] = row;
                row.CreateCells(surveysDataGridView);
            }
            int i = 0;
            foreach (patientFull.Survey element in data.surveys)
            {
                rows[i].Cells[0].Value = element.id.ToString();
                rows[i].Cells[1].Value = element.type;
                rows[i].Cells[2].Value = element.date;
                i++;
            }
            foreach (DataGridViewRow row in rows)
            {
                surveysDataGridView.Rows.Add(row);
            }
        }

        public void clearDataGridView()
        {
            surveysDataGridView.Rows.Clear();
            surveysDataGridView.Columns.Clear();
        }

        public void fillSurveyInformation()
        {
            dateTextBox.Text = _presenter._dateTextboxValue;
            if (_presenter._radioButtonValue == 1)
            {
                runRadioButton.Select();
            }
            else if (_presenter._radioButtonValue == 2)
            {
                walkRadioButton.Select();
            }
            else if (_presenter._radioButtonValue == 3)
            {
                strengthRadioButton.Select();
            }
            indicator1CheckBox.Checked = (_presenter._checkBoxValue & 1) == 1;
            indicator2CheckBox.Checked = (_presenter._checkBoxValue & 2) == 2;
            indicator3CheckBox.Checked = (_presenter._checkBoxValue & 4) == 4;
            indicator4CheckBox.Checked = (_presenter._checkBoxValue & 8) == 8;
            indicator5CheckBox.Checked = (_presenter._checkBoxValue & 16) == 16;
            
        }

        private void saveToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (nameTextBox.Text != null && surnameTextBox.Text != null && middlenameTextBox.Text != null)
            {
                _presenter.savePatient();
            }
            else
            {
            }

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void surveysGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dataGridView = (DataGridView)sender;
            try
            {
                int id = Convert.ToInt32(dataGridView.CurrentRow.Cells[0].Value.ToString());
                _presenter.getSurvey(id);
            }
            catch
            {
            }
        }

        private void surveyTypeRadioButton_Checked(object sender, EventArgs e)
        {
            RadioButton checkbox = (RadioButton)sender;
            if (checkbox.Text == "Run")
            {
                _presenter._radioButtonValue = 1;
            }
            else if (checkbox.Text == "Walk")
            {
                _presenter._radioButtonValue = 2;
            }
            else if (checkbox.Text == "Strengh")
            {
                _presenter._radioButtonValue = 3;
            }
        }

        private void indicator1CheckBox_CheckStateChanged(object sender, EventArgs e)
        {
            
        }

        private void indicator2CheckBox_CheckStateChanged(object sender, EventArgs e)
        {
            
        }

        private void indicator3CheckBox_CheckStateChanged(object sender, EventArgs e)
        {
            
        }

        private void indicator4CheckBox_CheckStateChanged(object sender, EventArgs e)
        {
            
        }

        private void indicator5CheckBox_CheckStateChanged(object sender, EventArgs e)
        {
            
        }

        private void saveSureveyButton_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(surveysDataGridView.CurrentRow.Cells[0].Value.ToString());
                _presenter.changeSurvey(id);
            }
            catch
            {
                MessageBox.Show("Выберите пациента");
            } 
        }

        private void createSurveyButton_Click(object sender, EventArgs e)
        {
            _presenter.createSurvey();
        }

        private void deleteSurveyButton_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(surveysDataGridView.CurrentRow.Cells[0].Value.ToString());
                _presenter.deleteSurvey(id);
            }
            catch
            {
                MessageBox.Show("Выберите пациента");
            } 
        }

        private void dateTextBox_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            _presenter._dateTextboxValue = textBox.Text;
        }

        private void indicator1CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void indicator2CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void indicator3CheckBox_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void indicator4CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void indicator5CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void indicator1CheckBox_Click(object sender, EventArgs e)
        {
            CheckBox checkbox = (CheckBox)sender;
            if (checkbox.Checked == true)
            {
                _presenter._checkBoxValue += 1;
            }
            else
            {
                _presenter._checkBoxValue -= 1;
            }
        }

        private void indicator2CheckBox_Click(object sender, EventArgs e)
        {
            CheckBox checkbox = (CheckBox)sender;
            if (checkbox.Checked == true)
            {
                _presenter._checkBoxValue += 2;
            }
            else
            {
                _presenter._checkBoxValue -= 2;
            }
        }

        private void indicator3CheckBox_Click(object sender, EventArgs e)
        {
            CheckBox checkbox = (CheckBox)sender;
            if (checkbox.Checked == true)
            {
                _presenter._checkBoxValue += 4;
            }
            else
            {
                _presenter._checkBoxValue -= 4;
            }
        }

        private void indicator4CheckBox_Click(object sender, EventArgs e)
        {
            CheckBox checkbox = (CheckBox)sender;
            if (checkbox.Checked == true)
            {
                _presenter._checkBoxValue += 8;
            }
            else
            {
                _presenter._checkBoxValue -= 8;
            }
        }

        private void indicator5CheckBox_Click(object sender, EventArgs e)
        {
            CheckBox checkbox = (CheckBox)sender;
            if (checkbox.Checked == true)
            {
                _presenter._checkBoxValue += 16;
            }
            else
            {
                _presenter._checkBoxValue -= 16;
            }
        }

        private void surnameTextBox_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            _presenter.setSurname(textBox.Text);
        }

        private void nameTextBox_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            _presenter.setName(textBox.Text);
        }

        private void middlenameTextBox_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            _presenter.setMiddlename(textBox.Text);
        }

    }
}
