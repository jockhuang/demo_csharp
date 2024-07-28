using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Demo.Model;
[Index(nameof(Name),Name="idx_product_name",IsUnique =true)]
 public class Product{
    /// <summary>
    /// product id
    /// </summary>
    public int Id{ get; set; }

    /// <summary>
    /// product name
    /// </summary>
    [Required]
    public String Name{ get; set; }="";

    /// <summary>
    /// product description
    /// </summary>
    public String? Description{ get; set; }

    /// <summary>
    /// product image url
    /// </summary>
    public String? ImageURL{ get; set; }

    /// <summary>
    /// product price 
    /// </summary>
    public double? Price{ get; set; }

    /// <summary>
    /// the flag of the product is released
    /// </summary>
    public Boolean IsRelease{ get; set; } = false;

    /// <summary>
    /// the create datetime of product
    /// </summary>
    public DateTime? CreateDate{ get; set; } = DateTime.Now;

    /// <summary>
    /// the update datetime of product
    /// </summary>
    public DateTime? UpdateDate{ get; set; } = DateTime.Now;

}

