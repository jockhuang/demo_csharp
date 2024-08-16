using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Demo.Model;

[Index(nameof(Email), Name = "idx_email", IsUnique = true)]
public class MailList
{
 /// <summary>
 ///     id
 /// </summary>
 public int Id { get; set; }

 /// <summary>
 ///     email address
 /// </summary>
 [Required]
    public string Email { get; set; } = "";

 /// <summary>
 ///     description
 /// </summary>
 public string? Description { get; set; }

 /// <summary>
 ///     the record create date time
 /// </summary>
 public DateTime? CreateDate { get; set; }
}