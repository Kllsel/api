using Businesslogic.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Businesslogic.Interfaces
{
    public interface IOrdersService
    {
        Task<IEnumerable<OrderDto>> GetAllByUser(string userId);
        Task Create(string userId);
    }
}