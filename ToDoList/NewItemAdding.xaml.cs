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
using ToDoListData.Utils;

namespace ToDoListApp
{
    /// <summary>
    /// Interaction logic for NewItemAdding.xaml
    /// </summary>
    public partial class NewItemAdding : Window
    {
        private ToDoListItemRepository _toDoListItemRepository;
        private int listId;
        public NewItemAdding(int id)
        {
            InitializeComponent();
            _toDoListItemRepository = new ToDoListItemRepository();
            listId = id;
        }

        private void BtnItemAdding_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ToDoListStatus status;
                switch (cmbStatus.SelectedValue)
                {
                    case "Created":
                        status = ToDoListStatus.Created;
                        break;

                    case "Completed":
                        status = ToDoListStatus.Completed;
                        break;

                    case "NotCompleted":
                        status = ToDoListStatus.NotCompleted;
                        break;

                    case "Expired":
                        status = ToDoListStatus.Expired;
                        break;
                        
                    default:
                        status = ToDoListStatus.Created;
                        break;
                }
                
                var newItem = new ToDoListItem
                {
                    Name = txtItemName.Text,
                    Description = txtDescription.Text,
                    DeadLine = dtpDeadLine.SelectedDate.Value,
                    Status = status,
                    ToDoListId = listId,
                    CreatedOn = DateTime.Now
                };
                _toDoListItemRepository.Add(newItem);
                MessageBox.Show("New item added!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
