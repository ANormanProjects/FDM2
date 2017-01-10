using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADODemo
{
    // public interface IAccountRepositoryDisconnected : IAccountRepository    // Implement original interface for same methods.


    //{     NO need to type this as it is exactly the same as IAccountRepository...
    //    List<Accounts> GetAllAccounts();

    //    void UpdateAccount(int accountToUpdateID, Accounts newAccount);
    //}



    public class AccountRepositoryDisconnected : IAccountRepository
    {
        string _connectionString;

        IDbConnection connection;

        IDbCommand command;

        IDbCommand selectCommand;

        public AccountRepositoryDisconnected(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Accounts> GetAllAccounts()      // All is similar to IAccountRepository, but two new things below.
        {
            List<Accounts> allAccounts = new List<Accounts>();

            string _sqlStatement =
                "SELECT id, firstName, lastName FROM Accounts";

            DataSet dataSet = new DataSet();                        // New DataSet for holding data we download
            IDbDataAdapter dataAdapter = new SqlDataAdapter();      // Convert from database to our dataset

            IDbConnection connection = new SqlConnection(_connectionString);
            IDbCommand command = new SqlCommand(_sqlStatement, (SqlConnection)connection);

            dataAdapter.SelectCommand = command;
            try
            {
                connection.Open();
                dataAdapter.Fill(dataSet);          // Put results into the DataSet
            }

            catch (SqlException exception)
            {
                throw;
            }

            finally
            {
                connection.Close();
            }


            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                allAccounts.Add(new Accounts()
                {
                    id = int.Parse(row["id"].ToString()),
                    firstName = row["firstName"].ToString(),
                    lastName = row["lastName"].ToString()
                });
            }

            return allAccounts;
        }


        public void AddNewAccount(Accounts accountToAdd)
        {
            throw new NotImplementedException();
        }

        public void UpdateAccount(int accountToUpdateID, Accounts newAccount)
        {
            string _sqlSelectStatement =
                "SELECT id, firstName, lastName FROM Accounts";

            string _sqlStatement =
                "UPDATE Accounts SET firstName = @firstName, lastName = @lastName WHERE id = @id";

            DataSet dataSet = new DataSet();
            IDbDataAdapter dataAdapter = new SqlDataAdapter();

            IDbConnection connection = new SqlConnection(_connectionString);
            IDbCommand selectCommand = new SqlCommand(_sqlSelectStatement, (SqlConnection)connection);

            dataAdapter.SelectCommand = selectCommand;

            try
            {
                connection.Open();
                dataAdapter.Fill(dataSet);
            }
            catch (SqlException exception)
            {
                throw;
            }
            finally
            {
                connection.Close();
            }


            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                if (int.Parse(row["id"].ToString()) == accountToUpdateID)
                {
                    row["firstName"] = newAccount.firstName;
                    row["lastName"] = newAccount.lastName;
                    break;

                }
            }

            IDbCommand updateCommand =
                new SqlCommand(_sqlStatement, (SqlConnection)connection);

            IDataParameter paramFName = new SqlParameter("@firstName", SqlDbType.VarChar, 255);
            paramFName.Value = newAccount.firstName;
            command.Parameters.Add(paramFName);

            IDataParameter paramLName = new SqlParameter("@lastName", SqlDbType.VarChar, 255);
            paramLName.Value = newAccount.lastName;
            command.Parameters.Add(paramLName);

            IDataParameter paramID = new SqlParameter("@id", SqlDbType.Int, 25);
            paramID.Value = accountToUpdateID;
            command.Parameters.Add(paramID);

            dataAdapter.UpdateCommand = updateCommand;

            try
            {
                connection.Open();
                dataAdapter.Update(dataSet);
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
            throw new NotImplementedException();
        }

        private IDbConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }

        private IDbCommand GetCommand(string _sqlStatement)
        {
            return new SqlCommand(_sqlStatement, (SqlConnection)connection);
        }

        private IDbCommand GetSelectCommand(string _sqlSelectStatement)
        {
            return new SqlCommand(_sqlSelectStatement, (SqlConnection)connection);
        }


    }
}
