using System.Collections.Generic;
using System.Linq;
using DomainLayer;
using DomainLayer.Constants;
using DomainLayer.ExceptionsCustom;
using DomainLayer.IRepositories;
using DomainLayer.Models;
using DomainLayer.UtilityObject;

namespace DataAccessLayer.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly AppSolutionDBContext _appSolutionDBContext;

        public UserRepository(AppSolutionDBContext appSolutionDBContext)
            : base(appSolutionDBContext)
        {
            _appSolutionDBContext = appSolutionDBContext;
        }

        public List<User> Rechercher(UserRecherche userRecherche)
        {
            return _appSolutionDBContext.Users.Where(x => (string.IsNullOrEmpty(userRecherche.Email) || x.Email.ToUpper().Contains(userRecherche.Email.ToUpper()))
                                                  && (string.IsNullOrEmpty(userRecherche.LastName) || x.LastName.ToUpper().Contains(userRecherche.LastName.ToUpper()))
                                                  && (string.IsNullOrEmpty(userRecherche.FirstName) || x.FirstName.ToUpper().Contains(userRecherche.FirstName.ToUpper())))
                                              .ToList();
        }

        public void SupprimerListe(List<int> listeASupprimer)
        {
            IEnumerable<User> listFctEmpASupprimer = _appSolutionDBContext.Users.Where(x => listeASupprimer.Contains(x.UserId));
            if (listFctEmpASupprimer.Count() != listeASupprimer.Count)
            {
                throw new ErreurValidationException(RegleGestion.ENTITE_INEXISTANTE, "Les utilisateurs inexistante");
            }

            _appSolutionDBContext.Users.RemoveRange(listFctEmpASupprimer);
        }
    }
}
