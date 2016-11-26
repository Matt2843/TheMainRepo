﻿using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Windows.Input;
using TrustedActivityCreator.Model;

namespace TrustedActivityCreator.ViewModel {
    class ActivityVM : ObservableObject {

        /// <summary>
        /// The current activity information.
        /// </summary>
        private int activityId;
        private Activity currentActivity;

        /// <summary>
        /// The commands for databinding
        /// </summary>
        private ICommand currentActivityCommand;

        private ICommand activityMouseDownCommand;
        private ICommand activityMouseMoveCommand;
        private ICommand activityMouseUpCommand;

        /// <summary>
        /// The command properties
        /// </summary>
        public ICommand CurrentActivityCommand {
            get {
                if(currentActivity == null) {
                    currentActivityCommand = new RelayCommand(getCurrentActivity);
                }
                return currentActivityCommand;
            }
        }



        private void getCurrentActivity() {
            // TODO - GET ACTIVITY WITH CURRENT ID FROM ACTIVITY MAP
        }
    }
}
