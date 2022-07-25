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
        private string _name;
        private string _lastName;
        #endregion

        [Key]
        public int Id { get; set; }

        [MaxLength(30,ErrorMessage = Message.MaxLengthExceeded)]
        public string Name { get { return _name; } set { _name = value; } }

        [MaxLength(30, ErrorMessage = Message.MaxLengthExceeded)]
        public string LastName { get { return _lastName; } set { _lastName = value; } }

        [MaxLength(200, ErrorMessage = Message.MaxLengthExceeded)]
        public string Email { get; set; }
        [NotMapped]
        public string FullName { get { return string.Concat(_name, " ", _lastName); } }

    }
}
