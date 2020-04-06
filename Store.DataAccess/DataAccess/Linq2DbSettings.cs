using System;
using System.Collections.Generic;
using LinqToDB.Configuration;

namespace Store.DataAccess.DataAccess
{
    /// <summary>
    /// Настройки строки БД.
    /// </summary>
    public class ConnectionStringSettings : IConnectionStringSettings
    {
        public string ConnectionString { get; set; }
        public string Name { get; set; }
        public string ProviderName { get; set; }
        public bool IsGlobal => false;
    }

    /// <summary>
    /// Настройки провайдера linq2db.
    /// </summary>
    public class Linq2DbSettings : ILinqToDBSettings
    {
        string _connStr;
        public Linq2DbSettings(string connStr)
        {
            _connStr = connStr ?? throw new ArgumentNullException(nameof(connStr));
        }

        public IEnumerable<IDataProviderSettings> DataProviders
        {
            get { yield break; }
        }

        public string DefaultConfiguration => "PostgreSQL";
        public string DefaultDataProvider => "PostgreSQL";

        public IEnumerable<IConnectionStringSettings> ConnectionStrings
        {
            get
            {
                yield return
                    new ConnectionStringSettings
                    {
                        Name = "PostgreSQL",
                        ProviderName = "PostgreSQL",
                        ConnectionString = _connStr
                    };
            }
        }
    }
}