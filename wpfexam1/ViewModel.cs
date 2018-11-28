using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace wpfexam1
{
    class ViewModel : INotifyPropertyChanged
    {
        Model _num = new Model();

        public int Num
        {
            get
            {
                return _num.num;
            }
            set
            {
                _num.num = value;
                OnPropertyChanged("Num");
            }
        }

        public int First { get { return _num.first; } set { _num.first = value; } }
        public int Second { get { return _num.second; } set { _num.second = value; } }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(String propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        
        
        #region Calc Data
        /// <summary>
        /// Binding object (VM->V)
        /// </summary>

        private char cmd = '+';

        private ICommand plusCommand;

        public ICommand PlusCommand
        {
            get { return (this.plusCommand) ?? (this.plusCommand = new RelayCommand(Plus)); }
        }

        private void Plus()
        {
            cmd = '+';
            First = Num;
            Num = 0;
        }

        private ICommand minusCommand;

        public ICommand MinusCommand
        {
            get { return (this.minusCommand) ?? (this.minusCommand = new RelayCommand(Minus)); }
        }

        private void Minus()
        {
            cmd = '-';
            First = Num;
            Num = 0;
        }

        private ICommand mulCommand;

        public ICommand MulCommand
        {
            get { return (this.mulCommand) ?? (this.mulCommand = new RelayCommand(Mul)); }
        }

        private void Mul()
        {
            cmd = '*';
            First = Num;
            Num = 0;
        }
        

        private ICommand divCommand;

        public ICommand DivCommand
        {
            get { return (this.divCommand) ?? (this.divCommand = new RelayCommand(Div)); }
        }

        private void Div()
        {
            cmd = '/';
            First = Num;
            Num = 0;
        }

        private ICommand resultCommand;

        public ICommand ResultCommand
        {
            get { return (this.resultCommand) ?? (this.resultCommand = new RelayCommand(Result)); }
        }

        private void Result()
        {
            Second = Num;
            switch (cmd)
            {
                case '+':
                    Num = First + Second;
                    break;
                case '-':
                    Num = First - Second;
                    break;
                case '*':
                    Num = First * Second;
                    break;
                case '/':
                    if (Second == 0) Num = First;
                    else Num = First / Second;
                    break;
            }
            First = 0; Second = 0;
        }

        private ICommand ceCommand;

        public ICommand CeCommand
        {
            get { return (this.ceCommand) ?? (this.ceCommand = new RelayCommand(CE)); }
        }

        private void CE()
        {
            cmd = '+';
            Num = 0; First = 0; Second = 0;
        }

        private ICommand btn1Command;

        public ICommand Btn1Command
        {
            get { return (this.btn1Command) ?? (this.btn1Command = new RelayCommand(Btn1)); }
        }

        private void Btn1()
        {
            Num = Num * 10 + 1;
        }

        private ICommand btn2Command;

        public ICommand Btn2Command
        {
            get { return (this.btn2Command) ?? (this.btn2Command = new RelayCommand(Btn2)); }
        }

        private void Btn2()
        {
            Num = Num * 10 + 2;
        }

        private ICommand btn3Command;

        public ICommand Btn3Command
        {
            get { return (this.btn3Command) ?? (this.btn3Command = new RelayCommand(Btn3)); }
        }

        private void Btn3()
        {
            Num = Num * 10 + 3;
        }

        private ICommand btn4Command;

        public ICommand Btn4Command
        {
            get { return (this.btn4Command) ?? (this.btn4Command = new RelayCommand(Btn4)); }
        }

        private void Btn4()
        {
            Num = Num * 10 + 4;
        }

        private ICommand btn5Command;

        public ICommand Btn5Command
        {
            get { return (this.btn5Command) ?? (this.btn5Command = new RelayCommand(Btn5)); }
        }

        private void Btn5()
        {
            Num = Num * 10 + 5;
        }

        private ICommand btn6Command;

        public ICommand Btn6Command
        {
            get { return (this.btn6Command) ?? (this.btn6Command = new RelayCommand(Btn6)); }
        }

        private void Btn6()
        {
            Num = Num * 10 + 6;
        }

        private ICommand btn7Command;

        public ICommand Btn7Command
        {
            get { return (this.btn7Command) ?? (this.btn7Command = new RelayCommand(Btn7)); }
        }

        private void Btn7()
        {
            Num = Num * 10 + 7;
        }

        private ICommand btn8Command;

        public ICommand Btn8Command
        {
            get { return (this.btn8Command) ?? (this.btn8Command = new RelayCommand(Btn8)); }
        }

        private void Btn8()
        {
            Num = Num * 10 + 8;
        }

        private ICommand btn9Command;

        public ICommand Btn9Command
        {
            get { return (this.btn9Command) ?? (this.btn9Command = new RelayCommand(Btn9)); }
        }

        private void Btn9()
        {
            Num = Num * 10 + 9;
        }

        private ICommand btn0Command;

        public ICommand Btn0Command
        {
            get { return (this.btn0Command) ?? (this.btn0Command = new RelayCommand(Btn0)); }
        }

        private void Btn0()
        {
            Num = Num * 10 + 0;
        }
        // made by 오준환
        #endregion

        public class RelayCommand : ICommand
        {
            public event EventHandler CanExecuteChanged
            {
                add { CommandManager.RequerySuggested += value; }
                remove { CommandManager.RequerySuggested -= value; }
            }
            private Action methodToExecute;
            private Func<bool> canExecuteEvaluator;
            public RelayCommand(Action methodToExecute, Func<bool> canExecuteEvaluator)
            {
                this.methodToExecute = methodToExecute;
                this.canExecuteEvaluator = canExecuteEvaluator;
            }
            public RelayCommand(Action methodToExecute)
                : this(methodToExecute, null)
            {
            }
            public bool CanExecute(object parameter)
            {
                if (this.canExecuteEvaluator == null)
                {
                    return true;
                }
                else
                {
                    bool result = this.canExecuteEvaluator.Invoke();
                    return result;
                }
            }
            public void Execute(object parameter)
            {
                this.methodToExecute.Invoke();
            }
        }
    }
}
