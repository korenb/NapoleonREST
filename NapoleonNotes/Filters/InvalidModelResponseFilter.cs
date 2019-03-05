using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NapoleonNotes.Filters
{
    public class InvalidModelResponseFilter : ActionFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                context.Result = new BadRequestResult();
            }
        }
    }
}
