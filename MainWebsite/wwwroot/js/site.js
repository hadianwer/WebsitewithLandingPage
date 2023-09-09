// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

        // Function to add the blinking effect on website load
   

    
    function toggleMenu() {
    const menu = document.querySelector('.hamburger-menu');
    const navigation = document.querySelector('.main-navigation');
    menu.classList.toggle('open');
    navigation.classList.toggle('open');
    }

var subscribed = @Json.Serialize(ViewBag.Subscribed ?? false);

$(document).ready(function () {

    if (subscribed) {
        $('#thankYouToast').toast('show');
    }
});
