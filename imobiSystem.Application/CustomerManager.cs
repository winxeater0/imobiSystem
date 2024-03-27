using imobiSystem.Application.Dtos;
using imobiSystem.Application.Interfaces;
using imobiSystem.Application.Interfaces.Mapping;
using imobiSystem.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace imobiSystem.Application
{
    public class CustomerManager : ICustomerManager
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ICustomerMapper _customerMapper;

        public CustomerManager(ICustomerRepository customerRepository, ICustomerMapper customerMapper)
        {
            _customerRepository = customerRepository;
            _customerMapper = customerMapper;
        }

        public void Add(CustomerDto customerDto)
        {
            var customer = _customerMapper.MapDtoToEntity(customerDto);
            _customerRepository.Add(customer);
        }

        public IEnumerable<CustomerDto> GetAll()
        {
            var customers = _customerRepository.GetAll();
            return _customerMapper.MapListCustomerDto(customers);
        }

        public CustomerDto GetById(int id)
        {
            var customer = _customerRepository.GetById(id);
            return _customerMapper.MapEntityToDto(customer);
        }

        public void Remove(CustomerDto customerDto)
        {
            var customer = _customerMapper.MapDtoToEntity(customerDto);
            _customerRepository.Delete(customer);
        }

        public void Update(CustomerDto customerDto)
        {
            var customer = _customerMapper.MapDtoToEntity(customerDto);
            _customerRepository.Update(customer);
        }
    }
}
