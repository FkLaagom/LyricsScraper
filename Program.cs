//#define debugURL
//#define restartOnAds
using System;
using HtmlAgilityPack;
using System.Timers;

namespace LyricsScraper
{
    class Program
    {
        public static string lastPlayed;
        private static System.Timers.Timer aTimer;

        static void Main(string[] args)
        {

            Console.CursorVisible = false;
            Console.Title = "LyricsScraper";
                        
            aTimer = new Timer(250);
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;

            while (true)
            {

            }

        }
        private static void SetTimer()
        {
            // Create a timer with a two second interval.
            aTimer = new Timer(250);
            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }
        private static void OnTimedEvent(Object source, ElapsedEventArgs e)
        {

            if (lastPlayed != Spotify.GetTrackInfo())
            {
                lastPlayed = Spotify.GetTrackInfo();
                if (lastPlayed == "Paused")
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\r\nPaused");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (lastPlayed == "Spotify is not running!")
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\r\nSpotify is not running!");
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else if (lastPlayed == "Advertising")
                {
#if restartOnAds
                    aTimer.Enabled = false;
                    Spotify.RestartSpotify();
                    aTimer.Enabled = true;
#else
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\r\nAdvertising");
                    Console.ForegroundColor = ConsoleColor.White;
#endif
                }
                else
                {
                    tryfindlyrics();
                }

            }
        }

        private static void tryfindlyrics()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\r\n\r\n" + Spotify.GetTrackInfo() + "\r\n");
            Console.ForegroundColor = ConsoleColor.White;
#if debugURL
            Console.WriteLine(UrlBuilder.Musicmatch());
            Console.WriteLine("Artist: "+Spotify.GetArtist());
            Console.WriteLine("Song: "+Spotify.GetSong());
#endif

            var html = UrlBuilder.Musicmatch();
            HtmlWeb web = new HtmlWeb();
            var htmlDoc = web.Load(html);

