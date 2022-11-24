using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;


namespace Web6.Jwt
{
	public static class JwtTokenExtensions
    {
		public static void AddJwtService(this IServiceCollection services) 
		{
			var sp = services.BuildServiceProvider();
			var jwtTokenConfiguration = sp.GetService<JwtTokenConfiguration>();

			if (jwtTokenConfiguration == null)
				throw new ArgumentNullException(nameof(jwtTokenConfiguration));

			AddJwtToken(services, jwtTokenConfiguration);
		}
		public static void AddJwtService(this IServiceCollection services, JwtTokenConfiguration jwtTokenConfiguration)
		{
			if (jwtTokenConfiguration == null)
				throw new ArgumentNullException(nameof(jwtTokenConfiguration));

			AddJwtToken(services, jwtTokenConfiguration);
		}
		public static void AddJwtService(this IServiceCollection services, Action<JwtTokenConfiguration> options)
		{
			JwtTokenConfiguration jwtTokenConfiguration = new JwtTokenConfiguration();
			options(jwtTokenConfiguration);

			AddJwtToken(services, jwtTokenConfiguration);
		}
		private static void AddJwtToken(IServiceCollection services, JwtTokenConfiguration jwtTokenConfiguration)
		{
			services.AddScoped<IJwtService, JwtService>();
			var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtTokenConfiguration.SecretKey));
			services.AddAuthentication(options =>
			{
				options.DefaultAuthenticateScheme = "Bearer";
				options.DefaultChallengeScheme = "Bearer";
			})
				.AddJwtBearer(jwtBearerOptions =>
				{
					//jwtBearerOptions.SaveToken = true; //suitable 
					jwtBearerOptions.TokenValidationParameters = new TokenValidationParameters
					{
						ValidateAudience = true,
						ValidAudience = jwtTokenConfiguration.Audience,
						ValidateIssuer = true,
						ValidIssuer = jwtTokenConfiguration.Issuer,
						ValidateIssuerSigningKey = true,
						IssuerSigningKey = signingKey,
						ValidateLifetime = true
					};
					jwtBearerOptions.Events = new JwtBearerEvents
					{
						OnForbidden = context => { return Task.CompletedTask; },
						OnAuthenticationFailed = context => { return Task.CompletedTask; },
						OnTokenValidated = context => { return Task.CompletedTask; }
					};
				});
		}

		public static void UseJwt(this IApplicationBuilder app)
		{
			app.UseAuthentication();
			//app.UseUserClaimsMiddleware();
			app.UseAuthorization();
		}
	}
}
