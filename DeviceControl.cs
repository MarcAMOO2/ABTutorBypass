using System;
using System.Threading;
using System.Collections;//arrayList
using System.Runtime.InteropServices;
using PortAudioSharp;
using Bassoon;
using libsndfileSharp;

using CSCore;
using Hardware.Info;
using System.Linq; // fetching audio dev
using CSCore.CoreAudioAPI;
using NetCoreAudio.Interfaces;
using NetCoreAudio;

// Make sure to run sudo apt-get install libasound2-dev
// When on Linux

namespace DeviceControl {
    public static class Linux {
        static readonly IHardwareInfo hardwareInfo = new HardwareInfo();
        public static List<string> soundDeviceList = new List<string>();
        public static string osInfo;


        public static void LinuxSituation() {
            Console.WriteLine("Device Operations now handled in Device Control namespace");
            
            #region Microphone
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("De-activating all microphones... ");

            int totalProgress = 999;  // The total number of steps in your process
            int previousCursorPositionTop = Console.CursorTop;


            for (int progress = 0; progress <= totalProgress; progress++) {
                // Save the current cursor position
                int currentCursorPositionTop = Console.CursorTop;

                // Move the cursor to the previous line
                Console.SetCursorPosition(0, previousCursorPositionTop);

                // Clear the previous line
                Console.Write(new string(' ', Console.WindowWidth - 1));

                // Move the cursor back to the current line
                Console.SetCursorPosition(0, currentCursorPositionTop);
                Global.UpdateLoadingBar(progress, totalProgress);
                // NAUDIO WONT WORK HERE AS ITS LINUX

                // osInfo = hardwareInfo.OperatingSystem.ToString();
                // foreach (var hardware in hardwareInfo.SoundDeviceList) {
                //     soundDeviceList.Append(hardware.ToString());
                // }

                previousCursorPositionTop = Console.CursorTop;

                #region LISTING MICROPHONES - LONG
                

                #endregion
            }

            Console.WriteLine($"Full User Report Gathered! \n OS: {hardwareInfo.OperatingSystem} \n Audio Devices (int): {hardwareInfo.SoundDeviceList.Count}");
            foreach (var hardware in hardwareInfo.SoundDeviceList) 
                Console.WriteLine(hardware);
            Console.WriteLine($"\nTotal of  found and disabled! Task complete!");


            #endregion
        }
        
    }

    public static class Windows {
        public static void WindowsSituation() {
        }
    }

    public static class Global {
        public static void UpdateLoadingBar(int progress, int totalProgress) {
            Console.CursorLeft = 0;  // Move the cursor to the beginning of the line
            Console.Write("[");  // Start of the loading bar

            int barLength = 30;  // The length of the loading bar
            int filledLength = progress * barLength / totalProgress;

            // Fill the loading bar with '=' characters up to the progress point
            for (int i = 0; i < filledLength; i++)
            {
                Console.Write("=");
            }

            // Fill the remaining space with empty spaces
            for (int i = filledLength; i < barLength; i++)
            {
                Console.Write(" ");
            }
            double percentage = (double)progress / totalProgress * 100;
            Console.Write($"] {percentage:F2}%");  // End of the loading bar
        }
    }
}
