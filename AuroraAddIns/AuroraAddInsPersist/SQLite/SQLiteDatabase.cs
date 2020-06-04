using Aurora.AddInsPersist.DatabaseModels;
using Dapper;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aurora.AddInsPersist.SQLite
{
    /// <summary>
    /// https://richardniemand.wordpress.com/2015/04/24/sqlite-and-dapper-in-c/
    /// </summary>
    public class SQLiteDatabase
    {
        private string _connectionString = "";

        public SQLiteDatabase()
        {
            _connectionString = "Data Source=AuroraAddInsDB.db;Version=3;New=False;Compress=True;";
        }


        public long? InsertTech(DbTechObject objectToSave)
        {
            try
            {
                var sQLiteConnection = new SQLiteConnection(this._connectionString);
                sQLiteConnection.Open();
                var result = InsertTech(sQLiteConnection, objectToSave);
                sQLiteConnection.Close();
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public long? InsertTech(SQLiteConnection theConnection, DbTechObject objectToSave)
        {
            long? result = null;
            try
            {
                result = theConnection.Insert(objectToSave);
            }
            catch (Exception)
            {
                theConnection.Close();
                throw;
            }
            return result;
        }

        public List<T> GetQueryResult<T>(string queryString)
        {
            var result = new List<T>();
            try
            {
                var sQLiteConnection = new SQLiteConnection(this._connectionString);
                sQLiteConnection.Open();
                result = UsingExistingConnectionGetQueryResult<T>(queryString, sQLiteConnection);
                sQLiteConnection.Close();
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        public List<T> UsingExistingConnectionGetQueryResult<T>(string queryString, SQLiteConnection theConnection)
        {
            if (LooksLikeAValidSelectQuery(queryString) == false)
            {
                throw new FormatException($"UsingExistingConnectionGetQueryResult expects a SELECT query, but was given : {queryString}");
            }

            var result = new List<T>();
            try
            {
                result = theConnection.Query<T>(queryString).ToList();
            }
            catch (Exception)
            {
                theConnection.Close();
                throw;
            }
            return result;
        }

        private bool LooksLikeAValidSelectQuery(string theQuery)
        {
            return (theQuery.ToLowerInvariant().StartsWith("select"));
        }
    }
}
