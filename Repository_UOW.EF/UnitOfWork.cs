using Repository_UOW.Core.Interfaces;
using Repository_UOW.Core.Models;
using Repository_UOW.EF.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository_UOW.EF
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext Context;
        public IBookRepository Books { get; private set; }

        public IBaseRepository<Author> Authors { get; private set; }


        public UnitOfWork(ApplicationDbContext context)
        {
            Context = context;
            Authors = new BaseRepository<Author>(context);
            Books = new BookRepository(context);
        }

        public int Complete()
        {
            return Context.SaveChanges();
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
