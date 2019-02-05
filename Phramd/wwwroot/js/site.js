/*Pops up the Login/Signup*/
var modal = document.getElementById('logIn', 'register');
window.onclick = function (event) {
    if (event.target === modal) {
        modal.style.display = "none";
    }
}
/*Hides other Input Fields to allow only one at a time - reduces confusion*/
$(function () {
        $("#gmailCal").on("click", function () {
            $("#hiddenGmail").toggle()
            $("#hiddenApple").toggle(this.hidden)
            $("#hiddenMicro").toggle(this.hidden)
        })
        $("#appleCal").on("click", function () {
            $("#hiddenApple").toggle()
            $("#hiddenGmail").toggle(this.hidden)
            $("#hiddenMicro").toggle(this.hidden)
        })
        $("#microCal").on("click", function () {
            $("#hiddenMicro").toggle()
            $("#hiddenGmail").toggle(this.hidden)
            $("#hiddenApple").toggle(this.hidden)
        })
        $("#gPhoto").on("click", function () {
            $("#hiddenGPhoto").toggle()
        })
    }
)
/*Slider for Product Information*/
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
