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
        //ha gebasz lenne namespacekkel, ezt kell törölni: xmlns:vm="clr-namespace:Orarend_osszerako.ViewModel", 
        //és a datacontextet is alatta.
        private bool canExecute = true;

        public string RegisterButtonContent
        {
            get
            {
                return "Register";
            }
        }

        public bool CanExecute
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
        
    }
}
