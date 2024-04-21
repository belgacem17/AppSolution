using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using DomainLayer.IRepositories;
using Business.Services;
using Business.DTO;
using DomainLayer.Constants;
using DomainLayer.ExceptionsCustom;
using FluentAssertions;
using DomainLayer.Models;

namespace BusinessLayerTest.Services
{
    public class UserServiceTest
    {
        private readonly Mock<IUserRepository> _userRepository;
        private readonly UserService _userService;

        public UserServiceTest()
        {
            _userRepository = new Mock<IUserRepository>();
            _userService = new UserService(_userRepository.Object);
        }

        #region Ajouter
        [Fact]
        public void Ajouter_siFirstNameEstNullOuVide_AlorsRetourneeErreurValidationUser0001()
        {
            // Arrange
            var userDTO = new UserDTO();

            // Act
            _userService.Invoking(x => x.Ajouter(userDTO))

            // Assert
            .Should().Throw<ErreurValidationException>()
            .Where(x => x.CodeErreur == RegleGestion.LAST_NAME_INVALIDE);
        }

        [Fact]
        public void Ajouter_siLastNameEstNullOuVide_AlorsRetourneeErreurValidationUser0002()
        {
            // Arrange
            var userDTO = new UserDTO()
            {
                LastName = "Foulen",
            };

            // Act
            _userService.Invoking(x => x.Ajouter(userDTO))

            // Assert
            .Should().Throw<ErreurValidationException>()
            .Where(x => x.CodeErreur == RegleGestion.FIRST_NAME_INVALIDE);
        }

        [Fact]
        public void Ajouter_siEmailEstNullOuVide_AlorsRetourneeErreurValidationUser0003()
        {
            // Arrange
            var userDTO = new UserDTO()
            {
                LastName = "Foulen",
                FirstName = "Foulen",
            };

            // Act
            _userService.Invoking(x => x.Ajouter(userDTO))

            // Assert
            .Should().Throw<ErreurValidationException>()
            .Where(x => x.CodeErreur == RegleGestion.EMAIL_INVALIDE);
        }

        [Fact]
        public void Ajouter_siEmailEstNonNullEtNonVideEtInValide_AlorsRetourneeErreurValidationUser0003()
        {
            // Arrange
            var userDTO = new UserDTO()
            {
                LastName = "Foulen",
                FirstName = "Foulen",
                Email = "foulen.com"
            };

            // Act
            _userService.Invoking(x => x.Ajouter(userDTO))

            // Assert
            .Should().Throw<ErreurValidationException>()
            .Where(x => x.CodeErreur == RegleGestion.EMAIL_INVALIDE);
        }

        [Fact]
        public void Ajouter_siPasswordEstNullOuVide_AlorsRetourneeErreurValidationUser0004()
        {
            // Arrange
            var userDTO = new UserDTO()
            {
                LastName = "Foulen",
                FirstName = "Foulen",
                Email = "foulen@gmail.com"
            };

            // Act
            _userService.Invoking(x => x.Ajouter(userDTO))

            // Assert
            .Should().Throw<ErreurValidationException>()
            .Where(x => x.CodeErreur == RegleGestion.PASSWORD_INVALIDE);
        }

        [Fact]
        public void Ajouter_siToutLesPArametresValidee_AlorsAjouterUtilisateur()
        {
            // Arrange
            var userDTO = new UserDTO()
            {
                LastName = "Foulen",
                FirstName = "Foulen",
                Email = "foulen@gmail.com",
                Password= "pwd"
            };

            // Act
            _userService.Ajouter(userDTO);
            
            // Assert
            _userRepository.Verify(x => x.Ajouter(It.Is<User>(x => x.LastName == userDTO.LastName 
                                                                    && x.FirstName == userDTO.FirstName
                                                                    && x.Email == userDTO.Email
                                                                    && x.Password == userDTO.Password)));
            _userRepository.Verify(x => x.Enregistrer());

        }
        #endregion

        #region GetByID
        [Fact]
        public void GetByID_siUitlisateurExistant_alorsRetournUtilisateur()
        {
            // Arrange
            int userId = 5;
            User utilisateur = ObjectMother.CreerUtilisateur(userId: userId);
            _userRepository.Setup(x => x.Get(userId)).Returns(utilisateur);

            // Act
            _userService.Invoking(x => x.GetByID(userId))

            // Assert
            .Should().NotBeNull();

        }
        #endregion
    }
}
