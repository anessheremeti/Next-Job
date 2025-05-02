using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class ContractStatusController : ControllerBase
{
    private readonly IContractStatusService _service;

    public ContractStatusController(IContractStatusService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var items = await _service.GetAllAsync();
        return Ok(items);
    }
}
