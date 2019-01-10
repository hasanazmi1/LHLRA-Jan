var states = [{state: "Closed",value: 23 }, {state: "Pending",value: 9 }, {state: "Ongoing",value: 4 }, {state: "Reopened",value: 5 }];
var loc = [{loc: "Karachi",value: 2 }, {loc: "Lahore",value: 10 }, {loc: "Islamabad",value: 5 }, {loc: "Faislabad",value: 12 }, {loc: "Sargodha",value: 5 }, {loc: "Sukkhur",value: 3 }, {loc: "Sahiwal",value: 7 }, {loc: "Okara",value: 4 }, {loc: "Murree",value: 13 }, {loc: "Ayubia",value: 4 }];
var dCauses = [{cause: "Poison",value: 2 }, {cause: "Aid",value: 10 }, {cause: "Murder",value: 5 }, {cause: "Suicide",value: 12 }, {cause: "Heart fail",value: 5 }, {cause: "Cancer",value: 3 }, {cause: "Brain Hambridge",value: 7 }];
var referalls = [{cause: "Adeem",value: 10 }, {cause: "Ahad",value: 9 }, {cause: "Kiran",value: 8 }, {cause: "Faraz",value: 7 }, {cause: "Abid",value: 6 }, {cause: "Zain",value: 5 }, {cause: "Ahmed",value: 4 }, {cause: "Muzammil",value: 3 }, {cause: "Tahir",value: 2 }, {cause: "Ashar",value: 1 }];
$(function(){
    $("#stateBar").dxChart({
        dataSource: states, 
        series: {
            argumentField: "state",
            valueField: "value",
            name: "State",
            type: "bar",
            color: mApp.getColor("success")
        }
    });
    $("#locBar, #callLocBar").dxChart({
        dataSource: loc, 
        series: {
            argumentField: "loc",
            valueField: "value",
            name: "Locations",
            type: "bar",
            color: mApp.getColor("error")
        }
    });
    $("#deathBar").dxChart({
        dataSource: dCauses, 
        series: {
            argumentField: "cause",
            valueField: "value",
            name: "Locations",
            type: "bar",
            color: mApp.getColor("warning")
        }
    });
    $("#referalls").dxChart({
        dataSource: referalls, 
        series: {
            argumentField: "cause",
            valueField: "value",
            name: "Locations",
            type: "bar",
            color: mApp.getColor("success")
        }
    });
});