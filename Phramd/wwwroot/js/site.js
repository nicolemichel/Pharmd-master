
// Login/Signup Drop down
var modal = document.getElementById('logIn', 'register');
window.onclick = function (event) {
    if (event.target === modal) {
        modal.style.display = "none";
    }
}

// Only show selected email for calendar
$(function () {
    $(".gmailCal").on("click", function (e) {
        $(".hiddenGmail").toggle()
        $(".hiddenApple").toggle(this.hidden)
        $(".hiddenMicro").toggle(this.hidden)

    })
    $(".appleCal").on("click", function (e) {
        $(".hiddenApple").toggle()
        $(".hiddenMicro").toggle(this.hidden)
        $(".hiddenGmail").toggle(this.hidden)
        e.preventDefault();
    })
    $(".microCal").on("click", function (e) {
        $(".hiddenMicro").toggle()
        $(".hiddenApple").toggle(this.hidden)
        $(".hiddenGmail").toggle(this.hidden)
        e.preventDefault();
    })
    $(".gPhoto").on("click", function (e) {
        $(".hiddenGPhoto").toggle()
        e.preventDefault();
    })
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

$("noRefresh").click(function (e) {
    e.preventDefault();
});


