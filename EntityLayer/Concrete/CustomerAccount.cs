using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete;

public class CustomerAccount
{
    [Key]
    public int CustomerAccountId { get; set; }
    public string CustomerAccountNumber { get; set; }
    public string CustomerAccountCurrency { get; set; }
    public decimal CustomerAccountBalance { get; set; }
    public string CustomerAccountBankBranch { get; set; }

    public int AppUserId { get; set; }
    public AppUser AppUser { get; set; }
}