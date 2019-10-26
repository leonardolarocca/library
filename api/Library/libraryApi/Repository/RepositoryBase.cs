using libraryApi.Config;
using libraryApi.Repository.Interfaces;
using NHibernate;
using System;
using System.Collections.Generic;

namespace libraryApi.Repository
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected ISession Session = null;
        protected ITransaction Transaction = null;

        public RepositoryBase()
        {
            Session = Database.OpenSession();
        }

        public void BeginTransaction()
        {
            Transaction = Session.BeginTransaction();
        }

        public void CommitTransaction()
        {
            Transaction.Commit();
            CloseTransaction();
        }

        public void RollbackTransaction()
        {
            Transaction.Rollback();
            CloseTransaction();
            CloseSession();
        }

        private void CloseTransaction()
        {
            Transaction.Dispose();
            Transaction = null;
        }

        private void CloseSession()
        {
            Session.Close();
            Session.Dispose();
            Session = null;
        }

        public void Dispose()
        {
            if (Transaction != null)
            {
                CommitTransaction();
            }
            if (Session != null)
            {
                Session.Flush();
                CloseSession();
            }
        }

        public void Create(T entity)
        {
            BeginTransaction();

            try
            {
                Session.Save(entity);
                CommitTransaction();

            }
            catch (Exception ex)
            {
                if (!Transaction.WasCommitted)
                    RollbackTransaction();

                throw new Exception($"Error on create, {ex.Message}");
            }
        }

        public void Update(T entity)
        {
            BeginTransaction();

            try
            {
                Session.SaveOrUpdate(entity);
                CommitTransaction();
            }
            catch (Exception ex)
            {
                if (!Transaction.WasCommitted)
                    RollbackTransaction();

                throw new Exception($"Error on update, {ex.Message}");
            }
        }

        public T Retrieve(Guid id)
        {
            BeginTransaction();

            try
            {
                return Session.Get<T>(id);
            }
            catch (Exception ex)
            {
                if (!Transaction.WasCommitted)
                    RollbackTransaction();

                throw new Exception($"Error at retrieve the object with id: {id}, {ex.Message}");
            }
        }

        public void Delete(Guid id)
        {
            BeginTransaction();

            try
            {
                var obj = Retrieve(id);
                Session.Delete(obj);
                CommitTransaction();
            }
            catch (Exception ex)
            {
                if (!Transaction.WasCommitted)
                    RollbackTransaction();

                throw new Exception($"Error at delete, {ex.Message}");
            }
        }

        public IList<T> RetrieveAll()
        {
            BeginTransaction();

            try
            {
                return Session.CreateCriteria<T>().List<T>();
            }
            catch (Exception ex)
            {
                if (!Transaction.WasCommitted)
                    RollbackTransaction();

                throw new Exception($"Error on retrieve data, {ex.Message}");
            }
        }
    }
}
