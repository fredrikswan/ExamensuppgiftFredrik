using System.Web.Mvc;
using EPiServer.Web.Mvc;
using Kentorse.Models.Pages;
using Kentorse.Models.ViewModels;
using Kentorse.Helpers;
using EPiServer.ServiceLocation;
using EPiServer;
using EPiServer.Core;
using System.Linq;
using Kentorse.SelectionFactory;
using System.Collections.Generic;
using Kentorse.Models.Blocks;

namespace ExamensuppgiftFredrik.Controllers
{
    public class NewsArchiveController : BaseController<NewsArchivePage>
    {
        public ActionResult Index(NewsArchivePage currentPage)
        {
            var contentRepository = ServiceLocator.Current.GetInstance<IContentRepository>();
            var startPage = contentRepository.GetChildren<StartPage>(ContentReference.RootPage).FirstOrDefault();


            var model = new NewsArchiveViewModel
            {
                CurrentPage = currentPage,
                NewsList = PageUtilities.GetArticlesForNewsArchivePage(currentPage.PageLink, startPage.WordpressAPIUrl),
                BtnText = currentPage.BtnText,
                NewsItemsToShow = currentPage.NewsItemsToShow == 0 ? 7 : currentPage.NewsItemsToShow,
                NewsItemsToShowPerClick = currentPage.NewsItemsToShowPerClick == 0 ? 8 : currentPage.NewsItemsToShowPerClick,
                MetaTitle = currentPage.MetaTitle ?? currentPage.Name,
                MetaDescription = currentPage.MetaDescription,
                MetaImageUrl = ContentUtilities.GetMetaImageUrl(currentPage.MetaImage),
                ArticleTypes = GetAllArticleTypes().ToList()
            };

            return View(model);
        }

        private IEnumerable<ArticleType> GetAllArticleTypes()
        {
            yield return new ArticleType { Name = "Alla", Value = "all" };
            yield return new ArticleType { Name = "Nyhet", Value = "news" };
            yield return new ArticleType { Name = "Event", Value = "event" };
            yield return new ArticleType { Name = "Webinarium", Value = "webinar" };
            yield return new ArticleType { Name = "Pressmeddelande", Value = "pressrelease" };
            yield return new ArticleType { Name = "Blogg", Value = "blog" };
        }
    }

}