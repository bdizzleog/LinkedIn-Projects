$(document)
    .ready(function () {
        $('#Team1PlayersToAdd option').prop('selected', true);
        $('#Team2PlayersToAdd option').prop('selected', true);

        $('#trade1')
           .on('click',
               function () {

                   $('#Team1PlayersToAdd option:selected').remove().appendTo('#Team2PlayersToAdd');
                   $('#Team1PlayersToAdd option').prop('selected', true);
               });
        $('#trade2')
          .on('click',
              function () {
                  $('#Team2PlayersToAdd option:selected').remove().appendTo('#Team1PlayersToAdd');
                  $('#Team2PlayersToAdd option').prop('selected', true);
              });
        $('#save')
         .on('click',
             function () {
                 $('#Team1PlayersToAdd option').prop('selected', true);
                 $('#Team2PlayersToAdd option').prop('selected', true);
             });
    });