namespace AluguelRV.Core.Models;
public class Config
{
    public int Id { get; set; }
    public string Key { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Value { get; set; } = null!;
}