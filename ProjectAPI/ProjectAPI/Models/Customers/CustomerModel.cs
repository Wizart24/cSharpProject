namespace ProjectAPI.Models.Customers
{
    public class CustomerModel : CustomerBaseModel
    {
        public CustomerModel(
            int id,
            string name,
            string password,
            string email,
            int phoneNumber,
            string address,
            string role)
            : base(
                  name,
                  password,
                  email,
                  phoneNumber,
                  address,
                  role)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
