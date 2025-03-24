using Dangl.Calculator;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CalculatorApp.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class CalcViewModel
    {
        public string? Formula { get; set; }

        public string? Result { get; set; }



        public ICommand BackspaceCommand => new Command(
            () => { 
                if (Formula!=null && Formula.Length > 0) Formula = Formula.Remove(Formula.Length - 1); 
            });

        public ICommand ResetCommand => new Command(Reset);

        private void Reset(object obj)
        {
            Result = "0";
            Formula = "";
        }

        public ICommand OperationCommand { get; }

        public ICommand CalculateCommand { get; }

        public CalcViewModel()
        {
            CalculateCommand = new Command(
            () =>
            {
                if (Formula!=null && Formula.Length == 0)
                    return;
                var calculation = Calculator.Calculate(Formula);
                Result = calculation.Result.ToString();
            });
            OperationCommand = new Command((number) => Formula += number);
        }
    }
}
