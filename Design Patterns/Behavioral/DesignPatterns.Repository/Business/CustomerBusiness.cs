using DesignPatterns.Repository.DataAccess.Interfaces;
using DesignPatterns.Repository.DBContexts.DBEntities;


namespace DesignPatterns.Repository.Business
{
    public  class CustomerBusiness
    {
        private readonly ICustomerRepositoy customerRepository;

        public CustomerBusiness(ICustomerRepositoy customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public Customer CreateCustomer(Customer customer)
        {
            return customerRepository.Add(customer);
        }

        public Customer GetOldestCustomer()
        {
            return customerRepository.GetOldestCustomer();
        }
    }
}
