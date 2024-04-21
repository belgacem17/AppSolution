using Application.Controllers;
using Business.DTO;
using Business.IServices;
using DomainLayer.Models;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;
namespace ApplicationLayerTest.Controller
{
    public class UsersControllerTest : HttpClientSetup
    {
        #region Ajouter
        [Fact]
        public async Task Ajouter_alorsUtilisateurAjoute2()
        {
            // Arrange
            var userDTO = new UserDTO()
            {
                LastName = "Foulen",
                FirstName = "Foulen",
                Email = "foulen@gmail.com",
                Password = "password",
            };

            HttpRequestMessage req = GetHttpRequestMessage(HttpMethod.Post, "Users", userDTO);

            // Act
            HttpResponseMessage response = await TestClient.SendAsync(req);
            var resultat = await response.Content.ReadAsAsync<User>();
            resultat.Should().BeEquivalentTo(userDTO);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        #endregion

        
    }
}
