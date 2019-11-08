using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BudgetBuddy.Startup))]
namespace BudgetBuddy
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
