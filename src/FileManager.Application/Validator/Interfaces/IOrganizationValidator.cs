namespace FileManager.Application.Validator.Interfaces;

public interface IOrganizationValidator
{
    Task EnsureUniqueOrg(string email, long? id = null);
}