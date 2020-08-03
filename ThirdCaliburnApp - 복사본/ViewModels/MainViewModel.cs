using ArduinoMonitoringWinFormApp.Base;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Windows.Forms;
namespace ThirdCaliburnApp.ViewModels
{
    class MainViewModel : Conductor<object>, IHaveDisplayName
    {
        SerialPort serial;
        private short xCount = 200;
        private short maxPhotoVal = 1023;
        List<SensorData> photoDatas = new List<SensorData>();

        string strConnString = "Server=localhost;Port=3306;" +
            "Database=iot_sensordata;Uid=root;Pwd=mysql_p@ssw0rd";

        public bool IsSimulation { get; set; }

        Timer timer = new Timer();
        Random rand = new Random();


        public MainViewModel()
        {
        }

        private void Init()
        {
            throw new NotImplementedException();
        }
        
    }
}
