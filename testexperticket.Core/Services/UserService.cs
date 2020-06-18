using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using testexperticket.Core.Messages;
using testexperticket.Persistence.Repositories.User;

namespace testexperticket.Core.Services
{
    public class UserService : IUserService
    {
        public UserContext UserContext { get; }

        public UserService(UserContext userContext)
        {
            this.UserContext = userContext ?? throw new ArgumentNullException(nameof(userContext));
        }

        public async Task<CreatedUser> Add(CreateUser createUser)
        {
            User user = new User()
            {
                Name = createUser.Name,
                BirthDate = createUser.BirthDate
            };

            await this.UserContext.AddAsync(user);
            await this.UserContext.SaveChangesAsync();

            return new CreatedUser()
            {
                Id = user.Id,
            };
        }

        public async Task<RequestedUser> Get(RequestUser requestUser)
        {
            User user = await this.UserContext.Users
                .Where(x => x.Id == requestUser.Id)
                .FirstOrDefaultAsync();
            return new RequestedUser(user.Id, user.Name, user.BirthDate);
        }

        public async Task<RequestedUsers> Get(RequestUsers request)
        {
            IEnumerable<User> users = await this.UserContext.Users.ToListAsync();
            return new RequestedUsers(users.Select(x => new RequestedUser(x.Id, x.Name, x.BirthDate)));
        }

        public async Task<UpdatedUser> Update(UpdateUser request)
        {
            User user = new User()
            {
                Id = request.Id,
                Name = request.Name,
                BirthDate = request.BirthDate,
            };
            
            this.UserContext.Users.Update(user);
            await this.UserContext.SaveChangesAsync();

            return new UpdatedUser(request.Id);
        }

        public async Task<DeletedUser> Delete(DeleteUser request)
        {
            User user = new User()
            {
                Id = request.Id,
            };

            this.UserContext.Users.Remove(user);
            await this.UserContext.SaveChangesAsync();

            return new DeletedUser(request.Id);
        }
    }
}