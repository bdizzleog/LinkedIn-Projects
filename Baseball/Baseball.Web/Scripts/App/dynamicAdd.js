$(document)
    .ready(function () {   
       $('#PlayersToAdd option').prop('selected', true);
        $('#add')
            .on('click',
                function () {
                    $('#FreeAgents option:selected').remove().appendTo('#PlayersToAdd');                 
                    $('#PlayersToAdd option').prop('selected', true);
                });     
        $('#save')
           .on('click',
               function () {                  
                   $('#PlayersToAdd option').prop('selected', true);            
               });
    });