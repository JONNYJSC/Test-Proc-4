using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace WebEnacal.Models
{
    public class PersonaDAL
    {
        string cadena = "Server=DESKTOP-P24U9SO; Initial Catalog=bdTest-2; User ID=sa; Password=admin123; Trusted_Connection=false";

        public async Task<Persona> CreateMetodo(Persona p)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(cadena))
                {
                    SqlCommand cmd = cnn.CreateCommand();
                    cnn.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "CreatePersona";
                    cmd.Parameters.Add("@Nombre", SqlDbType.VarChar, 50).Value = p.Nombre;
                    Task<int> mcResult = cmd.ExecuteNonQueryAsync();
                    await Task.WhenAll(mcResult);
                    return p;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Persona> EditMetodo(int id, Persona p)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(cadena))
                {
                    SqlCommand cmd = cnn.CreateCommand();
                    cnn.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "EditarPersona";
                    cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id;
                    cmd.Parameters.Add("@Nombre", SqlDbType.VarChar, 50).Value = p.Nombre;
                    Task<int> mcResult = cmd.ExecuteNonQueryAsync();
                    await Task.WhenAll(mcResult);
                    return p;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<int> DeleteMetodo(int id)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(cadena))
                {
                    SqlCommand cmd = cnn.CreateCommand();
                    cnn.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "DeletePersona";
                    cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id;
                    Task<int> mcResult = cmd.ExecuteNonQueryAsync();
                    await Task.WhenAll(mcResult);
                    return id;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
