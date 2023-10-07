// Copyright (c) Microsoft Corporation.
// Licensed under the MIT license.
using System;

namespace Hosts.PlaceMembershipObtainer
{
    public class WorkSpacesReaderRequest
    {
        public Guid RunId { get; set; }
        public string Url { get; set; }
        public int Top { get; set; }
        public int Skip { get; set; }
    }
}