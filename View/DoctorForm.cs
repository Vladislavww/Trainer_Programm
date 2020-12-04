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
    public partial class DoctorForm : Form, IDoctorForm
    {
        private DoctorPresenter _presenter;

        public DoctorForm()
        {
            InitializeComponent();
            _presenter = new DoctorPresenter(this);
            _presenter.initView();
        }

        public void fillDataGridView(IEnumerable<String> SNMarray, IEnumerable<int> IDarray)
        {
            patientsDataGridView.Columns.Add("column1", "ID");
            patientsDataGridView.Columns.Add("column0", "ФИО");
            int arrayLength = SNMarray.Count<String>();
            DataGridViewRow[] rows = new DataGridViewRow[arrayLength];
            for (int j = 0; j < arrayLength; j++)
            {
                DataGridViewRow row = new DataGridViewRow();
                rows[j] = row;
                row.CreateCells(patientsDataGridView);
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
                patientsDataGridView.Rows.Add(row);
            }
        }

        private void showAllPatientsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void searchPatienttoolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void patientsDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
