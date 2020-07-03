using IceCreamShopServiceDAL.BindingModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace IceCreamShopClientView
{
    public partial class FormRegister : Form
    {
        public FormRegister()
        {
            InitializeComponent();
        }

        private void ButtonRegister_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxFIO.Text) &&
           !string.IsNullOrEmpty(textBoxLogin.Text) &&
           !string.IsNullOrEmpty(textBoxPassword.Text))
            {
                try
                {
                    ApiClient.PostRequest("api/client/register", new ClientBindingModel
                    {
                        ClientFIO = textBoxFIO.Text,
                        Login = textBoxLogin.Text,
                        Password = textBoxPassword.Text
                    });
                    MessageBox.Show("Регистрация прошла успешно", "Сообщение",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                    MessageBox.Show(ex.InnerException.Message, "Ошибка", MessageBoxButtons.OK,
                  MessageBoxIcon.Error);
                    MessageBox.Show(ex.InnerException.InnerException.Message, "Ошибка", MessageBoxButtons.OK,
                  MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Введите логин, пароль и ФИО", "Ошибка",
               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
