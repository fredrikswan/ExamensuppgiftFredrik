using EPiServer;
using EPiServer.Core;
using EPiServer.Framework.Localization;
using EPiServer.ServiceLocation;
using EPiServer.Web.Routing;
using Kentorse.Helpers;
using Kentorse.Helpers.Interfaces;
using Kentorse.Models.Pages;

namespace ExamensuppgiftFredrik.Models.ViewModels
{
    /// <summary> 
    /// Basklass som hanterar gemensam logik för alla sidor, t ex huvudmeny och sidfot.
    /// </summary> 
    public class BaseViewModel
    {
        IContentUtilities _contentUtilties = ServiceLocator.Current.GetInstance<IContentUtilities>();
        IPageUtilities _pageUtilities = ServiceLocator.Current.GetInstance<IPageUtilities>();
        IMainMenuUtilities _mainMenuUtilities = ServiceLocator.Current.GetInstance<IMainMenuUtilities>();

        private static PageData CurrentPage
        {
            get
            {
                return ServiceLocator.Current.GetInstance<IPageRouteHelper>().Page;
            }
        }

        private static StartPage StartPage
        {
            get
            {
                return ServiceLocator.Current.GetInstance<IContentRepository>().Get<StartPage>(ContentReference.StartPage);
            }
        }


        public MainMenu MainMenuData { get; set; }
        public Breadcrumbs BreadcrumbData { get; set; }
        public Footer FooterData { get; set; }
        public string LinkToSearchPage { get; set; }
        public string LinkToJobsPage { get; set; }
        public string MetaTitle { get; set; }
        public bool MetaNoIndex { get; set; }
        public string MetaDescription { get; set; }
        public string MetaImageUrl { get; set; }
        public string Language { get; set; }
        public string ScriptTags { get; set; }
        public string CookieConsentScript { get; set; }
        public string SearchBoxPlaceholder { get; set; }
        public string SearchBoxClose { get; set; }
        public string SearchButton { get; set; }
        public string GTMBodyTag { get; set; }


        public BaseViewModel()
        {
            MainMenuData = _mainMenuUtilities.GetMainMenu();
            BreadcrumbData = _pageUtilities.GetBreadcrumbItems(CurrentPage.PageLink);
            MetaNoIndex = ((ContentPage)CurrentPage).MetaNoIndex;
            FooterData = _pageUtilities.GetFooterData();
            LinkToSearchPage = _contentUtilties.GetUrl(StartPage.LinkToSearchPage);
            LinkToJobsPage = _contentUtilties.GetUrl(StartPage.LinkToJobsPage);
            Language = CurrentPage?.MasterLanguage?.Name ?? "sv";
            GTMBodyTag = StartPage?.GTMBodyTag ?? string.Empty;
            ScriptTags = StartPage?.ScriptTags ?? string.Empty;
            CookieConsentScript = StartPage?.CookieConsentScript ?? string.Empty;
            SearchButton = LocalizationService.Current.GetString("/placeholders/search/btn");
            SearchBoxPlaceholder = LocalizationService.Current.GetString("/placeholders/search/boxph");
            SearchBoxClose = LocalizationService.Current.GetString("/placeholders/search/boxclose");
        }
    }
}