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
    /// Interaction logic for ToDoListItems.xaml
    /// </summary>
    public partial class ToDoListItems : Window
    {
        private UserRepository _userRepository;
        private ToDoListRepsitory _toDoListRepsitory;
        private ToDoListItemRepository _toDoListItemRepository;
        private int userId;
        private int listId;

        public ToDoListItems(int selectedListId, int selectedUserId)
        {
            InitializeComponent();
            Loaded += ToDoLists_Loaded;
            _userRepository = new UserRepository();
            _toDoListRepsitory = new ToDoListRepsitory();
            _toDoListItemRepository = new ToDoListItemRepository();
            listId = selectedListId;
            userId = selectedUserId;
        }

        private void ToDoLists_Loaded(object sender, RoutedEventArgs e)
        {
            GetDataGridItems();
        }

        private void BtnAddItem_Click(object sender, RoutedEventArgs e)
        {
            NewItemAdding newItemAdding = new NewItemAdding(listId);
            newItemAdding.ShowDialog();
            GetDataGridItems();
        }

        private void BtnItemUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ToDoListItem toDoListItem = (ToDoListItem)dtgToDoListItems.SelectedItem;
                if (toDoListItem == null)
                {
                    MessageBox.Show("Please select one item!");
                }
                else
                {
                    _toDoListItemRepository.Update(toDoListItem);
                    GetDataGridItems();
                    MessageBox.Show("Item updated!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void BtnItemDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ToDoListItem toDoListItem = (ToDoListItem)dtgToDoListItems.SelectedItem;
                if (toDoListItem == null)
                {
                    MessageBox.Show("Please select one item!");
                }
                else
                {
                    if ((MessageBox.Show("Are you sure?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes))
                    {
                        _toDoListItemRepository.Delete(toDoListItem);
                        GetDataGridItems();
                        MessageBox.Show("Item deleted!");
                    }
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void GetDataGridItems()
        {
            ToDoLists toDoLists = new ToDoLists(userId);
            ToDoList toDoList = (ToDoList)toDoLists.dtgToDoLists.SelectedItem;
            var toDoListItems = _toDoListItemRepository.GetToDoListItemByFilter(x => x.ToDoListId == listId);
            dtgToDoListItems.ItemsSource = toDoListItems;
            
        }
    }
}
