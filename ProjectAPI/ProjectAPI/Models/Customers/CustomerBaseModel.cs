namespace ProjectAPI.Models.Customers
{
    public class CustomerBaseModel
    {
        public CustomerBaseModel(
            string name,
            string password,
            string email,
            int phoneNumber,
            string address,
            string role)
        {
            Name = name;
            Password = password;
            Email = email;
            PhoneNumber = phoneNumber;
            Address = address;
            Role = role;
        }

        public string Name { get; }
        public string Password { get; }
        public string Email { get; }
        public int PhoneNumber { get; }
        public string Address { get; }
        public string Role { get; set; }
    }
}
