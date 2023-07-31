using Entities.LinkModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
namespace HotelBooking.Presentation.Controllers;

[Route("api")]
[ApiController]
[Authorize]
public class RootController : ControllerBase
{
    private readonly LinkGenerator _linkGenerator;
    public RootController(LinkGenerator linkGenerator) => _linkGenerator = linkGenerator;


    [HttpGet(Name = "GetRoot")]
    public IActionResult GetRoot([FromHeader(Name = "Accept")] string mediaType)
    {
        if (!mediaType.Contains("application/vnd.hotelbooking.apiroot"))
            return NoContent();

        var links = new List<Link>
            {
                new Link
                {
                    Href = _linkGenerator.GetUriByName(HttpContext, nameof(GetRoot), new { }),
                    Rel = "self",
                    Method = "GET"
                },
                new Link
                {
                    Href = _linkGenerator.GetUriByName(HttpContext, "GetHotels", new { }),
                    Rel = "hotels",
                    Method = "GET"
                },
                new Link
                {
                    Href = _linkGenerator.GetUriByName(HttpContext, "CreateHotel", new { }),
                    Rel = "create_hotel",
                    Method = "POST"
                },
                new Link
                {
                    Href = _linkGenerator.GetUriByName(HttpContext, "GetRoles", new { }),
                    Rel = "roles",
                    Method = "GET"
                },
                new Link
                {
                    Href = _linkGenerator.GetUriByName(HttpContext, "CreateRole", new { }),
                    Rel = "create_role",
                    Method = "POST"
                },
                new Link
                {
                    Href = _linkGenerator.GetUriByName(HttpContext, "GetUsers", new { }),
                    Rel = "users",
                    Method = "GET"
                },
                new Link
                {
                    Href = _linkGenerator.GetUriByName(HttpContext, "CreateUser", new { }),
                    Rel = "create_user",
                    Method = "POST"
                },
                new Link
                {
                    Href = _linkGenerator.GetUriByName(HttpContext, "GetRoomTypes", new { }),
                    Rel = "roomTypes",
                    Method = "GET"
                },
                new Link
                {
                    Href = _linkGenerator.GetUriByName(HttpContext, "CreateRoomType", new { }),
                    Rel = "create_roomType",
                    Method = "POST"
                },
                new Link
                {
                    Href = _linkGenerator.GetUriByName(HttpContext, "CreateFeedback", new { }),
                    Rel = "create_feedback",
                    Method = "POST"
                }
            };

        return Ok(links);
    }
}