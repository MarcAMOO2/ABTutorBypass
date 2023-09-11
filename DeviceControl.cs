using System;
using System.Threading;
using NAudio.CoreAudioApi;
using NAudio.Wave;
using NAudio;
using System.Runtime.InteropServices;
using PortAudioSharp;
using Bassoon;
using libsndfileSharp;

using CSCore;
using Hardware.Info; // fetching audio dev

namespace DeviceControl {
    public static class Linux {
        static readonly IHardwareInfo hardwareInfo = new HardwareInfo();
        
        public static void LinuxSituation() {
            Console.WriteLine("Device Operations now handled in Device Control namespace");
            
            #region Microphone
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("De-activating all microphones... ");

            int totalProgress = 10;  // The total number of steps in your process
            for (int progress = 0; progress <= totalProgress; progress++) {
                hardwareInfo.RefreshAll();
                


                Global.UpdateLoadingBar(progress, totalProgress);
                // NAUDIO WONT WORK HERE AS ITS LINUX

                #region LISTING MICROPHONES - LONG
                



                #endregion
            }
            Console.WriteLine($"Full User Report Gathered! \n OS: {hardwareInfo.OperatingSystem}, \n Audio Devices (int): {hardwareInfo.SoundDeviceList.Count}");
            foreach (var hardware in hardwareInfo.SoundDeviceList) 
                Console.WriteLine(hardware);
            Console.WriteLine($"\nTotal of  found and disabled! Task complete!");


            #endregion
        }
        
    }

    public static class Windows {
        public static void WindowsSituation() {
            // fetch all audio in devices (microphones) using NAudio
            MMDeviceEnumerator enumerator = new MMDeviceEnumerator();
            MMDevice defaultAudioDevice = enumerator.GetDefaultAudioEndpoint(DataFlow.Render, Role.Multimedia);

            MMDeviceEnumerator aDevices = new MMDeviceEnumerator();
            foreach (var device in aDevices.EnumerateAudioEndPoints(DataFlow.Capture, DeviceState.Active))
            {
                Console.WriteLine(device.FriendlyName); // Print the friendly name of the audio capture device
            }
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