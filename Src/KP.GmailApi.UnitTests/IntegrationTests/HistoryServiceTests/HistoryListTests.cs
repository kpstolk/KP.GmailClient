﻿using System;
using System.Net;
using FluentAssertions;
using KP.GmailApi.Services;

namespace KP.GmailApi.UnitTests.IntegrationTests.HistoryServiceTests
{
    public class HistoryListTests
    {
        private readonly HistoryService _service;

        public HistoryListTests()
        {
            GmailClient client = SettingsManager.GetGmailClient();
            _service = new HistoryService(client);
        }

        //[Fact]
        public void CanList()
        {
            // Act
            //_service.List(ulong.MaxValue);
        }

        //[Fact]
        public void NonExistingId_ReturnsNotFound()
        {
            // Act
            Action action = () => _service.List(ulong.MaxValue);

            // Assert
            action.ShouldThrow<GmailException>()
                .And.StatusCode.Should().Be(HttpStatusCode.NotFound);//TODO: currently returns 400
        }
    }
}