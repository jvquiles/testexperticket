using System;
using MediatR;

namespace testexperticket.Core.Messages
{
    public sealed class CreateUser : IRequest<CreatedUser>
    {
        public string Name { get; set; }

        public DateTime BirthDate { get; set; }
    }
}