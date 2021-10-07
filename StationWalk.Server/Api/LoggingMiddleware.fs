module LoggingMiddleware

open Microsoft.AspNetCore.Http

let logRequest = 
    fun next (httpContext : HttpContext) ->
        Log.instance.Debug("Making {method} call to: {path}", httpContext.Request.Method, httpContext.Request.Path)
        next httpContext