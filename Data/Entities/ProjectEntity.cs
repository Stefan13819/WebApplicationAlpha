

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Data.Entities;

public class ProjectEntity
{
    [Key]
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string ProjectName { get; set; } = null!;
    public string ClientName { get; set; } = null!;
    public string? Description { get; set; } 

    [Column(TypeName = "date")]
    public DateTime StartDate { get; set; }
    [Column(TypeName = "date")]
    public DateTime? EndDate { get; set; }
    public decimal? Budget { get; set; }

}
