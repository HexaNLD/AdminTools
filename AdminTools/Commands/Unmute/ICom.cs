﻿using CommandSystem;
using Exiled.Permissions.Extensions;
using Exiled.API.Features;
using System;

namespace AdminTools.Commands.Unmute
{
    public class ICom : ICommand
    {
        public string Command { get; } = "icom";

        public string[] Aliases { get; } = new string[] { };

        public string Description { get; } = "Removes intercom mutes everyone in the server";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            EventHandlers.LogCommandUsed((CommandSender)sender, EventHandlers.FormatArguments(arguments, 0));
            if (!((CommandSender)sender).CheckPermission("at.mute"))
            {
                response = "You do not have permission to use this command";
                return false;
            }

            if (arguments.Count != 0)
            {
                response = "Usage: unmute icom";
                return false;
            }

            foreach (Player Ply in Player.List)
                Ply.IsIntercomMuted = false;

            response = "Everyone from the server who is not a staff can speak in the intercom now";
            return true;
        }
    }
}
