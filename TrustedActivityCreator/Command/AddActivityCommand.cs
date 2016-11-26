using System;
using System.Collections.ObjectModel;
using TrustedActivityCreator.Model;

namespace TrustedActivityCreator.Command {
    class AddActivityCommand : IUndoRedoCommand {

        ObservableCollection<Activity> activities;
        private Activity activity;

        public AddActivityCommand(ObservableCollection<Activity> activities, Activity activity) {
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