            // Loop for finding correct coresponding XML-Path to Lyrics-URL
            try
            {
                var node1 = htmlDoc.DocumentNode.SelectSingleNode("//*[@id='site']/div/div[1]/div/main/div/div/div[3]/div[1]/div/div/div/div[1]/div[1]/span/p");
                var node2 = htmlDoc.DocumentNode.SelectSingleNode("//*[@id='site']/div/div[1]/div/main/div/div/div[3]/div[1]/div/div/div/div[1]/div[1]/span/div/p/span");
                Console.WriteLine(node1.InnerText);
                Console.WriteLine(node2.InnerText);
            }
            catch (Exception)
            {
                try
                {
                    var node2 = htmlDoc.DocumentNode.SelectSingleNode("//*[@id='site']/div/div[1]/div/main/div/div/div[3]/div[1]/div/div/div/div[1]/div[1]/p[1]/span");
                    Console.WriteLine(node2.InnerText);
                }
                catch (Exception)
                {
                    try
                    {

                        var node1 = htmlDoc.DocumentNode.SelectSingleNode("//*[@id='site']/div/div[1]/div/main/div/div/div[3]/div[1]/div/div/div/div[1]/div[2]/span/p");
                        var node2 = htmlDoc.DocumentNode.SelectSingleNode("//*[@id='site']/div/div[1]/div/main/div/div/div[3]/div[1]/div/div/div/div[1]/div[2]/span/div/p/span");
                        Console.WriteLine(node1.InnerText);
                        Console.WriteLine(node2.InnerText);
                    }
                    catch (Exception)
                    {
                        try
                        {
                            var node2 = htmlDoc.DocumentNode.SelectSingleNode(" //*[@id='site']/div/div[1]/div/main/div/div/div[3]/div[1]/div/div/div/div[2]/div[3]/p[1]/span");
                            Console.WriteLine(node2.InnerText);
                        }
                        catch (Exception)
                        {
                            try
                            {
                                var node1 = htmlDoc.DocumentNode.SelectSingleNode("//*[@id='site']/div/div[1]/div/main/div/div/div[3]/div[1]/div/div/div/div[2]/div[2]/span/p");
                                var node2 = htmlDoc.DocumentNode.SelectSingleNode("//*[@id='site']/div/div[1]/div/main/div/div/div[3]/div[1]/div/div/div/div[2]/div[2]/span/div/p/span");

                                Console.WriteLine(node1.InnerText);
                                Console.WriteLine(node2.InnerText);
                            }
                            catch (Exception)
                            {
                                try
                                {
                                    var node2 = htmlDoc.DocumentNode.SelectSingleNode("//*[@id='site']/div/div[1]/div/main/div/div/div[3]/div[1]/div/div/div/div[1]/div[1]/p[3]/span");
                                    Console.WriteLine(node2.InnerText);
                                }
                                catch (Exception)
                                {
                                    try
                                    {

                                        var node1 = htmlDoc.DocumentNode.SelectSingleNode("//*[@id='site']/div/div[1]/div/main/div/div/div[3]/div[1]/div/div/div/div[2]/div[1]/span/p");
                                        var node2 = htmlDoc.DocumentNode.SelectSingleNode("//*[@id='site']/div/div[1]/div/main/div/div/div[3]/div[1]/div/div/div/div[2]/div[1]/span/div/p/span");
                                        Console.WriteLine(node1.InnerText);
                                        Console.WriteLine(node2.InnerText);
                                    }
                                    catch (Exception)
                                    {
                                        try
                                        {
                                            var node2 = htmlDoc.DocumentNode.SelectSingleNode("//*[@id='site']/div/div[1]/div/main/div/div/div[3]/div[1]/div/div/div/div[1]/div[2]/p[1]/span");
                                            Console.WriteLine(node2.InnerText);
                                        }
                                        catch (Exception)
                                        {
                                            try
                                            {

                                                var node1 = htmlDoc.DocumentNode.SelectSingleNode("//*[@id='site']/div/div[1]/div/main/div/div/div[3]/div[1]/div/div/div/div[3]/div[1]/span/p");
                                                var node2 = htmlDoc.DocumentNode.SelectSingleNode("//*[@id='site']/div/div[1]/div/main/div/div/div[3]/div[1]/div/div/div/div[3]/div[1]/span/div/p/span");
                                                Console.WriteLine(node1.InnerText);
                                                Console.WriteLine(node2.InnerText);
                                            }
                                            catch (Exception)
                                            {
                                                try
                                                {
                                                    var node2 = htmlDoc.DocumentNode.SelectSingleNode("//*[@id='site']/div/div[1]/div/main/div/div/div[3]/div[1]/div/div/div/div[1]/div[3]/p[1]/span");
                                                    Console.WriteLine(node2.InnerText);
                                                }
                                                catch (Exception)
                                                {

                                                    try
                                                    {

                                                        var node1 = htmlDoc.DocumentNode.SelectSingleNode("//*[@id='site']/div/div[1]/div/main/div/div/div[3]/div[2]/div/div/div/div[1]/div[1]/span/p");
                                                        var node2 = htmlDoc.DocumentNode.SelectSingleNode("//*[@id='site']/div/div[1]/div/main/div/div/div[3]/div[2]/div/div/div/div[1]/div[1]/span/div/p/span");
                                                        Console.WriteLine(node1.InnerText);
                                                        Console.WriteLine(node2.InnerText);
                                                    }
                                                    catch (Exception)
                                                    {
                                                        try
                                                        {
                                                            var node2 = htmlDoc.DocumentNode.SelectSingleNode("//*[@id='site']/div/div[1]/div/main/div/div/div[3]/div[1]/div/div/div/div[2]/div[1]/p[1]/span");
                                                            Console.WriteLine(node2.InnerText);
                                                        }
                                                        catch (Exception)
                                                        {
                                                            try
                                                            {

                                                                var node1 = htmlDoc.DocumentNode.SelectSingleNode("//*[@id='site']/div/div[1]/div/main/div/div/div[3]/div[3]/div/div/div/div[1]/div[1]/span/p");
                                                                var node2 = htmlDoc.DocumentNode.SelectSingleNode("//*[@id='site']/div/div[1]/div/main/div/div/div[3]/div[3]/div/div/div/div[1]/div[1]/span/div/p/span");
                                                                Console.WriteLine(node1.InnerText);
                                                                Console.WriteLine(node2.InnerText);
                                                            }
                                                            catch (Exception)
                                                            {
                                                                try
                                                                {
                                                                    var node2 = htmlDoc.DocumentNode.SelectSingleNode("//*[@id='site']/div/div[1]/div/main/div/div/div[3]/div[1]/div/div/div/div[3]/div[1]/p[1]/span");
                                                                    Console.WriteLine(node2.InnerText);
                                                                }
                                                                catch (Exception)
                                                                {
                                                                    try
                                                                    {

                                                                        var node1 = htmlDoc.DocumentNode.SelectSingleNode("//*[@id='site']/div/div[1]/div/main/div/div/div[3]/div[3]/div/div/div/div[2]/div[1]/span/p");
                                                                        var node2 = htmlDoc.DocumentNode.SelectSingleNode("//*[@id='site']/div/div[1]/div/main/div/div/div[3]/div[3]/div/div/div/div[2]/div[1]/span/div/p/span");
                                                                        Console.WriteLine(node1.InnerText);
                                                                        Console.WriteLine(node2.InnerText);
                                                                    }
                                                                    catch (Exception)
                                                                    {
                                                                        try
                                                                        {
                                                                            var node2 = htmlDoc.DocumentNode.SelectSingleNode("//*[@id='site']/div/div[1]/div/main/div/div/div[3]/div[3]/div/div/div/div[2]/div[1]/p[1]/span");
                                                                            Console.WriteLine(node2.InnerText);
                                                                        }
                                                                        catch (Exception)
                                                                        {
                                                                            try
                                                                            {

                                                                                var node1 = htmlDoc.DocumentNode.SelectSingleNode("//*[@id='site']/div/div[1]/div/main/div/div/div[3]/div[2]/div/div/div/div[2]/div[1]/span/p");
                                                                                var node2 = htmlDoc.DocumentNode.SelectSingleNode("//*[@id='site']/div/div[1]/div/main/div/div/div[3]/div[2]/div/div/div/div[2]/div[1]/span/div/p/span");
                                                                                Console.WriteLine(node1.InnerText);
                                                                                Console.WriteLine(node2.InnerText);
                                                                            }
                                                                            catch (Exception)
                                                                            {
                                                                                try
                                                                                {
                                                                                    var node2 = htmlDoc.DocumentNode.SelectSingleNode("//*[@id='site']/div/div[1]/div/main/div/div/div[3]/div[1]/div/div/div/div[2]/div[2]/p[1]/span");
                                                                                    Console.WriteLine(node2.InnerText);
                                                                                }
                                                                                catch (Exception)
                                                                                {

                                                                                    try
                                                                                    {
                                                                                        var node1 = htmlDoc.DocumentNode.SelectSingleNode("//*[@id='site']/div/div[1]/div/main/div/div/div[3]/div[1]/div/div/div/div[1]/div[3]/span/p");
                                                                                        var node2 = htmlDoc.DocumentNode.SelectSingleNode("//*[@id='site']/div/div[1]/div/main/div/div/div[3]/div[1]/div/div/div/div[1]/div[3]/span/div/p/span");
                                                                                        Console.WriteLine(node1.InnerText);
                                                                                        Console.WriteLine(node2.InnerText);
                                                                                    }
                                                                                    catch (Exception)
                                                                                    {
                                                                                        try
                                                                                        {
                                                                                            var node2 = htmlDoc.DocumentNode.SelectSingleNode("//*[@id='site']/div/div[1]/div/main/div/div/div[3]/div[1]/div/div/div/div[1]/div[1]/p[2]/span");

                                                                                            Console.WriteLine(node2.InnerText);
                                                                                        }
                                                                                        catch (Exception)
                                                                                        {

                                                                                            Console.WriteLine("Couldn't find lyrics :C");
                                                                                        }

                                                                                    }
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            Console.SetCursorPosition(1, 1);

        }
    }



}
