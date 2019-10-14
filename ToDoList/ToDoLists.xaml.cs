using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
    /// Interaction logic for ToDoLists.xaml
    /// </summary>
    public partial class ToDoLists : Window
    {
        private ToDoListRepsitory _toDoListRepsitory;
        private int userId;
        public ToDoLists(int id)
        {
            InitializeComponent();
            Loaded += ToDoLists_Loaded;
            _toDoListRepsitory = new ToDoListRepsitory();
            userId = id;
        }

        private void ToDoLists_Loaded(object sender, RoutedEventArgs e)
        {
            GetDataGridList();
        }

        private void BtnAddNewList_Click(object sender, RoutedEventArgs e)
        {
            NewListAdding newListAdding = new NewListAdding(userId);
            newListAdding.ShowDialog();
            GetDataGridList();
        }

        private void BtnDeleteList_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ToDoList toDoList = (ToDoList)dtgToDoLists.SelectedItem;
                if (MessageBox.Show("Are you sure?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    _toDoListRepsitory.Delete(toDoList);
                    GetDataGridList();
                    MessageBox.Show("List deleted!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MainWindow home = new MainWindow();
            home.Show();
        }

        private void BtnShowItems_Click(object sender, RoutedEventArgs e)
        {
            ToDoList toDoList = (ToDoList)dtgToDoLists?.SelectedItem;
            if (toDoList == null)
            {
                MessageBox.Show("Please select a to-do list!");
            }
            else
            {
                ToDoListItems toDoListItems = new ToDoListItems(toDoList.Id, userId);
                toDoListItems.ShowDialog();
            }
        }

        private void GetDataGridList()
        {
            var todoo = _toDoListRepsitory.GetToDoListByFilter(x => x.UserId == userId);
            dtgToDoLists.ItemsSource = todoo;
        }

        private void BtnLogOut_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
