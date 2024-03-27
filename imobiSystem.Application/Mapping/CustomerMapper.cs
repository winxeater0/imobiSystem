using imobiSystem.Application.Dtos;
using imobiSystem.Application.Interfaces.Mapping;
using imobiSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace imobiSystem.Application.Mapping
{
    public class CustomerMapper : ICustomerMapper
    {
        public Customer MapDtoToEntity(CustomerDto customerDto)
        {
            return new Customer()
            {

            };
        }

        public CustomerDto MapEntityToDto(Customer customer)
        {
            return new CustomerDto()
            {

            };
        }

        public IEnumerable<CustomerDto> MapListCustomerDto(IEnumerable<Customer> customers)
        {
            return customers.Select(c => new CustomerDto
            {
                //
            });
        }
    }
}
