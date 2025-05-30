﻿using System;
using System.Drawing;

namespace Wifi.PlaylistEditor.Core
{
    public interface IPlaylistItem : IFileTypeInfo
    {        
        string Title { get; }

        string Artist { get; }

        TimeSpan Duration { get; }

        string Path { get; }

        /// <summary>
        /// 128x128 px
        /// </summary>
        Image Thumbnail { get; }
        
        //byte[] ThumbnailRaw { get; }
    }
}