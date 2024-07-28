using Microsoft.EntityFrameworkCore;

namespace Demo.Model;
[Index(nameof(Email),Name="idx_email",IsUnique =true)]
public class MailList{
     /// <summary>
     /// id
     /// </summary>
    public int Id{ get; set; }
   /// <summary>
   /// email address
   /// </summary>
    public String? Email{ get; set; }

     /// <summary>
    ///  description
    /// </summary>
    public String? Description{ get; set; }

    /// <summary>
    /// the record create date time
    /// </summary>
    public DateTime? CreateDate{ get; set; }
}