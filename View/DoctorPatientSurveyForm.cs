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
    public partial class DoctorPatientSurveyForm : Form, IDoctorPatientSurveyForm
    {
        DoctorPatientSurveyPresenter _presenter;

        public DoctorPatientSurveyForm(patientFull.Survey survey)
        {
            InitializeComponent();
            _presenter = new DoctorPatientSurveyPresenter(this, survey);
            _presenter.initView();
        }

        public void fillSensorsDataGridView()
        {
            sensorsDataGridView.Columns.Add("column0", "Name");
            sensorsDataGridView.Columns.Add("column1", "Type");
            sensorsDataGridView.Columns.Add("column2", "Condition");
        }

        public void initSensorTypeComboBox(IEnumerable<String> sensorsType)
        {
            foreach (var element in sensorsType)
            {
                sensorTypeComboBox.Items.Add(element);
            }
        }

        public void showNewSensorError()
        {
            MessageBox.Show("Fill information about sensor", "Warning");
        }

        public void showNameSensorError()
        {
            MessageBox.Show("Sensors' names must be uniqe", "Warning");
        }

        public void addSensorToSensorsDataGridView(String name, String type, String condition)
        {
            DataGridViewRow row = new DataGridViewRow();
            row.CreateCells(sensorsDataGridView);
            row.Cells[0].Value = name;
            row.Cells[1].Value = type;
            row.Cells[2].Value = condition;
            sensorsDataGridView.Rows.Add(row);
        }

        public void deleteSelectedRow()
        {
            sensorsDataGridView.Rows.Remove(sensorsDataGridView.CurrentRow);
        }

        public void activateSelectedSensor()
        {
            sensorsDataGridView.CurrentRow.Cells[2].Value = "OK";
        }

        private void addSensorButton_Click(object sender, EventArgs e)
        {
            _presenter.addNewSensor(sensorNameTextBox.Text, sensorTypeComboBox.Text);
        }

        private void sensorsDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dataGridView = (DataGridView)sender;
            try
            {
                sensorNameLabel.Text = dataGridView.CurrentRow.Cells[0].Value.ToString();
                sensorTypeLabel.Text = dataGridView.CurrentRow.Cells[1].Value.ToString();
                sensorConditionLabel.Text = dataGridView.CurrentRow.Cells[2].Value.ToString();
            }
            catch
            {
                sensorNameLabel.Text = "Not choised";
                sensorTypeLabel.Text = "Not choised";
                sensorConditionLabel.Text = "Not choised";
            }
        }

        private void deleteSensorButton_Click(object sender, EventArgs e)
        {
            try
            {
                String name = sensorsDataGridView.CurrentRow.Cells[0].Value.ToString();
                _presenter.deleteSensor(name);
            }
            catch
            {
                MessageBox.Show("Choose a sensor", "Warning");
            }    
        }

        private void activateSensorButton_Click(object sender, EventArgs e)
        {
            try
            {
                String name = sensorsDataGridView.CurrentRow.Cells[0].Value.ToString();
                _presenter.activateSensor(name);
            }
            catch
            {
                MessageBox.Show("Choose a sensor", "Warning");
            }    
        }
    }
}
