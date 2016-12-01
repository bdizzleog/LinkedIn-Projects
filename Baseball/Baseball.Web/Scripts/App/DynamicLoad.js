$(document)
    .ready(function () {
        // select all the items in the roster list
        // this is due to model binding only posting values that are selected
        $('#PlayersToAdd option').prop('selected', true);

        $('#add')
            .on('click',
                function () {
                    $('#available option:selected').remove().appendTo('#PlayersToAdd');

                    // ensure all values stay selected, so they will all post
                    $('#PlayersToAdd option').prop('selected', true);
                });

        $('#remove')
            .on('click',
                function () {
                    $('#PlayersToAdd option:selected').remove().appendTo('#available');

                    // ensure all values stay selected, so they will all post
                    $('#PlayersToAdd option').prop('selected', true);
                });
    });