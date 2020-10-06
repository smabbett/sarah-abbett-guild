$(document).ready(function () {
    $('h1').addClass('text-center');
    $('h2').addClass('text-center');
    $('.myBannerHeading').addClass('page-header');
    $('.myBannerHeading').removeClass('myBannerHeading');
    $("#yellowHeading").text("Yellow Team");
    $(".orange").css('background-color','orange');
    $(".blue").css('background-color','blue');
    $(".red").css('background-color','red');
    $(".yellow").css('background-color','yellow');
    $("#yellowTeamList").append('ul').html('<li>Joseph Banks</li><li>Simon Jones</li>');
    $('#oops').hide();
    $('#footerPlaceholder').remove();
    $('#footer').append('p').text('Sarah Abbett sarah.abbett@gmail.com');
    $('footer').css({'height':'24','font-family':'Courier', 'text-align':'center'});
});
