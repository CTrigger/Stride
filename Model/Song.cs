using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    public record Song
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Language { get; set; }
        public int AlbumId
        {
            get
            {
                return _AlbumId;
            }
            set
            {
                _AlbumId = value;
            }
        }
        private int _AlbumId = -1;
    }
}
