namespace Autenticazione.Shared
{
    public class UserDto
    {
        public string guid { get; set; }
        public string username { get; set; }

        public UserDto() { }

        public UserDto(string guid, string username)
        {
            this.username = username;
            this.guid = guid;
        }
    }
}
