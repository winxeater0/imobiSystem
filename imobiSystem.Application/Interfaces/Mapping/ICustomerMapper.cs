using imobiSystem.Application.Dtos;
using imobiSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace imobiSystem.Application.Interfaces.Mapping
{
    public interface ICustomerMapper
    {
        Customer MapDtoToEntity(CustomerDto customerDto);
        IEnumerable<CustomerDto> MapListCustomerDto(IEnumerable<Customer> customers);
        CustomerDto MapEntityToDto(Customer customer);
    }
}
