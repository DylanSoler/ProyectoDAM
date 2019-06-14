using FootballTrainingManagerDAL.Manejadoras;
using FootballTrainingManagerEntidades.Persistencia;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using Windows.ApplicationModel.Resources;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace FootballTrainingManagerUI.Views
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class CambiarPassw : Page
    {
        public CambiarPassw()
        {
            this.InitializeComponent();
        }

        String code = "";
        clsManager mng = null;
        ResourceLoader resourceLoader = Windows.ApplicationModel.Resources.ResourceLoader.GetForCurrentView("Resources");

        private void btnVolverClick(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Login));
        }

        /// <summary>
        /// Envia al correo del manager si este esta registrado, para con el recuperar la contrasenia
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnSendCode(object sender, RoutedEventArgs e)
        {
            String strError404 = resourceLoader.GetString("strSendCode404");
            String strErrorFormat = resourceLoader.GetString("strSendCodeFormat");

            clsManejadoraManager manejadora = new clsManejadoraManager();

            if (correoCorrecto())
            {

                mng = await manejadora.obtenerManagerPorEmail(txbCorreo.Text);

                if (mng != null)
                {

                    txblInsertEmail.Visibility = Visibility.Collapsed;
                    txbCorreo.Visibility = Visibility.Collapsed;
                    btnSendCod.Visibility = Visibility.Collapsed;
                    txbConfirmacionesUsuario.Visibility = Visibility.Collapsed;
                    code = sendCodeToEmail(txbCorreo.Text);
                    txblCheckCode.Visibility = Visibility.Visible;
                    txbCode.Visibility = Visibility.Visible;
                    btnCheckCod.Visibility = Visibility.Visible;
                }
                else
                {
                    txbConfirmacionesUsuario.Text = strError404;
                    txbConfirmacionesUsuario.Visibility = Visibility.Visible;
                }
            }
            else
            {
                txbConfirmacionesUsuario.Text = strErrorFormat;
                txbConfirmacionesUsuario.Visibility = Visibility.Visible;
            }
        }

        /// <summary>
        /// Comprueba que el codigo sea correcto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCheckCode(object sender, RoutedEventArgs e)
        {
            String strErrorCode = resourceLoader.GetString("strErrorSameCode");

            if (!String.IsNullOrEmpty(txbCode.Text) && txbCode.Text.Equals(code.ToString()))
            {
                txblCheckCode.Visibility = Visibility.Collapsed;
                txbCode.Visibility = Visibility.Collapsed;
                btnCheckCod.Visibility = Visibility.Collapsed;
                txbConfirmacionesUsuario.Visibility = Visibility.Collapsed;
                txblCambiarPsw.Visibility = Visibility.Visible;
                pwbNewPassword.Visibility = Visibility.Visible;
                pwbRNewPassword.Visibility = Visibility.Visible;
                btnChangePsw.Visibility = Visibility.Visible;
            }
            else
            {
                txbConfirmacionesUsuario.Text = strErrorCode;
                txbConfirmacionesUsuario.Visibility = Visibility.Visible;
            }
        }

        /// <summary>
        /// Actualiza la contrasenia
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void BtnChangePsw_Click(object sender, RoutedEventArgs e)
        {
            String strErrorPsws = resourceLoader.GetString("strErrorSamePsw");

            if (!String.IsNullOrEmpty(pwbNewPassword.Password) && !String.IsNullOrEmpty(pwbRNewPassword.Password)
                && pwbNewPassword.Password.Equals(pwbRNewPassword.Password))
            {

                txblCambiarPsw.Visibility = Visibility.Collapsed;
                pwbNewPassword.Visibility = Visibility.Collapsed;
                pwbRNewPassword.Visibility = Visibility.Collapsed;
                btnChangePsw.Visibility = Visibility.Collapsed;

                SHA256 mySHA256 = SHA256.Create();
                byte[] psw = mySHA256.ComputeHash(Encoding.UTF8.GetBytes(pwbNewPassword.Password));
                String password = Convert.ToBase64String(psw);

                clsManejadoraManager manej = new clsManejadoraManager();
                bool ok = await manej.actualizarPasswordManagerDAL(mng.id, password);
                String strOk = resourceLoader.GetString("strRestorePswOk");
                String strError = resourceLoader.GetString("strRestorePswNotOk");

                if (ok)
                {
                    txbConfirmacionesUsuario.Text = strOk;
                    txbConfirmacionesUsuario.Foreground = new SolidColorBrush(Windows.UI.Colors.LightGreen);
                    txbConfirmacionesUsuario.Visibility = Visibility.Visible;
                }
                else
                {
                    txbConfirmacionesUsuario.Text = strError;
                    txbConfirmacionesUsuario.Visibility = Visibility.Visible;
                }
            }
            else {
                txbConfirmacionesUsuario.Text = strErrorPsws;
                txbConfirmacionesUsuario.Visibility = Visibility.Visible;
            }
        }

        /// <summary>
        /// Verifica el formato del correo
        /// </summary>
        /// <returns></returns>
        private bool correoCorrecto()
        {

            bool ret = false;
            String formato = "^[^@]+@[^@]+\\.[a-zA-Z]{2,}$";

            if (!String.IsNullOrEmpty(txbCorreo.Text) && Regex.IsMatch(txbCorreo.Text, formato))
                ret = true;

            return ret;
        }

        /// <summary>
        /// Genera un codigo y lo envia al email
        /// </summary>
        /// <param name="correo"></param>
        /// <returns></returns>
        private String sendCodeToEmail(String correo) {

            String code = Guid.NewGuid().ToString();

            SmtpClient smtp = new SmtpClient();
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.UseDefaultCredentials = false;
            smtp.EnableSsl = true;
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.Credentials = new NetworkCredential("footballtrainingmanager@gmail.com", "F00tball.Training.Manager");

            string from = "footballtrainingmanager@gmail.com";
            string to = correo;
            MailMessage message = new MailMessage(from, to);
            message.Subject = "Code to restore your password";
            message.Body = @"Insert this code in your FTM application: "+code;

            try
            {
                smtp.Send(message);
            } catch (Exception ex) {
                
            }

            return code;
        }
    }
}
