using System;

namespace MidiGremlin
{
    ///<summary>
    ///TEST TEST TEST TEST
    ///</summary>
    public class Scale
    {
        public Scale(params Tone[] tones)
        {
            
        }

        MusicObject this[int interval]
        {
            get { throw new NotImplementedException();}
        }
    }
}