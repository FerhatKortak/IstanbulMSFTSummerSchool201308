using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR.Hubs;
using Microsoft.AspNet.SignalR;
using System.Threading.Tasks;

namespace SignalRHitCount
{
    public class HitCounter : Hub
    {
        static int _hitCount;

        public void RecordHit()
        {
            _hitCount += 1;
            Clients.All.onHitRecorded(_hitCount);
        }

        public override Task OnDisconnected()
        {
            _hitCount -= 1;
            return Clients.All.onHitRecorded(_hitCount);
        }
    }
}