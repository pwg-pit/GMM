// Copyright (c) Microsoft Corporation.
// Licensed under the MIT license.
using Entities;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using Models;
using Repositories.Contracts;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Hosts.TeamsChannelUpdater
{
    public class FileDownloaderFunction
    {
        private readonly ILoggingRepository _loggingRepository;
        private readonly IBlobStorageRepository _blobStorageRepository = null;

        public FileDownloaderFunction(ILoggingRepository loggingRepository, IBlobStorageRepository blobStorageRepository)
        {
            _loggingRepository = loggingRepository ?? throw new ArgumentNullException(nameof(loggingRepository));
            _blobStorageRepository = blobStorageRepository ?? throw new ArgumentNullException(nameof(blobStorageRepository));
        }

        [FunctionName(nameof(FileDownloaderFunction))]
        public async Task<string> DownloadFileAsync([ActivityTrigger] FileDownloaderRequest request)
        {
            var blobResult = new BlobResult { BlobStatus = BlobStatus.NotFound };

            await _loggingRepository.LogMessageAsync(new LogMessage { Message = $"Downloading file {request.FilePath}", RunId = request.SyncJob.RunId }, VerbosityLevel.DEBUG);

            if (request.FilePath.Contains("cache"))
            {
                blobResult = await _blobStorageRepository.DownloadCacheFileAsync(request.FilePath);
                if (blobResult.BlobStatus == BlobStatus.NotFound)
                {
                    await _loggingRepository.LogMessageAsync(new LogMessage { Message = $"Cache File {request.FilePath} was not found", RunId = request.SyncJob.RunId }, VerbosityLevel.DEBUG);
                    return string.Empty;
                }
            }
            else
            {
                blobResult = await _blobStorageRepository.DownloadFileAsync(request.FilePath);
                if (blobResult.BlobStatus == BlobStatus.NotFound)
                {
                    throw new FileNotFoundException($"File {request.FilePath} was not found");
                }
            }

            await _loggingRepository.LogMessageAsync(new LogMessage { Message = $"Downloaded file {request.FilePath}", RunId = request.SyncJob.RunId }, VerbosityLevel.DEBUG);

            var content = blobResult.Content;
            return content;
        }
    }
}
