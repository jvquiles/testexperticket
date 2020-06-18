using System;
using MediatR;

namespace testexperticket.Core.Messages
{
    public class UpdateUser : IRequest<UpdatedUser>
    {
        public int Id { get; }

        public string Name { get; set; }

        public DateTime BirthDate { get; set; }
        
        public UpdateUser(int id, string name, DateTime birthDate)
        {
            this.Id = id;
            this.Name = name;
            this.BirthDate = birthDate;
        }
    }
}