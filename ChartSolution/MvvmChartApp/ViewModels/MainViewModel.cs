using Caliburn.Micro;
using System;

namespace MvvmChartApp.ViewModels
{
   
    
    internal class MainViewModel :Conductor<object>
    {
        public void LoadLineChart()
        {
            ActivateItem(new LineChartViewModel());
        }

        public void ExitProgram()
        {
            Environment.Exit(1);
        }
        public void LoadGaugeChart()
        {
            ActivateItem(new GaugeChartViewModel());
        }
    }
}
