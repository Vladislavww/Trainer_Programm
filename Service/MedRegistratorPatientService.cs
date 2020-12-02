using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;
using Entity;

namespace Service
{
    public class MedRegistratorPatientService : BaseService
    {
        BasicRepository _repository;
        patientFull _patient;

        public MedRegistratorPatientService(int id)
        {
            _repository = repository;
            _patient = _repository.getPatientFullDatabase(id);
        }

        public MedRegistratorPatientService()
        {
            _repository = repository;
            _patient = new patientFull();
        }

        public patientFull getPatient()
        {
            return _patient;
        }

        public void addNewPatient(patientFull data)
        {
            _repository.add(data);
        }

        public void changePatient(patientFull data)
        {
            _repository.changePatientFull(data);
        }

        public void deleteSurvey(int id)
        {
            try
            {
                _patient.surveys.Remove(searchSurvey(id));
            }
            catch
            {
            }
        }

        public patientFull.Survey getSurvey(int id)
        {
            return searchSurvey(id);
        }

        public void changeSurvey(int id, String date, String type, patientFull.Survey.Sensors sensors)
        {
            patientFull.Survey surveyToChange;
            surveyToChange.id = id;
            surveyToChange.date = date;
            surveyToChange.type = type;
            surveyToChange.sensors = sensors;
            try
            {
                _patient.surveys[searchSurveyForIndex(id)] = surveyToChange;
            }
            catch
            {
            }
            /*patientFull.Survey survey;
            survey.date = date;
            survey.type = type;
            survey.sensors = sensors;
            survey.id = calculateSurveyId(date, type, sensors);
            _patient.surveys.Add(survey*/
        }

        public void createSurvey(String date, String type, patientFull.Survey.Sensors sensors)
        {
            patientFull.Survey newSurvey;
            newSurvey.id = calculateSurveyId(date, type, sensors);
            newSurvey.date = date;
            newSurvey.type = type;
            newSurvey.sensors = sensors;
            _patient.surveys.Add(newSurvey);
        }

        private patientFull.Survey searchSurvey(int id)
        {
            foreach (var element in _patient.surveys)
            {
                if (element.id == id)
                {
                    return element;
                }
            }
            return new patientFull.Survey();
        }

        private int searchSurveyForIndex(int id)
        {
            int i = 0;
            foreach (var element in _patient.surveys)
            {
                if (element.id == id)
                {
                    return i;
                }
                i++;
            }
            return -1;
        }

        private int calculateSurveyId(String date, String type, patientFull.Survey.Sensors sensors)
        {
            return date.GetHashCode() + type.GetHashCode() + sensors.GetHashCode();
        }

    }
}
