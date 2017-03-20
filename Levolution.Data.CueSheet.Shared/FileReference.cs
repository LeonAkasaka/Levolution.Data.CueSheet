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

        public override string ToString()
        {
            var builder = new StringBuilder();
            ToString(builder);
            return builder.ToString();
        }

        internal void ToString(StringBuilder builder)
        {
            builder.AppendLine($"FILE \"{Path}\" {Format}");
            foreach (var track in Tracks)
            {
                track.ToString(builder);
            }
        }
    }
}
