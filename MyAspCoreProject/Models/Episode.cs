using System;
using System.Collections.Generic;

namespace MyAspCoreProject.Models
{
    public partial class Episode
    {
        public int EpisodeId { get; set; }
        public int SerialId { get; set; }
        public int EpisodeNumber { get; set; }

        public virtual Serial Serial { get; set; }
    }
}
