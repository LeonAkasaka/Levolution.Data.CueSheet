using System;
using System.Collections.Generic;
using System.Text;

namespace Levolution.Data.CueSheet
{
    public interface IAudioInformation
    {
        string Title { get; set; }

        string Performer { get; set; }

        string SongWriter { get; set; }
    }
}
