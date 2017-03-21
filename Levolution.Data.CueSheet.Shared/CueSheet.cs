using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace Levolution.Data.CueSheet
{
    /// <summary>
    /// Cue sheet.
    /// </summary>
    public class CueSheet : IAudioInformation
    {
        /// <summary>
        /// At top-level this will specify the album name.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Catalog.
        /// </summary>
        public string Catalog { get; set; }

        /// <summary>
        /// The file that the cue sheet is currently referencing.
        /// </summary>
        public IEnumerable<FileReference> Files { get; set; }

        /// <summary>
        /// At top-level this will specify the CD artist.
        /// </summary>
        public string Performer { get; set; }

        /// <summary>
        /// Per-disc songwriter name.
        /// </summary>
        public string SongWriter { get; set; }

        public override string ToString()
        {
            var type = GetType();
            var info = type.GetTypeInfo();

            var builder = new StringBuilder();
            builder.AppendLine($"TITLE {Title}");
            builder.AppendLine($"PERFORMER {Performer}");

            foreach (var file in Files)
            {
               file.ToString(builder);
            }

            return builder.ToString();
        }

        public static CueSheet Parse(string text)
        {
            var files = new List<FileReference>();
            var cueSheet = new CueSheet() { Files = files };

            var regex = new Regex("(?:^| )(\"(?:[^\"]+|\"\")*\"|[^ ]*)");
            var reader = new StringReader(text);

            IAudioInformation currentInfo = cueSheet;
            FileReference currentFile = null;
            List<Track> currentTracks = null;
            Track currentTrack = null;
            List<Index> currentIndices = null;

            while (true)
            {
                var line = reader.ReadLine();
                if (line == null) { break; }

                var command = regex.Matches(line)
                    .Cast<object>()
                    .Select(x => x.ToString().Trim().Trim('"'))
                    .Where(x => !string.IsNullOrEmpty(x))
                    .ToArray();
                switch(command[0])
                {
                    case "CATALOG": { cueSheet.Catalog = command[1]; break; }
                    case "TITLE": { currentInfo.Title = command[1]; break; }
                    case "PERFORMER": { currentInfo.Performer = command[1]; break; }
                    case "SONGWRITER": { currentInfo.SongWriter = command[1]; break; }
                    case "FILE":
                    {
                        currentTracks = new List<Track>();
                        currentFile = new FileReference() { Path = command[1], Format = command[2], Tracks = currentTracks };
                        files.Add(currentFile);
                        break;
                    }
                    case "TRACK":
                    {
                        currentIndices = new List<Index>();
                        currentTrack = new Track() { Number = int.Parse(command[1]), Type = command[2], Indices = currentIndices };
                        currentInfo = currentTrack;
                        currentTracks.Add(currentTrack);
                        break;
                    }
                    case "INDEX":
                    {
                        var time = command[2].Split(':');
                        var index = new Index() { Number = int.Parse(command[1]), Minute = int.Parse(time[0]), Second = int.Parse(time[1]), Frame = int.Parse(time[2]) };
                        currentIndices.Add(index);
                        break;
                    }
                }
            }

            return cueSheet;
        }
    }
}
