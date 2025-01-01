using Newtonsoft.Json;
namespace FreelancerAlerts
{
    public class RootObject
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("result")]
        public Result Result { get; set; }

        [JsonProperty("request_id")]
        public string RequestId { get; set; }
    }

    public class Result
    {
        [JsonProperty("projects")]
        public List<Project> Projects { get; set; }

        [JsonProperty("total_count")]
        public int TotalCount { get; set; }
    }
    public class Project
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("owner_id")]
        public int OwnerId { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("seo_url")]
        public string SeoUrl { get; set; }

        [JsonProperty("currency")]
        public Currency Currency { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("submitdate")]
        public long SubmitDate { get; set; }

        [JsonProperty("preview_description")]
        public string PreviewDescription { get; set; }

        [JsonProperty("deleted")]
        public bool Deleted { get; set; }

        [JsonProperty("nonpublic")]
        public bool NonPublic { get; set; }

        [JsonProperty("hidebids")]
        public bool HideBids { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("bidperiod")]
        public int BidPeriod { get; set; }

        [JsonProperty("budget")]
        public Budget Budget { get; set; }

        [JsonProperty("featured")]
        public bool Featured { get; set; }

        [JsonProperty("urgent")]
        public bool Urgent { get; set; }

        [JsonProperty("bid_stats")]
        public BidStats BidStats { get; set; }

        [JsonProperty("time_submitted")]
        public long TimeSubmitted { get; set; }

        [JsonProperty("time_updated")]
        public long TimeUpdated { get; set; }

        [JsonProperty("upgrades")]
        public Upgrades Upgrades { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }

        [JsonProperty("hireme")]
        public bool HireMe { get; set; }

        [JsonProperty("frontend_project_status")]
        public string FrontendProjectStatus { get; set; }

        [JsonProperty("location")]
        public Location Location { get; set; }

        [JsonProperty("local")]
        public bool Local { get; set; }

        [JsonProperty("negotiated")]
        public bool Negotiated { get; set; }

        [JsonProperty("time_free_bids_expire")]
        public long TimeFreeBidsExpire { get; set; }

        [JsonProperty("pool_ids")]
        public List<string> PoolIds { get; set; }

        [JsonProperty("enterprise_ids")]
        public List<object> EnterpriseIds { get; set; }

        [JsonProperty("is_escrow_project")]
        public bool IsEscrowProject { get; set; }

        [JsonProperty("is_seller_kyc_required")]
        public bool IsSellerKycRequired { get; set; }

        [JsonProperty("is_buyer_kyc_required")]
        public bool IsBuyerKycRequired { get; set; }

        [JsonProperty("enterprises")]
        public List<object> Enterprises { get; set; }

        [JsonProperty("project_reject_reason")]
        public ProjectRejectReason ProjectRejectReason { get; set; }

        [JsonProperty("group_ids")]
        public List<object> GroupIds { get; set; }
    }

    public class Currency
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("sign")]
        public string Sign { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("exchange_rate")]
        public double ExchangeRate { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("is_external")]
        public bool IsExternal { get; set; }

        [JsonProperty("is_escrowcom_supported")]
        public bool IsEscrowComSupported { get; set; }
    }

    public class Budget
    {
        public string BudgetCustom
        {
            get => this.Minimum.ToString() + " - " + this.Maximum.ToString();
        }

        [JsonProperty("minimum")]
        public float Minimum { get; set; }

        [JsonProperty("maximum")]
        public float Maximum { get; set; }
    }

    public class BidStats
    {
        [JsonProperty("bid_count")]
        public int BidCount { get; set; }

        [JsonProperty("bid_avg")]
        public double BidAvg { get; set; }
    }

    public class Upgrades
    {
        [JsonProperty("featured")]
        public bool Featured { get; set; }

        [JsonProperty("sealed")]
        public bool Sealed { get; set; }

        [JsonProperty("nonpublic")]
        public bool NonPublic { get; set; }

        [JsonProperty("fulltime")]
        public bool FullTime { get; set; }

        [JsonProperty("urgent")]
        public bool Urgent { get; set; }

        [JsonProperty("qualified")]
        public bool Qualified { get; set; }

        [JsonProperty("NDA")]
        public bool NDA { get; set; }

        [JsonProperty("ip_contract")]
        public bool IpContract { get; set; }

        [JsonProperty("non_compete")]
        public bool NonCompete { get; set; }

        [JsonProperty("project_management")]
        public bool ProjectManagement { get; set; }

        [JsonProperty("pf_only")]
        public bool PfOnly { get; set; }

        [JsonProperty("premium")]
        public bool Premium { get; set; }

        [JsonProperty("enterprise")]
        public bool Enterprise { get; set; }
    }

    public class Location
    {
        [JsonProperty("country")]
        public Country Country { get; set; }
    }

    public class Country
    {
    }

    public class ProjectRejectReason
    {
    }
}
