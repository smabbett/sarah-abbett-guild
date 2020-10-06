$(document).ready(function () {
  loadDvds();

  $('#create-dvd-button').click(function (event) {
    $('#navHeader').hide();
    $('#dvdListDiv').hide();
    $('#add-dvd-form').show();
  });

  $('#add-dvd-button').click(function (event){

    $('#errorMessages').empty();

    var haveValidationErrors = checkAndDisplayValidationErrors($('#add-dvd-form').find('input'));
    if (haveValidationErrors) {
        return false;
    }

    $.ajax({
        type: 'POST',
        url: 'http://localhost:8080/dvd',
        data: JSON.stringify({
            title: $('#add-title').val(),
            realeaseYear: $('#add-year').val(),
            director: $('#add-director').val(),
            rating: $('#add-rating').val(),
            notes: $('#add-notes').val()
        }),
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        'dataType': 'json',
        success: function(data, status) {
            // clear errorMessages
            $('#errorMessages').empty();
           // Clear the form and reload the table
            $('#add-title').val('');
            $('#add-year').val('');
            $('#add-director').val('');
            $('#add-rating').val('');
            $('#add-notes').val('');

            hideAddForm();
            loadDvds();
        },
        error: function() {
            $('#errorMessages')
               .append($('<li>')
               .attr({class: 'list-group-item list-group-item-danger'})
               .text('Error calling web service.  Please try again later.'));
        }
    });
  });

  $('#edit-dvd-button').click(function(event){

    $('#errorMessages').empty();

    var haveValidationErrors = checkAndDisplayValidationErrors($('#edit-dvd-form').find('input'));
    if (haveValidationErrors) {
        return false;
    }

    $.ajax({
       type: 'PUT',
       url: 'http://localhost:8080/dvd/' + $('#edit-dvd-id').val(),
       data: JSON.stringify({
         dvdId: $('#edit-dvd-id').val(),
         title: $('#edit-title').val(),
         realeaseYear: $('#edit-year').val(),
         director: $('#edit-director').val(),
         rating: $('#edit-rating').val(),
         notes: $('#edit-notes').val()
       }),
       headers: {
         'Accept': 'application/json',
         'Content-Type': 'application/json'
       },
       'dataType': 'json',
        success: function() {
            $('#errorMessages').empty();
            hideEditForm();
            loadDvds();
       },
       error: function() {
         $('#errorMessages')
            .append($('<li>')
            .attr({class: 'list-group-item list-group-item-danger'})
            .text('Error calling web service.  Please try again later.'));
       }
   })

  })

  $('#search-button').click(function(event){

    $('#errorMessages').empty();
    var choice = $('#searchCategory').val();
    var searchTerm = $('#search-term-box').val();

    var haveValidationErrors = checkAndDisplayValidationErrors($('#search-form').find('input'));
    if (haveValidationErrors) {
        return false;
    }

    if (choice == null){
    return false;
    }

    clearDvdTable();

    var contentRows = $('#contentRows');

    $.ajax ({
        type: 'GET',
        url: 'http://localhost:8080/dvds/' + choice + '/' + searchTerm,
        success: function (data, status) {
            $.each(data, function (index, dvd) {
                var id = dvd.dvdId;
                var title = dvd.title;
                var releaseYear = dvd.realeaseYear;
                var director = dvd.director;
                var rating = dvd.rating;
                var notes = dvd.notes;

                var row = '<tr>';
                    row += '<td><a onclick="showDvdDetails(' + id + ')">' + title + '</a></td>';
                    row += '<td>' + releaseYear + '</td>';
                    row += '<td>' + director + '</td>';
                    row += '<td>' + rating + '</td>';
                    row += '<td><a onclick="showEditForm(' + id + ')">Edit</a> | <a onclick="deleteDvd(' + id + ')">Delete</a></td>';
                    row += '</tr>';
                contentRows.append(row);
            });
        },
        error: function() {
            $('#errorMessages')
                .append($('<li>')
                .attr({class: 'list-group-item list-group-item-danger'})
                .text('Error calling web service.  Please try again later.'));
        }
    });
  })

  $('#back-button').click(function(event){
    $('#dvdDetailsHeader').text('');
    $('#dvdDetails').text('');
    $('#dvdDetailsDiv').hide();
    $('#navHeader').show();
    $('#dvdListDiv').show();
  })
});

