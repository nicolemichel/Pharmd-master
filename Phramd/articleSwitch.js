let speed = 15000; // has to connect to dropdown list - default 15 seconds
let article = 0;
let timed = true;
let articleTimer = setInterval('SwapNews(' + article + ', ' + timed + ')' + speed);

let news = [
    @headline @published

    // grab article count from dropdown - bringing in needed articles

];

function SwapNews(timed) {
    if (timed) {
        article++;
    }
}

// get needed info from Razor 