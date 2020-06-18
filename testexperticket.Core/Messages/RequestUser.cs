using MediatR;

namespace testexperticket.Core.Messages
{
    public class RequestUser : IRequest<RequestedUser>
    {
        public int Id { get; }

        public RequestUser(int id)
        {
            this.Id = id;
        }
    }
}