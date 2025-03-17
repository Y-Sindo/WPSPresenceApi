using System.Net.Http.Headers;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Text.Json;

public static class RestApiClient
{
    private const string WpsResourceName = "YOUR_RESOURCE_NAME";
    private const string AccessKey = "YOUR_ACCESS_KEY";
    private static readonly HttpClient HttpClient = new();
    private static readonly JsonSerializerOptions JsonSerializerOptions = new() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
    public static async IAsyncEnumerable<GroupMember> ListConnectionsInGroupAsync(string hub, string groupName)
    {
        var baseUri = $"https://{WpsResourceName}.webpubsub.azure.com/api/hubs/{hub}/groups/{groupName}/connections";
        var access_token = GenerateAccessToken(baseUri);
        var nextLink = $"{baseUri}?api-version=2024-12-01";
        while (true)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, nextLink);
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", access_token);
            var response = await HttpClient.SendAsync(request);
            var content = await response.Content.ReadAsStringAsync();
            var connections = JsonSerializer.Deserialize<GroupMemberPagedValues>(content, JsonSerializerOptions);
            foreach (var connection in connections.Value)
            {
                yield return connection;
            }
            if (connections.NextLink == null)
            {
                yield break;
            }
            nextLink = connections.NextLink;
        }
    }

    public static string GenerateAccessToken(string auth)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(AccessKey));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        var token = new JwtSecurityToken(
                audience: auth,
                // claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: credentials
            );

        var tokenHandler = new JwtSecurityTokenHandler();
        return tokenHandler.WriteToken(token);
    }
}


public class GroupMemberPagedValues
{
    public List<GroupMember> Value { get; set; }
    public string NextLink { get; set; }
}

public class GroupMember
{
    public string ConnectionId { get; set; }
    public string UserId { get; set; }
}
