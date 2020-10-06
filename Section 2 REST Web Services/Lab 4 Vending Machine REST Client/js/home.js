$(document).ready(function () {

  loadVending();


$('#add-dollar-button').click(function (event) {

  var amount = (parseFloat($('#depositBox').val(), 10)) + (parseFloat($('#add-dollar-button').val(), 10));
  $('#depositBox').val(amount.toFixed(2));
    });

$('#add-quarter-button').click(function (event) {

  var amount = (parseFloat($('#depositBox').val(), 10)) + (parseFloat($('#add-quarter-button').val(), 10));
  $('#depositBox').val(amount.toFixed(2));
    });

$('#add-dime-button').click(function (event) {

  var amount = (parseFloat($('#depositBox').val(), 10)) + (parseFloat($('#add-dime-button').val(), 10));
  $('#depositBox').val(amount.toFixed(2));
    });

  $('#add-nickel-button').click(function (event) {

    var amount = (parseFloat($('#depositBox').val(), 10)) + (parseFloat($('#add-nickel-button').val(), 10));
    $('#depositBox').val(amount.toFixed(2));
      });

$('#make-purchase-button').click(function (event) {

  var haveValidationErrors = checkAndDisplayValidationErrors($('#itemBox'));
    if (haveValidationErrors) {
        return false;
    }

  var amount = $('#depositBox').val();
  $.ajax({
  type: 'GET',
  url: 'http://localhost:8080//money/' + amount + '/item/' + $('#itemBox').val(),
  success: function (data, status){
    $('#messageBox').val("Thank You!!");

    if (data.quarters > 1){
      var quarters = data.quarters + ' Quarters ';
    }
    else if (data.quarters == 1){
      quarters = data.quarters + ' Quarter ';
    }
    else{
      quarters = '';
    }

    if (data.dimes > 1){
      var dimes = data.dimes + ' Dimes ';
    }
    else if (data.dimes == 1){
      dimes = data.dimes + ' Dime ';
    }
    else{
      dimes = '';
    }

    if (data.nickels > 1){
      var nickels = data.nickels + " Nickels ";
    }
    else if (data.nickels == 1){
      nickels = data.nickels + ' Nickel ';
    }
    else{
      nickels = '';
    }

    if (data.pennies > 1){
      var pennies = data.pennies + " Pennies ";
    }
    else if (data.pennies == 1){
      pennies = data.pennies + ' Penny ';
    }
    else{
      pennies = '';
    }

    var change =  quarters + dimes + nickels + pennies;
    $('#changeBox').val(change);

    clearVending();
    loadVending();
  },

  error: function(jqXHR, status) {
    if (jqXHR.status == 422){
    $("#messageBox").val(jqXHR.responseJSON.message);
    }
}

});

});

$('#change-button').click(function (event){
  $('#changeBox').val("");
  $('#messageBox').val("");
  $('#itemBox').val("");
  $('#depositBox').val("0");
});

});

function loadVending(){

  var itemsTable = $('#itemsTable');

  $.ajax({
    type: 'GET',
    url: 'http://localhost:8080/items',
    success: function(data, status){
      $.each(data, function(index, item){
        var name = item.name;
        var price = item.price;
        var quantity = item.quantity;
        var id = item.id;

        var cell = '<div class="col-md-3 itemCell">';
            cell += '<p align= "left">' + id + '</p>';
            cell += '<p>' + name + '</p>';
            cell += '<p>' + '$' + price.toFixed(2) + '</p>';
            cell += '<p>' + 'Quantity Left: ' + quantity + '</p></div>'

            if (id % 3 == 0){
              cell +='<div class="row">';
            }

        itemsTable.append(cell);
        $('.itemCell').css({border: '2px solid black', margin: '5px'});
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

function clearVending(){
  $('#itemsTable').empty();
  $('#depositBox').val("0");

}

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
