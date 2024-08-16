using System.ComponentModel.DataAnnotations;

namespace Demo.Model;

public class QueryCondition
{
    public string? Search { get; set; }

    public string? OrderBy { get; set; }

    public bool IsDesc { get; set; }

    [Range(1, 1000, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
    public int PageIndex { get; set; } = 1;

    [Range(1, 100, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
    public int PageSize { get; set; } = 20;
}