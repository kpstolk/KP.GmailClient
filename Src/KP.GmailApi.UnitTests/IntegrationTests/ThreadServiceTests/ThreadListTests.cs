﻿using System;
using FluentAssertions;
using KP.GmailApi.ServiceExtensions;
using KP.GmailApi.Services;

namespace KP.GmailApi.UnitTests.IntegrationTests.ThreadServiceTests
{
    public class ThreadListTests
    {
        private readonly ThreadService _service;

        public ThreadListTests()
        {
            GmailProxy proxy = SettingsManager.GetGmailClient();
            _service = new ThreadService(proxy);
        }

        public void CanListIds()
        {
            // Act
            Action action = () => _service.ListIds();

            // Assert
            action.ShouldNotThrow();
        }

        public void CanList()
        {
            // Act
            Action action = () => _service.List();

            // Assert
            action.ShouldNotThrow();
        }
    }
}
