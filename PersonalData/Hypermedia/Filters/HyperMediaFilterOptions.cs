using PersonalData.Hypermedia.Abstract;

namespace PersonalData.Hypermedia.Filters
{
	public class HyperMediaFilterOptions
	{
		public List<IResponseEnricher> ContentResponseEnricherList = new List<IResponseEnricher>();
	}
}

