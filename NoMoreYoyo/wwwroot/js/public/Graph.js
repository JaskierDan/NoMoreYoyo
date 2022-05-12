
console.log(data);
function drawGraph() {

    let width = 400;
    let height = 300;
    let body = document.getElementsByTagName("body")[0];
    
    let canvas = document.createElement('canvas');
    canvas.style.backgroundColor = "#eee";
    canvas.width = width;
    canvas.height = height;
    canvas.style.borderRadius = "5px"
    canvas.style.marginLeft ="20px"

    body.appendChild(canvas)

    let ctx = canvas.getContext("2d");
    ctx.lineWidth = 1;
    ctx.strokeStyle = "#b5b5b5";

    let minimum = Math.min.apply(Math, data)
    let maximum = Math.max.apply(Math, data)
    minimum -= 10;
    maximum += 10;
    ctx.font = '12px serif';
    for (var i = minimum; maximum >= i; i += 5) {
        
        ctx.strokeText(i, width-35, (height * (((i - minimum) / (maximum - minimum))))-5);
        ctx.moveTo(0, (height * (((i - minimum)/ (maximum - minimum)))));
        ctx.lineTo(width, (height * (((i - minimum) / (maximum - minimum)))));


        ctx.stroke();
        
    }
        
    ctx.strokeStyle = "#000";
    ctx.lineWidth = 2;
    ctx.beginPath();
    if (data.length == 1) {
        ctx.moveTo(width/2,height/2);
        ctx.lineTo(width / 2,0);
       /* ctx.moveTo( height - (data[0]),(width / 2));
        ctx.lineTo( height - (data[0] + 1),(width / 2));*/
        ctx.stroke();

    }
    else {
        for (var i = (data.length > (width/2)/40? 149: data.length-2); i >= 0; i--) {


            ctx.moveTo((width / 2) - (i * 40), height - (height * (((data[i] - minimum) / (maximum - minimum)))));
            ctx.bezierCurveTo(
                (width / 2) - (i * 40 +20),
                height - (height * ((((data[i] - minimum) / (maximum - minimum))))),
                (width / 2) - (i * 40 +20),
                height - (height * ((((data[i + 1] - minimum) / (maximum - minimum))))),
                (width / 2) - (i * 40 + 40),
                height - (height * (((data[i + 1] - minimum) / (maximum - minimum)))))
            ctx.stroke();
            /*
            ctx.moveTo((width / 2) - (i * 10 + 10), height - (height * (((data[i + 1] - minimum) / (maximum - minimum)))));
            ctx.lineTo((width / 2) - (i * 10), height - (height * (((data[i] - minimum) / (maximum - minimum)))));*/
            
    }

    }
    




   
}
drawGraph()