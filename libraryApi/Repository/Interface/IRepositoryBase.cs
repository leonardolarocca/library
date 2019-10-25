using System;
using System.Collections.Generic;

namespace book.Repository.Interface
{
    public interface IRepositoryBase<T>
    {
        void Create(T entity);
        void Update(T entity);
        T Retrieve(Guid id);
        void Delete(T entity);
        IList<T> RetrieveAll();
    }
}