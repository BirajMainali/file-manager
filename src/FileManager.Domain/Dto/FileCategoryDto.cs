using FileManager.Domain.Entities;

namespace FileManager.Domain.Dto
{
    public record FileCategoryDto(Organization Organization, string Name, string Description, long Priority);
    
}