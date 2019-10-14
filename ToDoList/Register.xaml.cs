using System;
using System.Collections.Generic;
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
using ToDoListData.Entities;
using ToDoListData.Repositories.Concrete;

namespace ToDoListApp
{
    /// <summary>
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        private UserRepository _userRepository;
        public Register()
        {
            InitializeComponent();
            _userRepository = new UserRepository();
        }

        private void BtnRegister_Click(object sender, RoutedEventArgs e)
        {
            var user = _userRepository.GetUserListByFilter(x => x.UserName == txtUserName.Text);
            if (user.Any())
            {
                MessageBox.Show("User Name is already exist!");
            }
            else if (txtPassword.Password.ToString() != txtConfirmedPassword.Password.ToString())
            {
                MessageBox.Show("Password and Confirmed Password must be same!");
            }
            else
            {
                var newUser = new User
                {
                    FirstName = txtFirstName.Text,
                    LastName = txtLastName.Text,
                    UserName = txtUserName.Text,
                    Password = txtPassword.Password.ToString()
                };
                try
                {
                    _userRepository.Add(newUser);
                    MessageBox.Show("User added!");

                    MainWindow home = new MainWindow();
                    home.Show();
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void BtnHome_Click(object sender, RoutedEventArgs e)
        {
            MainWindow home = new MainWindow();
            home.Show();
            this.Close();
        }
    }
}
