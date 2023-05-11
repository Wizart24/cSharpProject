namespace ProjectAPI.Models.Customers
{
    public class CreateCustomerModel : CustomerBaseModel
    {
        public CreateCustomerModel(
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
        }
    }
}
