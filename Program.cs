using System;
using CSCore;
using DeviceControl;
using NAudio.Wave;
using Supabase;
using Supabase.Storage;
using System.Threading;

namespace ScreenAfinity {


    public class Program {
        static Supabase.Client? supabase;
        
        public static async Task Main(string[] args) {
            // Initalisation();
            await SupabaseConnect();
        }

        public static async Task SupabaseConnect() {      
            try
            {
                supabase = new Supabase.Client("https://czbesaouzimntuctbook.supabase.co", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6ImN6YmVzYW91emltbnR1Y3Rib29rIiwicm9sZSI6InNlcnZpY2Vfcm9sZSIsImlhdCI6MTY5NDU2Mjc5OSwiZXhwIjoyMDEwMTM4Nzk5fQ.ydwuZeD2SHbxpsq5d9Sgj083zMWS6QXg5pl8M_aBiKM", new Supabase.SupabaseOptions { AutoConnectRealtime = true });
                await supabase.InitializeAsync();
                Console.WriteLine("CONNECTED!");

                var storage = supabase.Storage;
                var exists = await storage.GetBucket("audio") != null;
                if (!exists)
                    await storage.CreateBucket("NULLFoundX", new Supabase.Storage.BucketUpsertOptions { Public = true });
                var buckets = await storage.ListBuckets();

                foreach (var b in buckets)
                    Console.WriteLine($"[{b.Id}] {b.Name}");
                
                var bytes = await supabase.Storage
                .From("audio")
                .Download("pickupCoin.wav", (sender, progress) => Console.WriteLine($"{progress}%"));

            }
            catch (Exception ex)
            {
                Console.WriteLine("An unexpected error occurred: " + ex.Message);
                Console.WriteLine("Stack Trace: " + ex.StackTrace); // Log the stack trace
            }
        }


        public static void Initalisation() {
            Console.WriteLine("[DISCLAIMER] You are allowing your network to connect to an online database and fetch updates from there. \n There is no negative impact from this.");
            Console.WriteLine("[INFO] - What platform are you currently operating? [1] Windows, [2] MacOS, [3] Linux (Ubuntu only)");
            var platform = Console.ReadLine();
            if(platform == "3") {
                Console.Clear();
                Console.WriteLine("You are operating on Linux (Ubuntu), activating screen affinity blocker...");
                try {
                    Console.WriteLine("Connecting to the Supabase database. This may take ~5s depending on your network speed...");

                

                    DeviceControl.Linux.LinuxSituation();

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