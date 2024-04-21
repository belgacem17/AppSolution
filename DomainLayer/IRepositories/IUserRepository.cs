using System.Collections.Generic;
using DomainLayer.Models;
using DomainLayer.UtilityObject;

namespace DomainLayer.IRepositories;

public interface IUserRepository : IRepository<User>
{
    public List<User> Rechercher(UserRecherche userRecherche);

    public void SupprimerListe(List<int> listeASupprimer);
}
