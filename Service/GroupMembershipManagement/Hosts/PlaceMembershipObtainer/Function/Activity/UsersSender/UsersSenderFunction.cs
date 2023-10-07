// Copyright (c) Microsoft Corporation.
// Licensed under the MIT license.
using Models;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using Repositories.Contracts;
using Services;
using System.Threading.Tasks;

namespace Hosts.PlaceMembershipObtainer
{
    public class UsersSenderFunction
    {
        private readonly ILoggingRepository _log;
        private readonly PlaceMembershipObtainerService _membershipProviderService;

        public UsersSenderFunction(ILoggingRepository loggingRepository, PlaceMembershipObtainerService membershipProviderService)
        {
            _log = loggingRepository;
            _membershipProviderService = membershipProviderService;
        }

        [FunctionName(nameof(UsersSenderFunction))]
        public async Task<string> SendUsersAsync([ActivityTrigger] UsersSenderRequest request)
        {
            string filePath = null;

            await _log.LogMessageAsync(new LogMessage { Message = $"{nameof(UsersSenderFunction)} function started", RunId = request.RunId }, VerbosityLevel.DEBUG);

            filePath = await _membershipProviderService.SendMembershipAsync(request.SyncJob, request.Users, request.CurrentPart, request.Exclusionary);

            await _log.LogMessageAsync(new LogMessage
            {
                RunId = request.RunId,
                Message = $"Successfully uploaded {request.Users.Count} users from source groups {request.SyncJob.Query} to blob storage to be put into the destination group {request.SyncJob.TargetOfficeGroupId}."
            });

            await _log.LogMessageAsync(new LogMessage { Message = $"{nameof(UsersSenderFunction)} function completed", RunId = request.RunId }, VerbosityLevel.DEBUG);

            return filePath;
        }
    }
}