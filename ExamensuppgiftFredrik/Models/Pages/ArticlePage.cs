using System.ComponentModel.DataAnnotations;
using EPiServer;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using Kentorse.Models.Properties;
using Kentorse.Models.Blocks;
using EPiServer.Web;
using Kentorse.Attributes;
using EPiServer.Shell.ObjectEditing;
using Kentorse.SelectionFactory;
using EPiServer.Cms.Shell.UI.ObjectEditing.EditorDescriptors;
using System;

namespace ExamensuppgiftFredrik.Models.Pages
{
    [ContentType(GUID = "196d3a28-e13d-4182-b1e4-51c3cfb55b8f")]
    [ImageUrl("~/Assets/Preview_image/Artikelsida.png")]
    [AvailableContentTypes(Include = new[] { typeof(QuizPage) })]
    public class ArticlePage : NewsListablePage
    {
        // Visa brödsmulor, visa inte i menyn        

        public override void SetDefaultValues(ContentType contentType)
        {
            base.SetDefaultValues(contentType);

            ShowBreadcrumbs = true;
            VisibleInMenu = false;
            RelatedArticleTag = "Artikel";
            DisplayDate = true;
            ArticleType = "default";
        }

        [Display(GroupName = GroupNames.Content, Order = 1)]
        [SelectMany(SelectionFactoryType = typeof(ArticleSelectionFactory))]
        public virtual string ArticleType
        {
            get { return this.GetPropertyValue(page => page.ArticleType) ?? "default"; }
            set { this.SetPropertyValue(page => page.ArticleType, value); }
        }

        [ScaffoldColumn(false)]
        public override string Type { get; set; }

        [Display(
            GroupName = GroupNames.Content,
            Order = 7)]
        [AllowedTypes(new[] {
            typeof(ContactboxBlock),
            typeof(WhitePaperBlock),
            typeof(ContactFormBlock),
            typeof(AccordionBlock)

        })]
        public virtual ContentArea Content { get; set; }

        [Display(
            GroupName = GroupNames.Content,
            Order = 8)]
        [AllowedTypes(new[] {
            typeof(EmployeeExpertiseBlock),
            typeof(VacanciesBlock),
            typeof(PersonBlock),
            typeof(TextAreaBlock),
            typeof(EmployeeQuoteBlock),
            typeof(CurrentProjectsBlock),
            typeof(EmployeeBlock),
            typeof(DefaultBlock),
            typeof(QuoteBlock),
            typeof(ArticlePuffsBlock),
            typeof(VideoBlock),
            typeof(RelatedContentBlock),
            typeof(VideoBlock),
            typeof(AccordionBlock),
            typeof(BlogBlock),
            typeof(LinkWithImageBlock)
        })]
        public virtual ContentArea Content2 { get; set; }

        [Display(
           GroupName = GroupNames.Content,
           Order = 16,
            Name = "Thumbnail image",
            Description = "If there is no thumbnail image, Head image will be used as thumbnail"
            )]
        [UIHint(UIHint.Image)]
        public virtual ContentReference ThumbnailImage { get; set; }

        [Display(
            GroupName = GroupNames.Content,
            Order = 17,
             Name = "Thumbnail image description",
            Description = "Shortly describe the image with text. Example: Blue car."
            )]
        public virtual string ThumbnailAlt { get; set; }

        [Display(GroupName = GroupNames.Content,
            Order = 200,
            Name = "Startdate for event")]
        [CultureSpecific]

        public virtual DateTime StartDate { get; set; }

        [Display(GroupName = GroupNames.Content,
            Order = 200,
            Name = "Location of the event")]
        [CultureSpecific]

        public virtual string EventLocation { get; set; }

        [Display(
          GroupName = GroupNames.Content,
          Order = 210,
           Name = "Text Registration button")]
        public virtual string BtnText
        {
            get { return this.GetPropertyValue(page => page.BtnText) ?? "Anmälan"; }
            set { this.SetPropertyValue(page => page.BtnText, value); }
        }

        [Display(
            GroupName = GroupNames.Content,
            Order = 220,
            Name = "Registrationform events")]
        public virtual string LinkToRegistrationForm { get; set; }



        [CultureSpecific]
        [Display(
            GroupName = GroupNames.RelatedArticles,
            Order = 100
            )]
        public virtual string RelatedArticleTag { get; set; }

        [Display(
            GroupName = GroupNames.RelatedArticles,
            Order = 100)]
        public virtual bool DisplayDate { get; set; }

        [Display(
            GroupName = GroupNames.Settings, Name = "Dölj i Abc-lista",
            Order = 10000)]
        public virtual bool HideInAbcServiceList { get; set; }

        [Display(GroupName = GroupNames.RelatedArticles, Name = "Youtube film", Description = "Ersätter bild vid relaterad artikel", Order = 10000)]
        public virtual YoutubeBlock YoutubeBlock { get; set; }



    }
}