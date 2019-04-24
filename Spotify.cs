using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;

namespace LyricsScraper
{
    class Spotify
    {
        public static string GetTrackInfo()
        {
            var proc = Process.GetProcessesByName("Spotify").FirstOrDefault(p => !string.IsNullOrWhiteSpace(p.MainWindowTitle));

            if (proc == null)
                return "Spotify is not running!";

            if (string.Equals(proc.MainWindowTitle, "Spotify", StringComparison.InvariantCultureIgnoreCase) || string.Equals(proc.MainWindowTitle, "Spotify Premium", StringComparison.InvariantCultureIgnoreCase))
                return "Paused";

            if (!proc.MainWindowTitle.Contains('-'))
                return "Advertising";
            
            return proc.MainWindowTitle;
        }

        public static string GetArtist()
        {
            try
            {
                string trackInfo = GetTrackInfo();
                string artist = trackInfo.Substring(0, trackInfo.IndexOf('-') - 1);
                return artist;
            }
            catch (Exception)
            {
                return "No Song Playing";
            }

        }

        public static string GetSong()
        {
            try
            {
                string trackInfo = GetTrackInfo();
                string song = trackInfo.Substring(trackInfo.IndexOf('-') + 1);
                return song;
            }
            catch (Exception)
            {

                return "No Artist Playing";
            }
        
        }

        public static void RestartSpotify()
        {
            foreach (Process proc in Process.GetProcessesByName("Spotify"))
            {
                proc.Kill();
            }
            Process.Start("Spotify.exe");
            Thread.Sleep(5000);
        
        }
    }
}
