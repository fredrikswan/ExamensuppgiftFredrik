var EventArchiveItem = require('./EventArchiveItem');
var Breadcrumbs = require('../Breadcrumbs/Breadcrumbs');
var Image = require('../Image/Image');


var EventArchive = React.createClass({
    getInitialState() {
        return {
            menuData: this.props.menuData,
            page: this.props.eventItemsToShow,
            eventItemsToShowPerClick: this.props.eventItemsToShowPerClick,
        };
    },
    componentDidMount() {
        this.setFlowtype();
    },
    componentDidUpdate() {
        this.setFlowtype();
    },
    setFlowtype() {
        $(this.refs.title).flowtype({
            minFont: 35,
            maxFont: 48,
            fontRatio: 16
        });
    },
    handlePagination() {
        var self = this;
        this.setState({
            page: self.state.page + self.state.eventItemsToShowPerClick
        });
        this.handleSearch();
    },
    handleSearch(event) {
        if (event) {
            event.preventDefault();
        }
    },
    changeArticle(obj, e) {
        var currentURL =
            window.location.protocol +
            "//" +
            window.location.host +
            window.location.pathname +
            "?articletype=" +
            obj;
        window.history.pushState({ path: currentURL }, "", currentURL);

        var filteredArticles = this.props.eventList.NewsItems.filter(function (el) {
            return el.ArticleType == obj;
        });

        this.setState({
            sortedArticles: filteredArticles,
            articleClicked: obj,
        });
    },
    render() {
        var eventArchiveItem = [];
        articlesFilteredTotal = 0;
        var articleTypes = this.props.articleTypes.map(
            function (object, i) {
                return (
                    <span
                        className={
                            "jobs__offices" +
                            (this.state.articleClicked === object.Value
                                ? " jobs__offices--active"
                                : "")
                        }
                        ref={"articletype" + i}
                        onClick={this.changeArticle.bind(this, object.Value)}
                        key={i}
                    >
                        {object.Name}
                    </span>
                );
            }.bind(this)
        );
        if (this.props.eventList.NewsItems != null) {
            eventArchiveItem = this.props.eventList.NewsItems
                .map(function (object, i) {
                    return <EventArchiveItem key={i} data={object} thumbnailImg={object.ThumbnailImage} thumbnailAlt={object.ThumbnailAlt} />;
                });
            articlesFilteredTotal = eventArchiveItem.length
            eventArchiveItem = eventArchiveItem.slice(0, this.state.page)
        }
        if (this.props.eventList.NewsItems != null && this.state.articleClicked && this.state.articleClicked !== "all" && this.state.articleClicked !== undefined) {
            eventArchiveItem = this.props.eventList.NewsItems
                .filter((article) => {
                    if (this.state.articleClicked && this.state.articleClicked !== "all" && this.state.articleClicked !== undefined) {
                        return article.ArticleType.includes(this.state.articleClicked);
                    } else {
                        return article;
                    }
                })
                .map(function (object, i) {
                    return <EventArchiveItem key={i} data={object} thumbnailImg={object.ThumbnailImage} thumbnailAlt={object.ThumbnailAlt} />;
                });
            articlesFilteredTotal = eventArchiveItem.length
            eventArchiveItem = eventArchiveItem.slice(0, this.state.page)
        }
        return (
            <div className="event-archive">
                <div className="breadcrumbs-flex-div case-page-hero__wrapper">
                    <div className={"case-page-hero__image-wrapper " + (this.props.heroHeader != null ? "linear-background" : "")}>
                        {
                            this.props.heroHeader != null ?
                                <div className="case-page-hero__image-content-wrapper">
                                    <h1>{this.props.heroHeader}</h1>
                                    <div style={{ color: "#FFF" }} dangerouslySetInnerHTML={{ __html: this.props.heroText }} />
                                </div>
                                : null
                        }
                        <Image imageUrl={this.props.heroImage} imgTagClass="case-page__hero-image" alt="..." height="735" width="960" />
                    </div>
                    {
                        this.props.breadcrumbs &&
                        <Breadcrumbs items={this.props.breadcrumbs} placeholder={this.props.breadcrumbs.HomePlaceholder} />
                    }
                </div>
                <div className="event-archive__wrapper">
                    <h1 className="event-archive__title" ref="title">{this.props.header}</h1>
                    <div className="jobs__top-wrapper">
                        <div className="jobs__offices-wrapper">
                            {articleTypes}
                        </div>
                    </div>
                    <div className="event-archive__items">
                        {eventArchiveItem}
                    </div>
                    <div className="event-archive__button-wrap">
                        {(this.props.eventList.NewsItems.length > this.props.eventItemsToShow) && (this.state.page < this.props.eventList.NewsItems.length) && (articlesFilteredTotal > this.state.page) &&
                            <div className="event-archive__button-inner-wrap">
                                <a className="event-archive__button btn btn--case" onClick={this.handlePagination}>{this.props.btnText}</a>
                            </div>
                        }
                    </div>
                </div>
            </div>
        );
    }
});
module.exports = EventArchive;