using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
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
using ICB_TASK.LoadData.ViewModel;
namespace ICB_TASK.LoadData
{
    /// <summary>
    /// Interaction logic for LOAD.xaml
    /// </summary>
    public partial class LOAD : UserControl
    {
       
        public LOAD()
        {
            InitializeComponent();
            MainViewModel viewModel = new MainViewModel();
            base.DataContext = viewModel;

        }
    }
}
