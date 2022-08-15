using Model.InternalMessage;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Model
{
    public record User
    {
        #region Variables
        private string _firstName;
        private string _lastName;
        #endregion

        [Key]
        public uint Id { get; set; }

        public uint AccessId { get; set; }

        public uint ContactDataId { get; set; }

        public Guid ActorAddressId { get; set; }

        [MaxLength(30,ErrorMessage = Message.MaxLengthExceeded)]
        public string FirstName { get { return _firstName; } set { _firstName = value; } }

        [MaxLength(30, ErrorMessage = Message.MaxLengthExceeded)]
        public string LastName { get { return _lastName; } set { _lastName = value; } }

        [MaxLength(200, ErrorMessage = Message.MaxLengthExceeded)]
        public string Login { get; set; }

        [NotMapped]
        public string Password { get; set; }

        [NotMapped]
        public string FullName { get { return string.Concat(_firstName, " ", _lastName); } }

    }
}
