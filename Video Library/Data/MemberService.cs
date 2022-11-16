using Microsoft.Data.SqlClient;
using System.Data;

namespace Video_Library.Data
{
	public class MemberService
	{
		private string connectionString = "Data Source=DESKTOP-6Q529GM\\SQLEXPRESS;Initial Catalog=VLDB;Integrated Security=True;Encrypt=False;User ID=xyz;pwd=top$secret";
		public List<Member> GetAllMembers()
		{
			List<Member> members = new List<Member>();
			using(SqlConnection connection = new SqlConnection(connectionString))
			{
				//SqlCommand cmd = new SqlCommand("select * from members",connection);
				SqlCommand cmd = new SqlCommand("SP_GetMembers", connection);
				cmd.CommandType = CommandType.StoredProcedure;
				connection.Open();
				SqlDataReader sdr = cmd.ExecuteReader();
				while (sdr.Read())
				{
					Member mem = new Member();
					mem.MemberId = sdr.GetInt32(0);
					mem.Fname= sdr.GetString(1);
					mem.Lname= sdr.GetString(2);
					mem.Phone = sdr.GetInt32(3);
					members.Add(mem);
				}
				connection.Close();
			}
			return members;
		}
		public bool InsertMember(Member member)
		{
			bool r = false;
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				//SqlCommand cmd = new SqlCommand("insert into Members(Fname,Lname,Phone)values('"+member.Fname+"','"+member.Lname+"','"+member.Phone+"')",connection);
				SqlCommand cmd = new SqlCommand("SP_InsertMember", connection);
				SqlParameter sps = new SqlParameter
				{
					ParameterName = "@Fname",
					SqlDbType = SqlDbType.VarChar,
					Value = member.Fname,
					Direction = ParameterDirection.Input,
				};
				cmd.Parameters.Add(sps);
				cmd.Parameters.Add(new SqlParameter
				{
					ParameterName = "@Lname",
					SqlDbType = SqlDbType.VarChar,
					Value = member.Lname,
					Direction = ParameterDirection.Input,
				});
				cmd.Parameters.Add(new SqlParameter
				{
					ParameterName = "@Phone",
					SqlDbType = SqlDbType.Int,
					Value = member.Phone,
					Direction = ParameterDirection.Input,
				});
				cmd.CommandType = CommandType.StoredProcedure;
				connection.Open();
				int res = cmd.ExecuteNonQuery();
				if(res > 0)
				{
					r = true;
				}
				connection.Close();
			}
			return r;
		}
		public bool UpdateMember(Member member)
		{
			bool r = false;
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				//SqlCommand cmd = new SqlCommand("insert into Members(Fname,Lname,Phone)values('"+member.Fname+"','"+member.Lname+"','"+member.Phone+"')",connection);
				SqlCommand cmd = new SqlCommand("SP_UpdateMember", connection);
				SqlParameter sps = new SqlParameter
				{
					ParameterName = "@Fname",
					SqlDbType = SqlDbType.VarChar,
					Value = member.Fname,
					Direction = ParameterDirection.Input,
				};
				cmd.Parameters.Add(sps);
				cmd.Parameters.Add(new SqlParameter
				{
					ParameterName = "@Lname",
					SqlDbType = SqlDbType.VarChar,
					Value = member.Lname,
					Direction = ParameterDirection.Input,
				});
				cmd.Parameters.Add(new SqlParameter
				{
					ParameterName = "@memId",
					SqlDbType = SqlDbType.Int,
					Value = member.MemberId,
					Direction = ParameterDirection.Input,
				});
				cmd.Parameters.Add(new SqlParameter
				{
					ParameterName = "@Phone",
					SqlDbType = SqlDbType.Int,
					Value = member.Phone,
					Direction = ParameterDirection.Input,
				});
				cmd.CommandType = CommandType.StoredProcedure;
				connection.Open();
				int res = cmd.ExecuteNonQuery();
				if (res > 0)
				{
					r = true;
				}
				connection.Close();
			}
			return r;
		}

		public bool DeleteMember(Member member)
		{
			bool r = false;
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				//SqlCommand cmd = new SqlCommand("insert into Members(Fname,Lname,Phone)values('"+member.Fname+"','"+member.Lname+"','"+member.Phone+"')",connection);
				SqlCommand cmd = new SqlCommand("SP_DeleteMember" , connection);
	
				cmd.Parameters.Add(new SqlParameter
				{
					ParameterName = "@memId",
					SqlDbType = SqlDbType.Int,
					Value = member.MemberId,
					Direction = ParameterDirection.Input,
				});

				cmd.CommandType = CommandType.StoredProcedure;
				connection.Open();
				int res = cmd.ExecuteNonQuery();
				if (res > 0)
				{
					r = true;
				}
				connection.Close();
			}
			return r;
		}
	}
}
