using System;
using System.Collections.Generic;
using System.Text;

namespace LyricsScraper
{
    class UrlBuilder
    {
        private static string Artist()
        {
            string temp = Spotify.GetArtist().Replace("'","-");

            char[] replaceThis = new char[] { ' ', '.', ',', '_', '+', '(', ')', '[', ']', '*', '&', '$', '=','#','|','<','>','~','/'};
            foreach (char item in replaceThis)
            {
                temp = temp.Replace(item, '-');
            }

            string artist = "";

            for (int i = 0; i < temp.Length; i++)
            {
                try
                {
                    if (!(temp[i] == '-' && temp[i + 1] == '-'))
                    {
                        artist += temp[i];
                    }
                }
                catch (IndexOutOfRangeException)
                {
                    artist += temp[i];
                }
            }

            artist = artist.TrimEnd('-').TrimStart('-');

            return artist;
        }

        private static string Song()
        {
            string temp = Spotify.GetSong().Replace("'", "-");

            char[] replaceThis = new char[] { ' ', '.', ',', '_', '+', '(', ')', '[', ']', '*', '&', '$', '=', '#', '|', '<', '>', '~','/' };
            foreach (char item in replaceThis)
            {
                temp = temp.Replace(item, '-');
            }

            string song = "";

            for (int i = 0; i < temp.Length; i++)
            {
                try
                {
                    if (!(temp[i] == '-' && temp[i + 1] == '-'))
                    {
                        song += temp[i];
                    }
                }
                catch (IndexOutOfRangeException)
                {
                    song += temp[i];
                }
            }

            song = song.TrimEnd('-').TrimStart('-');

            return song;

        }



        public static string Musicmatch()
        {
            var strB = new StringBuilder();
            strB.AppendFormat("https://www.musixmatch.com/lyrics/{0}/{1}", Artist(), Song());

            string url = strB.ToString();
            return url;


        }
    }
}
