$(document)
    .ready(function () {
        $('#TeamsToAdd option').prop('selected', true);
        $('#add')
            .on('click',
                function () {
                    $('#Leagueless option:selected').remove().appendTo('#TeamsToAdd');
                    $('#TeamsToAdd option').prop('selected', true);
                });
        $('#save')
           .on('click',
               function () {
                   $('#TeamsToAdd option').prop('selected', true);
               });
    });