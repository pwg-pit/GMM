// Copyright (c) Microsoft Corporation.
// Licensed under the MIT license.
using Microsoft.AspNetCore.JsonPatch;
using Services.Messages.Contracts.Requests;
using WebApi.Models.DTOs;

namespace Services.Messages.Requests
{
    public class PatchJobRequest : RequestBase
    {
        public bool IsAdmin { get; set; }
        public Guid SyncJobId { get; }
        public string UserIdentity { get; }
        public JsonPatchDocument<SyncJobPatch> PatchDocument { get; }

        public PatchJobRequest(bool isAdmin, string userIdentity, Guid syncJobId, JsonPatchDocument<SyncJobPatch> patchDocument)
        {
            IsAdmin = isAdmin;
            UserIdentity = userIdentity;
            SyncJobId = syncJobId;
            PatchDocument = patchDocument;
        }
    }
}
