$(document)
    .ready(function () { 
        $('#PlayersToAdd option').prop('selected', true);

        $('#remove')
           .on('click',
               function () {
                   $('#PlayersToRemove option:selected').remove().appendTo('#PlayersToAdd');          
                   $('#FreeAgency option').prop('selected', true);
               });
        $('#saveRemove')
         .on('click',
             function () {
                 $('#PlayersToAdd option').prop('selected', true);
             });
    });