using MySql.Data.MySqlClient.Memcached;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
using Newtonsoft.Json;

namespace GUI
{
    /// <summary>
    /// Lógica de interacción para Balance_View.xaml
    /// </summary>
    public partial class Balance_View : Window
    {

        public Balance_View(string Cuenta, string Usuario, string Deuda)
        {
            InitializeComponent();
            infCuenta.Content = Cuenta;
            infUsuario.Content = Usuario;
            infDeuda.Content = Deuda;
         
        }



        private void Cancelar_Click(object sender, RoutedEventArgs e)
        {
            AccountView objSecondWindow = new AccountView();
            this.Visibility = Visibility.Hidden;
            objSecondWindow.Show();
        }

        private void Pagar_Click(object sender, RoutedEventArgs e)
        {
            object x = infDeuda.Content;
            string Deuda = x.ToString();

            object y = infUsuario.Content;
            string Usuario = y.ToString();
            
            Payment_View objFourthWindow = new Payment_View(Usuario, Deuda);
            this.Visibility = Visibility.Hidden;
            objFourthWindow.Show();
        }
    }
    
        
   
}