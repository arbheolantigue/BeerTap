using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using IqmetrixBeerTap.Domain.Model;

namespace IqmetrixBeerTap.Domain.Controller
{
    public class KegService : RepositoryService<Keg>, IKegService
    {

        public Keg Update(Keg keg)
        {
            var currentKeg = _context.Kegs.Find(keg.Id);
            currentKeg.Name = keg.Name;
            currentKeg.Container = keg.Container;
            Save();
            return currentKeg;
        }

        public IEnumerable<Keg> GetAllByOffice(int officeId)
        {
            return _context.Kegs.Where(k => k.OfficeId == officeId);
        }

        public Keg GetByKegId(int id, int officeId)
        {
            var keg = _context.Kegs.Where(k => k.OfficeId == officeId && k.Id == id);
            if (keg.FirstOrDefault() == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return keg.FirstOrDefault();
        }

        public Keg AddKeg(int officeId, Keg keg)
        {
            var newKeg = new Keg()
            {
                Name = keg.Name,
                Container = FULL_KEG,
                OfficeId = officeId,
                Id = keg.Id
            };
            _context.Kegs.Add(newKeg);
            Save();
            return newKeg;
        }

        public decimal GetBeer(int id, decimal amount, int officeId)
        {
            var currentKeg = GetByKegId(id, officeId);
            if (GetKegState(currentKeg.Container) == KegState.SheIsDryMate)
            {
                throw new HttpResponseException(HttpStatusCode.MethodNotAllowed);
            }
            var amountGet = (currentKeg.Container < amount) ? currentKeg.Container : (amount);
            currentKeg.Container = (currentKeg.Container < amount) ? 0 : (currentKeg.Container - amount);
            Save();
            return amountGet;
        }

        public Keg ReplaceKeg(int id, int officeId)
        {
            var kegToReplace = GetByKegId(id, officeId);
            if (GetKegState(kegToReplace.Container) == KegState.New ||
                GetKegState(kegToReplace.Container) == KegState.GoinDown)
            {
                throw new HttpResponseException(HttpStatusCode.MethodNotAllowed);
            }
            kegToReplace.Container = FULL_KEG;
            Save();
            return kegToReplace;
        }

        public static KegState GetKegState(decimal currentAmount)
        {
            if (currentAmount <= 100 && currentAmount >= 71)
                return KegState.New;

            if (currentAmount <= 70 && currentAmount >= 31)
                return KegState.GoinDown;

            if (currentAmount <= 30 && currentAmount >= 10)
                return KegState.AlmostEmpty;

            return KegState.SheIsDryMate;
        }

        private const int FULL_KEG = 100;
    }
}
