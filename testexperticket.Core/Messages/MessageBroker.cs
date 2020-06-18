using System;
using System.Threading;
using System.Threading.Tasks;
using testexperticket.Core.Services;

namespace testexperticket.Core.Messages
{
    public sealed class MessageBroker : IMessageBroker
    {
        public IUserService UserService { get; }

        public MessageBroker(IUserService userService)
        {
            this.UserService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        public async Task<CreatedUser> Handle(CreateUser request, CancellationToken cancellationToken)
        {
            CreatedUser user = await this.UserService.Add(request);
            return user;
        }

        public async Task<RequestedUser> Handle(RequestUser request, CancellationToken cancellationToken)
        {
            RequestedUser user = await this.UserService.Get(request);
            return user;
        }

        public async Task<RequestedUsers> Handle(RequestUsers request, CancellationToken cancellationToken)
        {
            RequestedUsers users = await this.UserService.Get(request);
            return users;

        }

        public async Task<UpdatedUser> Handle(UpdateUser request, CancellationToken cancellationToken)
        {
            UpdatedUser user = await this.UserService.Update(request);
            return user;
        }

        public async Task<DeletedUser> Handle(DeleteUser request, CancellationToken cancellationToken)
        {
            DeletedUser user = await this.UserService.Delete(request);
            return user;
        }
    }
}