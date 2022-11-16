using System.Data;
using Microsoft.Data.SqlClient;

namespace Video_Library.Data
{
	public class VideoService
	{
		private string connectionString = "Data Source=DESKTOP-6Q529GM\\SQLEXPRESS;Initial Catalog=VLDB;Integrated Security=True;Encrypt=False;User ID=xyz;pwd=top$secret";
		public List<Video> GetAllVideos()
		{
			List<Video> videos = new List<Video>();
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				SqlCommand cmd = new SqlCommand("SP_GetVideos", connection);
				cmd.CommandType = CommandType.StoredProcedure;
				connection.Open();
				SqlDataReader sdr = cmd.ExecuteReader();
				while (sdr.Read())
				{
					Video video = new Video();
					video.VId = sdr.GetInt32(0);
					video.BId = sdr.GetInt32(1);
					video.Title = sdr.GetString(2);
					videos.Add(video);
				}
				connection.Close();
			}
			return videos;
		}
	}


}
