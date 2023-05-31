var Image = require('../Image/Image');

var EventArchiveItem = React.createClass({

    render() {
        var articleType = this.props.data.ArticleType;
var articleTypesArray = articleType.split(",");

var articleTypes = articleTypesArray.map(
    function(object, i) {
                return (


            < p className ={i === 0 ? "section" : "section-secondary"} key ={ i} > { object}</ p >
                );
            }
        );

const convertAbsoluteHref = (redirectUrl) => {
    var redirectUrlHttps = redirectUrl.replace("https://", "");
    var redirectUrlHttp = redirectUrlHttps.replace("http://", "");
    return redirectUrlHttp;
}
        const convertRelativeHref = (redirectUrl) => {
    var origin = window.location.origin;
    var originWithoutHttps = origin.replace("https://", "");
    var originWithoutHttp = originWithoutHttps.replace("http://", "");
    return originWithoutHttp + redirectUrl;
}
const getCorrectHref = (redirectUrl) => {
    var href = "";
    if (redirectUrl.indexOf('://') > 0 || redirectUrl.indexOf('//') === 0)
    {
        href = convertAbsoluteHref(redirectUrl);
    }
    else
    {
        href = convertRelativeHref(redirectUrl)
            }

    return href
        }
        const current = new Date();
const currentDate = `${current.getDate()}/${ current.getMonth() + 1}/${ current.getFullYear()}`;


const customEventTracking = (redirectUrl, text, key, location) => {
try
{
    _paq.push(['setCustomDimension', customDimensionId = 2, customDimensionValue = location]);
_paq.push(['trackEvent', 'Link Clicks', 'redirect', text, key, { dimension1: getCorrectHref(redirectUrl) }]);
            } catch (error)
{

}
        }

        var button = "";
if (this.props.data.BtnText && this.props.data.LinkToRegForm)
{
    button = < a onClick ={ (e) => customEventTracking(this.props.data.LinkToRegForm, this.props.data.BtnText, 1, 'main')}
    href ={ this.props.data.LinkToRegForm}
    className = "no-touchevents btn--black-border btn-margin" >

< span >{ this.props.data.BtnText}</ span >


</ a >
        }


return (

    < div className = "event-archive__item" >


         < div className ={ this.props.data.DatePassed ? "overlay" : null}>

                < div className = "event-archive__image-wrap" >

                     < a onClick ={ (e) => customEventTracking(this.props.data.LinkUrl, this.props.data.Header, 0, 'main')}
className = "news-archive__link" href ={ this.props.data.LinkUrl}>
                            {
    this.props.data.ImageUrl.length > 0 &&

       < Image imageUrl ={
        this.props.thumbnailImg ?
this.props.thumbnailImg
: this.props.data.ImageUrl}
    alt ={
        this.props.thumbnailAlt ?
       this.props.thumbnailAlt
       : this.props.data.ImageAlt}
    imgTagClass = "event-archive__image"
                                    isLazyLoaded
                                height = "250"
                                width = "550"
                                />
                            }
                        </ a >

                    </ div >

                    < div className = "event-archive__text-wrapper" >
 

                         < div className = "article-types" >{ articleTypes}</ div >
      
                              < p className = "event-archive__header" >{ this.props.data.Header}</ p >

                        {
    this.props.data.DatePassed ? < div className = "event-archive__date_button" >

       < div className = "event-location" > { this.props.data.EventLocation}</ div >

        </ div > :
                        < div className = "event-archive__date_button" >
 

                                 < div className = "event-date" >{ this.props.data.StartDate != null ? this.props.data.StartDate : "Datum kommer"}</ div >
      
                                      < div className = "event-location" > { this.props.data.EventLocation}</ div >
           

                                           < div >
                                    { this.props.NotFoundStyle ? null : < span >{ button}</ span >}
                                </ div >


                        </ div >
                        }
                    </ div >
                </ div >
            </ div >
        );
    }
});
module.exports = EventArchiveItem;