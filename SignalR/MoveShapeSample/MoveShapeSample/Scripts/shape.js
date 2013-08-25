/// <reference path="jquery-1.6.4.js" />
/// <reference path="jquery.signalR-1.0.1.js" />
/// <reference path="jquery-ui-1.8.20.js" />

(function () {

    var hub = $.connection.moveShape,
        $shape = $('#shape');

    hub.client.shapeMoved = function (x, y) {

        $shape.css({ left: x, top: y });
    }

    $.connection.hub.start().done(function () {

        $shape.draggable({
            drag: function () {

                hub.server.move(this.offsetLeft, this.offsetTop || 0);
            }
        });
    });

}());