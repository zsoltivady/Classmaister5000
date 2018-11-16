using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Orarend_osszerako.BusinessLogic;

namespace Orarend_osszerako.Command
{
    public class RelayCommand : ICommand
    {
        #region felesleges ennyire overkill ICommand implementálás, Zsolti megoldása tökéletes
        //private Action<object> execute; //fogalmam nincs ez mi a lófaszt csinál

        //private Predicate<object> canExecute; //megfelel-e egy adott objektum a metódus kritériumainak?

        //private event EventHandler CanExecuteChangedInternal; //eventet kezel???

        //public RelayCommand(Action<object> execute)
        //    : this(execute, DefaultCanExecute)
        //{
        //}

        //public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        //{
        //    if (execute == null)
        //    {
        //        throw new ArgumentNullException("execute");
        //    }

        //    if (canExecute == null)
        //    {
        //        throw new ArgumentNullException("canExecute");
        //    }

        //    this.execute = execute;
        //    this.canExecute = canExecute;
        //}

        //public event EventHandler CanExecuteChanged
        //{
        //    add
        //    {
        //        CommandManager.RequerySuggested += value;
        //        this.CanExecuteChangedInternal += value;
        //    }

        //    remove
        //    {
        //        CommandManager.RequerySuggested -= value;
        //        this.CanExecuteChangedInternal -= value;
        //    }
        //}

        //public bool CanExecute(object parameter)
        //{
        //    return this.canExecute != null && this.canExecute(parameter);
        //}

        //public void Execute(object parameter)
        //{
        //    this.execute(parameter);
        //}

        //public void OnCanExecuteChanged()
        //{
        //    EventHandler handler = this.CanExecuteChangedInternal;
        //    if (handler != null)
        //    {
        //        //DispatcherHelper.BeginInvokeOnUIThread(() => handler.Invoke(this, EventArgs.Empty));
        //        handler.Invoke(this, EventArgs.Empty);
        //    }
        //}

        //public void Destroy()
        //{
        //    this.canExecute = _ => false;
        //    this.execute = _ => { return; };
        //}

        //private static bool DefaultCanExecute(object parameter)
        //{
        //    return true;
        //}
        #endregion 
        private Predicate<object> _canExecute; // amit ennek átadunk, az dönti el, hogy lefuthat-e az adott action. általános esetben mindig true-t adunk át, de ha speciális eset kell, hogy ne lehessen futtatni a metódust, ez esetben ide logikai kiértékelést adunk át
        private Action<object> _execute; //ebbe kerül a metódushívás

        public RelayCommand(Predicate<object> canExecute, Action<object> execute)
        {
            this._canExecute = canExecute;
            this._execute = execute;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
    }
}
}
