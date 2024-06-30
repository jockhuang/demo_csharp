using Microsoft.EntityFrameworkCore;

namespace Demo.Model;
[Index(nameof(Email),Name="idx_email",IsUnique =true)]
public class Maillist{
     /// <summary>
     /// id
     /// </summary>
    public int Id{ get; set; }
   /// <summary>
   /// email address
   /// </summary>
    public String? Email{ get; set; }
    /// <summary>
    /// the record create datetime
    /// </summary>
    public DateTime? CreateDate{ get; set; }
}