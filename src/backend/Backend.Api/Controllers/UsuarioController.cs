using Backend.Api.Bases;
using Backend.Application.Configurations;
using Backend.Application.Validators.Usuarios;
using Backend.Domain.Usuarios.ApplicationServices;
using Backend.Domain.Usuarios.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Api.Controllers
{
    [Route("api/usuarios")]
    public class UsuarioController : MainController
    {
        private readonly AdicionarUsuarioRequestValidator _validator;
        private readonly IUsuarioApplicationService _applicationService;

        public UsuarioController(AdicionarUsuarioRequestValidator validator, IUsuarioApplicationService applicationService)
        {
            _validator = validator;
            _applicationService = applicationService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] AdicionarUsuarioRequest request)
        {
            if (!ModelState.IsValid)
            {
                return CustomResponseError(ModelState);
            }

            var validateResult = _validator.Validate(request);
            if (validateResult.IsValid)
            {
                return CustomResponse((CustomValidationResult) await _applicationService.Adicionar(request));
            }

            return CustomResponseError(validateResult);
        }
    }
}
