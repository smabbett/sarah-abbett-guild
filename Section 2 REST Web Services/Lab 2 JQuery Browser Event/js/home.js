$(document).ready(function () {
    $('#akronInfoDiv').hide();
    $('#minneapolisInfoDiv').hide();
    $('#louisvilleInfoDiv').hide();
    $('#mainButton').on('click', function(){
      $('#mainInfoDiv').show();
      $('#louisvilleInfoDiv').hide();
      $('#minneapolisInfoDiv').hide();
      $('#akronInfoDiv').hide();
    });
    $('#akronButton').on('click', function(){
      $('#mainInfoDiv').hide();
      $('#louisvilleInfoDiv').hide();
      $('#minneapolisInfoDiv').hide();
      $('#akronInfoDiv').show();
      $('#akronWeather').hide();
    });
  $('#minneapolisButton').on('click', function(){
    $('#mainInfoDiv').hide();
    $('#akronInfoDiv').hide();
    $('#louisvilleInfoDiv').hide();
    $('#minneapolisInfoDiv').show();
    $('#minneapolisWeather').hide();
  });
$('#louisvilleButton').on('click', function(){
  $('#mainInfoDiv').hide();
  $('#akronInfoDiv').hide();
  $('#minneapolisInfoDiv').hide();
  $('#louisvilleInfoDiv').show();
  $('#louisvilleWeather').hide();
  });
$('#akronWeatherButton').on('click', function(){
  $('#akronWeather').toggle('fast');
  });
$('#minneapolisWeatherButton').on('click', function(){
  $('#minneapolisWeather').toggle('fast');
  });
$('#louisvilleWeatherButton').on('click', function(){
  $('#louisvilleWeather').toggle('fast');
  });
$('tr:nth-child(2)').hover(
    function(){
      $(this).css('background-color', 'WhiteSmoke');
    },
    function(){
      $(this).css('background-color', '');
    }
  );
$('tr:nth-child(3)').hover(
      function(){
        $(this).css('background-color', 'WhiteSmoke');
      },
      function(){
        $(this).css('background-color', '');
      }
    );
});
