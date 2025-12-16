using Repository_UOW.Core.Interfaces;
using Repository_UOW.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository_UOW.EF.Repositories
{
    public class BookRepository : BaseRepository<Book>, IBookRepository
    {
        private readonly ApplicationDbContext Context;

        public BookRepository(ApplicationDbContext context) : base(context)
        {
            Context = context;
        }


        public void BookOnlyFunction()
        {
            Console.WriteLine("Only Book Function");
        }
    }
}
