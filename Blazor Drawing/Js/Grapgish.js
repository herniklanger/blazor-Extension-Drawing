window.GrapgishExtension = {
    DrawImage: function (canvasId, grapgish) {
        var ctx = document.getElementById(canvasId).getContext("2d");
        grapgish.forEach(g => {
            ctx.beginPath();
            switch (g.shape) {
                case 0://Circle
                    ctx.arc(g.xposision[0], g.yposision[0], g.xposision[2], g.xposision[1] * Math.PI, g.yposision[1] * Math.PI);
                    break;
                case 1://Ellipse
                    ctx.ellipse(g.xposision[0], g.yposision[0], g.xposision[1], g.yposision[1], 0, g.xposision[2] * Math.PI, g.yposision[2] * Math.PI )
                    break;
                case 2://Lines
                    ctx.moveTo(g.xposision[0], g.yposision[0]);
                    for (i = 1; i < g.xposision.length; i++) {
                        ctx.lineTo(g.xposision[i], g.yposision[i]);
                    }
                case 3://Polygon
                    ctx.moveTo(g.xposision[0], g.yposision[0]);
                    for (i = 1; i < g.xposision.length; i++) {
                        ctx.lineTo(g.xposision[i], g.yposision[i]);
                    }
                    ctx.closePath();
                    break;
                case 4://Text
                    ctx.font = g.color.textureFill[0];
                    ctx.textAlign = g.color.textureOutLine[0];
                    ctx.fillText(g.text, g.xposision[0], g.yposision[0]);
                    break;
            }
            if (g.color.fill != null) {
                var grd;
                if (g.color.linear) {
                    grd = ctx.createLinearGradient(g.color.gradiant[0], g.color.gradiant[1], g.color.gradiant[2], g.color.gradiant[3]);
                } else {
                    grd = ctx.createLinearGradient(g.color.gradiant[0], g.color.gradiant[1], g.color.gradiant[4], g.color.gradiant[2], g.color.gradiant[3], g.color.gradiant[5]);
                }
                var StebtOver = 0;
                for (i = 0; i < g.color.textureFill.length; i++) {
                    if (g.color.textureFill[i][0] == '#') {
                        grd.addColorStop(i - StebtOver, g.color.textureFill[i])
                    } else {
                        StebtOver++;
                    }
                }
                ctx.fillStyle = grd;
                ctx.fill();
            }
            if (g.color.OutLine != null)
            {
                var grd;
                if (g.color.linear) {
                    grd = ctx.createLinearGradient(g.color.gradiant[0], g.color.gradiant[1], g.color.gradiant[2], g.color.gradiant[3]);
                } else {
                    grd = ctx.createLinearGradient(g.color.gradiant[0], g.color.gradiant[1], g.color.gradiant[4], g.color.gradiant[2], g.color.gradiant[3], g.color.gradiant[5]);
                }
                for (i = 0; i < g.color.textureOutLine.length; i++) {
                    if (g.color.textureOutLine[i][0] == '#') {
                        grd.addColorStop(i - StebtOver, g.color.textureOutLine[i])
                    } else {
                        StebtOver++;
                    }
                }
                ctx.strokeStyle = grd;
            }
            ctx.lineWidth = g.color.borderWidth;
            ctx.stroke();
        });
    },
    ClearImage: function (canvasId) {
        var canvas =  document.getElementById(canvasId);
        var ctx = canvas.getContext("2d");
        ctx.clearRect(0, 0, canvas.width, canvas.height);
    }
}