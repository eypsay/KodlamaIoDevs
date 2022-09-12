using Application.Features.Models.Models;
using Application.Features.SubTechnologies.Commands.CreateSubTechnology;
using Application.Features.SubTechnologies.Commands.DeleteSubTechnology;
using Application.Features.SubTechnologies.Commands.UpdateSubTechnology;
using Application.Features.SubTechnologies.Dtos;
using Application.Features.SubTechnologies.Queries.GetByIdSubTechnologyQuery;
using Application.Features.SubTechnologies.Queries.GetListSubTechnology;
using Application.Features.UserSocialMedias.Commands.CreateUserSocialMedia;
using Application.Features.UserSocialMedias.Commands.DeleteUserSocialMedia;
using Application.Features.UserSocialMedias.Commands.UpdateUserSocialMedia;
using Application.Features.UserSocialMedias.Dtos;
using Application.Features.UserSocialMedias.Queries.GetByIdSocialMediaQuery;
using Application.Features.UserSocialMedias.Queries.GetListSocialMediaQuery;
using Core.Application.Requests;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserSocialMediasController : BaseController
    {

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListUserSocialMediaQuery getListUserSocialMediaQuery = new GetListUserSocialMediaQuery { PageRequest = pageRequest };
            var result = await Mediator.Send(getListUserSocialMediaQuery);
            return Ok(result);
        }


        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdUserSocialMediaQuery getByIdUserSocialMediaQuery)
        {
            UserSocialMediaGetByIdDto userSocialMediaGetByIdDto = await Mediator.Send(getByIdUserSocialMediaQuery);
            return Ok(userSocialMediaGetByIdDto);
        }



        [HttpPost]
        public async Task<IActionResult> Add(
            [FromBody] CreateUserSocialMediaCommand createUserSocialMediaCommand)
        {
            CreatedUserSocialMediaDto result = await Mediator.Send(createUserSocialMediaCommand);
            return Created("", result);

        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(
            [FromRoute] DeleteUserSocialMediaCommand deleteUserSocialMediaCommand)
        {
            DeletedUserSocialMediaDto result = await Mediator.Send(deleteUserSocialMediaCommand);
            return Ok(result);

        }



        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateUserSocialMediaCommand updateUserSocialMediaCommand)
        {
            UpdatedUserSocialMediaDto result = await Mediator.Send(updateUserSocialMediaCommand);
            return Ok(result);
        }
    }
}

