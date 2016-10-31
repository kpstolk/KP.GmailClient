﻿using System;
using System.Threading.Tasks;
using KP.GmailClient.Common;
using KP.GmailClient.Models;
using KP.GmailClient.Services;
using KP.GmailClient.Tests.IntegrationTests;

namespace KP.GmailClient.Tests
{
    public class CleanupHelpers
    {
        public static CleanupHelper<Draft, Draft> GetDraftServiceCleanupHelper()
        {
            GmailProxy proxy = SettingsManager.GetGmailProxy();
            var service = new DraftService(proxy);

            return GetDraftServiceCleanupHelper(service);
        }

        public static CleanupHelper<Draft, Draft> GetDraftServiceCleanupHelper(DraftService service)
        {
            Func<Draft, Task> deleteAction = async label => await service.DeleteAsync(label.Id);
            Func<Draft, Task<Draft>> createAction = service.CreateAsync;
            return new CleanupHelper<Draft, Draft>(createAction, deleteAction);
        }

        public static CleanupHelper<Message, Message> GetMessageServiceCleanupHelper(MessageService service)
        {
            Func<Message, Task> deleteAction = async message => await service.TrashAsync(message.Id);
            return new CleanupHelper<Message, Message>(null, deleteAction);
        }
    }
}