using Bo.TodoAppNTİer.DataAccess.Interfaces;
using Bo.TodoAppNTİer.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bo.TodoAppNTİer.DataAccess.UnıtOfWork
{
    public interface IUow
    {
        IRepository<T> GetRepository<T>() where T : BaseEntity;
        Task Savechanges();
    }
}
