using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using PrismApp.Core;
using System;

namespace LeftModule.ViewModels
{
    public class MessageViewModel :BindableBase
    {
        IEventAggregator _ea;


        private string message;

        public string Message
        {
            get => message;
            set => SetProperty(ref message, value);
        }

        public DelegateCommand SendMessageCommand { get; set; }

        public MessageViewModel(IEventAggregator ea)
        {
            _ea = ea;
            SendMessageCommand = new DelegateCommand(SendMessage);
        }

        private void SendMessage()
        {
            _ea.GetEvent<MessageSentEvent>().Publish(Message);
        }
    }
}
