namespace Homework15.Middlewares;

public class BookingRestrictionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IConfiguration _configuration;

  
    public BookingRestrictionMiddleware(RequestDelegate next, IConfiguration configuration)
    {
        _next = next;
        _configuration = configuration;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        
        bool isBookingNotAllowed = _configuration.GetValue<bool>("BookingNotAllowed");

        
        if (isBookingNotAllowed && (context.Request.Path == "/" || context.Request.Path.StartsWithSegments("/Booking")))
        {
            context.Response.ContentType = "text/html; charset=utf-8";
            await context.Response.WriteAsync("<h2 style='color:red; text-align:center; margin-top:50px;'>Booking is currently disabled by administration!</h2>");
            return; 
        }

       
        await _next(context);
    }
}