using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service;
using Repository;
using Entity;

namespace Presenter
{
    public class MedRegistratorPresenter
    {
        private IMedRegistratorForm _view;
        private MedRegistratorService _service;
        private MedRegistratorService _service1;

        public MedRegistratorPresenter(IMedRegistratorForm view)
        {
            _view = view;
            _service = new MedRegistratorService();
            _service1 = new MedRegistratorService();
        }

        public void initView()
        {
            IEnumerable<patientLimited> database = requestDataBase();
            _view.fillDataGridView(getSNM(database), getId(database));
        }

        public void deletePatient(int id)
        {
            _service.delete(id);
            _view.deleteSelectedRow();
        }

        public void reloadView()
        {
            _view.clearDataGridView();
            initView();
        }

        private IEnumerable<patientLimited> requestDataBase()
        {
            return _service.getAllLimitedDatabase();
        }

        private IEnumerable<String> getSNM(IEnumerable<patientLimited> data)
        {
            String[] toReturn = new String[data.Count()];
            int i = 0;
            foreach (patientLimited element in data)
            {
                toReturn[i] = element.surname + ' ' + element.name + ' ' + element.middlename;
                i++;
            }
            return toReturn;
        }

        private IEnumerable<int> getId(IEnumerable<patientLimited> data)
        {
            int[] toReturn = new int[data.Count()];
            int i = 0;
            foreach (patientLimited element in data)
            {
                toReturn[i] = element.id;
                i++;
            }
            return toReturn;
        }

        public void callNewForm(int id)
        {
            _view.callForm(id);
        }

        public void callNewForm()
        {
            _view.callForm();
        }
    }
}
