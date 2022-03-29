using System;
using CmlLib.Core;
using CmlLib.Core.Auth;
using System.Threading;

namespace Ultralight_Launcher
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Client baslatiliyor...");
            Console.WriteLine("Eger bilgisayarinizda 1.8.9 yuklu degilse yukleyecektir yani acilmasi icin bekleyiniz.");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Config: Ver-" + args[0] + ",username-" + args[1] + ",Ultralight_Config-Vista");
            void launch()
            {
                var path = new MinecraftPath();

                var launcher = new CMLauncher(path);
                var launchOption = new MLaunchOption
                {
                    MaximumRamMb = Convert.ToInt32(args[0]),

                    ScreenWidth = 1280,
                    ScreenHeight = 720,
                    Session = MSession.GetOfflineSession(args[1]),
                    ServerIp = "yourenotsupposedtosee",
                    GameLauncherName = "Ultralight",
                    FullScreen = false,
                };
                var process = launcher.CreateProcess("1.8.9", launchOption, true);

                process.Start();
            }

            Thread thread = new Thread(() => launch());
            thread.IsBackground = false;
            thread.Start();

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Client baslatildi.");
        }
    }
}
