using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using TrustedActivityCreator.Model;

namespace TrustedActivityCreator.Command {
    class RemoveActivityCommand : IUndoRedoCommand {

        private ObservableCollection<ActivityM> activities;

        private List<ActivityM> activitiesToRemove;

        public RemoveActivityCommand(ObservableCollection<ActivityM> activities, List<ActivityM> activitiesToRemove) {
            this.activities = activities;
            this.activitiesToRemove = activitiesToRemove;
        }

        public void Execute() {
            activitiesToRemove.ForEach(x => activities.Remove(x));
        }

        public void UnExecute() {
            activitiesToRemove.ForEach(x => activities.Add(x));
        }
    }
}
