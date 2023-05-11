namespace ProjectAPI.Models.Customers
{
    public class UpdateCustomerModel : CustomerModel
    {
        public UpdateCustomerModel(
            int id,
            string name,
            string password,
            string email,
            int phoneNumber,
            string address,
            string role)
            : base(
                  id,
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
