// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Connector;
using Microsoft.Bot.Schema;
using Newtonsoft.Json.Linq;

namespace Microsoft.BotBuilderSamples.Bots
{
    public class EchoBot : ActivityHandler
    {

        public static IMessageActivity CreateMessageActivityWChanneldata()
        {
            string json = @"{'messageAudience': 'AGENTS_AND_MANAGER'}";

            JObject LPChannelData = JObject.Parse(json);

            return new Activity(ActivityTypes.Message)
            {
                Attachments = new List<Attachment>(),
                Entities = new List<Entity>(),
                Text = "private massage",
                ChannelData = LPChannelData,
            };
        }

        protected override async Task OnMessageActivityAsync(ITurnContext<IMessageActivity> turnContext, CancellationToken cancellationToken)
        {



            //var Action = turnContext.Activity.Action
            var AttachmentLayout = turnContext.Activity.AttachmentLayout;
            var Attachments = turnContext.Activity.Attachments;
            //var CallerId = turnContext.Activity.CallerId;
            var ChannelData = turnContext.Activity.ChannelData;
            var ChannelId = turnContext.Activity.ChannelId;
            //var Code = turnContext.Activity.Code;
            var Conversation = turnContext.Activity.Conversation;
            var DeliveryMode = turnContext.Activity.DeliveryMode;
            var Entities = turnContext.Activity.Entities;
            var Expiration = turnContext.Activity.Expiration;
            var From = turnContext.Activity.From;
            //var HistoryDisclosed = turnContext.Activity.HistoryDisclosed;
            var Id = turnContext.Activity.Id;
            var Importance = turnContext.Activity.Importance;
            var InputHint = turnContext.Activity.InputHint;
            //var Label = turnContext.Activity.Label;
            //var ListenFor = turnContext.Activity.ListenFor;
            var LocalTimestamp = turnContext.Activity.LocalTimestamp;
            //var LocalTimezone = turnContext.Activity.LocalTimezone;
            var Locale = turnContext.Activity.Locale;
            // var MembersAdded = turnContext.Activity.MembersAdded;
            //var MembersRemoved = turnContext.Activity.MembersRemoved;
            //var Name = turnContext.Activity.Name;
            //var Properties = turnContext.Activity.Properties;
            //var ReactionsAdded = turnContext.Activity.ReactionsAdded;
            //var ReactionsRemoved = turnContext.Activity.ReactionsRemoved;
            var Recipient = turnContext.Activity.Recipient;
            //var RelatesTo = turnContext.Activity.RelatesTo;
            var ReplyToId = turnContext.Activity.ReplyToId;
            //var SemanticAction = turnContext.Activity.SemanticAction;
            var ServiceUrl = turnContext.Activity.ServiceUrl;
            var Speak = turnContext.Activity.Speak;
            var SuggestedActions = turnContext.Activity.SuggestedActions;
            var Summary = turnContext.Activity.Summary;
            var Text = turnContext.Activity.Text;
            var TextFormat = turnContext.Activity.TextFormat;
            //var TextHighlights = turnContext.Activity.TextHighlights;
            var Timestamp = turnContext.Activity.Timestamp;
            //var TopicName = turnContext.Activity.TopicName;
            var Type = turnContext.Activity.Type;
            var Value = turnContext.Activity.Value;
            //var ValueType = turnContext.Activity.ValueType;

            var replyText = $"" +
            $"TurnContext:\n " +
            $"{AttachmentLayout}\n" +
            $"{Attachments}\n" +
            $"{ChannelData}\n" +
            $"{ChannelId}\n" +
            $"{Conversation}\n" +
            $"{DeliveryMode}\n" +
            $"{Entities}\n" +
            $"{Expiration}\n" +
            $"{From}\n" +
            $"{Id}\n" +
            $"{Importance}\n" +
            $"{InputHint}\n" +
            $"{LocalTimestamp}\n" +
            $"{Locale}\n" +
            $"{Recipient}\n" +
            $"{ReplyToId}\n" +
            $"{ServiceUrl}\n" +
            $"{Speak}\n" +
            $"{SuggestedActions}\n" +
            $"{Summary}\n" +
            $"{Text}\n" +
            $"{TextFormat}\n" +
            $"{Timestamp}\n" +
            $"{Type}\n" +
            $"{Value}\n";

            string json = @"{'channelData': {'messageAudience': 'AGENTS_AND_MANAGERS'}}";

            JObject LPChannelData = JObject.Parse(json);
            var asd = CreateMessageActivityWChanneldata();
            await turnContext.SendActivityAsync(asd);
            


            //await turnContext.SendActivityAsync(MessageFactory.Text(replyText, replyText), cancellationToken);

        }

        protected override async Task OnMembersAddedAsync(IList<ChannelAccount> membersAdded, ITurnContext<IConversationUpdateActivity> turnContext, CancellationToken cancellationToken)
        {
            var welcomeText = "Hello and welcome!";
            foreach (var member in membersAdded)
            {
                if (member.Id != turnContext.Activity.Recipient.Id)
                {
                    await turnContext.SendActivityAsync(MessageFactory.Text(welcomeText, welcomeText), cancellationToken);
                }
            }
        }
    }
}
