using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// Interface for database object models.
/// </summary>
/// <remarks>This can hold fields common across all entities, like ID. This can also help us with creating base service CRUD ops across all models.</remarks>
namespace EligoCustomerPortal.Data.Models.Interfaces
{
    public interface IEligoEntity
    {
        /// <summary>
        /// Primary key.
        /// </summary>
        int ID { get; set; }
    }
}