function loadDvds(){
  clearDvdTable();

  var contentRows = $('#contentRows');

    $.ajax ({
        type: 'GET',
        url: 'http://localhost:8080/dvds',
        success: function (data, status) {
            $.each(data, function (index, dvd) {
                var id = dvd.dvdId;
                var title = dvd.title;
                var releaseYear = dvd.realeaseYear;
                var director = dvd.director;
                var rating = dvd.rating;
                var notes = dvd.notes;

                var row = '<tr>';
                    row += '<td><a onclick="showDvdDetails(' + id + ')">' + title + '</a></td>';
                    row += '<td>' + releaseYear + '</td>';
                    row += '<td>' + director + '</td>';
                    row += '<td>' + rating + '</td>';
                    row += '<td><a onclick="showEditForm(' + id + ')">Edit</a> | <a onclick="deleteDvd(' + id + ')">Delete</a></td>';
                    row += '</tr>';
                contentRows.append(row);
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

function clearDvdTable() {
    $('#contentRows').empty();
}

function showEditForm(dvdId) {
    $('#errorMessages').empty();

    $.ajax({
        type: 'GET',
        url: 'http://localhost:8080/dvd/' + dvdId,
        success: function(data, status) {
              $('#edit-header').append(data.title);
              $('#edit-title').val(data.title);
              $('#edit-year').val(data.realeaseYear);
              $('#edit-director').val(data.director);
              $('#edit-rating').val(data.rating);
              $('#edit-notes').val(data.notes);
              $('#edit-dvd-id').val(data.dvdId);
          },
          error: function() {
            $('#errorMessages')
               .append($('<li>')
               .attr({class: 'list-group-item list-group-item-danger'})
               .text('Error calling web service.  Please try again later.'));
          }
    });
    $('#navHeader').hide();
    $('#dvdListDiv').hide();
    $('#edit-dvd-form').show();
}

function hideAddForm(){
  $('#navHeader').show();
  $('#dvdListDiv').show();
  $('#add-dvd-form').hide();
}

function hideEditForm(){
  $('#navHeader').show();
  $('#dvdListDiv').show();
  $('#edit-dvd-form').hide();
}

function showDvdDetails(dvdId){
    $('#errorMessages').empty();

    $('#navHeader').hide();
    $('#dvdListDiv').hide();

  $.ajax ({
      type: 'GET',
      url: 'http://localhost:8080/dvd/' + dvdId,
      success: function (data, status) {

              var id = data.dvdId;
              var title = data.title;
              var releaseYear = data.realeaseYear;
              var director = data.director;
              var rating = data.rating;
              var notes = data.notes;

              var cell = '<p>' + releaseYear + '</p>';
                  cell += '<p>' + director + '</p>';
                  cell += '<p>' + rating + '</p>';
                  cell += '<p>' + notes + '</p>';

              $('#dvdDetailsHeader').append(title);
              $('#dvdDetails').append(cell);
              $('#dvdDetailsDiv').show();

      },
      error: function() {
          $('#errorMessages')
              .append($('<li>')
              .attr({class: 'list-group-item list-group-item-danger'})
              .text('Error calling web service.  Please try again later.'));
      }
  });

}

  function deleteDvd(dvdId) {
      var response = confirm("Are you sure you want to delete this DVD from your collection?");
      if (response == true){

        $.ajax ({
            type: 'DELETE',
            url: "http://localhost:8080/dvd/" + dvdId,
            success: function (status) {
                loadDvds();
            }
        });
      }
    }

function checkAndDisplayValidationErrors(input) {

    $('#errorMessages').empty();
    var errorMessages = [];

    input.each(function() {
        if(!this.validity.valid)
        {
          switch ($(this).attr('id')) {
            case 'search-term-box':
            this.setCustomValidity('Both Search Category and Search Term are required.');
            break;
            case 'searchCategory':
            this.setCustomValidity('Both Search Category and Search Term are required.');
            break;
            case 'edit-year':
            this.setCustomValidity('Please enter a 4-digit year.');
            break;
            case 'edit-title':
            this.setCustomValidity('Please enter a title for the DVD.');
            break;
            case 'add-year':
            this.setCustomValidity('Please enter a 4-digit year.');
            break;
            case 'add-title':
            this.setCustomValidity('Please enter a title for the DVD.');
            break;
            default:
          }
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
