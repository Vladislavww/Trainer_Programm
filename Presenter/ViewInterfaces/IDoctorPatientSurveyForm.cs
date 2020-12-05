using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presenter
{
    public interface IDoctorPatientSurveyForm
    {
        void fillSensorsDataGridView();
        void initSensorTypeComboBox(IEnumerable<String> sensorsType);
        void addSensorToSensorsDataGridView(String name, String type, String condition);
        void showNewSensorError();
        void showNameSensorError();
        void deleteSelectedRow();
        void activateSelectedSensor();
    }
}
