var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// ****************** DAPPERS ******************
builder.Services.AddScoped<Multiloja_DAL.Dapper.Interfaces.IDataAccessDapper, Multiloja_DAL.Dapper.DataAccessDapper>();


// ****************** SERVICES ******************
builder.Services.AddScoped<Multiloja_BLL.Services.StatusServices.Interfaces.IStatusService, Multiloja_BLL.Services.StatusServices.StatusService>();
builder.Services.AddScoped<Multiloja_BLL.Services.ProdutoServices.Interfaces.IProdutoService, Multiloja_BLL.Services.ProdutoServices.ProdutoService>();
builder.Services.AddScoped<Multiloja_BLL.Services.ClienteServices.Interfaces.IClienteService, Multiloja_BLL.Services.ClienteServices.ClienteService >();
builder.Services.AddScoped<Multiloja_BLL.Services.CarrinhoServices.Interfaces.ICarrinhoService, Multiloja_BLL.Services.CarrinhoServices.CarrinhoService>();
builder.Services.AddScoped<Multiloja_BLL.Services.DocumentoServices.Interfaces.IDocumentoService, Multiloja_BLL.Services.DocumentoServices.DocumentoService>();
builder.Services.AddScoped<Multiloja_BLL.Services.TipoDocumentoServices.Interfaces.ITipoDocumentoService, Multiloja_BLL.Services.TipoDocumentoServices.TipoDocumentoService>();


// ****************** REPOSITORIES ******************
builder.Services.AddScoped<Multiloja_DAL.Repositories.StatusRepositories.Interfaces.IStatusRepository, Multiloja_DAL.Repositories.StatusRepositories.StatusRepository>();
builder.Services.AddScoped<Multiloja_DAL.Repositories.ClienteRepositories.Interfaces.IClienteRepository, Multiloja_DAL.Repositories.ClienteRepositories.ClienteRepository>();
builder.Services.AddScoped<Multiloja_DAL.Repositories.ProdutoRepositories.Interfaces.IProdutoRepository, Multiloja_DAL.Repositories.ProdutoRepositories.ProdutoRepository>();
builder.Services.AddScoped<Multiloja_DAL.Repositories.CarrinhoRepositories.Interfaces.ICarrinhoRepository, Multiloja_DAL.Repositories.CarrinhoRepositories.CarrinhoRepository>();
builder.Services.AddScoped<Multiloja_DAL.Repositories.DocumentoRepositories.Interfaces.IDocumentoRepository, Multiloja_DAL.Repositories.DocumentoRepositories.DocumentoRepository>();
builder.Services.AddScoped<Multiloja_DAL.Repositories.TipoDocumentoRepositories.Interfaces.ITipoDocumentoRepository, Multiloja_DAL.Repositories.TipoDocumentoRepositories.TipoDocumentoRepository>();

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

app.MapControllerRoute(
    name: "default",
    pattern: "api/{controller=Index}/{action=Index}/{id?}");

app.Run();
