﻿namespace CampusSystem.Web.Controllers
{
    using System.Web.Mvc;

    using Services.Web;

    public abstract class BaseController : Controller
    {
        public ICacheService Cache { get; set; }
    }
}