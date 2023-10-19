namespace EntityFrameworkPractice
{
    public class CostumeMiddleware
    {
        private readonly RequestDelegate _requestDelegate;
        public CostumeMiddleware(RequestDelegate requestDelegate)
        {
            _requestDelegate = requestDelegate;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var result = context.Response;
            await _requestDelegate.Invoke(context);
            var result2 = context.Response;

        }
    }
}
