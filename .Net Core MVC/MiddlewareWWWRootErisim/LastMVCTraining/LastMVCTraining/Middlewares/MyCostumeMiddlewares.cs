namespace LastMVCTraining.Middlewares
{
    public class MyCostumeMiddlewares
    {
        private readonly RequestDelegate _delegate;

        public MyCostumeMiddlewares(RequestDelegate @delegate)
        {
            _delegate = @delegate;
        }




        public async Task Invoke(HttpContext context)
        {
            string a = "123";
            
            await _delegate.Invoke(context);

        }
    }
}
