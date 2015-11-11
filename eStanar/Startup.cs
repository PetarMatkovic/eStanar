using eStanar.Domain.Application;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using Owin.Security.Providers.GitHub;
using System.Security.Claims;
using System.Web.Helpers;

[assembly: OwinStartup(typeof(eStanar.Startup))]

namespace eStanar
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }

        // For more information on configuring authentication, please visit http://go.microsoft.com/fwlink/?LinkId=301864
        public void ConfigureAuth(IAppBuilder app)
        {
            // Enable the application to use a cookie to store information for the signed in user
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/LogOn")
            });

            /*app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            if (!string.IsNullOrEmpty(AppSettings.GoogleClientId))
            {
                app.UseGoogleAuthentication(
                    clientId: AppSettings.GoogleClientId,
                    clientSecret: AppSettings.GoogleClientSecret);
            }

            if (!string.IsNullOrEmpty(AppSettings.TwitterConsumerKey))
            {
                app.UseTwitterAuthentication(
                    consumerKey: AppSettings.TwitterConsumerKey,
                    consumerSecret: AppSettings.TwitterConsumerSecret);
            }

            if (!string.IsNullOrEmpty(AppSettings.GitHubClientId))
            {
                app.UseGitHubAuthentication(
                    clientId: AppSettings.GitHubClientId,
                    clientSecret: AppSettings.GitHubClientSecret);
            }*/

            AntiForgeryConfig.UniqueClaimTypeIdentifier = ClaimTypes.NameIdentifier;
        }
    }
}
