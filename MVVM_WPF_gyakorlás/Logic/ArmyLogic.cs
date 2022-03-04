using Microsoft.Toolkit.Mvvm.Messaging;
using MVVM_WPF_gyakorlás.Models;
using MVVM_WPF_gyakorlás.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_WPF_gyakorlás.Logic
{
    public class ArmyLogic : IArmyLogic
    {
        IList<Trooper> barrack;
        IList<Trooper> army;
        IMessenger messenger;
        ITrooperEditorSevice editorSevice;

        public ArmyLogic(IMessenger messenger, ITrooperEditorSevice editorSevice)
        {
            this.messenger = messenger;
            this.editorSevice = editorSevice;
        }
        public int AllCost
        {
            get
            {
                return army.Count == 0 ? 0 : army.Sum(t => t.Cost);
            }
        }
        public double AVGPower
        {
            get
            {
                return army.Count == 0 ? 0 : Math.Round(army.Average(t => t.Power), 2);
            }
        }
        public double AVGSpeed
        {
            get
            {
                return army.Count == 0 ? 0 : Math.Round(army.Average(t => t.Speed), 2);
            }
        }
        public void SetupCollections(IList<Trooper> barrack, IList<Trooper> army)
        {
            this.barrack = barrack;
            this.army = army;
        }

        public void AddToArmy(Trooper trooper)
        {
            army.Add(trooper);
            messenger.Send("Trooper Added", "TrooperInfo");
        }
        public void RemoveFromArmy(Trooper trooper)
        {
            army.Remove(trooper);
            messenger.Send("Trooper Removed", "TrooperInfo");
        }
        public void EditTooper(Trooper trooper)
        {
            editorSevice.Edit(trooper);
        }

    }
}
