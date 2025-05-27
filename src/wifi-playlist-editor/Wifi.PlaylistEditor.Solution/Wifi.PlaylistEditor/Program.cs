using Autofac;
using System;
using System.Windows.Forms;
using Autofac.Core;
using Wifi.PlaylistEditor.Core;
using Wifi.PlaylistEditor.Factories;
using Wifi.PlaylistEditor.Repositories;
using Wifi.PlaylistEditor.Repositories.Database;

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
            builder.RegisterType<TitleSelector>().As<ITitleSelector>();
#else 
            builder.RegisterType<NewPlaylistData>().As<INewPlaylistDataCreator>();
            builder.RegisterType<TitleSelector>().As<ITitleSelector>();
#endif
            builder.RegisterType<DatabaseRepository>().As<IDatabaseRepository>();
            builder.RegisterType<MongoDbDriver<PlaylistEntity>>().As<IDataBaseDriver<PlaylistEntity>>()
                   .WithParameters( new []
                   {
                       new NamedParameter("connectionString", "mongodb://admin:password@localhost:27017"), 
                       new NamedParameter("databaseName","playlist-db"), 
                       new NamedParameter("collectionName","playlist-collection")
                   });

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
