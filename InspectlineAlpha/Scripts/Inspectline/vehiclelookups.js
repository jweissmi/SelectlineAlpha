$(document).ready(function () {
    $('#MakeName').prop('disabled', true);
    $('#ModelName').prop('disabled', true);

    var Years = {};
    Years.url = '/CustomerVehicle/GetYears';
    Years.type = 'POST';
    Years.datatype = 'json';
    Years.contentType = 'application/json';
    Years.success = function (YearList) {
        $('#YearID').find('option').remove();

        $('#YearID').append($('<option>', {
            value: '',
            text: 'Select'
        }));

        $.each(YearList, function (i, model) {
            $('#YearID').append($('<option>', {
                value: model,
                text: model
            }));
        });
    };
    Years.error = function () { alert('Error getting years'); };
    $.ajax(Years);

    $('#YearID').change(function () {
        $('#ModelName').find('option').remove();
        $('#ModelName').prop('disabled', true);

        if ($('#YearID').val() != 'Select' && $('#YearID').val() != '')
        {
            var Makes = {};
            Makes.url = '/CustomerVehicle/GetMakes';
            Makes.type = 'POST';
            Makes.data = JSON.stringify({ year: $('#YearID').val() });
            Makes.datatype = 'json';
            Makes.contentType = 'application/json';
            Makes.success = function (MakeList) {
                $('#MakeName').find('option').remove();

                $('#MakeName').append($('<option>', {
                    value: '',
                    text: 'Select'
                }));

                $.each(MakeList, function (i, make) {
                    $('#MakeName').append($('<option>', {
                        value: make,
                        text: make
                    }));
                });

                $('#MakeName').prop('disabled', false);
            };
            Makes.error = function () { alert('Error getting makes'); };
            $.ajax(Makes);
        }
        else
        {
           $('#MakeName').find('option').remove();
           $('#MakeName').prop('disabled', true);
        }
    });

    $('#MakeName').change(function () {
        if ($('#MakeName').val() != 'Select' && $('#MakeName').val() != '') {
            var Models = {};
            Models.url = '/CustomerVehicle/GetModels';
            Models.type = 'POST';
            Models.data = JSON.stringify({ year: $('#YearID').val(), makeName: $('#MakeName').val()});
            Models.datatype = 'json';
            Models.contentType = 'application/json';
            Models.success = function (ModelList) {
                $('#ModelName').find('option').remove();

                $('#ModelName').append($('<option>', {
                    value: '',
                    text: 'Select'
                }));

                $.each(ModelList, function (i, model) {
                    $('#ModelName').append($('<option>', {
                        value: model,
                        text: model
                    }));
                });

                $('#ModelName').prop('disabled', false);
            };
            Models.error = function () { alert('Error getting models'); };
            $.ajax(Models);
        }
        else {
            $('#ModelName').find('option').remove();
            $('#ModelName').prop('disabled', true);
        }
    });
});
