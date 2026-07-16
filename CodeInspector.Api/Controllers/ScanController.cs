using CodeInspector.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CodeInspector.Api.Controllers;

[ApiController]
[Route("api/scan")]
public class ScanController : ControllerBase
{
    private readonly IGitService _gitService;

    public ScanController(IGitService gitService)
    {
        _gitService = gitService;
    }

    [HttpPost]
    public async Task<IActionResult> ScanRepository([FromBody] ScanRequest request)
    {
        var folder = await _gitService.CloneRepositoryAsync(
            request.RepositoryUrl,
            request.Branch);

        return Ok(new
        {
            Message = "Repository cloned successfully",
            Folder = folder
        });
    }
}

public class ScanRequest
{
    public string RepositoryUrl { get; set; } = "";

    public string Branch { get; set; } = "main";
}