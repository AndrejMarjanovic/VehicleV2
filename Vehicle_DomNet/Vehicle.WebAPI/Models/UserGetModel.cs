
namespace Vehicle.WebAPI.Models
{
    public class UserGetModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Username { get; set; }
        public int RoleId { get; set; }
        public RoleGetModel Role { get; set; }

    }
}
