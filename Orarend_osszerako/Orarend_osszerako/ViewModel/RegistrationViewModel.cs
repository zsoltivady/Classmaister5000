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
using System.ComponentModel;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using Orarend_osszerako.BusinessLogic.Exceptions;

namespace Orarend_osszerako.ViewModel
{
    public class RegistrationViewModel : INotifyPropertyChanged
    {
        //a viewekben található textboxok tartalma ezekbe a propertykbe kerül be a bindingon keresztül
        private string _FirstName;
        [Required(ErrorMessage = "First name is required!")] //nyilván ezek amíg a validáció és INotifyDataErrorInfo implementálva, ezek nem jelennek meg, de már bekészíthetjük őket
        public string FirstName
        {
            get { return _FirstName; }
            set
            {
                _FirstName = value;
            }
        }
        private string _LastName;
        [Required(ErrorMessage = "Last name is required!")]
        public string LastName
        {
            get { return _LastName; }
            set
            {
                _LastName = value;
            }
        }
        private string _UserName;
        [Required(ErrorMessage = "User name is required!")]
        public string UserName
        {
            get { return _UserName; }
            set
            {
                _UserName = value;
            }
        }
        private string _userPassword;
        [Required(ErrorMessage = "Password is required!")]
        public string UserPassword
        {
            get { return _userPassword; }
            set
            {
                _userPassword = value;
            }
        }
        private string _retryPassword;
        [Required(ErrorMessage = "You must retry the password!")]
        public string RetryPassword
        {
            get { return _retryPassword; }
            set
            {
                _retryPassword = value;
            }
        }
        //mivel még nincs implementálva a validáció, és ezzel a INotifyDataErrorInfo sincs
        //public bool HasErrors => throw new NotImplementedException();
        
        //public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        //public IEnumerable GetErrors(string propertyName)
        //{
        //    throw new NotImplementedException();
        //}

        public event PropertyChangedEventHandler PropertyChanged; //remélem az INotifyProperyChanged interface mezőit és metódusait nem kell magyarázni
        protected void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
        private ICommand _doRegistration; //itt hozzunk létre egy üres ICommandot 
        public ICommand DoRegistration
        {
            get
            {
                if (_doRegistration == null)
                {
                        _doRegistration = new RelayCommand(p => true, p => Registration.RegisterUser(UserName, UserPassword, RetryPassword, FirstName, LastName)); //p=> true azt mondja, hogy mindig futtatható az ICommand, ha szükség lesz rá, ezt logikai feltétellel vizsgálhatjuk, PL: Amíg nincsenek kitöltve egyáltán a TextBoxok, így a propertyk nem töltődtek fel, addig ne futtathassuk az ICommandot (tehát a gombnyomást), így nem terheljük (talán?) feleslegesen a programot
                }
                return _doRegistration;
            }
        }
    }
}
