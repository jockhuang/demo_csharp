using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Demo.Model;

[Index(nameof(Name), Name = "idx_product_name", IsUnique = true)]
public class Product
{
    /// <summary>
    ///     product id
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    ///     product name
    /// </summary>
    [Required]
    public string Name { get; set; } = "";

    /// <summary>
    ///     product description
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    ///     product image url
    /// </summary>
    public string? ImageURL { get; set; }

    /// <summary>
    ///     product price
    /// </summary>
    public double? Price { get; set; }

    /// <summary>
    ///     the flag of the product is released
    /// </summary>
    public bool IsRelease { get; set; } = false;

    /// <summary>
    ///     the create datetime of product
    /// </summary>
    public DateTime? CreateDate { get; set; }

    /// <summary>
    ///     the update datetime of product
    /// </summary>
    public DateTime? UpdateDate { get; set; }
}