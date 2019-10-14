using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListCore;
using ToDoListData.Entities;

namespace ToDoListData.Repositories.Abstract
{
    public interface IToDoListRepository:IEntityRepository<ToDoList>
    {
    }
}
