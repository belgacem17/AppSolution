using System.Collections.Generic;
using System.Threading.Tasks;

namespace DomainLayer.IRepositories
{
    public interface IRepository<T>
    {
        IEnumerable<T> Get();

        T Get(long id);

        T Get(int id);

        T Get(string id);

        T Obtenir(long id);

        T Obtenir(int id);

        T Obtenir(string id);

        T Ajouter(T entity);

        List<T> Ajouter(List<T> listEntity);

        T Modifier(T entity);

        void Supprimer(T entity);

        void Enregistrer();

        Task<int> EnregistrerAsync();

        /// <summary>
        ///  Vide le Contexte Entity Framework.
        ///  Par exemple, s'il y'a une entité modifiée et non encore persistée dans la BD, quand on appelle cette méthode, elle va supprimér les changements effectués sur l'unité du contexte.
        ///  Donc quand on appelle Enregistrer(), aucune modification ne sera appliquée dans la BD.
        /// </summary>
        void ViderContext();
    }
}
