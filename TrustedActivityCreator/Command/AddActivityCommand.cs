﻿using System;
using System.Collections.ObjectModel;
using TrustedActivityCreator.Model;

namespace TrustedActivityCreator.Command {
    class AddActivityCommand : IUndoRedoCommand {

        ObservableCollection<ActivityM> activities;
        private ActivityM activity;

        public AddActivityCommand(ObservableCollection<ActivityM> activities, ActivityM activity) {
            this.activities = activities;
            this.activity = activity;
        }

        public void Execute() {
            activities.Add(activity);
        }

        public void UnExecute() {
            activities.Remove(activity);
        }
    }
}
