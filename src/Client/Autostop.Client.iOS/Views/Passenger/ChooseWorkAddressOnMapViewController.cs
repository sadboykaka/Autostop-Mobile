﻿using Autostop.Client.Core.ViewModels.Passenger;
using Autostop.Client.Core.ViewModels.Passenger.ChooseOnMap;
using Autostop.Client.iOS.Constants;
using Autostop.Client.iOS.Extensions;
using JetBrains.Annotations;
using UIKit;

namespace Autostop.Client.iOS.Views.Passenger
{
    [UsedImplicitly]
    public class ChooseWorkAddressOnMapViewController : BaseChooseOnMapViewController<ChooseWorkAddressOnMapViewModel>
    {
        protected override UIImage GetPinImage() => Icons.DefaultPin;

        protected override string GetDoneButtonTitle() => "Save";

        public override async void ViewDidLoad()
        {
            base.ViewDidLoad();
            this.BindCommand(DoneButton, ViewModel.Done);
            await ViewModel.Load();
        }
    }
}
