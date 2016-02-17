using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using libmusic;
using Midi;

namespace ConsoleApplication.Generators
{
    class ChordTesting : libmusic.IMusicGenerator
    {
        List<SNote> sNotes = new List<SNote>();
        float _MaxTimeUsed;
        public ChordTesting()
        {
            List<Midi.Chord> cList = new List<Midi.Chord>();
            cList.Add(new Midi.Chord("A"));
            cList.Add(new Midi.Chord("C"));
            cList.Add(new Midi.Chord("D"));
            cList.Add(new Midi.Chord("G"));
            PlayChords(cList, 4, 0, 20);
        }
        public float Deadline()//Tid før næste kald i beats
        {
            return _MaxTimeUsed;
        }

        public ICollection<LibNoteMessage> GenerateMusic()//Returner en mængde noder til afspilning
        {
            List<LibNoteMessage> tempList = new List<LibNoteMessage>();
            foreach (SNote sN in sNotes)
            {
                tempList.Add(new NoteOn(sN.pitch, sN.Velocity, sN.StartTime, sN.channel));
            }
            return tempList;
        }

        public void Setup(InfoObject infoObject)// Ignore for now
        {
        }
        /// <summary>
        /// Plays through a list of chords with a constant time interval.
        /// </summary>
        /// <param name="chords">A list of the chords you want to play.</param>
        /// <param name="octave">The octave you want to play in.</param>
        /// <param name="startTime">The time you want the first chord to be played.</param>
        /// <param name="timeInterval">The time interval between each chord.</param>
        public void PlayChords(List<Chord> chords, int octave, int startTime, int timeInterval)
        {
            _MaxTimeUsed = timeInterval;
            int tempInt = 0;
            foreach(Chord c in chords)
            {
                ChordToNotes(c, octave, startTime + tempInt, tempInt += timeInterval);
            }
            GenerateMusic();
        }
        private void ChordToNotes(Chord chord, int octave, int time, int endTime)
        {
            Note[] tempNotes = chord.NoteSequence;
            foreach(Note n in tempNotes)
            {
                sNotes.Add(NoteToSNote(n, octave, time, endTime));
            }
        }
        private SNote NoteToSNote(Note note, int octave, float time, float endTime)
        {
            return NoteToSNote(note, octave, 80, time, endTime, 1);
        }
        private SNote NoteToSNote(Note note, int octave, int velocity, float time, float endTime, int channel)
        {
            SNote sNote = new SNote();
            sNote.pitch = note.PitchInOctave(octave);
            sNote.Velocity = velocity;
            sNote.StartTime = time;
            sNote.EndTime = endTime;
            sNote.channel = channel;
            return sNote;

        }
        private class SNote
        {
            public Pitch pitch;
            public int Velocity;
            public float StartTime;
            public float EndTime;
            public int channel;
        }
    }
}
