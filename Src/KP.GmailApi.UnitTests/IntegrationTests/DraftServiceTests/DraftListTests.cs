﻿using System.Linq;
using FluentAssertions;
using KP.GmailApi.ServiceExtensions;
using KP.GmailApi.Services;
using Xunit;

namespace KP.GmailApi.UnitTests.IntegrationTests.DraftServiceTests
{
    public class DraftListTests
    {
        private readonly DraftService _service;

        public DraftListTests()
        {
            GmailClient client = SettingsManager.GetGmailClient();
            _service = new DraftService(client);
        }

        [Fact]
        public void CanListIds()
        {
            // Act
            var ids = _service.ListIds();

            // Assert
            ids.Should().NotBeNull();
        }

        [Fact]
        public void CanList()
        {
            // Act
            var drafts = _service.List().ToList();

            // Assert
            drafts.Should().NotBeNull();
        }
    }
}