using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using NonFollowersAPI.Classes;
using System.Text.Json;

namespace Api.Controllers
{
    [EnableCors("AllowAllHeaders")]
    [Route("[controller]")]
    [ApiController]
    public class NonFollowersController : ControllerBase
    {
        private static readonly HttpClient client = new HttpClient();

        private static readonly string idProfile = "5765918114";

        static async Task<T> SendRequest<T>(string url)
            => await JsonSerializer.DeserializeAsync<T>(await client.GetStreamAsync(url));

        static async Task<Profile> GetProfile()
            => (await SendRequest<Root>($"users/{idProfile}/info")).user;

        static async Task<Response> GetResponseFollowers(string next_max_id = "")
            => await SendRequest<Response>($"friendships/{idProfile}/followers/"
                + (string.IsNullOrEmpty(next_max_id) ? "" : $"?max_id={next_max_id}"));

        static async Task<Response> GetResponseFollowing(string next_max_id = "")
            => await SendRequest<Response>($"friendships/{idProfile}/following/"
                + (string.IsNullOrEmpty(next_max_id) ? "" : $"?max_id={next_max_id}"));

        static async Task<List<ExternalUser>> GetAllFollowers(int followerCount)
        {
            var responseFollowers = await GetResponseFollowers();
            List<ExternalUser> followers = responseFollowers.users;

            while (followers.Count < followerCount)
            {
                responseFollowers = await GetResponseFollowers(responseFollowers.next_max_id);
                Console.WriteLine($"{followers.Count}/{followerCount}");
                followers.AddRange(responseFollowers.users);
            }

            return followers;
        }

        static async Task<List<ExternalUser>> GetAllFollowing(int followingCount)
        {
            var responseFollowing = await GetResponseFollowing();
            List<ExternalUser> following = responseFollowing.users;

            while (following.Count < followingCount)
            {
                responseFollowing = await GetResponseFollowing(responseFollowing.next_max_id);
                Console.WriteLine($"{following.Count}/{followingCount}");
                following.AddRange(responseFollowing.users);
            }

            return following;
        }

        static void ShowProfileInformations(Profile profile)
        {
            Console.WriteLine(profile.full_name);
            Console.WriteLine(profile.username);
            Console.WriteLine($"Seguidores: {profile.follower_count}");
            Console.WriteLine($"Seguindo: {profile.following_count}");
            Console.WriteLine();
        }

        [HttpGet]
        public async Task<string> Teste()
            => "testeeee";

        public async Task<Resultado> Gerar()
        {
            var resultado = new Resultado();

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Add("X-IG-App-ID", "936619743392459");
            client.DefaultRequestHeaders.Add("X-ASBD-ID", "198387");
            client.DefaultRequestHeaders.Add("X-IG-WWW-Claim", "hmac.AR1Nin1fSv8CugNJsPfcaQ1w-EIEHHB29OMEcQcBpOmQz1R6");
            client.DefaultRequestHeaders.Add("Cookie", "csrftoken=zLU6Gwtuel7dB4yUg9UNkxifa8VoXdmh; mid=YRV5NQALAAFyuULjYN12Y1PhKpiH; ig_did=3AC59F18-85DA-4FBD-936B-A0B887404845; fbm_124024574287414=base_domain=.instagram.com; ds_user_id=5765918114; datr=c8uYYm3KCEuHtAT9mdcGQxP3; sessionid=5765918114%3Ay7DmAgNzecnLkX%3A10%3AAYeCUd5x-WfCXVlnBE-OsCjJ2Znp_lKF-J3MtZQSUw; shbid=\"3206\\0545765918114\\0541701970485:01f7cef6afc189b291f785d4a120d427e8d6c5cf236d5b9b38a59c07cb72326fc5a0304d\"; shbts=\"1670434485\\0545765918114\\0541701970485:01f7658c02a1b03945ccae9ad5e20f5dcbc545353c43a934f541cc857325c174c2eacf4f\"; rur=\"NAO\\0545765918114\\0541702125271:01f7a9b80fbc0b14a5a0c1abbe1ff146596290bf0f1fbd423a8a615e0981803a1dc4c948\"; csrftoken=hPlY2D3udljKTC9GmH4mXJr7KKmEZcPT; ig_did=A78202B6-CE7C-454A-8F34-B150BFEFB0AD; mid=YXgtfwAEAAGy4DUwj156RX9gJ30S");

            client.BaseAddress = new Uri("https://i.instagram.com/api/v1/");
            Profile profile = await GetProfile();

            List<ExternalUser> followers = await GetAllFollowers(profile.follower_count);
            List<ExternalUser> following = await GetAllFollowing(profile.following_count);
            ShowProfileInformations(profile);

            resultado.Seguidores = profile.follower_count;
            resultado.Seguindo = profile.following_count;
            resultado.NaoSeguidores = new List<ExternalUser>();
            foreach (ExternalUser f in following)
                if (!followers.Exists(x => x.username == f.username))
                    resultado.NaoSeguidores.Add(f);

            return resultado;
        }
    }
}
