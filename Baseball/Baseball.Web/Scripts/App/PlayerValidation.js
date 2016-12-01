$(document)
    .ready(function() {
        $("#playerForm")
            .validate({
                rules: {
                    FirstName: {                    
                        required: true,
                        lettersonly: true,                  
                        rangelength: [1,25]
                    },
                    LastName: {
                        required: true,
                        lettersonly: true,
                        rangelength: [1, 25]
                    },
                    JerseyNumber: {
                        required: true,
                        digits: true,
                        range: [1, 99]

                    },
                    YearsPlayed: {
                        required: true,
                        digits: true,
                        range: [1,99]
                    },
                    BattingAvg: {
                        required: true,                     
                        range: [.001, 1]
                    },
                    Position: {
                        required: true
                    }

                },
                messages: {
                    FirstName: {
                        required: "Please enter a First Name for Player",
                        lettersonly: "Only Letters!!!",                        
                        rangelength: "Out of range, (25 letter max)"
                    },
                    LastName: {
                        required: "Please enter a Last Name for Player",
                        lettersonly: "No numbers only letters",
                        rangelength: "Out of range, (25 letter max)"
                    },
                    JerseyNumber: {
                        required: "Please Enter a Jersey Number",
                        digits: "Error: Only Numbers, no Spaces",
                        range: "Out of range, choose between 1 and 99"
                    },
                    YearsPlayed: {
                        required: "Please Enter Years Played",
                        digits: "Error: Only Numbers, no Spaces",
                        range: "Out of range, (1-99 years)"
                    },
                    BattingAvg: {
                        required: "Please Enter a Batting Average",                      
                        range: "Out of range, (.001-1 range for Batting Average)"
                    },
                    Position: {
                        required: "Please Select a Position"
                    }

                }
            });
    });
