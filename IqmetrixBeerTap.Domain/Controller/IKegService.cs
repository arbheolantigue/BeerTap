using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IqmetrixBeerTap.Domain.Model;

namespace IqmetrixBeerTap.Domain.Controller
{
    public interface IKegService : IRepositoryService<Keg>
    {
        Keg Update(Keg keg);
        IEnumerable<Keg> GetAllByOffice(int officeId);
        Keg GetByKegId(int id, int officeId);
        Keg AddKeg(int officeId, Keg keg);
        decimal GetBeer(int id, decimal amount, int officeId);
        Keg ReplaceKeg(int id, int officeId);
    }
}
