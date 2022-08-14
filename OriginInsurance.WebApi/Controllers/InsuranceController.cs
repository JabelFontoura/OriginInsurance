using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using OriginInsurance.Application.Dtos;
using OriginInsurance.Application.Interfaces;

namespace OriginInsurance.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InsuranceController : ControllerBase
    {
        private readonly IValidator<UserDataDto> _validator;
        private readonly IRiskCalculationService _service;

        public InsuranceController(IValidator<UserDataDto> validator, IRiskCalculationService service)
        {
            _validator = validator;
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult> CalculateRisk([FromBody] UserDataDto userDataDto)
        {
            var result = await _validator.ValidateAsync(userDataDto);

            if (!result.IsValid)
                return BadRequest(result);

            return Ok(await _service.Calculate(userDataDto));
        }
    }
}
