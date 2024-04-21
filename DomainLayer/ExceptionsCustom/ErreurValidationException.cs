using System;
using System.Net;
using System.Runtime.Serialization;

namespace DomainLayer.ExceptionsCustom;

/// <summary>
/// Représente une règle de gestion non satisfaite.
/// </summary>
[Serializable]
public class ErreurValidationException : ExceptionBase
{
    public ErreurValidationException(string codeErreur)
    {
        StatutHttp = (int)HttpStatusCode.BadRequest;
        CodeErreur = codeErreur;
    }

    public ErreurValidationException(string codeErreur, string message)
        : base(message)
    {
        StatutHttp = (int)HttpStatusCode.BadRequest;
        CodeErreur = codeErreur;
    }

    public ErreurValidationException(string codeErreur, string message, params object[] parametres)
        : base(message)
    {
        StatutHttp = (int)HttpStatusCode.BadRequest;
        CodeErreur = codeErreur;
        Parametres = parametres;
    }

    // Constructeur utilisé pour les tests de controlleurs (TimeTrackTest), quand le controlleur throw une ErreurValidationException,
    // Lors de la sérialisation de l'erreur depuis le Json retourné, ce constructeur est utilisé
    // Utilisé par exemple dans JournalAccesControllerTest.Rechercher_siNumPageVide_alorsErreurValidationJA0002
    // Dans la ligne response.Content.ReadAsAsync<ErreurValidationException>()
    protected ErreurValidationException(SerializationInfo info, StreamingContext context)
        : base(info, context)
    {
        StatutHttp = (int)HttpStatusCode.BadRequest;
        CodeErreur = info.GetString("codeErreur");
    }

    public override string TypeException => EXCEPTION_TYPE_ERREUR_VALIDATION;

    public override string CodeErreur { get; }

    public override int StatutHttp { get; }

    public override object[] Parametres { get; }
}
