using System.Collections.Generic;

namespace testexperticket.Core.Messages
{
    public class RequestedUsers
    {
        public IEnumerable<RequestedUser> requestedUsers { get; set; }

        public RequestedUsers(IEnumerable<RequestedUser> requestedUsers)
        {
            this.requestedUsers = requestedUsers;
        }
    }
}