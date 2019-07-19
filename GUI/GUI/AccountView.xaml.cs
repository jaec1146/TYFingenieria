using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
//using System.Net;
//using System.IO;
//using Newtonsoft.Json;
//using System.Data;

namespace GUI
{
    /// <summary>
    /// Lógica de interacción para AccountView.xaml
    /// </summary>
    public partial class AccountView : Window
    {
        

        public AccountView()
        {
            InitializeComponent();

            var mensaje = ConfigurationManager.AppSettings["mensaje"];
            Console.WriteLine(mensaje);



            

           

            Console.Read();


        }

        
            

        

        //------------- Eventos de Caja de Texto ------------//
        private void IdUsuario_MouseEnter(object sender, MouseEventArgs e)
        {
            if (IdUsuario.Text == "Número de cuenta ...")
            {
                IdUsuario.Text = "";
            }
        }

        private void IdUsuario_Initialized(object sender, EventArgs e)
        {
            IdUsuario.Text = "Número de cuenta ...";
        }

        //---- Boton para Borrar ----//
        private void Borrar_Click(object sender, RoutedEventArgs e)
        {
            IdUsuario.Text = "";
        }






        //------------------------//
        // Eventos de los Números //
        //------------------------//

        // Variable auxiliar para determinar cuando se debe borrar el texto que está en pantalla.
        bool limpiarPantalla = false;

        private void gridDigitos_Click(object sender, RoutedEventArgs e)
        {
            if (IdUsuario.Text =="Número de cuenta ..."){
                IdUsuario.Text = "";
            }
            //Comprobamos que el evento se originó en un botón.(recordar que WPF maneja eventos enrutados que son diferentes a los eventos win form clásicos.
            if (e.OriginalSource is Button)
            {
                Button digitoPulsado = (Button)e.OriginalSource; // Conversión de e.OriginalSource a Button.

                // Comprobamos que es un botón que representa un digito.
                int i = 0;
                bool isDigit = false;
                isDigit = int.TryParse(digitoPulsado.Tag.ToString(), out i);// Si la conversión es posible, el número entero se almacena en la variable i.

                if (isDigit)
                {
                    if (limpiarPantalla)
                    {
                        IdUsuario.Text = "";
                        limpiarPantalla = false;
                    }
                    IdUsuario.Text += digitoPulsado.Tag.ToString(); // se puede sustituir por i.
                }
            }
        }



        //--------------------------//
        //  Botones:                //
        //   -Cancelar              //
        //   -Aceptar               //
        //------------------------- //

        private void Cancelar_Click(object sender, RoutedEventArgs e)
        {
            MainWindow objfirstdWindow = new MainWindow();
            this.Visibility = Visibility.Hidden;
            objfirstdWindow.Show();
        }

        public void Aceptar_Click(object sender, RoutedEventArgs e)
        {
            

            if (IdUsuario.Text == "" || IdUsuario.Text == "Número de cuenta ...")
            {

            }
            else
            {
                /*
                string cuenta = IdUsuario.Text;
                string url = "" + cuenta;
                var json = new WebClient().DownloadString(url);
                dynamic m = JsonConvert.DeserializeObject(json);

                string Usuario = m.user;
                string Deuda = m.debt;

                if (m.message == "no existen datos del usuario.")
                {

                }
                else
                {
                    Balance_View objThirdWindow = new Balance_View(cuenta, Usuario, Deuda);
                    this.Visibility = Visibility.Hidden;
                    objThirdWindow.Show();
                }
               */

                var conectionString = ConfigurationManager.ConnectionStrings["GUI.Properties.Settings.kioskoConnectionString"].ConnectionString;

                string cuenta = IdUsuario.Text;
                Console.WriteLine(cuenta);
                var query = @"SELECT Customer,Debt 
                        from ClienteDB
                        where Account =@cuenta";
                

                using (SqlConnection sql = new SqlConnection(conectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, sql))
                    {
                        cmd.Parameters.Add(new SqlParameter("@cuenta", cuenta));
                        DataTable dt = new DataTable();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        sql.Open();
                        da.Fill(dt);
                        
                        
                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {
                            Console.WriteLine(String.Format("{0}", reader[0]));
                            var Usuario = String.Format("{0}", reader[0]);
                            var Deuda = String.Format("{0}", reader[1]);
                            Balance_View objThirdWindow = new Balance_View(cuenta, Usuario, Deuda);
                            this.Visibility = Visibility.Hidden;
                            objThirdWindow.Show();
                        }
                        else
                        {
                            
                        }

                    }

                }





            }


        }


    }
}
