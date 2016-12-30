﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace FeatureFolderSample.Application.Home
{
	public class HomeController : Controller
	{
		[HttpGet("")]
		public IActionResult SomeMethod()
		{
			return View("Home/Hello");
		}
	}
}