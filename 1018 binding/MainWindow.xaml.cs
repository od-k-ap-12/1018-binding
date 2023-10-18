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
        public MainWindow()
        {
            InitializeComponent();
        }

        public class Sum : INotifyPropertyChanged
        {
            private double A;
            private double B;
            private double Answer;
            public double _A
            {
                get
                {
                    return A;
                }
                set
                {
                    A = value;
                    Answer = A + B;
                    OnPropertyChanged("A");
                    OnPropertyChanged("Answer");
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
                    Answer = A + B;
                    OnPropertyChanged("B");
                    OnPropertyChanged("Answer");
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
                    OnPropertyChanged("Answer");
                }
            }

            public event PropertyChangedEventHandler PropertyChanged;
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
