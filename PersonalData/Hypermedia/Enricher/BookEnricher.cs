using System.Text;
using Microsoft.AspNetCore.Mvc;
using PersonalData.Data.VO;
using PersonalData.Hypermedia.Constants;

namespace PersonalData.Hypermedia.Enricher
{
	public class BookEnricher : ContentResponseEnricher<BookVO>
	{
        private readonly object _lock = new object();

        public BookEnricher()
		{
		}

        protected override Task EnrichModel(BookVO content, IUrlHelper urlHelper)
        {
            var path = "api/v1/Book";
            string link = GetLink(content.Id, urlHelper, path);

            content.Links.Add(new HyperMediaLink()
            {
                Action = HttpActionVerb.GET,
                Href = link,
                Rel = RelationType.self,
                Type = ResponseTypeFormat.DefaultGet
            });
            content.Links.Add(new HyperMediaLink()
            {
                Action = HttpActionVerb.POST,
                Href = link,
                Rel = RelationType.self,
                Type = ResponseTypeFormat.DefaultPost
            });
            content.Links.Add(new HyperMediaLink()
            {
                Action = HttpActionVerb.PUT,
                Href = link,
                Rel = RelationType.self,
                Type = "int"
            });
            content.Links.Add(new HyperMediaLink()
            {
                Action = HttpActionVerb.DELETE,
                Href = link,
                Rel = RelationType.self,
                Type = ResponseTypeFormat.DefaultGet
            });
            return null;
        }

        private string GetLink(long id, IUrlHelper urlHelper, string path)
        {
            lock (_lock)
            {
                var url = new
                {
                    controller = path,
                    id = id
                };
                return new StringBuilder(urlHelper.Link("DefaultApi", url)).Replace("%2F", "/").ToString();
            }
        }
    }
}

