using Microsoft.Extensions.DependencyInjection;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using Microsoft.Toolkit.Mvvm.Messaging;
using MVVM_WPF_gyakorlás.Logic;
using MVVM_WPF_gyakorlás.Services;
using MVVM_WPF_gyakorlás.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace MVVM_WPF_gyakorlás
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            Ioc.Default.ConfigureServices(
            new ServiceCollection()
            .AddSingleton<IArmyLogic, ArmyLogic>()
            .AddSingleton<ITrooperEditorSevice, TrooperEditorViaWindow>()
            .AddSingleton<IMessenger>(WeakReferenceMessenger.Default)
            .BuildServiceProvider()
);
        }
    }
}
