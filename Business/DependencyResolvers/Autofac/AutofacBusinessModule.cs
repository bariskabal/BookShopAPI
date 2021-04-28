using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete.EFCore.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<BookManager>().As<IBookService>().SingleInstance();
            builder.RegisterType<EFBookRepository>().As<IBookDal>().SingleInstance();

            builder.RegisterType<CategoryManager>().As<ICategoryService>().SingleInstance();
            builder.RegisterType<EFCategoryRepository>().As<ICategoryDal>().SingleInstance();

            builder.RegisterType<AuthorManager>().As<IAuthorService>().SingleInstance();
            builder.RegisterType<EFAuthorRepository>().As<IAuthorDal>().SingleInstance();

            builder.RegisterType<AuthorImageManager>().As<IAuthorImageService>().SingleInstance();
            builder.RegisterType<EFAuthorImageRepository>().As<IAuthorImageDal>().SingleInstance();

            builder.RegisterType<BookImageManager>().As<IBookImageService>().SingleInstance();
            builder.RegisterType<EFBookImageRepository>().As<IBookImageDal>().SingleInstance();

            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();

            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<EFUserRepository>().As<IUserDal>();

            builder.RegisterType<CartItemManager>().As<ICartItemService>();
            builder.RegisterType<EFCartItemRepository>().As<ICartItemDal>();

            builder.RegisterType<AddressManager>().As<IAddressService>();
            builder.RegisterType<EFAddressRepository>().As<IAddressDal>();

            builder.RegisterType<CreditCardManager>().As<ICreditCardService>();
            builder.RegisterType<EFCreditCardRepository>().As<ICreditCardDal>();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
