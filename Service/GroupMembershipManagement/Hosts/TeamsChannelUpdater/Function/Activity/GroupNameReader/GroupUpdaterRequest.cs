// Copyright (c) Microsoft Corporation.
// Licensed under the MIT license.
using System;

namespace Hosts.TeamsChannelUpdater
{
    public class GroupNameReaderRequest
    {
        public Guid RunId { get; set; }
        public Guid GroupId { get; set; }
    }
}