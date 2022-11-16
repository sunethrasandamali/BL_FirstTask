using Microsoft.Data.SqlClient;
using System.Data;

namespace Video_Library.Data
{
	public class BorrowDataService
	{
		private string connectionString = "Data Source=DESKTOP-6Q529GM\\SQLEXPRESS;Initial Catalog=VLDB;Integrated Security=True;Encrypt=False;User ID=xyz;pwd=top$secret";
		public List<BorrowData> GetAllBDetails()
		{
			List<BorrowData> borrows = new List<BorrowData>();
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				SqlCommand cmd = new SqlCommand("SP_GetBorrowData", connection);
				cmd.CommandType = CommandType.StoredProcedure;
				connection.Open();
				SqlDataReader sdr = cmd.ExecuteReader();
				while (sdr.Read())
				{
					BorrowData borrowdata = new BorrowData();
					borrowdata.BId = sdr.GetInt32(0);
					borrowdata.MemberId = sdr.GetInt32(1);
					borrowdata.BDate = sdr.GetDateTime(2);
					borrowdata.RDate = sdr.GetDateTime(3) ;
					borrows.Add(borrowdata);
				}
				connection.Close();
			}
			return borrows;
		}
	}
}
