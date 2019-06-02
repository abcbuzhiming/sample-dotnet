using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace SampleAspNetSwagger.Filters
{
    /// <summary>
    /// Operation filter to add the requirement of the custom header
    /// </summary>
    /// https://stackoverflow.com/questions/41493130/web-api-how-to-add-a-header-parameter-for-all-api-in-swagger
    /// https://alexdunn.org/2018/06/29/adding-a-required-http-header-to-your-swagger-ui-with-swashbuckle/
    public class MyHeaderFilter : IOperationFilter
    {
        public void Apply(Operation operation, OperationFilterContext context)
        {
            if (operation.Parameters == null)
                operation.Parameters = new List<IParameter>();

            operation.Parameters.Add(new NonBodyParameter
            {
                Name = "x-user-token",  //参数名称
                In = "header",      //参数放在哪里，query是url里，form是表单型参数,header是http头
                Type = "string",    //参数类型
                Required = false        //是否必须
            });
        }
    }
}