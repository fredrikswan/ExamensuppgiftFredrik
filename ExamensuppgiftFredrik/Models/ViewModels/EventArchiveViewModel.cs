using EPiServer.Core;
using ExamensuppgiftFredrik.Models.Pages;
using ExamensuppgiftFredrik.SelectionFactory;
using System.Collections;
using System.Collections.Generic;

namespace ExamensuppgiftFredrik.Models.ViewModels
{
    public class EventArchiveViewModel : BaseViewModel
    {
        public EventArchivePage CurrentPage { get; set; }
        public NewsList EventList { get; set; }
        public string BtnText { get; set; }
        public int EventItemsToShow { get; set; }
        public int EventItemsToShowPerClick { get; set; }
        public List<ArticleType> ArticleTypes { get; set; }
        public string HeroImage { get; set; }
        public string HeroTitle { get; set; }
        public string HeroText { get; set; }
        public bool HideHero { get; set; }
        public int HeroImageFocusSmallScreen { get; set; }
        public string EventLocation { get; set; }


    }
    public class ArticleType
    {
        public string Value { get; set; }
        public string Name { get; set; }
    }

}
