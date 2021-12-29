using FileManager.Domain.Entities.Interfaces;

namespace FileManager.Domain.Entities;

public class Organization : BaseEntity, ISoftDelete
{
    protected Organization()
    {
    }

    public Organization(string orgName, string address, string phone, string email, string fax, string url,
        string description, string? logo)
    {
        Copy(orgName, address, phone, email, fax, url, description, logo);
    }

    public string OrgName { get; protected set; }
    public string Address { get; protected set; }
    public string Phone { get; protected set; }
    public string Email { get; protected set; }
    public string? Fax { get; protected set; }
    public string? Url { get; protected set; }
    public string? Description { get; protected set; }
    public string? Logo { get; protected set; }

    public void Update(string orgName, string address, string phone, string email, string fax, string url,
        string description, string? logo)
    {
        Copy(orgName, address, phone, email, fax, url, description, logo);
    }

    private void Copy(string orgName, string address, string phone, string email, string fax, string url,
        string description, string? logo)
    {
        OrgName = orgName;
        Address = address;
        Phone = phone;
        Email = email;
        Fax = fax;
        Url = url;
        Description = description;
        Logo = logo;
    }
}