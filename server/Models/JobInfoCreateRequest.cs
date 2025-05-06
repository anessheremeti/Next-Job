using System;
using System.ComponentModel.DataAnnotations;

public class JobInfoCreateRequest
{
    [Required]
    [MaxLength(255)]
    public string JobTitle { get; set; } = string.Empty;

    [Required]
    [Range(1, int.MaxValue)]
    public int Vacancies { get; set; }

    [Required]
    public int JobTypeId { get; set; }

    public string? JobTag { get; set; }

    public string? JobCategory { get; set; }

    [Required]
    public int BudgetTypeId { get; set; }

    [Range(0, double.MaxValue)]
    public decimal? Budget { get; set; }

    [Required]
    public int ExperienceLevelId { get; set; }

    [Required]
    public DateTime Deadline { get; set; }

    [Required]
    public string JobDescription { get; set; } = string.Empty;
}
