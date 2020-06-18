using System;

namespace testexperticket.Core.Messages
{
    public class RequestedUser
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public DateTime BirthDate { get; set; }

        public RequestedUser(int id, string name, DateTime birthDate)
        {
            this.Id = id;
            this.Name = name;
            this.BirthDate = birthDate;
        }
    }
}