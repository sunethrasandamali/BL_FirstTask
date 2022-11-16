//using Microsoft.EntityFrameworkCore.Storage;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;

namespace Video_Library.Data
{
    public class Member
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int MemberId { get; set; } = 0;
        public String Fname { get; set; } = "";
        public String Lname { get; set; } = "";
        public int Phone  { get; set; } = 0;
    }
}
