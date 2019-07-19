﻿using System;
using System.Windows;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Configuration;

namespace GUI
{
    /// <summary>
    /// Lógica de interacción para Payment_View.xaml
    /// </summary>
    public partial class Payment_View : Window
    {
        double pago = 0;

        public Payment_View(string Usuario, string Deuda)
        {
            InitializeComponent();
            Console.WriteLine(Deuda);
            infDeuda2.Content = Deuda;
            this.Usuario = Usuario;
        }

        string Usuario;

        private void Quinientos_Click(object sender, RoutedEventArgs e)
        {
            pago = pago + 500;
            infDepositado.Content = pago;
            infRestante.Content = Convert.ToDouble(infDeuda2.Content) - pago;

               
        }

        private void Docientos_Click(object sender, RoutedEventArgs e)
        {
            pago = pago + 200;
            infDepositado.Content = pago;
            infRestante.Content = Convert.ToDouble(infDeuda2.Content) - pago;
        }

        private void Cien_Click(object sender, RoutedEventArgs e)
        {
            pago = pago + 100;
            infDepositado.Content = pago;
            infRestante.Content = Convert.ToDouble(infDeuda2.Content) - pago;
        }

        private void Ciencuenta_Click(object sender, RoutedEventArgs e)
        {
            pago = pago + 50;
            infDepositado.Content = pago;
            infRestante.Content = Convert.ToDouble(infDeuda2.Content) - pago;
        }

        private void Veinte_Click(object sender, RoutedEventArgs e)
        {
            pago = pago + 20;
            infDepositado.Content = pago;
            infRestante.Content = Convert.ToDouble(infDeuda2.Content) - pago;
        }

        private void Diez_Click(object sender, RoutedEventArgs e)
        {
            pago = pago + 10;
            infDepositado.Content = pago;
            infRestante.Content = Convert.ToDouble(infDeuda2.Content) - pago;
        }

        private void Cinco_Click_1(object sender, RoutedEventArgs e)
        {
            pago = pago + 5;
            infDepositado.Content = pago;
            infRestante.Content = Convert.ToDouble(infDeuda2.Content) - pago;
        }

        private void Dos_Click(object sender, RoutedEventArgs e)
        {
            pago = pago + 2;
            infDepositado.Content = pago;
            infRestante.Content = Convert.ToDouble(infDeuda2.Content) - pago;
        }

        private void Uno_Click(object sender, RoutedEventArgs e)
        {
            pago = pago + 1;
            infDepositado.Content = pago;
            infRestante.Content = Convert.ToDouble(infDeuda2.Content) - pago;
        }

        private void CincoCentavos_Click(object sender, RoutedEventArgs e)
        {
            pago = pago + 0.05;
            infDepositado.Content = pago;
            infRestante.Content = Convert.ToDouble(infDeuda2.Content) - pago;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(pago != 0)
            {

            }
            else
            {
                MainWindow objFirstWindow = new MainWindow();
                this.Visibility = Visibility.Hidden;
                objFirstWindow.Show();
            }
        }


        
        private void Pagar_Click(object sender, RoutedEventArgs e)
        {
            double depositado = Convert.ToDouble(infDepositado.Content);
            double Deuda = Convert.ToDouble(infDeuda2.Content);
            double Restante = Convert.ToDouble(infRestante.Content);
            DateTime Fecha = DateTime.Now;
            var cuenta = Usuario;

            var conectionString = ConfigurationManager.ConnectionStrings["GUI.Properties.Settings.kioskoConnectionString"].ConnectionString;

            var query = "UPDATE ClienteDB SET  Debt=@a1 , Paid=@a2 , Date=@a3 WHERE Customer=@a4";

            using (SqlConnection sql = new SqlConnection(conectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, sql))
                {
                    sql.Open();
                    cmd.Parameters.Add("a1", Restante);
                    cmd.Parameters.Add("a2", depositado);
                    cmd.Parameters.Add("a3", Fecha);
                    cmd.Parameters.Add("a4", cuenta);
                    cmd.ExecuteNonQuery();
                }

                MainWindow objFirstWindow = new MainWindow();
                this.Visibility = Visibility.Hidden;
                objFirstWindow.Show();
            }
        }
    }
}