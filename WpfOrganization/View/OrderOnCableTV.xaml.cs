using System;
using System.Collections.Generic;
using System.Data.Entity;
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
using System.Windows.Shapes;
using WpfOrganization.ViewModel;

namespace WpfOrganization.View
{
    /// <summary>
    /// Interaction logic for Orders.xaml
    /// </summary>
    public partial class Orders : Window
    {
        public Orders()
        {
            InitializeComponent();
            var a = new DbContext(@"Data Source=.\SQLEXPRESS;Initial Catalog=CableTV;Integrated Security=True");
            DataContext = new OrderOnCableTVViewModel();
        }
    }
}
