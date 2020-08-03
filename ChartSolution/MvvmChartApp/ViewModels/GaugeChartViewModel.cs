using Caliburn.Micro;
using System;
using System.Threading;

namespace MvvmChartApp.ViewModels
{
    internal class GaugeChartViewModel :Conductor<object>
    {
        double angValue;
        public double AngValue
        {
            get => angValue;
            set
            {
                angValue = value;
                NotifyOfPropertyChange(() => AngValue);
            }
        }

        public Timer CustomTimer { get; set; }
        

        internal GaugeChartViewModel()
        {
            CustomTimer = new Timer(TickCallBack);
            CustomTimer.Change(1000, 1000);

        }

        private void TickCallBack(object state)
        {
            AngValue = new Random().Next(0, 300);
        }
    }
}