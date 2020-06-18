using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using testexperticket.Core.Messages;

namespace testexperticket.webapi
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class LinkManager : ILinkManager
    {
        private IHttpContextAccessor HttpContextAccessor { get; }

        /// <summary>
        /// 
        /// </summary>
        public LinkManager(IHttpContextAccessor httpContextAccessor)
        {
            this.HttpContextAccessor = httpContextAccessor;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string GetUrl()
        {
            return $"{this.HttpContextAccessor.HttpContext.Request.Scheme}://{this.HttpContextAccessor.HttpContext.Request.Host}{this.HttpContextAccessor.HttpContext.Request.Path}";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public string UserURL(CreatedUser user)
        {
            return $"{this.HttpContextAccessor.HttpContext.Request.Scheme}://{this.HttpContextAccessor.HttpContext.Request.Host}{this.HttpContextAccessor.HttpContext.Request.Path}/{user.Id}";
        }
    }
}