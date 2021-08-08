using GraphqlDotNetDemo.Src.Models;

using Microsoft.AspNetCore.Mvc;

using System;

namespace GraphqlDotNetDemo.Src.Controllers
{
    [Route("auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public AuthController()
        {
        }

        [HttpPost("grant")]
        public IActionResult Grant([FromBody] AuthRequestBody body)
        {
            if (body.GrantType == GrantTypeEnum.password.ToString())
            {
                return Ok(new AuthResponse
                {
                    AccessToken = Guid.NewGuid().ToString(),
                    AccessTokenExpiracy = "",
                    RefreshToken = Guid.NewGuid().ToString(),
                    RefreshTokenExpiracy = "",
                });
            }

            if (body.GrantType == GrantTypeEnum.refresh_token.ToString())
            {
                return Ok(new AuthResponse
                {
                    AccessToken = Guid.NewGuid().ToString(),
                    AccessTokenExpiracy = "",
                    RefreshToken = Guid.NewGuid().ToString(),
                    RefreshTokenExpiracy = "",
                });
            }

            return BadRequest("unsupported_grant_type");
        }
    }
}
