namespace Video_Library.Data
{
	public class BorrowData
	{
		public int BId { get; set; } = 0;
		public int MemberId { get; set; } = 0;
		public DateTime BDate { get; set; }
		public DateTime RDate { get; set; }
	}
}
