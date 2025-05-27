using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Wifi.PlaylistEditor.Core;

namespace Wifi.PlaylistEditor
{
    public partial class MainForm : Form
    {
        private readonly IPlaylistFactory _playlistFactory;
        private readonly IPlaylistItemFactory _playlistItemFactory;
        private readonly IPlaylistRepositoryFactory _playlistRepositoryFactory;
        private readonly INewPlaylistDataCreator _creatorForm;
        private IPlaylist _playlist;

        public MainForm(IPlaylistFactory playlistFactory,
                        IPlaylistItemFactory playlistItemFactory,
                        IPlaylistRepositoryFactory playlistRepositoryFactory,
                        INewPlaylistDataCreator creatorForm)
        {
            InitializeComponent();

            _playlistFactory = playlistFactory;
            _playlistItemFactory = playlistItemFactory;
            _playlistRepositoryFactory = playlistRepositoryFactory;
            _creatorForm = creatorForm;
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


        private void MainForm_Load(object sender, EventArgs e)
        {
            lbl_playlistDetails.Text = string.Empty;
            lbl_playlistTitle.Text = string.Empty;
        }

        private void ConfigureFileDialog(FileDialog fileDialog, string title, IEnumerable<IFileTypeInfo> availableTypes)
        {
            fileDialog.Title = title;
            if (_playlist != null)
            {
                fileDialog.FileName = _playlist.Name;
            }
            fileDialog.Filter = CreateFilterString(availableTypes);
            fileDialog.FilterIndex = 1;
        }

        private string CreateFilterString(IEnumerable<IFileTypeInfo> availableTypes)
        {
            string filter = string.Empty;
            string allSupportedFilesFilter = string.Empty;

            //"BMP Files|*.bmp|GIF Files|*.gif
            //"All Graphics Types|*.bmp;*.jpg;*.jpeg;*.png;*.tif;*.tiff"
            foreach (var type in availableTypes)
            {
                filter += $"{type.Description}|*{type.Extension}|";
                allSupportedFilesFilter += $"*{type.Extension};";
            }

            //add all supported files filter
            filter = $"All supported files|{allSupportedFilesFilter}|" + filter;

            //remove last pipe (;)
            filter = filter.Remove(filter.Length - 1);

            return filter;
        }

        #region Items menu

        private void addItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Multiselect = true;
            ConfigureFileDialog(openFileDialog1, "Select item(s) to add", _playlistItemFactory.AvailableTypes);
            if (openFileDialog1.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            foreach (var file in openFileDialog1.FileNames)
            {
                var playlistItem = _playlistItemFactory.Create(file);
                if (playlistItem != null)
                {
                    _playlist.Add(playlistItem);
                }
            }

            //update UI
            UpdatePlaylistDetails();
            UpdatePlaylistItemView();
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lst_items.SelectedItems == null || lst_items.SelectedItems.Count == 0)
            {
                return;
            }

            foreach (ListViewItem selectedItem in lst_items.SelectedItems)
            {
                //retrieve the domain object
                var item = selectedItem.Tag as IPlaylistItem;
                if (item == null)
                {
                    continue;
                }

                _playlist.Remove(item);
            }

            //update UI
            UpdatePlaylistDetails();
            UpdatePlaylistItemView();
        }

        private void clearAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_playlist == null)
            {
                return;
            }

            _playlist.Clear();

            //update UI
            UpdatePlaylistDetails();
            UpdatePlaylistItemView();
        }

        #endregion 

        #region Playlist menu

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //open the Playlist data pop-up
            if (_creatorForm.StartDialog() != DialogResult.OK)
            {
                return;
            }

            //create new playlist
            _playlist = _playlistFactory.Create(_creatorForm.Title, _creatorForm.Author, DateTime.Now);

            //Update the view
            UpdatePlaylistTitle();
            UpdatePlaylistDetails();
            UpdatePlaylistItemView();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Multiselect = true;
            ConfigureFileDialog(saveFileDialog1, "Save playlist as", _playlistRepositoryFactory.AvailableTypes);
            if (saveFileDialog1.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            //create the right repository to save the playlist 
            var repository = _playlistRepositoryFactory.Create(saveFileDialog1.FileName);
            if (repository != null)
            {
                repository.Save(saveFileDialog1.FileName, _playlist);
            }
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Multiselect = false;
            ConfigureFileDialog(openFileDialog1, "Load playlist", _playlistRepositoryFactory.AvailableTypes);
            if (openFileDialog1.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            //create the right repository to save the playlist 
            var repository = _playlistRepositoryFactory.Create(openFileDialog1.FileName);
            if (repository != null)
            {
                _playlist = repository.Load(openFileDialog1.FileName);

                //update UI
                UpdatePlaylistTitle();
                UpdatePlaylistDetails();
                UpdatePlaylistItemView();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }


        #endregion

        
    }
}
