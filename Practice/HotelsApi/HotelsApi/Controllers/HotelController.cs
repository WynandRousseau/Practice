using HotelsApi.BusinessLogic;
using HotelsApi.BusinessServiceInterface;
using HotelsApi.Models;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class HotelController : ControllerBase, IHotelService
{
    private readonly UserService _userService;
    private readonly DistanceLogic _distanceLogic;

    public HotelController(UserService userService, DistanceLogic distanceLogic)
    {
        _userService = userService;
        _distanceLogic = distanceLogic;
    }

    [HttpPost("nearest-user")]
    public async Task<IEnumerable<Hotel>> GetNearestUser([FromBody] IEnumerable<Hotel> hotels)
    {
        IEnumerable<User> users = await _userService.GetUsersAsync();
        IEnumerable<Hotel> nearestUsersPerHotel = _distanceLogic.FindNearestUserPerHotel(hotels, users);

        return (IEnumerable<Hotel>)Ok(nearestUsersPerHotel);
    }

}
