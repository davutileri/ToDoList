using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListCore;
using ToDoListData.Repositories.Concrete;

namespace ToDoListData.Entities
{
    [Table("ToDoList", Schema = "dbo")]
    public class ToDoList: BaseEntity,IEntity
    {
        public string Name { get; set; }
        public int UserId { get; set; }

        private UserRepository _userRepsitory;
        public User User
        {
            get
            {
                _userRepsitory = new UserRepository();
                return _userRepsitory.GetUserListByFilter(x => x.Id == UserId).FirstOrDefault();
            }
        }
    }
}
