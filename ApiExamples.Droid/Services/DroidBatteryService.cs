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

using ApiExamples.Core.Services;


namespace ApiExamples.Droid.Services
{
    class DroidBatteryService : BroadcastReceiver, IBatteryService
    {
        private BatteryStatus? _status;
        private BatteryPlugged? _chargePlug;
        private Intent _batteryStatus;

        public bool? isCharging { get; private set; }
        public bool? usbCharge { get; private set; }
        public bool? acCharge { get; private set; }

        public float? batteryLevel { get; private set; }


        public DroidBatteryService()
        {
            IntentFilter ifilter = new IntentFilter(Intent.ActionBatteryChanged);
            _batteryStatus = Application.Context.RegisterReceiver(this, ifilter);

            isCharging = null;
            usbCharge = null;
            acCharge = null;
            batteryLevel = null;
        }


        public override void OnReceive(Context context, Intent intent)
        {
            int extraStatus = intent.GetIntExtra(BatteryManager.ExtraStatus, -1);
            _status = ((extraStatus == -1) ? (null) : ((BatteryStatus?) extraStatus) );
            isCharging = (_status == BatteryStatus.Charging || _status == BatteryStatus.Full);

            int extraPlugged = intent.GetIntExtra(BatteryManager.ExtraPlugged, -1);
            _chargePlug = ((extraPlugged == -1) ? (null) : ((BatteryPlugged?) extraPlugged));
            usbCharge = (_chargePlug == BatteryPlugged.Usb);
            acCharge = (_chargePlug == BatteryPlugged.Ac);

            int extraLevel = _batteryStatus.GetIntExtra(BatteryManager.ExtraLevel, 0);
            int extraScale = _batteryStatus.GetIntExtra(BatteryManager.ExtraScale, 100);

            if (extraScale != 0)
            {
                batteryLevel = ((extraLevel * 100) / ((float) extraScale));
            }
            else {
                batteryLevel = (float) extraLevel;
            }
        }

    }
}