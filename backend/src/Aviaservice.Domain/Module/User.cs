using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Aviaservice.Domain.Module
{
    public class User
    {
        public Guid Id { get; set; }
        public string PasswordHash { get; set; } = default!;
        public string Name { get; set; } = default!;
        public string SurName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public decimal Balance { get; set; } = default!;
        public Enum Role { get; set; } = default!;

    }
}
