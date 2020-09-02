﻿using CommandSystem;
using Exiled.Permissions.Extensions;
using System;

namespace AdminTools.Commands.Unmute
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    [CommandHandler(typeof(GameConsoleCommandHandler))]
    public class Unmute : ParentCommand
    {
        public Unmute() => LoadGeneratedCommands();

        public override string Command { get; } = "unmute";

        public override string[] Aliases { get; } = new string[] { };

        public override string Description { get; } = "Unmutes everyone from speaking or by intercom in the server";

        public override void LoadGeneratedCommands()
        {
            RegisterCommand(new All());
            RegisterCommand(new ICom());
        }

        protected override bool ExecuteParent(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            EventHandlers.LogCommandUsed((CommandSender)sender, EventHandlers.FormatArguments(arguments, 0));
            if (!((CommandSender)sender).CheckPermission("at.mute"))
            {
                response = "You do not have permission to use this command";
                return false;
            }

            response = "Invalid subcommand. Available ones: icom, all";
            return false;
        }
    }
}
