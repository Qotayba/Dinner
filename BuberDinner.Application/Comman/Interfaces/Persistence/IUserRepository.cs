using BuberDinner.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuberDinner.Application.Comman.Interfaces.Persistence
{
    public interface IUserRepository
    {
        User? getUserByEmail(string email);
        void Add(User user);
    }
}
