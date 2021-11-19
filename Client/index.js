var ko = require('knockout');
require('devexpress-reporting/dx-reportdesigner');
import "./style.css";

window.JsFunctions = {
    _viewerOptions: {
        reportUrl: ko.observable("MyReport"),
        requestOptions: {
            invokeAction: "/DXXRDV"
        }
    },
    _designerOptions: {
        reportUrl: ko.observable("MyReport"),
        requestOptions: {
            getDesignerModelAction: "api/Reporting/getReportDesignerModel"
        }
    },
    InitWebDocumentViewer: function () {
        ko.applyBindings(this._viewerOptions, document.getElementById("viewer"));
    },
    InitReportDesigner: function () {
        ko.applyBindings(this._designerOptions, document.getElementById("designer"));
    },
    Dispose: function (elementId) {
        var element = document.getElementById(elementId);
        element && ko.cleanNode(element);
    }
}