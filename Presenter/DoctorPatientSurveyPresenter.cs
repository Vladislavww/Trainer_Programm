using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service;
using Entity;
using EmulationGraphicData;

namespace Presenter
{
    public class DoctorPatientSurveyPresenter : IDoctorPatientSurveyPresenter
    {
        IDoctorPatientSurveyForm _view;
        DoctorPatientSurveyService _service;
        bool _surveyGoing;

        public DoctorPatientSurveyPresenter(IDoctorPatientSurveyForm view, patientFull.Survey survey)
        {
            _view = view;
            _service = new DoctorPatientSurveyService(this, survey);
            _surveyGoing = false;
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

        public void changeSurveyGoing()
        {
            if (_surveyGoing == true)
            {
                stopSurvey();
                _surveyGoing = false;
            }
            else
            {
                startSurvey();
                _surveyGoing = true;
            }
        }

        public void addDotToChart(double x, double y, int chartNum)
        {
            _view.addDotToChart(x, y, chartNum);
        }

        public void stopSurvey()
        {
            _service.stopSurvey();
        }

        private void startSurvey()
        {
            _view.removeCharts();
            IEnumerable<SensorStruct> activatedSensors = _service.getActivatedSensors();
            foreach (var element in activatedSensors)
            {
                _view.addChart(element.name, element.type);
            }
            _service.startSurvey();
        }
    }
}
