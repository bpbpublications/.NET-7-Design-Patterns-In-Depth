using System.Data;
using System.Data.SqlClient;

namespace PessimisticOfflineLock
{
    public class Author
    {
        public int AuthorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Version { get; set; }
    }

    public class AuthorDomain
    {
        public bool Modify(Author author)
        {
            LockManager.ReleaseAllLocks("Session 1");
            LockManager.AcquireLock(author.AuthorId, "Session 1");
            //
            LockManager.ReleaseLock(author.AuthorId, "Session 1");
            return true;
        }
    }
    public static class LockManager
    {
        static bool HasLock(int lockable, string owner)
        {
            //check if an owner already owns a lock.
            return true;
        }
        public static void AcquireLock(int lockable, string owner)
        {
            if (!HasLock(lockable, owner))
            {
                try
                {
                    //Insert into lock table/object
                }
                catch (SqlException ex)
                {
                    throw new DBConcurrencyException($"unable to lock {lockable}");
                }
            }
        }
        public static void ReleaseLock(int lockable, string owner)
        {
            try
            {
                //delete from lock table/object
            }
            catch (SqlException ex)
            {
                throw new Exception($"unable to release lock {lockable}");
            }
        }
        public static void ReleaseAllLocks(string owner)
        {
            try
            {
                //delete all locks for given owner from lock table/object
            }
            catch (SqlException ex)
            {
                throw new Exception($"unable to release locks owned by {owner}");
            }
        }
    }
}