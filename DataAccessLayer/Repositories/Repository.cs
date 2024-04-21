using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomainLayer;
using DomainLayer.Constants;
using DomainLayer.ExceptionsCustom;
using DomainLayer.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repository
{
    public class Repository<T> : IRepository<T>
  where T : class
    {
        private readonly AppSolutionDBContext _appSolutionDBContext;

        public Repository(AppSolutionDBContext appSolutionDBContext)
        {
            _appSolutionDBContext = appSolutionDBContext;
        }

        public IEnumerable<T> Get()
        {
            return _appSolutionDBContext.Set<T>().AsEnumerable();
        }

        public T Get(long id)
        {
            return _appSolutionDBContext.Set<T>().Find(id);
        }

        public T Get(int id)
        {
            return _appSolutionDBContext.Set<T>().Find(id);
        }

        public T Get(string id)
        {
            return _appSolutionDBContext.Set<T>().Find(id);
        }

        public T Obtenir(long id)
        {
            T entite = Get(id);
            return entite ?? throw new ErreurValidationException(RegleGestion.ENTITE_INEXISTANTE, "Entité inexistante", typeof(T).Name, id);
        }

        public T Obtenir(int id)
        {
            T entite = Get(id);
            return entite ?? throw new ErreurValidationException(RegleGestion.ENTITE_INEXISTANTE, "Entité inexistante", typeof(T).Name, id);
        }

        public T Obtenir(string id)
        {
            T entite = Get(id);
            return entite ?? throw new ErreurValidationException(RegleGestion.ENTITE_INEXISTANTE, "Entité inexistante", typeof(T).Name, id);
        }

        public T Ajouter(T entity)
        {
            _appSolutionDBContext.Set<T>().Add(entity);

            return entity;
        }

        public List<T> Ajouter(List<T> listEntity)
        {
            _appSolutionDBContext.Set<T>().AddRange(listEntity);

            return listEntity;
        }

        public T Modifier(T entity)
        {
            _appSolutionDBContext.Entry(entity).State = EntityState.Modified;

            return entity;
        }

        public List<T> Modifier(List<T> listEntity)
        {
            foreach (T entity in listEntity)
            {
                Modifier(entity);
            }

            return listEntity;
        }

        public void Supprimer(T entity)
        {
            _appSolutionDBContext.Set<T>().Remove(entity);
        }

        public void Enregistrer()
        {
            _appSolutionDBContext.SaveChanges();
        }

        public Task<int> EnregistrerAsync()
        {
            return _appSolutionDBContext.SaveChangesAsync();
        }

        public void ViderContext()
        {
            if (_appSolutionDBContext.ChangeTracker.HasChanges())
            {
                Console.WriteLine("viderContexte");
                _appSolutionDBContext.ChangeTracker.Clear();
            }
        }
    }
}
