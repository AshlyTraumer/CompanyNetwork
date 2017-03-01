using System.Web;
using DomenModel;
using NLog;

namespace CompanyNetwork.Core
{
    public static class HttpContextExtensions
    {
        public static CompanyContext GetContextPerRequest(this HttpContextBase httpContext)
        {
            const string key = "Context";

            var context = httpContext.Items[key] as CompanyContext;

            if (context != null) return context ;

            context = new CompanyContext();
            context.Database.Log = LogManager.GetCurrentClassLogger().Info;
            httpContext.Items[key] = context;

            return context;
        }
    }
}