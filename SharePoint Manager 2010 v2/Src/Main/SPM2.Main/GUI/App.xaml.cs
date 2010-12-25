﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using System.ComponentModel.Composition;
using System.Windows.Interop;
using System.Diagnostics;

using SPM2.Framework;
using SPM2.Framework.Collections;
using System.Windows.Threading;
using SPM2.Main.ViewModel;
using System.Threading;

namespace SPM2.Main
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    [Export()]
    public partial class App : Application
    {

        AppModel model = null;

        Stopwatch timerWatch = new Stopwatch();
        

        public App()
        {
            timerWatch.Start();

            this.model = new AppModel();

            this.DispatcherUnhandledException += new System.Windows.Threading.DispatcherUnhandledExceptionEventHandler(App_DispatcherUnhandledException);
        }


        void Start(object sender, StartupEventArgs e)
        {
            SPM2.Main.GUI.SplashScreen splash = new SPM2.Main.GUI.SplashScreen(new AsynchronousLoadDelegate(this.AsynchronousLoadHandler));
            splash.Closing += new System.ComponentModel.CancelEventHandler(splash_Closing);
            this.ShowWindow(splash);
        }


        void splash_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // Ensure to load the object model
            Window win = this.model.MainWindow;

            //Create the main window on the UI thread.
            this.ShowWindow(win);

            timerWatch.Stop();
            Trace.WriteLine("Load of application: " + timerWatch.ElapsedMilliseconds + " milliseconds");
        }


        private void AsynchronousLoadHandler(SPM2.Main.GUI.SplashScreen splashWindow)
        {
            // Preload the assemlies in the async method
            CompositionProvider.LoadAssemblies();

            // Load Validators




        }


        void ShowWindow(Window window)
        {
            // Create the main window, but on the UI thread.
            Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(delegate
            {
                this.MainWindow = window;
                this.MainWindow.Show();
            }));
        }

        void App_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            Trace.TraceError(e.Exception.GetMessages());

#if DEBUG
            MessageBox.Show(e.Exception.Message + "\r\n -> " + e.Exception.StackTrace, "Error! (Debug mode)", MessageBoxButton.OK, MessageBoxImage.Error);
#else
            MessageBox.Show(e.Exception.Message, "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
#endif
            e.Handled = true;
        }

    }
}
