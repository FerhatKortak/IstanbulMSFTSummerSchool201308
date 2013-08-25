using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoveShapeSample.Hubs {

    [HubName("moveShape")]
    public class MoveShapeHub : Hub {

        public void Move(int x, int y) {

            Clients.Others.shapeMoved(x, y);
        }
    }
}