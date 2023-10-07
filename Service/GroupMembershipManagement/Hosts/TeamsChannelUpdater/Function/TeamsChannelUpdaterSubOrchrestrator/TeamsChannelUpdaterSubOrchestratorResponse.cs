// Copyright (c) Microsoft Corporation.
// Licensed under the MIT license.
using Models.Entities;
using System.Collections.Generic;

namespace Hosts.TeamsChannelUpdater
{
    public class TeamsChannelUpdaterSubOrchestratorResponse
    {
        public RequestType Type { get; set; }
        public int SuccessCount { get; set; }
        public List<AzureADTeamsUser> UsersNotFound { get; set; }
        public List<AzureADTeamsUser> UsersFailed { get; set; }
    }
}