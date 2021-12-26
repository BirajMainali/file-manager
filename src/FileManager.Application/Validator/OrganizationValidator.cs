using System.Data;
using FileManager.Application.Repository.Interfaces;
using FileManager.Application.Validator.Interfaces;

namespace FileManager.Application.Validator;

public class OrganizationValidator : IOrganizationValidator
{
    private readonly IOrganizationRepository _organizationRepository;

    public OrganizationValidator(IOrganizationRepository organizationRepository)
    {
        _organizationRepository = organizationRepository;
    }

    public async Task EnsureUniqueOrg(string email, long? id = null)
    {
        if (await _organizationRepository.IsOrganizationUsed(email, id))
            throw new DuplicateNameException("Organization Email is in use");
    }
}