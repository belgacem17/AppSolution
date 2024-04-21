using DomainLayer.Models;
using DomainLayer.Utility;

namespace BusinessLayerTest;

public static partial class ObjectMother
{
    public static User CreerUtilisateur(int? userId= null, string? firstName = null, string? lastName = null, string? passwrd = null, string? email = null)
    {
        var user = new User() 
        {
            UserId = userId ?? Randomizer.RandomInt(),
            Password = passwrd ?? Randomizer.RandomString(),
            Email = email ?? Randomizer.RandomString(),
            LastName = lastName ?? Randomizer.RandomString(),
            FirstName = firstName ?? Randomizer.RandomString(),
        };
        return user;
    }
}
