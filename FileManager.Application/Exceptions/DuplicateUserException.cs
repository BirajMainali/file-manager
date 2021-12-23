namespace FileManager.Application.Exceptions
{
    public class DuplicateUserException : Exception
    {
        public DuplicateUserException(string message = "email must be unique") : base(message)
        {
        }
    }
}