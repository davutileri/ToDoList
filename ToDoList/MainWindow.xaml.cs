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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ToDoListData.Entities;
using ToDoListData.Repositories.Concrete;

namespace ToDoListApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private UserRepository _userRepository;
        private ToDoListRepsitory _toDoListRepsitory;
        private ToDoListItemRepository _toDoListItemRepository;

        
        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
            _userRepository = new UserRepository();
            _toDoListRepsitory = new ToDoListRepsitory();
            _toDoListItemRepository = new ToDoListItemRepository();
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void BtnRegister(object sender, RoutedEventArgs e)
        {
            Register newUser = new Register();
            newUser.Show();
            this.Close();
        }

        private void BtnLogIn(object sender, RoutedEventArgs e)
        {
            var user = GetCurrentUserId();

            if (user == null)
            {
                MessageBox.Show("User not found. Please check User Name and Password!");
            }
            else
            {
                ToDoLists toDoLists = new ToDoLists(user.Id);
                toDoLists.Show();
                this.Close();
            }
        }

        public User GetCurrentUserId()
        {
            return _userRepository.GetUserListByFilter(x => x.UserName == txtUserName.Text && x.Password == txtPassword.Password.ToString()).FirstOrDefault();
        }
        
    }
}
