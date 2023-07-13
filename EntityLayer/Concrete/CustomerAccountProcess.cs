using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete;

public class CustomerAccountProcess
{
    [Key]
    public int CustomerAccountProcessId { get; set; }
    public int CustomerAccountProcessType { get; set; }
    public decimal CustomerAccountProcessAmount { get; set; }
    public DateTime CustomerAccountProcessDate { get; set; }
}