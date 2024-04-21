using DataAccessLayerTest.Context;
using DomainLayer.Models;
using DomainLayer.Utility;

namespace DataAccessLayerTest;

public partial class ObjectMother
{
    public User CreerUtilisateur(string? firstName = null, string? lastName = null, string? passwrd = null, string? email = null)
    {
        var user = new User() 
        { 
            Password = passwrd ?? Randomizer.RandomString(),
            Email = email ?? Randomizer.RandomString(),
            LastName = lastName ?? Randomizer.RandomString(),
            FirstName = firstName ?? Randomizer.RandomString(),
        };
        ContextDB.Users.Add(user);
        ContextDB.SaveChanges();
        return user;
    }
}
