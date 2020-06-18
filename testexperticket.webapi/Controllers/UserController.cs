using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using testexperticket.Core.Messages;
using testexperticket.webapi.Models;

namespace testexperticket.webapi.Controllers
{
    /// <summary>
    /// User controller
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private IMediator Mediator { get; }

        private ILinkManager LinkManager { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="mediator"></param>
        /// <param name="linkManager"></param>
        public UserController(IMediator mediator, ILinkManager linkManager)
        {
            this.Mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            this.LinkManager = linkManager ?? throw new ArgumentNullException(nameof(linkManager));
        }

        /// <summary>
        /// Creates a new user.
        /// </summary>
        /// <param name="createUser">Data for the user to create.</param>
        /// <returns>A response containing new user data.</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreateUser createUser)
        {
            try
            {
                CreatedUser createdUser = await this.Mediator.Send<CreatedUser>(createUser);
                return Created(this.LinkManager.UserURL(createdUser), new { Link = this.LinkManager.UserURL(createdUser) });
            }
            catch(Exception)
            {
                // Log ex ...
                return BadRequest();
            }
        }

        /// <summary>
        /// Gets a user.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                RequestedUser user = await this.Mediator.Send<RequestedUser>(new RequestUser(id));
                if (user.Id == 0)
                {
                    return NotFound();
                }

                return Ok(user);
            }
            catch(Exception)
            {
                // Log ex ...
                return BadRequest();
            }
        }

        /// <summary>
        /// Gets all users.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                RequestedUsers requestedUsers = await this.Mediator.Send(new RequestUsers());
                return Ok(requestedUsers);
            }
            catch(Exception)
            {
                // Log ex...
                return BadRequest();
            }
        }

        /// <summary>
        /// Updates a user.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updateUserModel"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateUserModel updateUserModel)
        {
            try
            {
                UpdateUser updateUser = new UpdateUser(id, updateUserModel.Name, updateUserModel.BirthDate);
                UpdatedUser updatedUser = await this.Mediator.Send(updateUser);
                return Ok(updatedUser);
            }
            catch(Exception)
            {
                // Log ex ...
                return BadRequest();                
            }
        }

        /// <summary>
        /// Deletes a user.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                DeletedUser deletedUser = await this.Mediator.Send(new DeleteUser(id));
                
                if (deletedUser == null)
                {
                    return NotFound();
                }

                return Ok();
            }
            catch(Exception)
            {
                // Log ex...
                return BadRequest();
            }
        }
    }
}