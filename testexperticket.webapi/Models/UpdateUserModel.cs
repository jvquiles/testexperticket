using System;

namespace testexperticket.webapi.Models
{
    /// <summary>
    /// Update user model.
    /// </summary>
    public class UpdateUserModel
    {
        /// <summary>
        /// Name.
        /// </summary>
        /// <value></value>
        public string Name { get; set; }

        /// <summary>
        /// Birth date.
        /// </summary>
        /// <value></value>
        public DateTime BirthDate { get; set; }
    }
}