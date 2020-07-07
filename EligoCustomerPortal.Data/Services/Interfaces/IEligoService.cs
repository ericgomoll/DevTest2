using EligoCustomerPortal.Data.Models;
using EligoCustomerPortal.Data.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace EligoCustomerPortal.Data.Services.Interfaces
{
    /// <summary>
    /// Houses the base CRUD methods that will be shared accross all services.
    /// </summary>
    /// <typeparam name="T">Type of <see cref="IEligoEntity"/> to perform operations against.</typeparam>
    public interface IEligoService<T> where T: IEligoEntity
    {
        /// <summary>
        /// Retrieves all entities in the DB.
        /// </summary>
        IEnumerable<T> GetAll();

        /// <summary>
        /// Retrieves the selected entity by its unique ID.
        /// </summary>
        /// <param name="ID">ID of entity to retrieve.</param>
        T GetByID(int ID);

        /// <summary>
        /// Inserts or updates entity into the database.
        /// </summary>
        /// <param name="entity">Entity to insert or update.</param>
        bool AddOrUpdate(T entity);

        /// <summary>
        /// Removes entity from the database.
        /// </summary>
        /// <param name="entity">Entity to remove.</param>
        bool Delete(T entity);
    }
}
