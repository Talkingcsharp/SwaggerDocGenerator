using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwaggerDocGenerator.SDG.Routes.RouteResponses
{
    public class OpenApiRouteResponse
    {
        public Dictionary<string, OpenApiRouteResponseBody>? ResponseCodes { get; set; }
    }
}
