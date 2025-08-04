using Microsoft.EntityFrameworkCore;
using Parcoist.Business.Abstract;
using Parcoist.Business.Concrete;
using Parcoist.DataAccess.Abstract;
using Parcoist.DataAccess.Concrete;
using Parcoist.DataAccess.EntityFramework;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IAdminDal, EfAdminDal>();
builder.Services.AddScoped<IAdminService, AdminManager>();

builder.Services.AddScoped<IAdressDal, EfAdressDal>();
builder.Services.AddScoped<IAdressService, AdressManager>();

builder.Services.AddScoped<IBrandDal, EfBrandDal>();
builder.Services.AddScoped<IBrandService, BrandManager>();

builder.Services.AddScoped<IBrandCategoryDal, EfBrandCategoryDal>();
builder.Services.AddScoped<IBrandCategoryService, BrandCategoryManager>();

builder.Services.AddScoped<ICategoryDal, EfCategoryDal>();
builder.Services.AddScoped<ICategoryService, CategoryManager>();

builder.Services.AddScoped<ICityDal, EfCityDal>();
builder.Services.AddScoped<ICityService, CityManager>();

builder.Services.AddScoped<IContactDal, EfContactDal>();
builder.Services.AddScoped<IContactService, ContactManager>();

builder.Services.AddScoped<ICustomerDal, EfCustomerDal>();
builder.Services.AddScoped<ICustomerService, CustomerManager>();

builder.Services.AddScoped<ICustomerCouponDal, EfCustomerCouponDal>();
builder.Services.AddScoped<ICustomerCouponService, CustomerCouponManager>();

builder.Services.AddScoped<ICustomerFavoryDal, EfCustomerFavoryDal>();
builder.Services.AddScoped<ICustomerFavoryService, CustomerFavoryManager>();

builder.Services.AddScoped<IDeliveryDal, EfDeliveryDal>();
builder.Services.AddScoped<IDeliveryService, DeliveryManager>();

builder.Services.AddScoped<IDeliveryStatusDal, EfDeliveryStatusDal>();
builder.Services.AddScoped<IDeliveryStatusService, DeliveryStatusManager>();

builder.Services.AddScoped<IDistrictDal, EfDisctrictDal>();
builder.Services.AddScoped<IDisctrictService, DisctrictManager>();

//builder.Services.AddScoped<IFeatureTypeDal, EfFeatureTypeDal>();
//builder.Services.AddScoped<IFeatureTypeCateg, FeatureTypeManager>();

builder.Services.AddScoped<IFeatureTypeCategoryDal, EfFeatureTypeCategoryDal>();
builder.Services.AddScoped<IFeatureTypeCategoryService, FeatureTypeCategoryManager>();

builder.Services.AddScoped<IFeatureTypeDal, EfFeatureTypeDal>();
builder.Services.AddScoped<IFeatureTypeService, FeatureTypeManager>();

builder.Services.AddScoped<ILogoDal, EfLogoDal>();
builder.Services.AddScoped<ILogoService, LogoManager>();

builder.Services.AddScoped<IOrderDal, EfOrderDal>();
builder.Services.AddScoped<IOrderService, OrderManager>();

builder.Services.AddScoped<IOrderBrandStatusDal, EfOrderBrandStatusDal>();
builder.Services.AddScoped<IOrderBrandStatusService, OrderBrandStatusManager>();

builder.Services.AddScoped<IOrderItemDal, EfOrderItemDal>();
builder.Services.AddScoped<IOrderItemService, OrderItemManager>();

builder.Services.AddScoped<IPaymentCardDal, EfPaymentCard>();
builder.Services.AddScoped<IPaymentCardService, PaymentCardManager>();

builder.Services.AddScoped<IPaymentMethodDal, EfPaymentMethodDal>();
builder.Services.AddScoped<IPaymentMethodService, PaymentMethodManager>();

builder.Services.AddScoped<IProductDal, EfProductDal>();
builder.Services.AddScoped<IProductService, ProductManager>();

builder.Services.AddScoped<IProductImageDal, EfProductImageDal>();
builder.Services.AddScoped<IProductImageService, ProductImageManager>();

builder.Services.AddScoped<IProductVariantValueDal, EfProductVariantValueDal>();
builder.Services.AddScoped<IProductVariantValueService, ProductVariantValueManager>();

builder.Services.AddScoped<IReturnImageDal, EfReturnImageDal>();
builder.Services.AddScoped<IReturnImageService, ReturnImageManager>();

builder.Services.AddScoped<IReturnItemDal, EfReturnItemDal>();
builder.Services.AddScoped<IReturnItemService, ReturnItemManager>();

builder.Services.AddScoped<IReturnProcessDal, EfReturnProcessDal>();
builder.Services.AddScoped<IReturnProcessService, ReturnProcessManager>();

builder.Services.AddScoped<IReturnReasonDal, EfReturnReasonDal>();
builder.Services.AddScoped<IReturnReasonService, ReturnReasonManager>();

builder.Services.AddScoped<IReturnRequestDal, EfReturnRequestDal>();
builder.Services.AddScoped<IReturnRequestService, ReturnRequestManager>();

builder.Services.AddScoped<IReturnStatusDal, EfReturnStatusDal>();
builder.Services.AddScoped<IReturnStatusService, ReturnStatusManager>();

builder.Services.AddScoped<ISliderDal, EfSliderDal>();
builder.Services.AddScoped<ISliderService, SliderManager>();

builder.Services.AddScoped<IUserCommentDal, EfUserCommentDal>();
builder.Services.AddScoped<IUserCommentService, UserCommentManager>();

builder.Services.AddScoped<IFeatureValueDal, EfFeatureValueDal>();
builder.Services.AddScoped<IFeatureValueService, FeatureValueManager>();

builder.Services.AddScoped<IProductVariantCombinationDal, EfProductVariantCombinationDal>();
builder.Services.AddScoped<IProductVariantCombinationService, ProductVariantCombinationManager>();

builder.Services.AddScoped<IProductCommentDal, EfProductCommentDal>();
builder.Services.AddScoped<IProductCommentService, ProductCommentManager>();

builder.Services.AddScoped<IActionLogDal, EfActionLogDal>();
builder.Services.AddScoped<IActionLogService, ActionLogManager>();

builder.Services.AddDbContext<ParcoContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
        b => b.MigrationsAssembly("Parcoist.DataAccess"))); // ← önemli satır

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Default}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
