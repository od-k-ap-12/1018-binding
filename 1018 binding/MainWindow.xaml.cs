using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _1018_binding
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Sum _sum;
        public MainWindow()
        {
            InitializeComponent();
            _sum = new Sum();
            this.DataContext = _sum;
        }

        public class Sum : INotifyPropertyChanged
        {
            double A;
            double B;
            double Answer;
            public double _A
            {
                get
                {
                    return A;
                }
                set
                {
                    A = value;
                    _Answer = A + B;
                }
            }
            public double _B
            {
                get
                {
                    return B;
                }
                set
                {
                    B = value;
                    _Answer = A + B;
                }
            }
            public double _Answer
            {
                get
                {
                    return Answer;
                }
                set
                {
                    Answer = value;
                    OnPropertyChanged("_Answer");
                }
            }

            public event PropertyChangedEventHandler? PropertyChanged;
            public void OnPropertyChanged(params string[] propertyNames)
            {
                PropertyChangedEventHandler? handler = PropertyChanged;
                if (handler != null)
                {
                    foreach(var pn in propertyNames)
                    {
                        handler(this, new PropertyChangedEventArgs(pn));
                    }
                }
            }
        }
    }
}
