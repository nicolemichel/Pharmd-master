
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
// Movie Marvel Cast Page - Images Array ????
// Same as slider from the home page with a switch for time amount
Program.NewsData.headlines = parseInt(articleCount);
Program.NewsData.headline = article;
Program.NewsData.publishDates = parseInt(dateCount);
Program.NewsData.published = date;
Program.News.selTime = timeAmount;

let newsTimer = setInterval('Next()', timeAmount);

pos = 0;
articleCount = 0;
dateCount = 0;
function Next(_articleCount, _dateCount) {
    UpdateHeadline();
    pos++;
    articleCount++;
    dateCount++;
    if (pos === articleCount) {
        articleCount = 0;
        dateCount = 0;
    }
}

/*var nextHeadline = 0;
var nextPublished = 0;
function Next(_articleCount, _dateCount) {
    var i;
    var x = document.getElementById('newsGrid');
    for (i = 0; i < x.length; i++) {
        x[i].style.display = "none";
    }
    nextHeadline++;
    nextPublished++;
    if (nextHeadline === x.length) {
        nextHeadline = 1;
        nextPublished = 1;
    }
    UpdateHeadline();
}*/

let thisHeadline = document.getElementById('headline');
let thisPublished = document.getElementById('published');

function UpdateHeadline() {
    thisHeadline.innerHTML = nextHeadline;
    thisPublished.innerHTML = nextPublished;
}
