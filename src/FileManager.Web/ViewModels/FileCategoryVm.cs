using System.ComponentModel;

namespace FileManager.Web.ViewModels;

public class FileCategoryVm
{
    [DisplayName("Name")]
    public string Name { get; set; }
    [DisplayName("Description")]
    public string Description { get; set; }
    [DisplayName("Priority")]
    public long Priority { get; set; }
    
}