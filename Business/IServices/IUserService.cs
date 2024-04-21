using System.Collections.Generic;
using Business.DTO;
using DomainLayer.UtilityObject;

namespace Business.IServices
{
    public interface IUserService
    {
        public List<UserDTO> Rechercher(UserRecherche userRecherche);

        public UserDTO GetByID(int userId);

        public UserDTO Ajouter(UserDTO user);

        public UserDTO Modifier(int userId, UserDTO user);

        public void SupprimerListe(List<int> listUsers);
    }
}
