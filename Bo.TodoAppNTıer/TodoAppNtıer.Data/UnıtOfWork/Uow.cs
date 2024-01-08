using Bo.TodoAppNTİer.DataAccess.Context;
using Bo.TodoAppNTİer.DataAccess.Interfaces;
using Bo.TodoAppNTİer.DataAccess.Repositories;
using Bo.TodoAppNTİer.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bo.TodoAppNTİer.DataAccess.UnıtOfWork
{
    public class Uow : IUow
    {
        private readonly TodoContext _context;

        public Uow(TodoContext context)
        {
            _context = context;
        }

        public IRepository<T> GetRepository<T>() where T : BaseEntity
        {
            return new Repository<T>(_context);
        }

        public async Task Savechanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
