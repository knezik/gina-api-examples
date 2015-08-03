using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Nutiteq.Core;
using Nutiteq.Ui;
using Nutiteq.Utils;
using Nutiteq.PackageManager;
using Nutiteq.Projections;
using Nutiteq.WrappedCommons;
using Nutiteq.VectorTiles;
using Nutiteq.Layers;
using Nutiteq.DataSources;

namespace ApiExamples.Core.Services
{
    abstract public class MapService : IMapService {

        // mapView/mapViewer in UI
        protected Nutiteq.Ui.MapView _mapViewer;

        // package paths for package manager
        protected string _importPackagePath;
        protected string _downloadPackagePath;


        abstract public bool LoadNutiteqMap(Nutiteq.Ui.MapView mapViewer);

        protected bool LoadNutiteqMapCommon()
        {
            // Set base projection
            EPSG3857 proj = new EPSG3857();
            _mapViewer.Options.BaseProjection = proj; // note: EPSG3857 is the default, so this is actually not required

            // Set initial location and other parameters, don't animate
            _mapViewer.FocusPos = proj.FromWgs84(new MapPos(-0.8164, 51.2383)); // Berlin
            _mapViewer.Zoom = 2;
            _mapViewer.MapRotation = 0;
            _mapViewer.Tilt = 90;

            // Start package manager
            var packageManager = new NutiteqPackageManager("nutiteq.mbstreets", _downloadPackagePath);
            packageManager.Start();

            // Import initial package
            if (packageManager.GetLocalPackage("world0_4") == null)
            {
                packageManager.StartPackageImport("world0_4", 1, _importPackagePath);
            }

            // Set bounding box
            String bbox = "bbox(-0.8164,51.2382,0.6406,51.7401)"; // London (about 30MB)
            if (packageManager.GetLocalPackage(bbox) == null)
            {
                packageManager.StartPackageDownload(bbox);
            }

            // Now can add vector map as layer
            // define styling for vector map
            UnsignedCharVector styleBytes = AssetUtils.LoadBytes("osmbright.zip");
            MBVectorTileDecoder vectorTileDecoder = null;
            if (styleBytes != null)
            {
                // Create style set
                MBVectorTileStyleSet vectorTileStyleSet = new MBVectorTileStyleSet(styleBytes);
                vectorTileDecoder = new MBVectorTileDecoder(vectorTileStyleSet);
            }
            else
            {
                Log.Error("Failed to load style data");
            }

            // Create online base layer (no package download needed then). Use vector style from assets (osmbright.zip)
            // comment in to use online map. Packagemanager stuff is not needed then
            //			VectorTileLayer baseLayer = new NutiteqOnlineVectorTileLayer("osmbright.zip");

            var baseLayer = new VectorTileLayer(new PackageManagerTileDataSource(packageManager), vectorTileDecoder);
            _mapViewer.Layers.Add(baseLayer);

            return true;
        }
    }
}
