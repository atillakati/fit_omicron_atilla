using System;
using System.Collections.Generic;
using System.Linq;

namespace Wifi.PlaylistEditor.Core
{
    public class Playlist
    {
		private string _name;
		private string _author;
		private DateTime _createdAt;
        private List<IPlaylistItem> _itemList;

        public Playlist(string name, string author, DateTime createAt)
		{
            _name = name;
            _author = author;
            _createdAt = createAt;

            _itemList = new List<IPlaylistItem>();								
        }

		public Playlist(string name, string author)
			: this(name, author, DateTime.Now) 
		{
			//do other things...
		}

		public TimeSpan Duration
		{
			get
			{
				var duration = _itemList.Sum(x => x.Duration.TotalSeconds);				
				return TimeSpan.FromSeconds(duration);
			}
		}

        public DateTime CreatedAt
		{
			get { return _createdAt; }			
		}

		public IEnumerable<IPlaylistItem> ItemList
		{
			get { return _itemList; }			
		}

		public string Author
		{
			get { return _author; }			
		}

		public string Name
		{
			get { return _name; }			
		}


		public void Add(IPlaylistItem newItem)
		{
			if(newItem == null)
			{
				return;
			}

			_itemList.Add(newItem);
		}

        public void Remove(IPlaylistItem itemToRemove)
        {
            _itemList.Remove(itemToRemove);
        }        

		public void Clear()
		{
			_itemList.Clear();
		}		
    }
}
