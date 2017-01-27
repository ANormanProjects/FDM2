using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADODemo
{
    public interface IAccountRepository
    {
        List<Accounts> GetAllAccounts();

        void AddNewAccount(Accounts accountToAdd);

        void UpdateAccount(int accountToUpdateID, Accounts newAccount);

        void RemoveAccount(int accountToRemoveID);
    }


    public class MicrosoftSqlServerAccountRepository : IAccountRepository
    {
        string _connectionString;

        IDbConnection connection;

        IDbCommand command;


        public MicrosoftSqlServerAccountRepository(string connectionString)
        {
            _connectionString = connectionString;
        }


        public List<Accounts> GetAllAccounts()
        {

            List<Accounts> allAccounts = new List<Accounts>();

            string _sqlStatement =
                "SELECT id, firstName, lastName FROM Accounts";

            //IDbConnection connection =
            //    new SqlConnection(_connectionString);    //connection is passed down from IdbCon to IdbCommand

            //IDbCommand command =                                              // IdbCommand = what to do and where to go
            //    new SqlCommand(_sqlStatement, (SqlConnection)connection);     // Need to Cast (SqlConnection) for connection

            connection = GetConnection();
            command = GetCommand(_sqlStatement);

            try
            {
                connection.Open();

                IDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    allAccounts.Add(new Accounts()
                    {
                        id = int.Parse(reader["id"].ToString()),    // To fix errors, make sure to cast/convert (ToString)
                        firstName = reader["firstName"].ToString(),
                        lastName = reader["lastName"].ToString()
                    });
                }

            }

            catch (SqlException exception)
            {
                //Log exception
                return allAccounts;
            }

            finally
            {
                connection.Close();
            }

            return allAccounts;
        }


        public void AddNewAccount(Accounts accountToAdd)
        {
            string _sqlStatement = 
                "INSERT INTO Accounts(id, firstName, lastName) VALUES(@id, @firstName, @lastName)";

            // IDbConnection connection = new SqlConnection(_connectionString);

            // IDbCommand command = new SqlCommand(_sqlStatement, (SqlConnection)connection);

            // REFACTORED TO BELOW TO REDUCE CODE VOLUME AND REPETITION

            connection = GetConnection();
            command = GetCommand(_sqlStatement);

            IDataParameter paramID =
                new SqlParameter("@id", SqlDbType.Int, 25);
            paramID.Value = accountToAdd.id;
            command.Parameters.Add(paramID);

            IDataParameter paramFName =
                 new SqlParameter("@firstName", SqlDbType.VarChar, 255);
            paramFName.Value = accountToAdd.firstName;
            command.Parameters.Add(paramFName);

            IDataParameter paramLName =
                new SqlParameter("@lastName", SqlDbType.VarChar, 255);
            paramLName.Value = accountToAdd.lastName;
            command.Parameters.Add(paramLName);

            try
            {
                connection.Open();
                command.ExecuteNonQuery();
            }

            catch (SqlException exception)
            {
                throw;
            }

            finally
            {
                connection.Close();
            }


        }


        public void UpdateAccount(int accountToUpdateID, Accounts newAccount)
        {
            string _sqlStatement =
                "UPDATE Accounts SET firstName = @firstName, lastName = @lastName WHERE id = @id";

            connection = GetConnection();
            command = GetCommand(_sqlStatement);

            IDataParameter paramFName = new SqlParameter("@firstName", SqlDbType.VarChar, 255);
            paramFName.Value = newAccount.firstName;
            command.Parameters.Add(paramFName);

            IDataParameter paramLName = new SqlParameter("@lastName", SqlDbType.VarChar, 255);
            paramLName.Value = newAccount.lastName;
            command.Parameters.Add(paramLName);

            IDataParameter paramID = new SqlParameter("@id", SqlDbType.Int, 25);
            paramID.Value = accountToUpdateID;
            command.Parameters.Add(paramID);

            try
            {
                connection.Open();
                command.ExecuteNonQuery();
            }

            catch (SqlException exception)
            {
                throw;
            }

            finally
            {
                connection.Close();
            }
        }


        public void RemoveAccount(int accountToRemoveID)
        {
            string _sqlStatement =
                "DELETE FROM Accounts WHERE id = @id";

            connection = GetConnection();
            command = GetCommand(_sqlStatement);

            IDataParameter paramID = new SqlParameter("@id", SqlDbType.Int, 25);
            paramID.Value = accountToRemoveID;
            command.Parameters.Add(paramID);

            try
            {
                connection.Open();
                command.ExecuteNonQuery();
            }

            catch (SqlException exception)
            {
                throw;
            }

            finally
            {
                connection.Close();
            }
        }

        private IDbConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }

        private IDbCommand GetCommand(string _sqlStatement)
        {
            return new SqlCommand(_sqlStatement, (SqlConnection)connection);
        }
    }
}
