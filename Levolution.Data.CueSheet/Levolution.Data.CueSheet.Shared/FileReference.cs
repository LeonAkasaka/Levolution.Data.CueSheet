using System;
using System.Collections.Generic;
using System.Text;

namespace Levolution.Data.CueSheet
{
    /// <summary>
    /// 
    /// </summary>
    public class FileReference
    {
        /// <summary>
        /// File path.
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// File format.
        /// </summary>
        public string Format { get; set; }

        /// <summary>
        /// Tracks.
        /// </summary>
        public IEnumerable<Track> Tracks { get; set; }
    }
}
