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

namespace View
{
    public partial class MedRegistratorForm : Form, IMedRegistratorForm
    {
        private MedRegistratorPresenter _presenter;

        public MedRegistratorForm()
        {
            InitializeComponent();
            _presenter = new MedRegistratorPresenter(this);
            _presenter.initView();
        }


        public void fillDataGridView(IEnumerable<String> SNMarray, IEnumerable<int> IDarray)
        {
            PatientsDataGridView.Columns.Add("column1", "ID");
            PatientsDataGridView.Columns.Add("column0", "ФИО");
            int arrayLength = SNMarray.Count<String>();
            DataGridViewRow[] rows = new DataGridViewRow[arrayLength];
            for (int j=0; j < arrayLength; j++)
            {
                DataGridViewRow row = new DataGridViewRow();
                rows[j] = row;
                row.CreateCells(PatientsDataGridView);
            }
            int i = 0;
            foreach (var element in IDarray)
            {
                rows[i].Cells[0].Value = element.ToString();
                i++;
            }
            i = 0;
            foreach (var element in SNMarray)
            {
                rows[i].Cells[1].Value = element;
                i++;
            }
            foreach (DataGridViewRow row in rows)
            {
                PatientsDataGridView.Rows.Add(row);
            }
        }

        public void deleteSelectedRow()
        {
            PatientsDataGridView.Rows.Remove(PatientsDataGridView.CurrentRow);

        }

        public void clearDataGridView()
        {
            PatientsDataGridView.Rows.Clear();
            PatientsDataGridView.Columns.Clear();
        }

        /*public void show()
        {
            this.Show();
        }*/

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public void callForm()
        {
            new MedRegistratorPatientForm().Show();
        }

        public void callForm(int id)
        {
            new MedRegistratorPatientForm(id).Show();
        }

        private void showAllPatientsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _presenter.reloadView();
        }

        private void PatientsDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dataGridView = (DataGridView)sender;
            try
            {
                PatientNameLabel.Text = dataGridView.CurrentRow.Cells[1].Value.ToString();
            }
            catch
            {
                PatientNameLabel.Text = "Не выбрано";
            }

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void searchPatientToolStripMenuItem1_Click(object sender, EventArgs e)
        {
        }

        private void chooseButton_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(PatientsDataGridView.CurrentRow.Cells[0].Value.ToString());
                _presenter.callNewForm(id);
            }
            catch
            {
                MessageBox.Show("Выберите пациента");
            }     
        }

        private void deleteThisPatientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int id =  Convert.ToInt32(PatientsDataGridView.CurrentRow.Cells[0].Value.ToString());
                _presenter.deletePatient(id);
            }
            catch
            {
                MessageBox.Show("Выберите пациента");
            }    
        }

        private void addNewPatientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _presenter.callNewForm();
        }

        

    }
}