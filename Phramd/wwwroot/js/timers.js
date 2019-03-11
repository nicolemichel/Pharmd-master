
// Date Timer
// Change the date every day, 
// ensure the month changes over on the proper date
// switch statement (bundle months with 30/31 days) - account for leap years too

// Time Timer
// seconds, minutes, hours 
//(if statement for military time - hours counts to 24 - then resets @ 1)

let timeNow = new Date();
let hourNow = timeNow.getHours();
let minNow = timeNow.getMinutes();
let secNow = timeNow.getSeconds();

let timeTimer = setInterval('Tock()', 1000);

function Tock() {
    secNow++;
    if (secNow === 60) {
        secNow = 0;
        minNow++;
        if (minNow === 60) {
            hourNow++;
            if (hourNow === 12) {
                /*if (Program.DateFormats.selHour === 'military') {
                    // if selHour === military
                    if (hour === 24)
                        hour = 0;
                }*/
            }
            hour = 0;
            minNow = 0;
        }
    }
    UpdateTime();
}


let thisSec = document.getElementById('second');
let thisMin = document.getElementById('minute');
let thisHour = document.getElementById('hour');

let thisZeroHour = document.getElementById('zeroHour');

function UpdateTime() {
    thisSec.innerHTML =  ":" + secNow;
    if (secNow < 10) {
        thisSec.innerHTML = ":0" + secNow;
    }
    thisMin.innerHTML = minNow;
    if (minNow < 10) {
        thisMin.innerHTML = "0" + minNow;
    }
    if (Program.DateFormats.selHour < 10 && thisZeroHour.length > 1) {
        thisHour.innerHTML = "0" + hourNow + ":";
    }
    else {
        thisHour.innerHTML = hourNow + ":";
    }
}


// News 
var index = 0;

newsSlider();
function newsSlider() {
    var i;
    var y = document.getElementsByClassName("newsSlider");
    for (i = 0; i < y.length; i++) {
        y[i].style.display = "none";
    }
    index++;
    if (index > y.length) { index = 1 }
    y[index - 1].style.display = "block";
    setTimeout(newsSlider, 15000);
}


