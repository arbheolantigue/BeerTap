using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IqmetrixBeerTap.Domain.Model;

namespace IqmetrixBeerTap.Domain.Controller
{
    public class OfficeService : RepositoryService<Office>, IOfficeService
    {

        public Office Update(Office office)
        {
            var currentOffice = _context.Offices.Find(office.Id);
            currentOffice.Name = office.Name;
            currentOffice.Description = office.Description;
            Save();
            return currentOffice;
        }

    }
}                 
