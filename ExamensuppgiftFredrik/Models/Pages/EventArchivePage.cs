using System;
using System.Collections.Generic;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using ExamensuppgiftFredrik.Models.Properties;
using EPiServer.Web;
using EPiServer.Core;

namespace ExamensuppgiftFredrik.Models.Pages
{
    [ContentType(GUID = "10D64A65-B973-4420-BDE8-AD011E7E9891", DisplayName = "EventArchive")]
    [ImageUrl("~/Assets/Preview_image/EventArkiv.png")]
    [AvailableContentTypes(Include = new[] { typeof(ArticlePage) })]

    public class EventArchivePage : ContentPage
    {
        [UIHint(UIHint.Image)]
        [Display(
            GroupName = GroupNames.Hero,
            Order = 1)]
        public virtual ContentReference HeroImage { get; set; }

        [CultureSpecific]
        [Display(
            GroupName = GroupNames.Hero,
            Order = 2)]
        [UIHint(UIHint.Textarea)]
        public virtual string HeroHeader { get; set; }

        [CultureSpecific]
        [Display(
            GroupName = GroupNames.Hero,
            Order = 3)]
        [UIHint(UIHint.Textarea)]
        public virtual string HeroText { get; set; }

        [CultureSpecific]
        [Display(
           GroupName = GroupNames.Hero,
           Order = 4)]
        public virtual bool HideHero { get; set; }

        [Range(0, 3000)]
        [Display(
             GroupName = GroupNames.Hero,
             Order = 10)]
        public virtual int ImageFocusSmallScreen { get; set; }
        [Display(
           GroupName = GroupNames.Content,
           Order = 1)]
        public virtual string Header { get; set; }

        [Display(
            GroupName = GroupNames.Content,
            Order = 2)]
        public virtual string BtnText { get; set; }

        [Display(
            GroupName = GroupNames.Content,
            Order = 3)]
        public virtual int EventItemsToShow { get; set; }

        [Display(
            GroupName = GroupNames.Content,
            Order = 4)]
        public virtual int EventItemsToShowPerClick { get; set; }
    }

}