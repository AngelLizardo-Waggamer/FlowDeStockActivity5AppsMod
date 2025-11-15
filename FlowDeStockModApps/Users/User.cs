/**
 * User.cs
 * Model of the User Entity.
 */

namespace FlowDeStockModApps.Users
{
    internal class User(int idUser, string name, string mail, string password, Company company, Roles role)
    {
        // Attributes
        public int IDUser { get; } = idUser;
        public string Name { get; set; } = name;
        public string Mail { get; set; } = mail;
        public string Password { get; set; } = password;
        public int IDCompany { get; set; } = company.IDCompany;
        public Roles Role { get; set; } = role;

        // Methods

        // LogIn is not defined because it is not necessary in this context

        // LogOut is not defined because it is not necessary in this context

        // ChangePassword is not defined because it is not necessary in this context

        // SignIn is not defined because it is not necessary in this context

        // ChangeName is not defined because it is not necessary in this context

        // ChangeRole is not defined because it is not necessary in this context
    }
}
