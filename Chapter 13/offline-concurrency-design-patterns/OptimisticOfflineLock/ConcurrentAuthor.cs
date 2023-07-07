using System.Data;
using System.Data.SqlClient;

namespace OptimisticOfflineLock
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
        public async Task<Author> Find(int authorId)
        {
            IDataReader reader = await new SqlCommand($"" +
                $"SELECT * " +
                $"FROM author " +
                $"WHERE AuthorId={authorId}").ExecuteReaderAsync();
            reader.Read();
            return new Author()
            {
                AuthorId = (int)reader["AuthorId"],
                FirstName = (string)reader["FirstName"],
                LastName = (string)reader["LastName"],
                Version = (int)reader["Version"]
            };
        }
        public async Task<bool> ModifyAuthor(Author author)
        {
            var result = await new SqlCommand($"" +
                $"UPDATE author " +
                $"SET FirstName='{author.FirstName}', " +
                $"    LastName='{author.LastName}'," +
                $"    Version = Version +1 " +
                $"WHERE AuthorId={author.AuthorId} AND " +
                $"      Version={author.Version}").ExecuteNonQueryAsync();
            if (result == 0)
                throw new DBConcurrencyException();
            else
                return true;
        }
    }
}