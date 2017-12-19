﻿using System;
using System.Reactive.Linq;
using Autostop.Client.Core.ViewModels.Passenger;
using Autostop.Client.iOS.Controllers;
using Autostop.Client.iOS.Controls;
using Autostop.Common.Shared.Models;
using CoreGraphics;
using Google.Maps;
using UIKit;

namespace Autostop.Client.iOS.Extensions.MainView
{
	public static class MainViewExtensions
	{
	    public static void GmsMapViewEventsToMainViewModelObservables(this MapView gmsMapView, MainViewModel viewModel)
	    {
	        
        }

	    public static SearchPlaceTextField GetSearchText(this MainViewController controller, BaseSearchPlaceViewModel vm, UIViewController viewController)
	    {
	        viewController.EdgesForExtendedLayout = UIRectEdge.None;
	        viewController.NavigationItem.HidesBackButton = true;
	        var frame = new CGRect(0, 0, controller.NavigationController.NavigationBar.Frame.Size.Width - 20, 30);
	        var searchTextField = new SearchPlaceTextField(frame, vm, () => controller.NavigationController.PopViewController(true));
	        viewController.NavigationItem.TitleView = searchTextField;
	        searchTextField.BecomeFirstResponder();
	        return searchTextField;
	    }
    }
}