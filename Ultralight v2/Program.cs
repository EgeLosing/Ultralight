using System.Drawing;
using System;
using System.Diagnostics;
using static System.Console;
using static System.ConsoleColor;
using System.Security.Cryptography;
using Microsoft.VisualBasic;
using Pastel;
using System.Text;
using CmlLib.Core;
using CmlLib.Core.Auth;
using System.Runtime.InteropServices;
using Microsoft.TeamFoundation.Common.Internal;

// Ultralight v2

// WARNING!! THIS BUILD OF ULTRALIGHT DOESN'T USE SUNCORE FEATURES BUT IT SUPPORTS THEM.

ForegroundColor = Yellow;

// Login Page

Clear();
ForegroundColor = Blue;
string password;

#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
void checkUsername()
{
    WriteLine("##          ##########  ########   ##  ######     ###".Pastel(Color.FromArgb(255, 137, 105)));
    WriteLine("##          ##      ##  ##         ##  ###  ##    ###".Pastel(Color.FromArgb(255, 137, 105)));
    WriteLine("##          ##      ##  ##         ##  ###   ##   ###".Pastel(Color.FromArgb(255, 137, 105)));
    WriteLine("##          ##      ##  ##  #####  ##  ###    ##  ###".Pastel(Color.FromArgb(255, 137, 105)));
    WriteLine("##          ##      ##  ##     ##  ##  ###     ## ###".Pastel(Color.FromArgb(255, 137, 105)));
    WriteLine("##########  ##########  #########  ##  ###      #####".Pastel(Color.FromArgb(255, 137, 105)));

    Write("Username: ".Pastel(Color.FromArgb(255, 220, 105)));
    string username = ReadLine();
    Write("Password: ".Pastel(Color.FromArgb(255, 220, 105)));
    password = ReadLine();
    if (username == null || username.Length < 3 || username.Length > 16 || username.Contains(" "))
    {
        WriteLine("Your username is invalid. You can't enter to game with this username.".Pastel(Color.FromArgb(255, 0, 0)));
        checkUsername();
    }
}
checkUsername();

#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.

#pragma warning disable SYSLIB0021 // Type or member is obsolete
SHA512 sha = new SHA512CryptoServiceProvider();
#pragma warning disable CS8604 // Possible null reference argument.
string hashedPassword = Convert.ToBase64String(sha.ComputeHash(Encoding.UTF8.GetBytes(password)));

// Some magic controls when servers went up

Clear();

WriteLine("Main MENU".Pastel(Color.FromArgb(255, 137, 105)));
WriteLine("Choose an option".Pastel(Color.FromArgb(255, 168, 110)));
WriteLine("1) Launch Game");
WriteLine("2) Options");
WriteLine("3) Switch account");
WriteLine("");
WriteLine("4) Close launcher");

char option;

System.Net.ServicePointManager.DefaultConnectionLimit = 12000;

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
        GameLauncherName = "Ultralight",
        FullScreen = false
    };
    var process = launcher.CreateProcess("1.8.9", launchOption, true);

    process.Start();
}

[DllImport("kernel32.dll")]
[return: MarshalAs(UnmanagedType.Bool)]
static extern bool GetPhysicallyInstalledSystemMemory(out long TotalMemoryInKilobytes);

long memKb;
GetPhysicallyInstalledSystemMemory(out memKb);
long memMb = memKb / 1024;

uint maxAdjustableRAM;
uint c_m1(double x)
{
    return Convert.ToUInt32(x);
}

#region RAM

if (memMb <= 512)
{
    WriteLine("This PC can't run Ultralight v2.".Pastel(Color.FromArgb(255, 0, 0)));
    WriteLine("Press enter to exit.");
    ReadLine();
    Environment.Exit(4);
}
else if (memMb < 1 * 1024) maxAdjustableRAM = c_m1(1 * 1024 / 2 * 1.5);
else if (memMb < 2 * 1024) maxAdjustableRAM = c_m1(2 * 1024 / 2 * 1.5);
else if (memMb < 3 * 1024) maxAdjustableRAM = c_m1(3 * 1024 / 2 * 1.5);
else if (memMb < 4 * 1024) maxAdjustableRAM = c_m1(4 * 1024 / 2 * 1.5);
else if (memMb < 5 * 1024) maxAdjustableRAM = c_m1(5 * 1024 / 2 * 1.5);
else if (memMb < 6 * 1024) maxAdjustableRAM = c_m1(6 * 1024 / 2 * 1.5);
else if (memMb < 8 * 1024) maxAdjustableRAM = c_m1(8 * 1024 / 2 * 1.5);
else if (memMb < 12 * 1024) maxAdjustableRAM = c_m1(12 * 1024 / 2 * 1.5);
else if (memMb < 16 * 1024) maxAdjustableRAM = c_m1(16 * 1024 / 2 * 1.5);
else if (memMb < 24 * 1024) maxAdjustableRAM = c_m1(24 * 1024 / 2 * 1.5);
else if (memMb < 32 * 1024) maxAdjustableRAM = c_m1(32 * 1024 / 2 * 1.5);
else if (memMb < 48 * 1024) maxAdjustableRAM = c_m1(48 * 1024 / 2 * 1.5);
else if (memMb < 64 * 1024) maxAdjustableRAM = c_m1(64 * 1024 / 2 * 1.5);
else if (memMb < 96 * 1024) maxAdjustableRAM = c_m1(96 * 1024 / 2 * 1.5);
else if (memMb < 128 * 1024) maxAdjustableRAM = c_m1(128 * 1024 / 2 * 1.5);
else if (memMb < 192 * 1024) maxAdjustableRAM = c_m1(192 * 1024 / 2 * 1.5);
else if (memMb < 256 * 1024) maxAdjustableRAM = c_m1(256 * 1024 / 2 * 1.5);
else if (memMb < 384 * 1024) maxAdjustableRAM = c_m1(384 * 1024 / 2 * 1.5);
else if (memMb < 512 * 1024) maxAdjustableRAM = c_m1(512 * 1024 / 2 * 1.5);
else if (memMb < 768 * 1024) maxAdjustableRAM = c_m1(768 * 1024 / 2 * 1.5);
else if (memMb < 1024 * 1024) maxAdjustableRAM = c_m1(1024 * 1024 / 2 * 1.5);

#endregion

void optionsMenu()
{
    char opt;
    WriteLine("Choose an option".Pastel(Color.FromArgb(255, 168, 110)));

    WriteLine("1) Set RAM Amount");
    WriteLine("2) Change version");
    opt = Convert.ToChar(Read());
    switch (opt)
    {
        case '1':

            break;
    }
}

option = Convert.ToChar(Read());
switch (option)
{
    case '1':

        break;
    case '2':
        optionsMenu();
        break;

    case '3':

        break;
    case '4':

        break;
    default:

        break;
}
