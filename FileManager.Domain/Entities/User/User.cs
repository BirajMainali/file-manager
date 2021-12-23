using Base.Entities.Interfaces;
using FileManager.Domain.Entities.Interfaces;

namespace FileManager.Domain.Entities.User
{
    public class User : GenericModel, ISoftDelete
    {
        public long Id { get; set; }
        public string Name { get; protected set; }
        public string Gender { get; protected set; }
        public string Email { get; protected set; }
        public string Password { get; protected set; }
        public string Address { get; protected set; }
        public string Phone { get; protected set; }
        public virtual Organization Organization { get; protected set; }
        public long OrganizationId { get; set; }

        public User()
        {
        }

        public User(Organization organization, string name, string gender, string email, string password, string address, string phone)
        {
            Organization = organization;
            Copy(name, gender, email, password, address, phone);
        }

        public void Update(string name, string gender, string email, string password, string address, string phone)
            => Copy(name, gender, email, password, address, phone);

        private void Copy(string name, string gender, string email, string password, string address, string phone)
        {
            Name = name;
            Gender = gender;
            Email = email;
            Password = password;
            Address = address;
            Phone = phone;
        }
    }
}