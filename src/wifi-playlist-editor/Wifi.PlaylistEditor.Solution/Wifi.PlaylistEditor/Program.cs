using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Wifi.PlaylistEditor.Core;
using Wifi.PlaylistEditor.Factories;

namespace Wifi.PlaylistEditor
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            //HINT: Replace this by using Nuget Package AutoFac!!
            var playlistFactory = new PlaylistFactory();
            var playlistItemFactory = new PlaylistItemFactory();
            var playlistRepositoryFactory = new RepositoryFactory(playlistFactory, playlistItemFactory);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new MainForm(playlistFactory, 
                                         playlistItemFactory,
                                         playlistRepositoryFactory));
        }
    }
}
