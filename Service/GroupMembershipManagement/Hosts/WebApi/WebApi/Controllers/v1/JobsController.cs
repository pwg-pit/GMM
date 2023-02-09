// Copyright (c) Microsoft Corporation.
// Licensed under the MIT license.
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Services.Messages.Requests;
using Services.Messages.Responses;

namespace WebApi.Controllers.v1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/jobs")]
    public class JobsController : ControllerBase
    {
        private readonly IRequestHandler<GetJobsRequest, GetJobsResponse> _getJobsRequestHandler;

        public JobsController(IRequestHandler<GetJobsRequest, GetJobsResponse> getJobsRequestHandler)
        {
            _getJobsRequestHandler = getJobsRequestHandler ?? throw new ArgumentNullException(nameof(getJobsRequestHandler));
        }

        [Authorize(Roles = "Admin")]
        [HttpGet()]
        public async Task<ActionResult<GetJobsResponse>> GetJobsAsync()
        {
            var response = await _getJobsRequestHandler.ExecuteAsync(new GetJobsRequest());
            return Ok(response);
        }
    }
}
