function Chart(model, title, element) {
    var str = [];

    for (var i = 0; i < model.length; ++i) {
        str.push({ y: model[i].Value, name: model[i].Description, legendMarkerType: "triangle" });
    }

    var chart = new CanvasJS.Chart(element,
    {
        title: {
            text: title,
            fontFamily: "arial black"
        },
        animationEnabled: true,
        legend: {
            verticalAlign: "bottom",
            horizontalAlign: "center"
        },
        theme: "theme1",
        data: [
            {
                type: "pie",
                indexLabelFontFamily: "Garamond",
                indexLabelFontSize: 14,
                indexLabelFontWeight: "bold",
                startAngle: 0,
                indexLabelFontColor: "MistyRose",
                indexLabelLineColor: "darkgrey",
                indexLabelPlacement: "inside",
                toolTipContent: "{name}: {y}",
                showInLegend: true,
                indexLabel: "#percent%",
                dataPoints: str
            }
        ]
    });
    chart.render();
}