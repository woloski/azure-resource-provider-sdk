﻿using System.Web.Http;

namespace ResourceProvidR
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // -------- Subscription Notifications --------
            // POST /events
            config.Routes.MapHttpRoute(
                name: "Events",
                routeTemplate: "events",
                defaults: new { controller = "Events", action = "HandleSubscriptionNotifications" }
            );

            // -------- Cloud Services Management --------

            // GET /subscriptions/{subscriptionId}/cloudservices
            config.Routes.MapHttpRoute(
               name: "CloudService-Management-Subscription",
               routeTemplate: "subscriptions/{subscriptionId}/cloudservices",
               defaults: new
               {
                   controller = "CloudServices",
                   action = "GetAllCloudServices"
               }
           );

            // Cloud Service level resource management
            // GET /subscriptions/{subscriptionId}/cloudservices/{cloudServiceName}
            // DELETE /subscriptions/{subscriptionId}/cloudservices/{cloudServiceName}
            config.Routes.MapHttpRoute(
               name: "CloudService-Management",
               routeTemplate: "subscriptions/{subscriptionId}/cloudservices/{cloudServiceName}",
               defaults: new {
                   controller = "CloudServices"
               }
           );

           // -------- Resource Management --------

           // GET /subscriptions/{subscriptionId}/cloudservices/{cloudServiceName}/resources/{resourceName}
           // PUT /subscriptions/{subscriptionId}/cloudservices/{cloudServiceName}/resources/{resourceName}
           // DELETE subscriptions/{subscriptionId}/cloudservices/{cloudServiceName}/resources/{resourceName}
           config.Routes.MapHttpRoute(
               name: "Resource-Management",
               //routeTemplate: "subscriptions/{subscriptionId}/cloudservices/{cloudServiceName}/resources/{resourceType}/{resourceName}",
               routeTemplate: "subscriptions/{subscriptionId}/cloudservices/{cloudServiceName}/resources/{resourceName}",
               defaults: new
               {
                   controller = "Resources"
               }
           );

           // -------- Single Sign On --------

           // GET subscriptions/{subscriptionId}/cloudservices/{cloudServiceName}/resources/{resourceType}/{resourceName}/GenerateSSOToken
           //config.Routes.MapHttpRoute(
           //    name: "Resource-Management-SingleSignOn",
           //    routeTemplate: "subscriptions/{subscriptionId}/cloudservices/{cloudServiceName}/resources/{resourceType}/{resourceName}/GenerateSSOToken",
           //    defaults: new
           //    {
           //        controller = "Resources",
           //        action = "GenerateSSOToken"
           //    }
           //);
        }
    }
}