using WebApppf.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.Add(new ServiceDescriptor(typeof(IEntrada),
                     new EntradaRepository()));
builder.Services.Add(new ServiceDescriptor(typeof(ITemporalReserva),
                     new TemporalReservaRepository()));
builder.Services.Add(new ServiceDescriptor(typeof(ILogin),
                     new LoginRepository()));
builder.Services.Add(new ServiceDescriptor(typeof(IAdmin),
                     new AdminRepository()));
builder.Services.Add(new ServiceDescriptor(typeof(IReserva),
                     new ReservaRepository()));
builder.Services.Add(new ServiceDescriptor(typeof(IDetalle),
                     new DetalleRepository()));
builder.Services.AddControllersWithViews();

builder.Services.AddSession(options => {
    options.IdleTimeout = TimeSpan.FromSeconds(3600);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseSession();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Listado}/{action=Index}/{id?}");

app.Run();
