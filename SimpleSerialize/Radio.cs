namespace SimpleSerialize
{
    [Serializable]
    public class Radio
    {
        public bool hasTweeters;
        public bool hasSubWoofers;
        public List<double> stationPresets = [];
        public string radioID = "XF-552RR6";

        public override string ToString()
        {
            var presets = string.Join(",", stationPresets.Select(i => i.ToString()).ToList());
            return $"HasTweeters:{hasTweeters} HasSubWoofers:{hasSubWoofers} Station Presets:{presets}";
        }
    }
}
