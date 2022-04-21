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

#pragma warning disable CS8604 // Possible null reference argument.
// hash magic that you're not supposed to see.

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
        ServerIp = "yourenotsupposedtosee",
        GameLauncherName = "Ultralight",
        FullScreen = false,
    };
    var process = launcher.CreateProcess("1.8.9", launchOption, true);

    process.Start();
}

option = Convert.ToChar(Read());
switch (option)
{
    case '1':

        break;
    case '2':

        break;

    case '3':

        break;
    case '4':

        break;
    default:

        break;
}
