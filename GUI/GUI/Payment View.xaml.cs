﻿using DeviceLibrary.Models;
using Newtonsoft.Json;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Windows;
using DeviceLibrary;


namespace GUI
{
    /// <summary>
    /// Lógica de interacción para Payment_View.xaml
    /// </summary>
    /// 


    public partial class Payment_View : Window
    {
        double pago = 0;


        public Payment_View(string Cuenta, string Usuario, string Deuda)
        {
            InitializeComponent();
            Console.WriteLine(Deuda);
            infDeuda2.Content = Deuda;
            this.Usuario = Usuario;
            this.Cuenta = Cuenta;


        }
        //----- Variables Publicas ----//
        string Usuario;
        string Cuenta;

        void DoNothing(object sender, EventArgs e)
        {
        }


         void Quinientos_Click(object sender, RoutedEventArgs e)
        {
            var Status = DeviceLibrary.Models.Enums.DeviceStatus.Enabled;
            
            var Bill = DeviceLibrary.Models.Enums.DocumentType.Bill;
            Document objquinientos = new Document(500, Bill, 500);

            var deviceLibrary = new DeviceLibrary.DeviceLibrary();
            deviceLibrary.SimulateInsertion(objquinientos);

            pago = pago + objquinientos.Count;
            infDepositado.Content = pago;   
            infRestante.Content = Convert.ToDouble(infDeuda2.Content) - pago;

            deviceLibrary.AcceptedDocument += new Action<Document>(deviceLibrary.SimulateInsertion);
            deviceLibrary.AcceptedDocument -= null;

            Console.WriteLine(Status);  
        }





        private void Docientos_Click(object sender, RoutedEventArgs e)
        {
            var Bill = DeviceLibrary.Models.Enums.DocumentType.Bill;
            Document objdocientos = new Document(200, Bill, 200);

            var deviceLibrary = new DeviceLibrary.DeviceLibrary();
            deviceLibrary.SimulateInsertion(objdocientos);

            pago = pago + objdocientos.Count;
            infDepositado.Content = pago;
            infRestante.Content = Convert.ToDouble(infDeuda2.Content) - pago;

            deviceLibrary.AcceptedDocument += new Action<Document>(deviceLibrary.SimulateInsertion);
            deviceLibrary.AcceptedDocument -= null;
        }

        private void Cien_Click(object sender, RoutedEventArgs e)
        {
            var Bill = DeviceLibrary.Models.Enums.DocumentType.Bill;
            Document objcien = new Document(100, Bill, 100);

            var deviceLibrary = new DeviceLibrary.DeviceLibrary();
            deviceLibrary.SimulateInsertion(objcien);

            pago = pago + objcien.Count;
            infDepositado.Content = pago;
            infRestante.Content = Convert.ToDouble(infDeuda2.Content) - pago;

            deviceLibrary.AcceptedDocument += new Action<Document>(deviceLibrary.SimulateInsertion);
            deviceLibrary.AcceptedDocument -= null;
        }

        private void Ciencuenta_Click(object sender, RoutedEventArgs e)
        {
            var Bill = DeviceLibrary.Models.Enums.DocumentType.Bill;
            Document objcincuenta = new Document(50, Bill, 50);

            var deviceLibrary = new DeviceLibrary.DeviceLibrary();
            deviceLibrary.SimulateInsertion(objcincuenta);

            pago = pago + objcincuenta.Count;
            infDepositado.Content = pago;
            infRestante.Content = Convert.ToDouble(infDeuda2.Content) - pago;

            deviceLibrary.AcceptedDocument += new Action<Document>(deviceLibrary.SimulateInsertion);
            deviceLibrary.AcceptedDocument -= null;
        }

        private void Veinte_Click(object sender, RoutedEventArgs e)
        {
            var Bill = DeviceLibrary.Models.Enums.DocumentType.Bill;
            Document objveinte = new Document(20, Bill, 20);

            var deviceLibrary = new DeviceLibrary.DeviceLibrary();
            deviceLibrary.SimulateInsertion(objveinte);

            pago = pago + objveinte.Count;
            infDepositado.Content = pago;
            infRestante.Content = Convert.ToDouble(infDeuda2.Content) - pago;

            deviceLibrary.AcceptedDocument += new Action<Document>(deviceLibrary.SimulateInsertion);
            deviceLibrary.AcceptedDocument -= null;
        }

        private void Diez_Click(object sender, RoutedEventArgs e)
        {
            var Coin = DeviceLibrary.Models.Enums.DocumentType.Coin;
            Document objveinte = new Document(10, Coin, 10);

            var deviceLibrary = new DeviceLibrary.DeviceLibrary();
            deviceLibrary.SimulateInsertion(objveinte);

            pago = pago + objveinte.Count;
            infDepositado.Content = pago;
            infRestante.Content = Convert.ToDouble(infDeuda2.Content) - pago;

            deviceLibrary.AcceptedDocument += new Action<Document>(deviceLibrary.SimulateInsertion);
            deviceLibrary.AcceptedDocument -= null;
        }

