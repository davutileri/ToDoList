using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ToDoListCore;
using ToDoListData.Entities;

namespace ToDoListData.Repositories.Abstract
{
    public interface IUserRepository:IEntityRepository<User>
    {
        List<User> GetUserListByFilter(Expression<Func<User, bool>> filter = null);
    }
}
