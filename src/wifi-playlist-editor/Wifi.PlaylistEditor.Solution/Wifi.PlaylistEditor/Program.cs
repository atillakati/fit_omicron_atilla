using Autofac;
using System;
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
            //us an IoC container to register and resolve required types
            var builder = new ContainerBuilder();

#if DEBUG
            builder.RegisterType<DummyNewPlaylist>().As<INewPlaylistDataCreator>();
#else 
            builder.RegisterType<NewPlaylistData>().As<INewPlaylistDataCreator>();
#endif
            builder.RegisterType<PlaylistFactory>().As<IPlaylistFactory>();
            builder.RegisterType<PlaylistItemFactory>().As<IPlaylistItemFactory>();
            builder.RegisterType<RepositoryFactory>().As<IPlaylistRepositoryFactory>();
            builder.RegisterType<MainForm>();

            var container = builder.Build();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(container.Resolve<MainForm>());
        }
    }
}
