
// Login/Signup Drop down
var modal = document.getElementById('logIn', 'register');
window.onclick = function (event) {
    if (event.target === modal) {
        modal.style.display = "none";
    }
};

// Only show selected email for calendar
$(function () {
    $(".gmailCal").on("click", function (e) {
        $(".hiddenGmail").toggle();
        $(".hiddenApple").toggle(this.hidden);
        $(".hiddenMicro").toggle(this.hidden);

    });
    $(".appleCal").on("click", function (e) {
        $(".hiddenApple").toggle();
        $(".hiddenMicro").toggle(this.hidden);
        $(".hiddenGmail").toggle(this.hidden);
        e.preventDefault();
    });
    $(".microCal").on("click", function (e) {
        $(".hiddenMicro").toggle();
        $(".hiddenApple").toggle(this.hidden);
        $(".hiddenGmail").toggle(this.hidden);
        e.preventDefault();
    });
    $(".gPhoto").on("click", function (e) {
        $(".hiddenGPhoto").toggle();
        e.preventDefault();
    });
});

// Logout/No Account Slider
// SHOULD MAKE THE HOME PAGE
var myIndex = 0;
carousel();
function carousel() {
    var i;
    var x = document.getElementsByClassName("mySlides");
    for (i = 0; i < x.length; i++) {
        x[i].style.display = "none";
    }
    myIndex++;
    if (myIndex > x.length) { myIndex = 1 }
    x[myIndex - 1].style.display = "block";
    setTimeout(carousel, 5000);
}

function ClearPhotos() {
    document.getElementById("gPhotoText").value = "";
}

function ClearDT() {
    document.getElementById("dropDate").value = "";
    doument.getElementById("dropDate").text = "Date";
    document.getElementById("dropMonth").value = "";
    doument.getElementById("dropMonth").text = "Month";
    document.getElementById("dropDay").value = "";
    doument.getElementById("dropDay").text = "Day";
    document.getElementById("dropYear").value = "";
    doument.getElementById("dropYear").text = "Year";
    document.getElementById("dropHour").value = "";
    doument.getElementById("dropHour").text = "Hour";
    document.getElementById("dropMin").value = "";
    doument.getElementById("dropMin").text = "Minutes";
    document.getElementById("dropSec").value = "";
    doument.getElementById("dropSec").text = "Seconds";
    document.getElementById("dropAP").value = "";
    doument.getElementById("dropAP").text = "Time";
}

function ClearWeather() {
    document.getElementById("country").value = "";
    document.getElementById("country").text = "Country";
    document.getElementById("city").value = "";
    document.getElementById("city").text = "City";
    document.getElementById("unit").value = "";
    document.getElementById("unit").text = "Unit of Measurement";
}

function ClearNews() {
    document.getElementById("coun").value = "";
    document.getElementById("coun").text = "Country";
    document.getElementById("article").value = "";
    document.getElementById("article").text = "Articles";
    document.getElementById("dropTime").value = "";
    document.getElementById("dropTime").text = "Time to Read";
}

