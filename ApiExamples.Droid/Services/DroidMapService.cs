using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using Java.IO;

using Cirrious.CrossCore.Platform;
using Cirrious.MvvmCross.Droid.Platform;
using Cirrious.MvvmCross.ViewModels;
using Cirrious.CrossCore;

using Nutiteq.Core;
using Nutiteq.Ui;
using Nutiteq.Utils;
using Nutiteq.PackageManager;
using Nutiteq.Projections;


namespace ApiExamples.Droid.Services
{
    public class DroidMapService : Core.Services.MapService
    {
        public override bool LoadNutiteqMap(Nutiteq.Ui.MapView mapViewer)
        {
            _mapViewer = mapViewer;

            // Register license
            Nutiteq.Utils.Log.ShowError = true;
            Nutiteq.Utils.Log.ShowWarn = true;
            MapView.RegisterLicense("XTUMwQ0ZRQzdURnJKck9HYUdhT09VNGFSN3o3Nmg3UWhjQUlVTnV4TStMMk0vemhPMXUwUnBGRlhwbmFtTklFPQoKcHJvZHVjdHM9c2RrLXhhbWFyaW4taW9zLTMuKixzZGsteGFtYXJpbi1hbmRyb2lkLTMuKgpwYWNrYWdlTmFtZT1jb20ubnV0aXRlcS5oZWxsb21hcC54YW1hcmluCmJ1bmRsZUlkZW50aWZpZXI9Y29tLm51dGl0ZXEuaGVsbG9tYXAueGFtYXJpbgp3YXRlcm1hcms9bnV0aXRlcQp2YWxpZFVudGlsPTIwMTUtMDYtMDEKdXNlcktleT0yYTllOWY3NDYyY2VmNDgxYmUyYThjMTI2MWZlNmNiZAo", Application.Context);

            // Create package manager folder (Platform-specific)
            var packageFolder = new File(Application.Context.GetExternalFilesDir(null), "packages");
            if (!(packageFolder.Mkdirs() || packageFolder.IsDirectory))
            {
                return false;
            }
            _downloadPackagePath = packageFolder.AbsolutePath;

            // Copy bundled tile data to file system, so it can be imported by package manager
            _importPackagePath = new File(Application.Context.GetExternalFilesDir(null), "world_ntvt_0_4.mbtiles").AbsolutePath;
            using (var input = Application.Context.Assets.Open("world_ntvt_0_4.mbtiles"))
            {
                using (var output = new System.IO.FileStream(_importPackagePath, System.IO.FileMode.Create))
                {
                    input.CopyTo(output);
                }
            }

            // Initialize map
            return LoadNutiteqMapCommon();
        }      
    }
}
