namespace Shiptech.Application.Dtos;

public class AssortmentDictionaryDto
{
    public Guid Id { get; set; }
    public string Number { get; set; }
    public string Name { get; set; }
    public string Distinguishing { get; set; }
    public string Unit { get; set; }
    public double? Amount { get; set; }
    public double? Weight { get; set; }
    public string? Material { get; set; }
    public string? Kind { get; set; }
    public string? DN1 { get; set; }
    public string? DN2 { get; set; }
    public double? Length { get; set; }
    public string RO { get; set; }
    public string? Comment { get; set; }
}