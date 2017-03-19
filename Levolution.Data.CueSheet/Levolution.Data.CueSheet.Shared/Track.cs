using System;
using System.Collections.Generic;
using System.Text;

namespace Levolution.Data.CueSheet
{
    /// <summary>
    /// Track.
    /// </summary>
    public class Track : IAudioInformation
    {
        /// <summary>
        /// Trakc number.
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// Track type.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Track name.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Performer { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string SongWriter { get; set; }

        /// <summary>
        /// Indices of this Track.
        /// </summary>
        public IEnumerable<Index> Indices { get; set; }
    }
}
