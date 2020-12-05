using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class DoctorPatientSurveyService
    {
        patientFull.Survey _survey;
        List<SensorStruct> _sensors;

        public DoctorPatientSurveyService(patientFull.Survey survey)
        {
            _survey = survey;
            _sensors = new List<SensorStruct>();
        }

        public IEnumerable<String> getSensorsType()
        {
            List<String> toReturn = new List<String>();
            if (_survey.sensors.sensor1 == true)
            {
                toReturn.Add("Blood Pressure");
            }
            if (_survey.sensors.sensor2 == true)
            {
                toReturn.Add("Skin's temperature");
            }
            if (_survey.sensors.sensor3 == true)
            {
                toReturn.Add("Skin's humidity");
            }
            if (_survey.sensors.sensor4 == true)
            {
                toReturn.Add("Heart rate");
            }
            if (_survey.sensors.sensor5 == true)
            {
                toReturn.Add("Skin's electrical conductivity");
            }
            return toReturn;
        }

        public void addSensor(String name, String type)
        {
            SensorStruct newSensor;
            newSensor.name = name;
            newSensor.type = type;
            newSensor.condition = false;
            _sensors.Add(newSensor);
        }

        public void deleteSensor(String name)
        {
            _sensors.Remove(searchSensor(name));
        }

        public bool checkName(String name)
        {
            if (searchSensor(name).name == null)
            {
                return true;
            }
            return false;
        }

        public void activateSensor(String name)
        {
            try
            {
                int index = searchSurveyForIndex(name);
                SensorStruct newSensor = _sensors[index];
                newSensor.condition = true;
                _sensors[index] = newSensor;
            }
            catch
            {
                Console.WriteLine("DoctorPatientSurveyServiceError: index error");
            }
        }
        private SensorStruct searchSensor(String name)
        {
            foreach(var element in _sensors)
            {
                if(element.name.Equals(name))
                {
                    return element;
                }
            }
            return new SensorStruct();
        }

        private int searchSurveyForIndex(String name)
        {
            int i = 0;
            foreach (var element in _sensors)
            {
                if (element.name == name)
                {
                    return i;
                }
                i++;
            }
            return -1;
        }
    }
}
