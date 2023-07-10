using System.Collections.Generic;

namespace NonFollowersAPI.Classes
{
 public class CreatorShoppingInfo
    {
        public List<object> linked_merchant_accounts { get; set; }
    }

    public class FanClubInfo
    {
        public object fan_club_id { get; set; }
        public object fan_club_name { get; set; }
        public object is_fan_club_referral_eligible { get; set; }
    }

    public class HdProfilePicUrlInfo
    {
        public string url { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }

    public class HdProfilePicVersion
    {
        public int width { get; set; }
        public int height { get; set; }
        public string url { get; set; }
    }

    public class LinkedFbInfo
    {
        public LinkedFbUser linked_fb_user { get; set; }
    }

    public class LinkedFbUser
    {
        public string id { get; set; }
        public string name { get; set; }
        public bool is_valid { get; set; }
        public int fb_account_creation_time { get; set; }
        public object link_time { get; set; }
    }

    public class Root
    {
        public Profile user { get; set; }
        public string status { get; set; }
    }

    public class SupervisionInfo
    {
        public bool is_eligible_for_supervision { get; set; }
        public bool is_supervised_user { get; set; }
        public bool is_guardian_user { get; set; }
        public bool is_supervised_by_viewer { get; set; }
        public bool is_guardian_of_viewer { get; set; }
        public bool has_stated_age { get; set; }
        public object screen_time_daily_limit_seconds { get; set; }
        public object screen_time_daily_limit_description { get; set; }
        public string fc_url { get; set; }
        public object quiet_time_intervals { get; set; }
        public bool is_quiet_time_feature_enabled { get; set; }
    }

