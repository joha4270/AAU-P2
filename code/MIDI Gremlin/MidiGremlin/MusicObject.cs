using System.Collections.Generic;

namespace MidiGremlin
{
    /*
     *  Potentially a list of other MusicObjects to be played in sequence. (SequentialMusicCollection)
     *  Potentially a list of other MusicObjects to be played at the same time. (Chord)
     *  Potentially an object signifying a pause. (Take a guess)
     *  Potentially an object signifying a pitch and a duration. (Tone)
     */
    ///<summary>
    ///TEST TEST TEST TEST
    ///The class Music object is an abstract class that represents several different musicstructures. 
    ///It handles the individual tones, pauses, and a sequence of tones or accords
    ///</summary>
    public abstract class MusicObject
    {
        internal abstract IEnumerator<SingleBeat> GetChildren ();
    }
}