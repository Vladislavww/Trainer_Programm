using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using Service;

namespace Presenter
{
    public class MedRegistratorPatientPresenter
    {
        MedRegistratorPatientService _service;
        IMedRegistratorPatientForm _view;
        public byte _radioButtonValue;
        public byte _checkBoxValue;
        public String _dateTextboxValue;

        public MedRegistratorPatientPresenter(IMedRegistratorPatientForm view)
        {
            _service = new MedRegistratorPatientService();
            _view = view;
        }

        public MedRegistratorPatientPresenter(IMedRegistratorPatientForm view, int id)
        {
            _service = new MedRegistratorPatientService(id);
            _view = view;
        }

        public void initView()
        {
            _view.fillViewInformation(_service.getPatient());
            _radioButtonValue = 0;
            _checkBoxValue = 0;
        }

        public void deleteSurvey(int id)
        {
            _service.deleteSurvey(id);
            reloadView();
        }

        public void reloadView()
        {
            _view.clearDataGridView();
            initView();
        }

        public void getSurvey(int id)
        {
            patientFull.Survey survey = _service.getSurvey(id);
            calculate_radioButtonValue(survey);
            calculate_checkBoxValue(survey.sensors);
            _dateTextboxValue = survey.date;
            _view.fillSurveyInformation();
        }

        public void changeSurvey(int id)
        {
            _service.changeSurvey(id, _dateTextboxValue, calculateServiceType(), calculateServiceSensors());
            reloadView();
        }

        public void createSurvey()
        {
            _service.createSurvey(_dateTextboxValue, calculateServiceType(), calculateServiceSensors());
            reloadView();
        }

        private void calculate_checkBoxValue(patientFull.Survey.Sensors data)
        {
            _checkBoxValue = 0;
            if (data.sensor1 == true)
            {
                _checkBoxValue += 1;
            }
            if (data.sensor2 == true)
            {
                _checkBoxValue += 2;
            }
            if (data.sensor3 == true)
            {
                _checkBoxValue += 4;
            }
            if (data.sensor4 == true)
            {
                _checkBoxValue += 8;
            }
            if (data.sensor5 == true)
            {
                _checkBoxValue += 16;
            }
        }

        private void calculate_radioButtonValue(patientFull.Survey data)
        {
            if (data.type.Equals("Run"))
            {
                _radioButtonValue = 1;
            }
            else if (data.type.Equals("Walk"))
            {
                _radioButtonValue = 2;
            }
            else if (data.type.Equals("Strengh"))
            {
                _radioButtonValue = 3;
            }
        }

        private String calculateServiceType()
        {
            if (_radioButtonValue == 1)
            {
                return "Run";
            }
            else if (_radioButtonValue == 2)
            {
                return "Walk";
            }
            else if (_radioButtonValue == 3)
            {
                return "Strengh";
            }
            return null;
        }

        private patientFull.Survey.Sensors calculateServiceSensors()
        {
            //bool sensor1, sensor2, sensor3, sensor4, sensor5;
            patientFull.Survey.Sensors sensors;
            sensors.sensor1 = (_checkBoxValue & 1) == 1;
            sensors.sensor2 = (_checkBoxValue & 2) == 2;
            sensors.sensor3 = (_checkBoxValue & 4) == 4;
            sensors.sensor4 = (_checkBoxValue & 8) == 8;
            sensors.sensor5 = (_checkBoxValue & 16) == 16;
            return sensors;
        }
    }
}
