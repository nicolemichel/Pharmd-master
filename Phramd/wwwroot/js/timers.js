
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
// Better to have slider or timer?
// C# Timer is working, just have to page refresh - just set up a js refresh for that div???
// Have to bring in the time selected from the drop down (or take away the time choice/only allow them 15 seconds)
// Same as slider from the home page with a switch for time amount???
// headlines = list, headline = pos in list - need to incriment the pos after the selected time amount
let headlines = [];
let publishDates = [];
let selTime;

function SetData(_headlines, _publishDates, _selTime) {
    headlines = _headlines;
    publishDates = _publishDates;
    selTime = _selTime;
}

let article = 0;
let date = 0;

let newsTimer = setInterval('Next()', selTime);

function Next() {
    article++;
    date++;
    
    if (article === headlines.length) {
        article = 0;
        date = 0;
    }
    UpdateHeadline();
}

let thisHeadline = document.getElementById('headline');
let thisPublished = document.getElementById('published');

function UpdateHeadline() {
    thisHeadline.innerHTML = headlines[article];
    thisPublished.innerHTML = published[date];
}
