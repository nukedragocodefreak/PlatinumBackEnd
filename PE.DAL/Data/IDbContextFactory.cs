using System.Data;
using PE.BO.Enums;

namespace CCA.DAL.Data
{
    public interface IDbContextFactory
    {
        IDbConnection GetConnection(string connectionString);
        dynamic GetMyConnection(ORM connectionType);
    }
}
