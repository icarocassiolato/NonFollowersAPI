using System.Collections.Generic;

namespace NonFollowersAPI.Classes
{
    public class Interventions
    {
    }

    public class GrowthFrictionInfo
    {
        public bool has_active_interventions { get; set; }
        public Interventions interventions { get; set; }
    }

    public class ExternalUser
    {
        public object pk { get; set; }
        public string username { get; set; }
        public string full_name { get; set; }
        public bool is_private { get; set; }
        public string profile_pic_url { get; set; }
        public string profile_pic_id { get; set; }
        public bool is_verified { get; set; }
        public int follow_friction_type { get; set; }
        public GrowthFrictionInfo growth_friction_info { get; set; }
        public List<object> account_badges { get; set; }
        public bool has_anonymous_profile_picture { get; set; }
        public bool has_highlight_reels { get; set; }
        public bool has_primary_country_in_feed { get; set; }
        public bool has_primary_country_in_profile { get; set; }
        public int latest_reel_media { get; set; }
    }

    public class Facepile
    {
        public object pk { get; set; }
        public string username { get; set; }
        public string full_name { get; set; }
        public bool is_private { get; set; }
        public string profile_pic_url { get; set; }
        public string profile_pic_id { get; set; }
        public bool is_verified { get; set; }
        public int follow_friction_type { get; set; }
        public GrowthFrictionInfo growth_friction_info { get; set; }
        public List<object> account_badges { get; set; }
        public bool has_anonymous_profile_picture { get; set; }
        public bool has_highlight_reels { get; set; }
        public bool has_primary_country_in_feed { get; set; }
        public bool has_primary_country_in_profile { get; set; }
    }

    public class Group
    {
        public string group { get; set; }
        public string title { get; set; }
        public string context { get; set; }
        public List<Facepile> facepile { get; set; }
        public string subtitle { get; set; }
        public string category { get; set; }
        public List<string> actions { get; set; }
    }

    public class Response
    {
        public List<ExternalUser> users { get; set; }
        public bool big_list { get; set; }
        public int page_size { get; set; }
        public string next_min_id { get; set; }
        public string next_max_id { get; set; }
        public List<Group> groups { get; set; }
        public bool more_groups_available { get; set; }
        public bool should_limit_list_of_followers { get; set; }
        public string status { get; set; }
    }
}