    public class Profile
    {
        public string pk { get; set; }
        public string username { get; set; }
        public string full_name { get; set; }
        public bool is_private { get; set; }
        public string profile_pic_url { get; set; }
        public string profile_pic_id { get; set; }
        public bool is_verified { get; set; }
        public int follow_friction_type { get; set; }
        public bool has_anonymous_profile_picture { get; set; }
        public int media_count { get; set; }
        public int follower_count { get; set; }
        public int following_count { get; set; }
        public int following_tag_count { get; set; }
        public SupervisionInfo supervision_info { get; set; }
        public bool is_supervision_features_enabled { get; set; }
        public string biography { get; set; }
        public string external_url { get; set; }
        public bool show_fb_link_on_profile { get; set; }
        public int primary_profile_link_type { get; set; }
        public bool has_biography_translation { get; set; }
        public bool can_boost_post { get; set; }
        public bool can_see_organic_insights { get; set; }
        public bool show_insights_terms { get; set; }
        public bool can_convert_to_business { get; set; }
        public bool can_create_sponsor_tags { get; set; }
        public bool is_allowed_to_create_standalone_nonprofit_fundraisers { get; set; }
        public bool is_allowed_to_create_standalone_personal_fundraisers { get; set; }
        public bool can_create_new_standalone_fundraiser { get; set; }
        public bool can_create_new_standalone_personal_fundraiser { get; set; }
        public bool can_be_tagged_as_sponsor { get; set; }
        public bool can_see_support_inbox { get; set; }
        public bool can_see_support_inbox_v1 { get; set; }
        public int total_igtv_videos { get; set; }
        public bool has_videos { get; set; }
        public int total_clips_count { get; set; }
        public bool has_saved_items { get; set; }
        public int total_ar_effects { get; set; }
        public string reel_auto_archive { get; set; }
        public bool is_profile_action_needed { get; set; }
        public int usertags_count { get; set; }
        public bool usertag_review_enabled { get; set; }
        public bool is_needy { get; set; }
        public bool is_interest_account { get; set; }
        public List<HdProfilePicVersion> hd_profile_pic_versions { get; set; }
        public HdProfilePicUrlInfo hd_profile_pic_url_info { get; set; }
        public bool has_placed_orders { get; set; }
        public bool fbpay_experience_enabled { get; set; }
        public bool show_conversion_edit_entry { get; set; }
        public bool aggregate_promote_engagement { get; set; }
        public string allowed_commenter_type { get; set; }
        public bool has_highlight_reels { get; set; }
        public bool has_guides { get; set; }
        public bool is_eligible_to_show_fb_cross_sharing_nux { get; set; }
        public object page_id_for_new_suma_biz_account { get; set; }
        public bool can_tag_products_from_merchants { get; set; }
        public CreatorShoppingInfo creator_shopping_info { get; set; }
        public List<object> eligible_shopping_signup_entrypoints { get; set; }
        public bool is_igd_product_picker_enabled { get; set; }
        public bool is_eligible_for_affiliate_shop_onboarding { get; set; }
        public List<object> eligible_shopping_formats { get; set; }
        public bool needs_to_accept_shopping_seller_onboarding_terms { get; set; }
        public bool is_shopping_settings_enabled { get; set; }
        public bool is_shopping_community_content_enabled { get; set; }
        public bool is_shopping_auto_highlight_eligible { get; set; }
        public bool is_shopping_catalog_source_selection_enabled { get; set; }
        public bool is_business { get; set; }
        public int professional_conversion_suggested_account_type { get; set; }
        public int account_type { get; set; }
        public object is_call_to_action_enabled { get; set; }
        public bool is_category_tappable { get; set; }
        public long interop_messaging_user_fbid { get; set; }
        public LinkedFbInfo linked_fb_info { get; set; }
        public List<object> bio_links { get; set; }
        public bool can_add_fb_group_link_on_profile { get; set; }
        public string allow_mention_setting { get; set; }
        public string allow_tag_setting { get; set; }
        public bool limited_interactions_enabled { get; set; }
        public bool is_quiet_mode_enabled { get; set; }
        public bool is_hide_more_comment_enabled { get; set; }
        public bool transparency_product_enabled { get; set; }
        public object personal_account_ads_page_name { get; set; }
        public object personal_account_ads_page_id { get; set; }
        public List<object> account_badges { get; set; }
        public string whatsapp_number { get; set; }
        public object has_eligible_whatsapp_linking_category { get; set; }
        public List<object> pronouns { get; set; }
        public string fbid_v2 { get; set; }
        public bool is_muted_words_global_enabled { get; set; }
        public bool is_muted_words_custom_enabled { get; set; }
        public FanClubInfo fan_club_info { get; set; }
        public bool has_nft_posts { get; set; }
        public bool has_connected_digital_wallets { get; set; }
        public int liked_clips_count { get; set; }
        public int all_media_count { get; set; }
        public int creators_subscribed_to_count { get; set; }
        public bool has_music_on_profile { get; set; }
        public bool can_share_roll_call { get; set; }
        public bool include_direct_blacklist_status { get; set; }
        public bool can_follow_hashtag { get; set; }
        public bool is_potential_business { get; set; }
        public bool request_contact_enabled { get; set; }
        public object robi_feedback_source { get; set; }
        public bool is_memorialized { get; set; }
        public bool open_external_url_with_in_app_browser { get; set; }
        public bool has_exclusive_feed_content { get; set; }
        public bool has_fan_club_subscriptions { get; set; }
        public int besties_count { get; set; }
        public bool show_besties_badge { get; set; }
        public int recently_bestied_by_count { get; set; }
        public object nametag { get; set; }
        public bool about_your_account_bloks_entrypoint_enabled { get; set; }
        public bool auto_expanding_chaining { get; set; }
        public bool existing_user_age_collection_enabled { get; set; }
        public bool show_post_insights_entry_point { get; set; }
        public bool has_public_tab_threads { get; set; }
        public bool feed_post_reshare_disabled { get; set; }
        public bool auto_expand_chaining { get; set; }
        public bool is_new_to_instagram { get; set; }
        public bool highlight_reshare_disabled { get; set; }
    }

}