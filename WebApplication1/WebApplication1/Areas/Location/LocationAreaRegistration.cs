﻿using System.Web.Mvc;

namespace WebApplication1.Areas.Location
{
    public class LocationAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Location";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {

            context.MapRoute(
                name: "Location_default",
                url: "Location/{controller}/{action}/{id}",
                defaults: new {controller = "Location", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}