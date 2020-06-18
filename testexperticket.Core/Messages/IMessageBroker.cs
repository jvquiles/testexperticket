using MediatR;

namespace testexperticket.Core.Messages
{
    public interface IMessageBroker:
        IRequestHandler<CreateUser, CreatedUser>,
        IRequestHandler<RequestUser, RequestedUser>,
        IRequestHandler<RequestUsers, RequestedUsers>,
        IRequestHandler<UpdateUser, UpdatedUser>,
        IRequestHandler<DeleteUser, DeletedUser>
    {         
    }
}