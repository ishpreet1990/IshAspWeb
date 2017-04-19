using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyAspCoreProject.Models
{
    public partial class Serial
    {
        public Serial()
        {
            Episode = new HashSet<Episode>();
        }

        public int SerialId { get; set; }
        public string SerialName { get; set; }
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:H:mm}")]
        public DateTime SerialTime { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime ReleaseDate { get; set; }

        public virtual ICollection<Episode> Episode { get; set; }
    }
}
