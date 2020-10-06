$(document).ready(function () {




  $('#getWeather-button').click(function (event) {

    var haveValidationErrors = checkAndDisplayValidationErrors($('#weather-form').find('input'));
    if (haveValidationErrors) {
        return false;
    }

    $('#currentConditions').empty();
    $('#fiveDayConditions').empty();

    getWeather();
    getFiveDay();
  });

  function getWeather(){

    var units = $('#units').val();
    var zipCode = $('#zipCode').val();

    $.ajax ({
        type: 'GET',
        url: 'http://api.openweathermap.org/data/2.5/weather?zip=' + zipCode + ',us&units=' + units + '&appid=be83ce8cb2691b28fe78af2ec7941437',
        success: function (data, status) {
          var image = 'http://openweathermap.org/img/w/' + data.weather[0].icon + '.png';

          $('#currentHeader').text('Current Conditions in ' + data.name);

          var row = '<div class="col-md-4 details">' + '<img src="'+image+'" alt="weather icon">' + '</div>';
          row += '<div class="col-md-4 details">' + 'Description: '  + data.weather[0].description + '</div>';
          row += '<div class="col-md-4 details">' + 'Temperature: ' + data.main.temp + 'F' + '<br>' + 'Humidity: ' + data.main.humidity + '%' + '<br>' + 'Wind: ' + data.wind.speed + 'MPH' + '</div>';

          $('#currentConditions').append(row);
        },
        error: function() {
            $('#errorMessages')
                .append($('<li>')
                .attr({class: 'list-group-item list-group-item-danger'})
                .text('Error calling web service.  Please try again later.'));
        }
    });

  }

  function getFiveDay(){

    $('#fiveDayHeader').text('Five Day Forecast');

    var units = $('#units').val();
    var zipCode = $('#zipCode').val();

    $.ajax({
      type: 'GET',
      url: 'http://api.openweathermap.org/data/2.5/forecast/daily?zip=' + zipCode + ',us&units=' + units + '&cnt=5&appid=be83ce8cb2691b28fe78af2ec7941437',
      success: function (data, status){
        $.each(data.list, function (index, day) {

          var month = new Array(12);
          month[1] = "January";
          month[2] = "February";
          month[3] = "March";
          month[4] = "April";
          month[5] = "May";
          month[6] = "June";
          month[7] = "July";
          month[8] = "August";
          month[9] = "September";
          month[10] = "October";
          month[11] = "November";
          month[12] = "December";
          var date = new Date(0);
                    date.setSeconds(day.dt);
                    var dd = date.getDate();
                    var m = date.getMonth();
                    var monthName = month[m];

          var icon = 'http://openweathermap.org/img/w/' + day.weather[0].icon + '.png';
          var description = day.weather[0].description;
          var high = day.temp.max;
          var low = day.temp.min;

          var cell = '<div class="col-md-2 details">';
          cell += dd + ' ' + monthName + '<br>';
          cell += '<img src="'+ icon +'" alt="weather icon">' + description + '<br>';
          cell += 'H '  + high + '   ' + 'L ' + low + '<br>';
          cell += '</div>';

          $('#fiveDayConditions').append(cell);
          });
        },
        error: function() {
            $('#errorMessages')
                .append($('<li>')
                .attr({class: 'list-group-item list-group-item-danger'})
                .text('Error calling web service.  Please try again later.'));
        }

      });

  }
});

function checkAndDisplayValidationErrors(input) {
    $('#errorMessages').empty();
    var errorMessages = [];

    input.each(function() {
        if(!this.validity.valid)
        {
            var errorField = $('label[for='+this.id+']').text();
            errorMessages.push(errorField + ' ' + this.validationMessage);
        }
    });

    if (errorMessages.length > 0){
        $.each(errorMessages,function(index,message){
            $('#errorMessages').append($('<li>').attr({class: 'list-group-item list-group-item-danger'}).text(message));
        });
        return true;
    } else {
        return false;
    }
}
