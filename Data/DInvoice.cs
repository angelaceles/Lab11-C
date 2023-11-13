using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace Data
{
    public class DInvoice
    {
        public static string connectionString = "Data Source=DESKTOP-9DD72M7;Initial Catalog=FacturaDB;User ID=userTecsup;Password=12345678";
        public List<Invoice> Get()
        {
            List<Invoice> result = new List<Invoice>();
         
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "ListarInvoices";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    
                    command.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Invoice invoice = new Invoice
                                {
                                    InvoiceId = reader.GetInt32(reader.GetOrdinal("Invoice_Id")),
                                    CustomerId = reader.GetInt32(reader.GetOrdinal("Customer_Id")),
                                    Date = reader.GetDateTime(reader.GetOrdinal("Date")),
                                    Total = reader.GetDecimal(reader.GetOrdinal("Total")),
                                    Active = reader.GetBoolean(reader.GetOrdinal("Active"))
                                };
                                result.Add(invoice);
                            }
                        }
                    }
                }
                connection.Close();
            }
            return result;
        }
        public void InsertarInvoices(Invoice invoice)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "InsertarInvoices";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@customer_id", SqlDbType.Int));
                    command.Parameters["@customer_id"].Value = invoice.CustomerId;
                    command.Parameters.Add(new SqlParameter("@date", SqlDbType.Date));
                    command.Parameters["@date"].Value = invoice.Date;
                    command.Parameters.Add(new SqlParameter("@total", SqlDbType.Decimal));
                    command.Parameters["@total"].Value = invoice.Total;

                    command.ExecuteNonQuery();
                }
            }
        }
        public void EliminarInvoices(Invoice invoice)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "EliminarInvoices";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Invoice_Id", invoice.InvoiceId);

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
