<script>    function checkIfFavorite() {
      $.ajax({
          type: 'GET',
          dataType: 'json',
          url: 'http://localhost:63445/api/Admin/Specials',
          success: function (data, status) {
              $.each(data, function (index, special) {
                  var name = special.;
                  var company = data.;

              });
          }
      });
  }</script>
