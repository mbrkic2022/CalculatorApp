using CalculatorApp.ViewModels;

namespace CalculatorApp
{
    public partial class CalcView : ContentPage
    {

        public CalcView()
        {
            InitializeComponent();
            BindingContext = new CalcViewModel();
        }

    }

}
