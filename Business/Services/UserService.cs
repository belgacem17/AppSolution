using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Business.DTO;
using Business.IServices;
using DomainLayer.Constants;
using DomainLayer.ExceptionsCustom;
using DomainLayer.IRepositories;
using DomainLayer.Models;
using DomainLayer.UtilityObject;

namespace Business.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository) 
        {
            _userRepository = userRepository;
        }

        public UserDTO Ajouter(UserDTO userDto)
        {
            ValiderInfosUtilisateur(userDto);
            User nvUser = MapperUserDTOToUser(userDto);
            _userRepository.Ajouter(nvUser);
            _userRepository.Enregistrer();
            return userDto;
        }

        public UserDTO GetByID(int userId)
        {
            User userDB = _userRepository.Get(userId);

            return MapperUserToUserDTO(userDB);
        }

        public UserDTO Modifier(int userId, UserDTO userDTO)
        {
            ValiderInfosUtilisateur(userDTO);
            User userDB = _userRepository.Get(userId);
            userDB.LastName = userDTO.LastName;
            userDB.FirstName = userDTO.FirstName;
            userDB.Email = userDTO.Email;
            userDB.Password = userDTO.Password;
            _userRepository.Enregistrer();
            return userDTO;
        }

        public List<UserDTO> Rechercher(UserRecherche userRecherche)
        {
            return _userRepository.Rechercher(userRecherche).Select(x => MapperUserToUserDTO(x))
                                                            .ToList();
        }

        public void SupprimerListe(List<int> listUsers)
        {
            _userRepository.SupprimerListe(listUsers);
            _userRepository.Enregistrer();
        }

        public static User MapperUserDTOToUser(UserDTO userDTO)
        {
            return new User()
            {
                Email = userDTO.Email,
                FirstName = userDTO.FirstName,
                LastName = userDTO.LastName,
                Password = userDTO.Password
            };
        }

        private static UserDTO MapperUserToUserDTO(User user)
        {
            return new UserDTO()
            {
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Password = user.Password
            };
        }

        private static void ValiderInfosUtilisateur(UserDTO user)
        {
            if (string.IsNullOrWhiteSpace(user.LastName))
            {
                throw new ErreurValidationException(RegleGestion.LAST_NAME_INVALIDE, "Nom d'utlisateur est invalide");
            }

            if (string.IsNullOrWhiteSpace(user.FirstName))
            {
                throw new ErreurValidationException(RegleGestion.FIRST_NAME_INVALIDE, "Prénon d'utlisateur est invalide");
            }            
            

            if (string.IsNullOrWhiteSpace(user.Email) || !IsEmailValide(user.Email))
            {
                throw new ErreurValidationException(RegleGestion.EMAIL_INVALIDE, "E-mail d'utlisateur est invalide");
            }

            if (string.IsNullOrWhiteSpace(user.Password))
            {
                throw new ErreurValidationException(RegleGestion.PASSWORD_INVALIDE, "E-mail d'utlisateur est invalide");
            }
        }
        public static bool IsEmailValide(string email)
        {
            return new EmailAddressAttribute().IsValid(email);
        }
    }
}
