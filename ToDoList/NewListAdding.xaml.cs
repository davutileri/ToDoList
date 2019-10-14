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
    /// Interaction logic for NewListAdding.xaml
    /// </summary>
    public partial class NewListAdding : Window
    {
        private UserRepository _userRepository;
        private ToDoListRepsitory _toDoListRepsitory;
        private ToDoListItemRepository _toDoListItemRepository;
        private int userId;
        public NewListAdding(int id)
        {
            InitializeComponent();
            Loaded += NewListAdding_Loaded;
            _userRepository = new UserRepository();
            _toDoListRepsitory = new ToDoListRepsitory();
            _toDoListItemRepository = new ToDoListItemRepository();
            userId = id;
        }

        private void NewListAdding_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void BtnNewList_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var newList = new ToDoList
                {
                    Name = txtNewList.Text,
                    UserId = userId
                };
                _toDoListRepsitory.Add(newList);
                MessageBox.Show("New list added!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
