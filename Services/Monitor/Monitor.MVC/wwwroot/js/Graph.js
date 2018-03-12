(function() {
    window.DisplayGraph = function DisplayGraph(canvasId, data, graphType, type) {
        // Get the canvas dom element.
        var canvasDOMElement = document.getElementById(canvasId);

        // Get the Canvas 2d graphic context.
        var canvasCtx = canvasDOMElement.getContext("2d");

        if (graphType === "line")
            CreateLineGraph(canvasCtx, data, type);
        else if (graphType === "bar")
            CreateBarGraph(canvasCtx, data, type);
    }

    window.RandomColorGenerator = function random_rgba() {
        var o = Math.round, r = Math.random, s = 255;
        return 'rgba(' + o(r() * s) + ',' + o(r() * s) + ',' + o(r() * s) + ', 0.2)';
    };

    function CreateLineGraph(ctx, data, type) {
        return new Chart(ctx,
            {
                type: 'line',
                data: data,
                options: {
                    elements: {
                        line: {
                            tension: 0
                        }  
                    },
                    scales: {
                        xAxes: [
                            {
                                type: type,
                                distribution: 'series'
                            }
                        ]
                    }
                }
            });
    }



    function CreateBarGraph(ctx, data, type) {
        return new Chart(ctx,
            {
                type: 'bar',
                data: data,
                options: {
                    scales: {
                        xAxes: [
                            {
                                type: type,
                                distribution: 'series'
                            }
                        ],
                        yAxes: [{
                            ticks: {
                                beginAtZero: true
                            }
                        }]
                    }
                }
            });
    }
})();
