using DotNetCore.Objects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DotNetCore.AspNetCore
{
    public class Result : IActionResult
    {
        private readonly IResult _result;

        public Result(IResult result)
        {
            _result = result;
        }

        public async Task ExecuteResultAsync(ActionContext context)
        {
            var statusCode = _result.Success ? StatusCodes.Status200OK : StatusCodes.Status422UnprocessableEntity;

            var objectResult = new ObjectResult(_result.Message) { StatusCode = statusCode };

            await objectResult.ExecuteResultAsync(context);
        }
    }
}
