using Application.Features.Models.Models;
using Application.Features.ProgrammingLanguages.Dtos;
using Application.Features.ProgrammingLanguages.Queries.GetByIdProgrammingLanguage;
using Application.Features.SubTechnologies.Commands.CreateSubTechnology;
using Application.Features.SubTechnologies.Commands.DeleteSubTechnology;
using Application.Features.SubTechnologies.Commands.UpdateSubTechnology;
using Application.Features.SubTechnologies.Dtos;
using Application.Features.SubTechnologies.Queries.GetByIdSubTechnologyQuery;
using Application.Features.SubTechnologies.Queries.GetListSubTechnology;
using Core.Application.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubTechnologyController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListSubTechnologyQuery getListSubTechnologyQuery = new GetListSubTechnologyQuery { PageRequest = pageRequest };
            SubTechnologyListModel result = await Mediator.Send(getListSubTechnologyQuery);
            return Ok(result);
        }


        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdSubTechnologyQuery getByIdSubTechnologyQuery)
        {
            SubTechnologyGetByIdDto subTechnologyGetByIdDto = await Mediator.Send(getByIdSubTechnologyQuery);
            return Ok(subTechnologyGetByIdDto);
        }



        [HttpPost]
        public async Task<IActionResult> Add(
            [FromBody] CreateSubTechnologyCommand createSubTechnologyCommand)
        {
            CreatedSubTechnologyDto result = await Mediator.Send(createSubTechnologyCommand);
            return Created("", result);

        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(
            [FromRoute] DeleteSubTechnologyCommand deleteSubTechnologyCommand)
        {
            DeletedSubTechnologyDto result = await Mediator.Send(deleteSubTechnologyCommand);
            return Ok(result);

        }



        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateSubTechnologyCommand subTechnologyCommand)
        {
            UpdatedSubTechnologyDto result = await Mediator.Send(subTechnologyCommand);
            return Ok(result);
        }
    }
}
