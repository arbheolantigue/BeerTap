using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IqmetrixBeerTap.Domain.Model;


namespace IqmetrixBeerTap.Domain.Controller
{
    public interface IOfficeService : IRepositoryService<Office>
    {
        Office Update(Office office);
    }
}  
