using MVVM_WPF_gyakorlás.Models;
using MVVM_WPF_gyakorlás.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_WPF_gyakorlás.ViewModels
{
    public class TrooperEditorViaWindow : ITrooperEditorSevice
    {
        public void Edit(Trooper trooper)
        {
            new TrooperEditorWindows(trooper).ShowDialog();
        }
    }
}
