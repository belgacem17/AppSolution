using Business.DTO;
using Business.IServices;
using DomainLayer.UtilityObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayerTest.Services
{
    public class UserService : IUserService
    {
        public UserDTO Ajouter(UserDTO user)
        {
            return new UserDTO() { 
            Email = user.Email,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Password  = user.Password,
            };
        }

        public UserDTO GetByID(int userId)
        {
            throw new NotImplementedException();
        }

        public UserDTO Modifier(int userId, UserDTO user)
        {
            throw new NotImplementedException();
        }

        public List<UserDTO> Rechercher(UserRecherche userRecherche)
        {
            throw new NotImplementedException();
        }

        public void SupprimerListe(List<int> listUsers)
        {
            throw new NotImplementedException();
        }
    }
}
