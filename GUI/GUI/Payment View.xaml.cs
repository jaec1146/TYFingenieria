using System;
using System.Windows;
using System.Data.SqlClient;
using System.Configuration;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using System.Data;
using DeviceLibrary;

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

            //---- VAriables ------//
            double depositado = Convert.ToDouble(infDepositado.Content);
            double Deuda = Convert.ToDouble(infDeuda2.Content);
            double Restante = Convert.ToDouble(infRestante.Content);
            DateTime Fecha = DateTime.Now;
            var cuenta = Usuario;
            new SqlParameter("@cuenta", cuenta);
            new SqlParameter("@depostado", depositado);

            //---- Ingresando datos de pago en base de datos Interna ------//
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


                //---- Ingresando datos de pago en base de datos externa ------//
                var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://linkxenter.com:3001/transaction?token=201ada5e70948aceb033a6c7fe1a3c4d");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";


                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json2 = "{account:"+cuenta+","+
                                    "paid:"+depositado+"}";

                    streamWriter.Write(json2);
                }

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    Console.WriteLine(result);
                }



                //----- comparacion de datos entre bases de datos -----//


                // ---- Base de datos Externa ---- //
                string url = "http://linkxenter.com:3000/account_balance?token=201ada5e70948aceb033a6c7fe1a3c4d&account=" + cuenta;
                var json = new WebClient().DownloadString(url);
                dynamic m = JsonConvert.DeserializeObject(json);

                string Usuario1 = m.user;
                string Deuda1 = m.debt;

                if (m.message == "no existen datos del usuario.")
                {
                    Console.WriteLine("no se logro encontrar usuario en base externa");
                }
                else
                {
                    // ----- Base de datos Local -----//
                    var conectionString2 = ConfigurationManager.ConnectionStrings["GUI.Properties.Settings.kioskoConnectionString"].ConnectionString;

                    var query2 = @"SELECT Customer,Debt 
                        from ClienteDB
                        where Account =@cuenta";

                    using (SqlConnection sql2 = new SqlConnection(conectionString2))
                    {
                        using (SqlCommand cmd = new SqlCommand(query2, sql2))
                        {
                            cmd.Parameters.Add(new SqlParameter("@cuenta", cuenta));
                            DataTable dt = new DataTable();
                            SqlDataAdapter da = new SqlDataAdapter(cmd);
                            sql2.Open();
                            da.Fill(dt);


                            SqlDataReader reader = cmd.ExecuteReader();

                            if (reader.Read())
                            {
                                Console.WriteLine(String.Format("{0}", reader[0]));
                                var Usuario2 = String.Format("{0}", reader[0]);
                                var Deuda2 = String.Format("{0}", reader[1]);


                                //--- Comparacion entre bases ---//
                                if (Usuario1 == Usuario2)
                                {
                                    if (Deuda1 == Deuda2)
                                    {
                                        //------ Finalizando Procedimientos -------//

                                        MainWindow objFirstWindow = new MainWindow();
                                        this.Visibility = Visibility.Hidden;
                                        objFirstWindow.Show();
                                    }
                                    else
                                    {
                                        Console.WriteLine("La deuda no es la misma entre bases");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Usuario no es el mismo entre bases");
                                }
                            }
                            else
                            {
                                Console.WriteLine("No se logro hacer la lectura ne vase de datos local");
                            }
                        }

                    }
                }




            }
        }
    }
}
