using System;
using System.Collections.Generic;
using System.Text;

namespace Levolution.Data.CueSheet
{
    /// <summary>
    /// Track index.
    /// </summary>
    public class Index
    {
        /// <summary>
        /// Index Number
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// Minute.
        /// </summary>
        public int Minute { get; set; }

        /// <summary>
        /// Second.
        /// </summary>
        public int Second { get; set; }

        /// <summary>
        /// Frame.
        /// </summary>
        public int Frame { get; set; }

        public override string ToString()
        {
            var builder = new StringBuilder();
            ToString(builder);
            return builder.ToString();
        }

        internal void ToString(StringBuilder builder)
        {
            var num = Number.ToString("00");
            var time = string.Format("{0:00}:{1:00}:{2:00}", Minute, Second, Frame);
            builder.AppendLine($"    INDEX {num} {time}");
        }
    }
}
