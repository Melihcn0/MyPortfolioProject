//layout menu
document.addEventListener('DOMContentLoaded', function () {
    var currentPage = window.location.pathname;
    var navLinks = document.querySelectorAll('.nav-link');

    navLinks.forEach(function (navLink) {
        var href = navLink.getAttribute('href');
        if (currentPage.includes(href) || currentPage === href) {
            navLink.classList.add('active');
            navLink.parentElement.classList.add('active'); // `li` öğesine `active` sınıfı ekleyin
        } else {
            navLink.classList.remove('active');
            navLink.parentElement.classList.remove('active'); // `li` öğesinden `active` sınıfını kaldırın
        }
    });
});


