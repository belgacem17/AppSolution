using System;
using System.Linq;

namespace DomainLayer.Utility;

public static class Randomizer
{
    private static readonly Random Random = new();

    public static string RandomString()
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        return new string(Enumerable.Repeat(chars, Random.Next(5, 10))
          .Select(s => s[Random.Next(s.Length)]).ToArray());
    }

    public static string RandomString(int taille)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        return new string(Enumerable.Repeat(chars, taille)
          .Select(s => s[Random.Next(s.Length)]).ToArray());
    }

    public static string RandomNumber(int taille)
    {
        const string chars = "0123456789";

        return new string(Enumerable.Repeat(chars, taille)
          .Select(s => s[Random.Next(s.Length)]).ToArray());
    }

    public static string RandomGsm()
    {
        const string chars = "123456789";

        return new string(Enumerable.Repeat(chars, 8)
          .Select(s => s[Random.Next(s.Length)]).ToArray());
    }

    public static string RandomEmail()
    {
        return RandomString(5) + "@technetworld.com";
    }

    public static DateOnly RandomDay(DateTime? aPartirDe = null, short? tailleIntervalle = null)
    {
        aPartirDe ??= DateTime.MinValue;
        tailleIntervalle ??= RandomShort();

        return DateOnly.FromDateTime(((DateTime)aPartirDe).AddDays(Random.Next(1, (int)tailleIntervalle)));
    }

    // Valeur max pour short = 2,147,483,647
    public static int RandomInt(int taille = 8)
    {
        const string chars = "123456789";

        return int.Parse(new string(Enumerable.Repeat(chars, taille)
          .Select(s => s[Random.Next(s.Length)]).ToArray()));
    }

    // Valeur max pour short = 32,767
    public static short RandomShort(int taille = 3)
    {
        const string chars = "123456789";

        return short.Parse(new string(Enumerable.Repeat(chars, taille)
          .Select(s => s[Random.Next(s.Length)]).ToArray()));
    }
}
