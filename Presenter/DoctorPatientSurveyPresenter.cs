using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service;
using Entity;

namespace Presenter
{
    public class DoctorPatientSurveyPresenter
    {
        IDoctorPatientSurveyForm _view;
        DoctorPatientSurveyService _service;

        public DoctorPatientSurveyPresenter(IDoctorPatientSurveyForm view, patientFull.Survey survey)
        {
            _view = view;
            _service = new DoctorPatientSurveyService(survey);
        }

        public void initView()
        {
            _view.fillSensorsDataGridView();
            _view.initSensorTypeComboBox(_service.getSensorsType());
        }

        public void addNewSensor(String name, String type)
        {
            if (!name.Equals("") && !type.Equals(""))
            {
                if (_service.checkName(name) == true)
                {
                    _service.addSensor(name, type);
                    _view.addSensorToSensorsDataGridView(name, type, "Bad");
                }
                else
                {
                    _view.showNameSensorError();
                }
            }
            else
            {
                _view.showNewSensorError();
            }
        }

        public void deleteSensor(String name)
        {
            _service.deleteSensor(name);
            _view.deleteSelectedRow();
        }

        public void activateSensor(String name)
        {
            _service.activateSensor(name);
            _view.activateSelectedSensor();
        }
    }
}
