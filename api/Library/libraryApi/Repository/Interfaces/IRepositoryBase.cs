using System;
using System.Collections.Generic;

namespace libraryApi.Repository.Interfaces
{
    public interface IRepositoryBase<T>
    {
        void Create(T entity);
        void Update(T entity);
        T Retrieve(Guid id);
        void Delete(Guid id);
        IList<T> RetrieveAll();
    }
}
