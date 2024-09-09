﻿using System.Security.Claims;
using System.Text.Json;

namespace XpressMart_FrontEnd.Services.AuthService
{
	public static class JwtParser
	{
		public static IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
		{
			var payload = jwt.Split('.')[1];
			var jsonBytes = ParseBase64WithoutPadding(payload);
			var keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);

			var claims = new List<Claim>();
			foreach (var kvp in keyValuePairs)
			{
				if (kvp.Key == ClaimTypes.Role)
				{
					if (kvp.Value is JsonElement rolesElement && rolesElement.ValueKind == JsonValueKind.Array)
					{
						foreach (var role in rolesElement.EnumerateArray())
						{
							claims.Add(new Claim(ClaimTypes.Role, role.GetString()));
						}
					}
					else
					{
						claims.Add(new Claim(ClaimTypes.Role, kvp.Value.ToString()));
					}
				}
				else
				{
					claims.Add(new Claim(kvp.Key, kvp.Value.ToString()));
				}
			}

			return claims;
		}

		private static byte[] ParseBase64WithoutPadding(string base64)
		{
			switch (base64.Length % 4)
			{
				case 2: base64 += "=="; break;
				case 3: base64 += "="; break;
			}
			return Convert.FromBase64String(base64);
		}
	}
}
