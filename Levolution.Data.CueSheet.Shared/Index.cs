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
        /// Hour.
        /// </summary>
        public int Hour { get; set; }

        /// <summary>
        /// Minute.
        /// </summary>
        public int Minute { get; set; }
        
        /// <summary>
        /// Second.
        /// </summary>
        public int Second { get; set; }
    }
}
