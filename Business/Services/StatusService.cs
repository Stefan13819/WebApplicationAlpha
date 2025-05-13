

/*
  public async Task<StatusResult> GetStatusesAsync()
    {
        var result = await _statusRepository.GetAllAsync();

        return result.Succeeded
            ? new StatusResult
            {
                Succeeded = true,
                StatusCode = result.StatusCode,
                Result = result.Result.Select(e => new Status
                {
                    Id = e.Id,
                    StatusName = e.StatusName
                }).ToList() // mozda treba ovo / ?? new List<Status>()
            }
            : new StatusResult
            {
                Succeeded = false,
                Error = "No statuses found."
            };
    }
 */