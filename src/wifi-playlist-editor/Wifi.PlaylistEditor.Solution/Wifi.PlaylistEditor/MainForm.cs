using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Wifi.PlaylistEditor.Core;

namespace Wifi.PlaylistEditor
{
    public partial class MainForm : Form
    {
        private readonly IPlaylistFactory _playlistFactory;
        private readonly IPlaylistItemFactory _playlistItemFactory;
        private readonly IPlaylistRepositoryFactory _playlistRepositoryFactory;
        private IPlaylist _playlist;

        public MainForm(IPlaylistFactory playlistFactory, 
                        IPlaylistItemFactory playlistItemFactory,
                        IPlaylistRepositoryFactory playlistRepositoryFactory)
        {
            InitializeComponent();

            _playlistFactory = playlistFactory;
            _playlistItemFactory = playlistItemFactory;
            _playlistRepositoryFactory = playlistRepositoryFactory;
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //open the Playlist data pop-up ==> REPLACE THIS!!
            //define an interface
            var form = new NewPlaylistData();
            if(form.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            //create new playlist
            _playlist = _playlistFactory.Create(form.PlaylistTitle,
                                                form.PlaylistAuthor,
                                                DateTime.Now);

            //Update the view
            UpdatePlaylistTitle();
            UpdatePlaylistDetails();
            UpdatePlaylistItemView();
        }

        private void UpdatePlaylistItemView()
        {
            int index = 0;

            imageList1.Images.Clear();
            lst_items.Items.Clear();

            foreach (var playlistItem in _playlist.ItemList)
            {
                var listviewItem = new ListViewItem(playlistItem.ToString());
                listviewItem.Tag = playlistItem;
                listviewItem.ImageIndex = index;

                if (playlistItem.Thumbnail != null)
                {
                    imageList1.Images.Add(playlistItem.Thumbnail);                    
                }
                else
                {
                    //add a placeholder image
                    imageList1.Images.Add(Image.FromStream(new MemoryStream(Resource1.No_Image_Available)));
                }

                index++;
                lst_items.Items.Add(listviewItem);
            }

            lst_items.LargeImageList = imageList1;
        }

        private void UpdatePlaylistDetails()
        {
            //Duration: 00:15:28 | Created: 22.05.2025 | Author: DJ Gandalf
            lbl_playlistDetails.Text = $"Duration: {_playlist.Duration} | " +
                                       $"Created: {_playlist.CreatedAt.ToShortDateString()} | " +
                                       $"Author: {_playlist.Author}";
        }

        private void UpdatePlaylistTitle()
        {
            lbl_playlistTitle.Text = _playlist.Name;
        }

        private void addItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            foreach (var file in openFileDialog1.FileNames)
            {
                var playlistItem = _playlistItemFactory.Create(file);
                if(playlistItem != null)
                {
                    _playlist.Add(playlistItem);
                }
            }

            //update UI
            UpdatePlaylistDetails();
            UpdatePlaylistItemView();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(saveFileDialog1.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            //create the right repository to save the playlist 
            var repository = _playlistRepositoryFactory.Create(saveFileDialog1.FileName);
            if(repository != null)
            {
                repository.Save(saveFileDialog1.FileName, _playlist);
            }
        }
    }
}
