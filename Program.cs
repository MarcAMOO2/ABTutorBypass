using System;
using CSCore;
using DeviceControl;
using NAudio.Wave;
using Supabase;
using Supabase.Storage;
using System.Threading;

namespace ScreenAfinity {


    public class Program {
        
        
        public static void Main(string[] args) {
            // Initalisation();
            SupabaseConnect();
        }

        public static async void SupabaseConnect() {      
            try
            {
                var supabase = new Supabase.Client("https://ytrhpeeeatvgbgxtsxae.supabase.co", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6Inl0cmhwZWVlYXR2Z2JneHRzeGFlIiwicm9sZSI6ImFub24iLCJpYXQiOjE2OTIwNzQ3NDIsImV4cCI6MjAwNzY1MDc0Mn0.p45vt004-Ls0W6cxdC3x3VkVFAZ59QBOJpOlzW-0L5k");
                var init = await supabase.InitializeAsync();
                Console.WriteLine("CONNECTED!");

                
                var bucket = await supabase.Storage.GetBucket("audio");
                Console.WriteLine(bucket.Name);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An unexpected error occurred: " + ex.Message);
            }
        }

        public static async void Initalisation() {
            Console.WriteLine("[DISCLAIMER] You are allowing your network to connect to an online database and fetch updates from there. \n There is no negative impact from this.");
            Console.WriteLine("[INFO] - What platform are you currently operating? [1] Windows, [2] MacOS, [3] Linux (Ubuntu only)");
            var platform = Console.ReadLine();
            if(platform == "3") {
                Console.Clear();
                Console.WriteLine("You are operating on Linux (Ubuntu), activating screen affinity blocker...");
                try {
                    Console.WriteLine("Connecting to the Supabase database. This may take ~5s depending on your network speed...");

                

                    //DeviceControl.Linux.LinuxSituation();

                } catch (Exception e) {
                    Console.WriteLine($"[ERROR] An error occurred: {e.Message}");
                    Console.WriteLine($"[ERROR] Stack Trace: {e.StackTrace}");
                }

            }
        }
    }
}


// Enviroment Variables
/* 
    winmm.dll
    
*/