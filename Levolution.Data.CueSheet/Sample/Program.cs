using Levolution.Data.CueSheet;
using System.IO;

namespace Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            var cueText = File.ReadAllText("Sample.cue");

            var cueSheet = CueSheet.Parse(cueText);
            var output = cueSheet.ToString();
        }
    }
}
