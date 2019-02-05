var modal = document.getElementById('logIn', 'register');
window.onclick = function (event) {
    if (event.target == modal) {
        modal.style.display = "none";
    }
}

$(function (){
        $(".gmailCal").on("click", function () {
            $(".hiddenGmail").toggle()
        })
        $(".appleCal").on("click", function () {
            $(".hiddenApple").toggle()
        })
        $(".microCal").on("click", function () {
            $(".hiddenMicro").toggle()
        })
        $(".gPhoto").on("click", function () {
            $(".hiddenGPhoto").toggle()
        })
    }
)
