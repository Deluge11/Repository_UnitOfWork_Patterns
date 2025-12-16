using Repository_UOW.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository_UOW.Core.Interfaces
{
    public interface IBookRepository : IBaseRepository<Book>
    {
        void BookOnlyFunction();
    }
}
