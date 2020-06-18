using MediatR;

namespace testexperticket.Core.Messages
{
    public class DeleteUser : IRequest<DeletedUser>
    {
        public int Id { get; set; }

        public DeleteUser(int id)
        {
            this.Id = id;
        }
    }
}