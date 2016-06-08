using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using IqmetrixBeerTap.Domain.Model;


namespace IqmetrixBeerTap.Domain.Controller
{
    public class RepositoryService<TEntity> where TEntity:class
    {
        public readonly BeerTapContext _context;
        private readonly DbSet<TEntity> _entity;
        public RepositoryService()
        {
            _context = new BeerTapContext();
            _entity = _context.Set<TEntity>();
        }
        public IEnumerable<TEntity> GetAll()
        {
            return _entity;
        }

        public TEntity GetById(int id)
        {
            var entity = _entity.Find(id);
            if (entity == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return entity;
        }

        public TEntity Insert(TEntity entity)
        {
            _entity.Add(entity);
            Save();
            return entity;
        }

        public void Delete(int id)
        {
            _entity.Remove(_entity.Find(id));
            Save();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
