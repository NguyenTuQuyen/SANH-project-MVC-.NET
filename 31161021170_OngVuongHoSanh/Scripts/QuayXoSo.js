
    function IsNumeric(n) {
            return !isNaN(n);
}

        $(function () {

        $("#getit").click(function () {

            var numLow = 1;
            var numHigh = 100;

            var adjustedHigh = (parseFloat(numHigh) - parseFloat(numLow)) + 1;

            var numRand3 = Math.floor(Math.random() * adjustedHigh) + parseFloat(numLow);

            if ((IsNumeric(numLow)) && (IsNumeric(numHigh)) && (parseFloat(numLow) <= parseFloat(numHigh)) && (numLow != '') && (numHigh != '')) {


                var so1 = document.getElementById("so1").value;
                if (isNaN(so1) || (so1 >= 101) || (so1 <= 0)) {
                    alert('Bạn vui lòng nhập lại số dự đoán thứ nhất');
                    return false;
                }
                if (so1 == '') {
                    alert('Bạn không được bỏ trống ô thứ nhất');
                    return false;
                }
                var so2 = document.getElementById("so2").value;
                if (isNaN(so2) || (so2 >= 101) || (so2 <= 0)) {
                    alert('Bạn vui lòng nhập lại số dự đoán thứ hai');
                    return false;
                }
                if (so2 == '') {
                    alert('Bạn không được bỏ trống ô thứ 2');
                    return false;
                }
                var so3 = document.getElementById("so3").value;
                if (isNaN(so3) || (so3 >= 101) || (so3 <= 0)) {
                    alert('Bạn vui lòng nhập lại số dự đoán thứ 3');
                    return false;
                }
                if (so3 == '') {
                    alert('Bạn không được bỏ trống ô thứ 3');
                    return false;
                }
                var a = '';
                $("#randomnumber4").text(numRand3);
                if (so1 == numRand3) {
                    a = 'Chúc mừng bạn đã dự đoán đúng';
                    $("#ketqua").text(a);
                } else {
                    if (so2 == numRand3) {
                        a = 'Chúc mừng bạn đã dự đoán đúng';
                        $("#ketqua").text(a);
                    } else {
                        if (so3 == numRand3) {
                            a = 'Chúc mừng bạn đã dự đoán đúng';
                            $("#ketqua").text(a);
                        } else {
                            a = 'Chúc bạn may mắn lần sau';
                            $("#ketqua").text(a);
                        }
                    }
                }

            } else {
                $("#randomnumber").text("Careful now...");
            }
            return false;


        });

    $("input[type=text]").each(function () {
        $(this).data("first-click", true);
    });

            $("input[type=text]").focus(function () {

                if ($(this).data("first-click")) {
        $(this).val("");
    $(this).data("first-click", false);
    $(this).css("color", "black");
}

});

});

        //<![CDATA[
        var pictureSrc = "https://1.bp.blogspot.com/-CXx9jt2JMRk/Vq-Lh5fm88I/AAAAAAAASwo/XivooDn_oSY/s1600/hoamai.png"; //the location of the snowflakes
        var pictureWidth = 30; //the width of the snowflakes
        var pictureHeight = 30; //the height of the snowflakes
        var numFlakes = 10; //the number of snowflakes
        var downSpeed = 0.01; //the falling speed of snowflakes (portion of screen per 100 ms)
        var lrFlakes = 10; //the speed that the snowflakes should swing from side to side


        if (typeof (numFlakes) != 'number' || Math.round(numFlakes) != numFlakes || numFlakes < 1) {numFlakes = 10; }

        //draw the snowflakes
        for (var x = 0; x < numFlakes; x++) {
            if (document.layers) { //releave NS4 bug
            document.write('<layer id="snFlkDiv' + x + '"><imgsrc="' + pictureSrc + '" height="' + pictureHeight + '"width="' + pictureWidth + '" alt="*" border="0"></layer>');
        } else {
            document.write('<div style="position:absolute; z-index:9999;"id="snFlkDiv' + x + '"><img src="' + pictureSrc + '"height="' + pictureHeight + '" width="' + pictureWidth + '" alt="*"border="0"></div>');
        }
    }

    //calculate initial positions (in portions of browser window size)
    var xcoords = new Array(), ycoords = new Array(), snFlkTemp;
        for (var x = 0; x < numFlakes; x++) {
            xcoords[x] = (x + 1) / (numFlakes + 1);
        do {
            snFlkTemp = Math.round((numFlakes - 1) * Math.random());
        } while (typeof (ycoords[snFlkTemp]) == 'number');
        ycoords[snFlkTemp] = x / numFlakes;
    }

    //now animate
        function flakeFall() {
            if (!getRefToDivNest('snFlkDiv0')) { return ; }
        var scrWidth = 0, scrHeight = 0, scrollHeight = 0, scrollWidth = 0;
        //find screen settings for all variations. doing this every time allows for resizing and scrolling
            if (typeof (window.innerWidth) == 'number') {scrWidth = window.innerWidth; scrHeight = window.innerHeight; } else {
                if (document.documentElement && (document.documentElement.clientWidth || document.documentElement.clientHeight)) {
            scrWidth = document.documentElement.clientWidth; scrHeight = document.documentElement.clientHeight;
                } else {
                    if (document.body && (document.body.clientWidth || document.body.clientHeight)) {
            scrWidth = document.body.clientWidth; scrHeight = document.body.clientHeight;
    }
}
}
            if (typeof (window.pageYOffset) == 'number') {scrollHeight = pageYOffset; scrollWidth = pageXOffset; } else {
                if (document.body && (document.body.scrollLeft || document.body.scrollTop)) {scrollHeight = document.body.scrollTop; scrollWidth = document.body.scrollLeft; } else {
                    if (document.documentElement && (document.documentElement.scrollLeft || document.documentElement.scrollTop)) {scrollHeight = document.documentElement.scrollTop; scrollWidth = document.documentElement.scrollLeft; }
    }
}
//move the snowflakes to their new position
            for (var x = 0; x < numFlakes; x++) {
                if (ycoords[x] * scrHeight > scrHeight - pictureHeight) {ycoords[x] = 0; }
                var divRef = getRefToDivNest('snFlkDiv' + x); if (!divRef) { return ; }
                if (divRef.style) {divRef = divRef.style; } var oPix = document.childNodes ? 'px' : 0;
        divRef.top = (Math.round(ycoords[x] * scrHeight) + scrollHeight) + oPix;
        divRef.left = (Math.round(((xcoords[x] * scrWidth) - (pictureWidth / 2)) + ((scrWidth / ((numFlakes + 1) * 4)) * (Math.sin(lrFlakes * ycoords[x]) - Math.sin(3 * lrFlakes * ycoords[x])))) + scrollWidth) + oPix;
        ycoords[x] += downSpeed;
    }
}

//DHTML handlers
        function getRefToDivNest(divName) {
            if (document.layers) { return document.layers[divName]; } //NS4
            if (document[divName]) { return document[divName]; } //NS4 also
            if (document.getElementById) { return document.getElementById(divName); } //DOM (IE5+, NS6+, Mozilla0.9+, Opera)
            if (document.all) { return document.all[divName]; } //Proprietary DOM - IE4
        return false;
    }

    window.setInterval('flakeFall();', 100);
        //]]>
