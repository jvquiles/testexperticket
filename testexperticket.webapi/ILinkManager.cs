using System.Collections.Generic;
using testexperticket.Core.Messages;

namespace testexperticket.webapi
{
    /// <summary>
    /// 
    /// </summary>
    public interface ILinkManager
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        string GetUrl();
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        string UserURL(CreatedUser user);
    }
}