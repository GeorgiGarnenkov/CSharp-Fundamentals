using System.Linq;

namespace FestivalManager.Entities
{
    using System.Collections.Generic;
    using Contracts;

    public class Stage : IStage
    {
        private List<ISet> sets;
        private List<ISong> songs;
        private List<IPerformer> performers;

        public Stage()
        {
            this.sets = new List<ISet>();
            this.songs = new List<ISong>();
            this.performers = new List<IPerformer>();
        }

        public IReadOnlyCollection<ISet> Sets => this.sets.AsReadOnly();
        public IReadOnlyCollection<ISong> Songs => this.songs.AsReadOnly();
        public IReadOnlyCollection<IPerformer> Performers => this.performers.AsReadOnly();


        public IPerformer GetPerformer(string name)
        {
            IPerformer performer = this.performers.FirstOrDefault(p => p.Name == name);

            return performer;
        }

        public ISong GetSong(string name)
        {
            ISong song = this.songs.FirstOrDefault(p => p.Name == name);

            return song;
        }

        public ISet GetSet(string name)
        {
            ISet set = this.sets.FirstOrDefault(p => p.Name == name);

            return set;
        }

        public void AddPerformer(IPerformer performer)
        {
            this.performers.Add(performer);
        }

        public void AddSong(ISong song)
        {
            this.songs.Add(song);
        }

        public void AddSet(ISet set)
        {
            this.sets.Add(set);
        }


        public bool HasPerformer(string name)
        {
            var performer = GetPerformer(name);

            if (performer != null)
            {
                return true;
            }

            return false;

        }

        public bool HasSong(string name)
        {
            var song = GetSong(name);

            if (song != null)
            {
                return true;
            }

            return false;
        }

        public bool HasSet(string name)
        {
            var set = GetSet(name);

            if (set != null)
            {
                return true;
            }

            return false;
        }
    }
}
