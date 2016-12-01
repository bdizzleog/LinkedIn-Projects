var uri = '/api/displayall/'

$(document)
    .ready(function () {
        loadDVDs();
    });

function loadDVDs() {

    $.getJSON(uri)
        .done(function (data) {
            
            $('#movies tbody tr').remove();
            //$('#posterView').remove();
            
            $.each(data,
                function (index, movie) {
                    // add a row to the table for the contact
                    switch(index % 3) {
                        case 0:
                            $('<div class="row">').appendTo($('#posterView'));
                            $(createPosterView(movie)).appendTo($('#posterView'));
                            break;
                        case 1:
                            $(createPosterView(movie)).appendTo($('#posterView'));
                            break;
                        case 2:
                            $(createPosterView(movie)).appendTo($('#posterView'));
                            $('</div>').appendTo($('#posterView'));
                            break;                                           
                    }
                    

                    $(createRow(movie)).appendTo($('#movies tbody'));
                })
                .done($('.clickable-row').click(function () {
                    var infoModal = $('#myModal');
                    var $anchor = $(this);
                    var selector = $anchor.attr('movieId');
                    $.ajax({
                        type: "GET",
                        url: uri + selector,
                        dataType: 'json',
                        success: function (data) {
                            $('.modal-body').empty();
                            $('.modal-footer').empty();
                            $(modalBody(data)).appendTo($('.modal-body'));
                            $(modalFooter(data)).appendTo($('.modal-footer'));
                            infoModal.modal('show');
                        }
                    });
                }), $(console.log("lol")));                  
        });
}

function createRow(movie) {
    return '<tr class="clickable-row" movieId="' + movie.Id +'"><td>' +
        '<img src="' + movie.Poster + '" height="250px" class="poster">' +
        '</td><td>' +
        movie.Title +
        '</td><td>' +
        movie.Director +
        '</td><td>' +
        movie.Year +
        '</td><td>' +
        movie.RatingString +
        '</td><td>' +
        movie.UserRating + "/10" +
        '</td><td>' +
        movie.ImdbRating + "/10" +
        '</td></tr>';
};

function createPosterView(movie) {
    return '<div class="col-sm-4 clickable-row posterDiv" movieId="' + movie.Id + '">' +
        '<center><img src="' + movie.Poster + '" width="240px" class="poster">' +
        '<div><h4>' + movie.Title + '</h4></div></center>' +
        '</div>';
};

function modalBody(movie) {
    var imdbLink = 'http://www.imdb.com/title/' + movie.ImdbId + '/';

    return '<p><strong>Title: </strong>' + movie.Title + '</p>' +
        '<p><strong>Year: </strong>' + movie.Year + '</p>' +
        '<p><strong>Director: </strong>' + movie.Director + '</p>' +
        '<p><strong>Studio: </strong>' + movie.Studio + '</p>' +
        '<p><strong>MPAA Rating: </strong>' + movie.RatingString + '</p>' + //fix this!  Only shows number
        '<p><strong>Release Date: </strong>' + movie.Released + '</p>' + //needs formatting
        '<p><strong>Runtime: </strong>' + movie.RunTime + '</p>' +
        '<p><strong>Genre: </strong>' + movie.Genre + '</p>' +
        '<p><strong>Writer: </strong>' + movie.Writer + '</p>' +
        '<p><strong>Actors: </strong>' + movie.Actors + '</p>' +
        '<p><strong>Plot Synopsis: </strong>' + movie.Plot + '</p>' +
        '<p><strong>Language: </strong>' + movie.Language + '</p>' +
        '<p><strong>Awards: </strong>' + movie.Awards + '</p>' +
        '<p><strong>MetaScore: </strong>' + movie.Metascore + '</p>' + 
        '<p><strong>IMDB Rating: </strong>' + movie.ImdbRating + '</p>' +
        '<p><strong>IMDB ID: </strong><a href="' + imdbLink + '" target="_blank">' + movie.ImdbId + '</a></p>' +
        '<p><strong>User Rating: </strong>' + movie.UserRating + '</p>' +
        '<p><strong>User Notes: </strong>' + movie.UserNotes + '</p>' +
        '<p><strong>Status: </strong>' + movie.StatusString + '</p>' + //fix this!  Only shows number
        '<p><strong>Check Out Date: </strong>' + movie.CheckOutDate + '</p>' + //needs formatting
        '<p><strong>Date Returned: </strong>' + movie.ReturnDate + '</p>' + //needs formatting
        '<p><strong>Previous Borrower: </strong>' + movie.Borrower + '</p>' //needs formatting
        ;
}

function modalFooter(movie) {
    var checkoutDVD = '<a class="btn btn-primary" href="/Admin/CheckoutDVD/' + movie.Id + '">Checkout DVD</a>';
    var returnDVD = '<a class="btn btn-primary" href="/Admin/ReturnDVD/' + movie.Id + '">Return DVD</a>';
    var deleteDVD = '<a class="btn btn-danger" href="/Admin/DeleteDVD/' + movie.Id + '">Delete DVD</a>';
    var closeModal = '<button type="button" class="btn btn-default" data-dismiss="modal">Close</button>';
    
    var str = "";

    switch(movie.Status)
    {
        case 0:
            str += checkoutDVD;
            break;
        case 1:
        case 2:
            str += returnDVD;
            break;
        default:
            str += checkoutDVD;
            str += returnDVD;
            console.log("woah there there is a bad enum value somehow")
            break;
    }
    str += deleteDVD;
    str += closeModal;
    return str;
}