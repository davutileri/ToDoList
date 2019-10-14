using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListCore;
using ToDoListData.Repositories.Concrete;
using ToDoListData.Utils;

namespace ToDoListData.Entities
{
    [Table("ToDoListItem", Schema = "dbo")]
    public class ToDoListItem: BaseEntity,IEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? DeadLine { get; set; }
        public ToDoListStatus Status { get; set; }
        public int ToDoListId { get; set; }
        public DateTime? CreatedOn { get; set; }
    }
}
