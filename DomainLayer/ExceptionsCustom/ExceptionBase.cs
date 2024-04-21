using System;
using System.Runtime.Serialization;

namespace DomainLayer.ExceptionsCustom
{
    [Serializable]
    public abstract class ExceptionBase : Exception
    {
        public const string EXCEPTION_TYPE_ERREUR_VALIDATION = "ErreurValidationException";
        public const string EXCEPTION_TYPE_JETON = "JetonInvalideException";
        public const string EXCEPTION_TYPE_JEU_DE_DONNEE = "JeuDeDonneeException";

        // Quand l'application rencontre une erreur HTTP 400-599 qui n'a pas de body
        public const string EXCEPTION_STATUT_HTTP = "StatutHttpException";

        // Une exception qui n'a pas été catchée par le BE
        public const string EXCEPTION_ERREUR_INTERNE = "ErreurInterneException";

        // Exception lors de l'appel à un système externe
        public const string EXCEPTION_ERREUR_EXTERNE = "ErreurExterneException";

        protected ExceptionBase()
        {
        }

        protected ExceptionBase(string message)
        : base(message)
        {
        }

        protected ExceptionBase(SerializationInfo info, StreamingContext context)

        // Normalement, on devrai appeler le constructeur : base(info, context), mais ceci génère l'exception : Member Message was not found
        : base()
        {
        }

        public abstract string TypeException { get; }

        public abstract string CodeErreur { get; }

        public abstract int StatutHttp { get; }

        // Les paramètres à injecter dans les messages d'erreurs
        public abstract object[] Parametres { get; }
    }
}
