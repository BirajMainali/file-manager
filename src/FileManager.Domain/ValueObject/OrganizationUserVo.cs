using FileManager.Domain.Dto;

namespace FileManager.Domain.ValueObject
{
    public class OrganizationUserVo : OrganizationDto
    {
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Password { get; set; }
    }
}