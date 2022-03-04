using MVVM_WPF_gyakorlás.Models;
using System.Collections.Generic;

namespace MVVM_WPF_gyakorlás.Logic
{
    public interface IArmyLogic
    {
        int AllCost { get; }
        double AVGPower { get; }
        double AVGSpeed { get; }

        void AddToArmy(Trooper trooper);
        void EditTooper(Trooper trooper);
        void RemoveFromArmy(Trooper trooper);
        void SetupCollections(IList<Trooper> barrack, IList<Trooper> army);
    }
}