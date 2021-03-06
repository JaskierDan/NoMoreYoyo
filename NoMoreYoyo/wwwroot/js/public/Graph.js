function drawGraph() {
    let width = 400;
    let height = 300;
    let body = document.querySelector('.card-body');
    let canvas = document.createElement('canvas');

    canvas.style.backgroundColor = "#eee";
    canvas.width = width;
    canvas.height = height;

    body.appendChild(canvas);

    let ctx = canvas.getContext("2d");
    ctx.lineWidth = 1;
    ctx.strokeStyle = "#b5b5b5";

    let minimum = Math.min.apply(Math, data);
    let maximum = Math.max.apply(Math, data);

    minimum -= 10;
    maximum += 10;
    ctx.font = '12px serif';

    let i = 0;

    for (i = minimum; maximum >= i; i += 5) {        
        ctx.strokeText(i, width-35, (height * ((i - minimum) / (maximum - minimum)))-5);
        ctx.moveTo(0, (height * ((i - minimum)/ (maximum - minimum))));
        ctx.lineTo(width, (height * ((i - minimum) / (maximum - minimum))));
        ctx.stroke();        
    }
        
    ctx.strokeStyle = "#000";
    ctx.lineWidth = 2;
    ctx.beginPath();

    if (data.length == 1) {
        ctx.moveTo(width/2,height/2);
        ctx.lineTo(width / 2,0);
        ctx.stroke();
    }
    else {
        for (i = (data.length > (width / 2) / 40 ? 149 : data.length - 2); i >= 0; i--) {
            ctx.moveTo((width / 2) - (i * 40), height - (height * ((data[i] - minimum) / (maximum - minimum))));
            ctx.bezierCurveTo(
                (width / 2) - (i * 40 +20),
                height - (height * ((data[i] - minimum) / (maximum - minimum))),
                (width / 2) - (i * 40 +20),
                height - (height * ((data[i + 1] - minimum) / (maximum - minimum))),
                (width / 2) - (i * 40 + 40),
                height - (height * ((data[i + 1] - minimum) / (maximum - minimum))))
            ctx.stroke();
        }
    }
}

drawGraph();