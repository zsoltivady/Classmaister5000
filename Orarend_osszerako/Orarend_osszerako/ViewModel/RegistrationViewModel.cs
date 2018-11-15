using Orarend_osszerako.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Orarend_osszerako.BusinessLogic;
using Orarend_osszerako.Command;

namespace Orarend_osszerako.ViewModel
{
    public class RegistrationViewModel : DependencyObject
    {
        private ICommand registrationCommand { set; get; }

        private bool canExecute = true;

        public bool CanExecute //mi a rák ez??????
        {
            get
            {
                return this.canExecute;
            }

            set
            {
                if (this.canExecute == value)
                {
                    return;
                }

                this.canExecute = value;
            }
        }
        //public ICommand RegistrationCommand
        //{
        //    get { return registrationCommand; }
        //    set
        //    {
        //        if (RegisterUser) ----> nem látja
        //        {

        //        }
        //    }
        //}

        
    }
}
