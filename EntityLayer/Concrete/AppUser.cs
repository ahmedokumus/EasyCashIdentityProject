using Microsoft.AspNetCore.Identity;

namespace EntityLayer.Concrete;

public class AppUser : IdentityUser<int>
{
    public string CustomerName { get; set; }
    public string CustomerSurname { get; set; }
    public string CustomerDistrict { get; set; }
    public string CustomerCity { get; set; }
    public string CustomerImageUrl { get; set; }
    public string ConfirmCode { get; set; }

    public List<CustomerAccount> CustomerAccounts { get; set; }
}