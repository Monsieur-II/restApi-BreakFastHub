using BreakFastHub.Services.BreakFasts;
using ErrorOr;

var builder = WebApplication.CreateBuilder(args);


{
    builder.Services.AddControllers();
    builder.Services.AddSingleton<IBreakFastService, BreakFastService>();
}

var app = builder.Build();


{
    //Handling exceptions
    app.UseExceptionHandler("/error");

    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}
