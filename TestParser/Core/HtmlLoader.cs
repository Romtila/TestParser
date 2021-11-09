using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace TestParser.Core
{
    public class HtmlLoader
    {
        private readonly HttpClient _client;
        private readonly string _url;

        public HtmlLoader(IParserSettings settings)
        {
            _client = new HttpClient();
            _url = $"{settings.BaseUrl}{settings.Prefix}/";
        }

        //Получаем html код страницы №id в string
        public async Task<string> GetSourceByPageId(int id)
        {
            var currentUrl = _url.Replace("{CurrentId}", id.ToString());
            var response = await _client.GetAsync(currentUrl);
            string source = null;

            if (response.StatusCode == HttpStatusCode.OK)
            {
                source = await response.Content.ReadAsStringAsync();
            }

            return source;
        }
    }
}
