using imobiSystem.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace imobiSystem.Application.Interfaces
{
    public interface ICustomerManager
    {
        void Add(CustomerDto customerDto);
        void Update(CustomerDto customerDto);
        void Remove(CustomerDto customerDto);
        IEnumerable<CustomerDto> GetAll();
        CustomerDto GetById(int id);
    }
}
