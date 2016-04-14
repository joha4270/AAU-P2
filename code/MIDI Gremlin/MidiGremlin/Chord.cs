using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidiGremlin
    ///<summary>
    ///This class implements a chord function
    ///</summary>
{
    public class Chord
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="toneSteps"></param>
        public Chord(params int[] toneSteps)
        {
                throw new NotImplementedException();
        }

        public static Chord Name(string name)
        {
            throw new NotImplementedException();
        }
            
        //TODO Og så videre. Muligvis ikke rent faktisk en dur det her.
        public static Chord Major { get; } = new Chord(4, 7);

        public MusicObject WithBaseTone(Tone tone)
        {
            return new ChordInstance();
        }
    }
}