        private void Cinco_Click_1(object sender, RoutedEventArgs e)
        {
            var Coin = DeviceLibrary.Models.Enums.DocumentType.Coin;
            Document objcinco = new Document(5, Coin, 5);

            var deviceLibrary = new DeviceLibrary.DeviceLibrary();
            deviceLibrary.SimulateInsertion(objcinco);

            pago = pago + objcinco.Count;
            infDepositado.Content = pago;
            infRestante.Content = Convert.ToDouble(infDeuda2.Content) - pago;

            deviceLibrary.AcceptedDocument += new Action<Document>(deviceLibrary.SimulateInsertion);
            deviceLibrary.AcceptedDocument -= null;
        }

        private void Dos_Click(object sender, RoutedEventArgs e)
        {
            var Coin = DeviceLibrary.Models.Enums.DocumentType.Coin;
            Document objdos = new Document(2, Coin, 2);

            var deviceLibrary = new DeviceLibrary.DeviceLibrary();
            deviceLibrary.SimulateInsertion(objdos);

            pago = pago + objdos.Count;
            infDepositado.Content = pago;
            infRestante.Content = Convert.ToDouble(infDeuda2.Content) - pago;

            deviceLibrary.AcceptedDocument += new Action<Document>(deviceLibrary.SimulateInsertion);
            deviceLibrary.AcceptedDocument -= null;
        }

        private void Uno_Click(object sender, RoutedEventArgs e)
        {
            var Coin = DeviceLibrary.Models.Enums.DocumentType.Coin;
            Document objuno = new Document(1, Coin, 1);

            var deviceLibrary = new DeviceLibrary.DeviceLibrary();
            deviceLibrary.SimulateInsertion(objuno);
           
            pago = pago + objuno.Count;
            infDepositado.Content = pago;
            infRestante.Content = Convert.ToDouble(infDeuda2.Content) - pago;

            deviceLibrary.AcceptedDocument += new Action<Document>(deviceLibrary.SimulateInsertion);
            deviceLibrary.AcceptedDocument -= null;
        }

        private void CincoCentavos_Click(object sender, RoutedEventArgs e)
        {
            var Coin = DeviceLibrary.Models.Enums.DocumentType.Coin;
            Document objCincoCentavos = new Document(1/2, Coin, 1/2);
            
            var deviceLibrary = new DeviceLibrary.DeviceLibrary();
            deviceLibrary.SimulateInsertion(objCincoCentavos);
                
            pago = pago + 0.5;
            infDepositado.Content = pago;
            infRestante.Content = Convert.ToDouble(infDeuda2.Content) - pago;

            deviceLibrary.AcceptedDocument += new Action<Document>(deviceLibrary.SimulateInsertion);
            deviceLibrary.AcceptedDocument -= null;
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

            //---- Variables ------//
            double depositado = Convert.ToDouble(infDepositado.Content);
            double Deuda = Convert.ToDouble(infDeuda2.Content);
            double Restante = Convert.ToDouble(infRestante.Content);
            DateTime Fecha = DateTime.Now;
            
     
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
                    cmd.Parameters.Add("a4", Usuario);
                    cmd.ExecuteNonQuery();
                }


                //---- Ingresando datos de pago en base de datos externa ------//

                var httpWebRequest2 = (HttpWebRequest)WebRequest.Create("http://linkxenter.com:3000/transaction?token=201ada5e70948aceb033a6c7fe1a3c4d");
                httpWebRequest2.ContentType = "application/json";
                httpWebRequest2.Method = "POST";
                var usuario = Usuario;



                using (var streamWriter = new StreamWriter(httpWebRequest2.GetRequestStream()))
                {
                    

                    string json2 = JsonConvert.SerializeObject(new { account = Cuenta , paid = depositado });


                    streamWriter.Write(json2);
                    Console.WriteLine(json2);
                }

                var httpResponse2 = (HttpWebResponse)httpWebRequest2.GetResponse();
                using (var streamReader = new StreamReader(httpResponse2.GetResponseStream()))
                {
                    var result = JsonConvert.DeserializeObject(streamReader.ReadToEnd());

                    Console.WriteLine("Respuesta de BD externa:"+ result);
                }


                //----- comparacion de datos entre bases de datos -----//


                // ---- Base de datos Externa ---- //
                string url = "http://linkxenter.com:3000/account_balance?token=201ada5e70948aceb033a6c7fe1a3c4d&account=" + Cuenta;
                var json = new WebClient().DownloadString(url);
                dynamic m = JsonConvert.DeserializeObject(json);

                string Usuario1 = m.user;
                string Deuda1 = m.debt;

                if (m.message == "no existen datos del usuario.")
                {
                    Console.WriteLine("no se logro encontrar usuario en base externa");
                    Console.WriteLine(Usuario1);
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
                            cmd.Parameters.Add(new SqlParameter("@cuenta", Cuenta));
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
                                        Console.WriteLine("el valor de base externa es:" + Deuda1);
                                        Console.WriteLine("el valor de base interna es:" + Deuda2);

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
