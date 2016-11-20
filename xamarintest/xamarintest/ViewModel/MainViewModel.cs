using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using xamarintest.Services;

namespace xamarintest.ViewModel
{
    public class MainViewModel
    {
        public ICommand enviarMsj
        {
            get
            {

                return new RelayCommand(SendJson);
            }

        }
        private async void SendJson()
        {
            string sender = "yo";
            string receiver = "tu";
            int question = 2;
            string answer = "respuesta";
             
           
            string respuesta =  await new MessageService().enviarRegistroMensaje(sender,receiver, question, answer);

       
       }
    }
}
