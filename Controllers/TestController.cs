using Microsoft.AspNetCore.Mvc;

[Route("api/test")]
[ApiController]
public class ItemsController : ControllerBase
{
    private static List<string> strings = new List<string>();

    [HttpGet]
    public ActionResult<IEnumerable<string>> GetStrings()
    {
        return Ok(strings);
    }

    [HttpPost]
    public ActionResult PostString([FromQuery] string str)
    {
        strings.Add(str);

        return NoContent();
    }
}