using DataAccessLayer.Repository;
using DomainLayer.Models;
using DomainLayer.UtilityObject;
using FluentAssertions;
using Xunit;

namespace DataAccessLayerTest.Repositories
{
    public class UserRepositoryTest : ObjectMother
    {
        private readonly UserRepository _userRepository;
        private readonly int nbusers;

        public UserRepositoryTest()
        {
            nbusers = ContextDB.Users.Count();
            _userRepository = new UserRepository(ContextDB);
        }

        #region Recherche

        [Fact]
        public void Recherche_siTousLesParametresOntLaValeurParDefault_alorsRetourneTousTUlisateurs()
        {
            // Arrange
            CreerUtilisateur();
            CreerUtilisateur();
            CreerUtilisateur();

            var userRecherche = new UserRecherche();

            // Act
            List<User> listUsersReturnee = _userRepository.Rechercher(userRecherche);

            // Assert
            listUsersReturnee.Should().HaveCount(nbusers + 3);
        }

        [Fact]
        public void Recherche_siTousLesParametresSontVideORNullSaufLastName_alorsRetourneToustUlisateursALastName()
        {
            // Arrange
            var users = new List<User>()
            {
                CreerUtilisateur(lastName: "AymenBEl"),
                CreerUtilisateur(lastName: "ALbib"),
                CreerUtilisateur(lastName: "Rania"),
            };

            var userRecherche = new UserRecherche() 
            {
                LastName = "Ayme"
            };

            // Act
            List<User> listUsersReturnee = _userRepository.Rechercher(userRecherche);

            // Assert
            listUsersReturnee.All(x => x.LastName.ToUpper().Contains(userRecherche.LastName.ToUpper())).Should().BeTrue();
        }

        [Fact]
        public void Recherche_siTousLesParametresSontVideEtNullSaufFirstName_alorsRetourneToustUlisateursAFirstName()
        {
            // Arrange
            var users = new List<User>()
            {
                CreerUtilisateur(firstName:"BElgacem", lastName: "Aymen"),
                CreerUtilisateur(firstName:"techlead", lastName: "ALbib"),
                CreerUtilisateur(firstName:"dev", lastName: "Rania"),
            };

            var userRecherche = new UserRecherche()
            {
                FirstName = "techlead"
            };

            // Act
            List<User> listUsersReturnee = _userRepository.Rechercher(userRecherche);

            // Assert
            listUsersReturnee.All(x => x.FirstName.ToUpper().Contains(userRecherche.FirstName.ToUpper())).Should().BeTrue();
        }

        [Fact]
        public void Recherche_siTousLesParametresSontVideORNullSaufEmail_alorsRetourneToustUlisateursAEmail()
        {
            // Arrange
            var users = new List<User>()
            {
                CreerUtilisateur(firstName:"BElgacem", lastName: "Aymen", email: "aymen@gmail.com" ),
                CreerUtilisateur(firstName:"techlead", lastName: "ALbib", email: "ALbib@gmail.com"),
                CreerUtilisateur(firstName:"dev", lastName: "Rania", email: "ALbib@gmail.com"),
            };

            var userRecherche = new UserRecherche()
            {
                Email = "aymen@gmail.com"
            };

            // Act
            List<User> listUsersReturnee = _userRepository.Rechercher(userRecherche);

            // Assert
            listUsersReturnee.All(x => x.Email.ToUpper().Contains(userRecherche.Email.ToUpper())).Should().BeTrue();
            listUsersReturnee.Should().HaveCount(1);
        }

        [Fact]
        public void Recherche_siTousLesParametresSontNonVideEtNonNull_alorsRetourneUlisateursAParametresdeRecherche()
        {
            // Arrange
            var users = new List<User>()
            {
                CreerUtilisateur(firstName:"BElgacem", lastName: "Aymen", email: "aymen@gmail.com" ),
                CreerUtilisateur(firstName:"techlead", lastName: "ALbib", email: "ALbib@gmail.com"),
                CreerUtilisateur(firstName:"dev", lastName: "Rania", email: "ALbib@gmail.com"),
            };

            var userRecherche = new UserRecherche()
            {
                LastName = "Ayme",
                Email = "ALbib@gmail.com",
                FirstName = "dev"
            };

            // Act
            List<User> listUsersReturnee = _userRepository.Rechercher(userRecherche);

            // Assert
            listUsersReturnee.All(x => x.LastName.ToUpper().Contains(userRecherche.LastName.ToUpper())
                                     && x.FirstName.ToUpper().Contains(userRecherche.FirstName.ToUpper())
                                     && x.Email.ToUpper().Contains(userRecherche.Email.ToUpper()))
                            .Should().BeTrue();
        }

        #endregion

        #region SupprimerListe

        #endregion

    }
}
