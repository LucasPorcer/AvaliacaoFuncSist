using Dapper;
using FI.AtividadeEntrevista.DML;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FI.WebAtividadeEntrevista.InfraData.Repositories.SQL
{
    public class BeneficiarioSQLRepository
    {
        private readonly string _connectionString;

        public BeneficiarioSQLRepository(string connetionString)
        {
            _connectionString = connetionString;
        }

        public IEnumerable<Beneficiario> GetBeneficiariosFromClientId(int clientId)
        {
            try
            {
                IEnumerable<Beneficiario> rt = null;

                using (var dbConn = new SqlConnection(_connectionString))
                {
                    dbConn.Open();

                    var strQuery = @"SELECT ID,
                                            CPF,
                                            NOME,
                                            IDCLIENTE                                            
                                           FROM BENEFICIARIOS (NOLOCK) WHERE IDCLIENTE = @IDCLIENTE";

                    rt = dbConn.Query<Beneficiario>(strQuery, new { IDCLIENTE = clientId });

                    dbConn.Close();
                    dbConn.Dispose();

                }
                return rt;
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<Beneficiario> AddBeneficiario(Beneficiario obj)
        {
            try
            {
                IEnumerable<Beneficiario> rt = null;

                using (var dbConn = new SqlConnection(_connectionString))
                {
                    dbConn.Open();

                    using (var transaction = dbConn.BeginTransaction())
                    {
                        dbConn.Execute("INSERT INTO BENEFICIARIOS VALUES (@CPF, @NOME, @IDCLIENTE);", new { CPF = obj.Cpf, NOME = obj.Nome, IDCLIENTE = obj.IDCliente }, transaction);

                        transaction.Commit();
                    }

                    dbConn.Close();
                    dbConn.Dispose();

                }
                return rt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Beneficiario GetBeneficiario(int beneficiarioId)
        {
            try
            {
                Beneficiario rt = null;

                using (var dbConn = new SqlConnection(_connectionString))
                {
                    dbConn.Open();

                    var strQuery = @"SELECT ID,
                                            CPF,
                                            NOME,
                                            IDCLIENTE                                            
                                           FROM BENEFICIARIOS (NOLOCK) WHERE ID = @IDBENEFICIARIO";

                    rt = dbConn.Query<Beneficiario>(strQuery, new { IDBENEFICIARIO = beneficiarioId }).AsList().FirstOrDefault();

                    dbConn.Close();
                    dbConn.Dispose();

                }
                return rt;
            }
            catch
            {
                return null;
            }
        }

        public bool DeleteBeneficiario(int beneficiarioId)
        {
            try
            {
                Beneficiario rt = null;

                using (var dbConn = new SqlConnection(_connectionString))
                {
                    dbConn.Open();

                    using (var transaction = dbConn.BeginTransaction())
                    {
                        var strQuery = @"DELETE FROM BENEFICIARIOS WHERE ID = @IDBENEFICIARIO";

                        rt = dbConn.Query<Beneficiario>(strQuery, new { IDBENEFICIARIO = beneficiarioId }, transaction).AsList().FirstOrDefault();

                        transaction.Commit();
                    }

                    dbConn.Close();
                    dbConn.Dispose();

                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool ValidateIfExists(string cpf, long beneficiarioId)
        {
            try
            {
                using (var dbConn = new SqlConnection(_connectionString))
                {
                    dbConn.Open();

                    var strQuery = @"SELECT * FROM BENEFICIARIOS (NOLOCK) WHERE IDCLIENTE = @IDBENEFICIARIO AND Cpf = @CPF";

                    var rt = dbConn.Query<Beneficiario>(strQuery, new { IDBENEFICIARIO = beneficiarioId, CPF= cpf }).First();

                    dbConn.Close();
                    dbConn.Dispose();

                    if (rt != null)
                        return true;
                    else
                        return false;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
