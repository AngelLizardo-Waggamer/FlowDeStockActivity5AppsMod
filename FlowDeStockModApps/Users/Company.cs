/**
 * Company.cs
 * Model of the Company Entity.
 */

namespace FlowDeStockModApps.Users
{
    internal class Company(int idCompany, string name)
    {
        // Attributes
        public int IDCompany { get; } = idCompany;
        public string Name { get; set; } = name;

        // Methods

        // CreateCompany is already defined because it is the constructor

        // DeleteCompany is not defined because it is not necessary in this context

        // AddMember is defined in the user class, not here.

        // RemoveMember is defined in the user class, not here.
    }
}
