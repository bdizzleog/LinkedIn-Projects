$('.clickable-row').click(function (e) {
    e.preventDefault();
    //alert("lol");
    var $anchor = $(this);
    var selector = $anchor.attr('href') + 'Collapse';
    $('.panel-collapse.in').not(selector).collapse('hide');
    $('html, body').stop().animate({
        scrollTop: ($($anchor.attr('href')).offset().top - 75)
    }, 1250, 'easeInOutExpo');

   
    console.log($(selector));
    $(selector).collapse('show');
});