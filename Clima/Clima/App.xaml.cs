using Prism;
using Prism.Ioc;
using Clima.ViewModels;
using Clima.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Clima.Services;
using Clima.Helpers;
using System.IO;
using System;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Clima
{
    public partial class App
    {
		static SQLiteHelper db;
		/* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
		public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("NavigationPage/MainPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
			containerRegistry.RegisterForNavigation<PesquisaPage, PesquisaPageViewModel>();
			containerRegistry.RegisterForNavigation<DetalhePage, DetalhePageViewModel>();
			containerRegistry.RegisterSingleton<ICidadeService, CidadeService>();
		}

		public static SQLiteHelper SQLiteDb
		{
			get
			{
				if (db == null)
					db = new SQLiteHelper(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Clima.db3"));

				return db;
			}
		}
	}
}
