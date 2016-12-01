$(document)
    .ready(function () {
        $('#teamForm')
            .validate({
                rules: {
                    Name: {
                        required: true,                      
                        rangelength: [1, 25]
                    },
                    Manager: {
                        required: true,                     
                        rangelength: [1, 25]
                    }

                },
                messages: {
                    Name: {
                        required: "Please enter a Name for the Team",                   
                        rangelength: "Out of range, (25 letter max)"
                    },
                    Manager: {
                        required: "Please enter a Name for the Team Manager",                    
                        rangelength: "Out of range, (25 letter max)"
                    }

                }
            });
    });