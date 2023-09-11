using System;
using DeviceControl;

namespace ScreenAfinity {

    public class Program {
        public static void Main(string[] args) {
            Initalisation();
        }

        public static void Initalisation() {
            Console.WriteLine("What platform are you currently operating? [1] Windows, [2] MacOS, [3] Linux (Ubuntu only)");
            var platform = Console.ReadLine();
            if(platform == "3") {
                Console.Clear();
                Console.WriteLine("You are operating on Linux (Ubuntu), activating screen affinity blocker...");

                DeviceControl.Linux.LinuxSituation();
            }
        }
    }
}