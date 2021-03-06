﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using Microsoft.Win32.SafeHandles;

namespace sarcasticBob.commands
{
    public class Commands
    {
        [Command("greet"), Description("Says hi to specified user."), Aliases("sayhi", "say_hi")]
        public async Task Greet(CommandContext ctx, DiscordMember member) 
        {
            await ctx.TriggerTypingAsync();

            var emoji = DiscordEmoji.FromName(ctx.Client, ":wave:");

            await ctx.RespondAsync($"{emoji} Hello, {member.Mention}");
        }

        [Command("mock"), Description("I say what he said"), Aliases("comeAgain")]
        public async Task Repeat(CommandContext ctx, DiscordMember member)
        {
            var utility = new Utility(); 
            await ctx.TriggerTypingAsync();
            var message = await utility.GetLastMessageAsync(ctx,member);

            var filePath = utility.CreateSpongeBob(message);
            await ctx.RespondWithFileAsync(filePath, $"{member.Mention}");
        }

        [Command("fuck"), Description("fuck him"), Aliases("screw")]
        public async Task Fuck(CommandContext ctx, DiscordMember member)
        {
            var daScrew = new ScrewYou();
            
            await ctx.RespondAsync($"{member.Mention}", false, new DiscordEmbed{Url = daScrew.Execute() });
        }
    }
}
