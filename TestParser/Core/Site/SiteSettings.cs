namespace TestParser.Core.Site
{
    class SiteSettings : IParserSettings
    {
        public SiteSettings(int start, int end)
        {
            StartPoint = start;
            EndPoint = end;
        }

        public string BaseUrl { get; set; } = "https://www.avito.ru/rossiya/noutbuki/apple-ASgCAQICAUCo5A0U9Nlm?";
        public string Prefix { get; set; } = "p={CurrentId}&";
        public int StartPoint { get; set; }
        public int EndPoint { get; set; }
    }
}
