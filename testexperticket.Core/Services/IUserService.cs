using System.Threading.Tasks;
using testexperticket.Core.Messages;

namespace testexperticket.Core.Services
{
    public interface IUserService
    {
        Task<CreatedUser> Add(CreateUser user);

        Task<RequestedUser> Get(RequestUser request);

        Task<RequestedUsers> Get(RequestUsers request);

        Task<UpdatedUser> Update(UpdateUser request);

        Task<DeletedUser> Delete(DeleteUser request);
    }
}