
// Login/Signup Drop down
var modal = document.getElementById('logIn', 'register');
window.onclick = function (event) {
    if (event.target === modal) {
        modal.style.display = "none";
    }
}

// Only show selected email for calendar
$(function () {
        $(".gmailCal").on("click", function () {
            $(".hiddenGmail").toggle()
            $(".hiddenApple").toggle(this.hidden)
            $(".hiddenMicro").toggle(this.hidden)
        })
        $(".appleCal").on("click", function () {
            $(".hiddenApple").toggle()
            $(".hiddenMicro").toggle(this.hidden)
            $(".hiddenGmail").toggle(this.hidden)
        })
        $(".microCal").on("click", function () {
            $(".hiddenMicro").toggle()
            $(".hiddenApple").toggle(this.hidden)
            $(".hiddenGmail").toggle(this.hidden)
        })
        $(".gPhoto").on("click", function () {
            $(".hiddenGPhoto").toggle()
        })
    }
)

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

// News 
// Better to have slider or timer?
// Movie Marvel Cast Page - Images Array ????



