﻿function SetStars(star, index) {


    //star.on('mouseover', function () {
    //    var index = $(this).attr('data-index');
    //    markStarsAsActive(index);
    //});

    markStarsAsActive('' + index - 1 + '');

    function markStarsAsActive(index) {
        unmarkActive();

        for (var i = 0; i <= index; i++) {
            switch (index) {
                case '0':
                    $(star.get(i)).addClass('oneStar');
                    break;
                case '1':
                    $(star.get(i)).addClass('twoStars');
                    break;
                case '2':
                    $(star.get(i)).addClass('threeStars');
                    break;
                case '3':
                    $(star.get(i)).addClass('fourStars');
                    break;
                case '4':
                    $(star.get(i)).addClass('fiveStars');
                    break;
            }
        }
    }

    function unmarkActive() {
        star.removeClass('oneStar twoStars threeStars fourStars fiveStars');
    }

    star.on('click', function (e) {


        if (star.hasClass("oneStar")) {
            console.log('1' + $(this).attr('data-contractor'));
        }

        if (star.hasClass("twoStars")) {
            console.log('2' + $(this).attr('data-contractor'));
        }

        if (star.hasClass("threeStars")) {
            console.log('3' + $(this).attr('data-contractor'));
        }

        if (star.hasClass("fourStars")) {
            console.log('4' + $(this).attr('data-contractor'));
        }

        if (star.hasClass("fiveStars")) {
            console.log('5' + $(this).attr('data-contractor'));
        }

    });



}

Dropzone.autoDiscover = false;
$(document).ready(function () {




    // this is for the is contractor checkbox that makes it 'customer or contractor'
    $('.IsContractor').checkboxpicker({
        html: true,
        offLabel: 'Customer',
        onLabel: 'Contractor'
    }).on('change', function () {


        switch ($(this).is(":checked")) {
            case true:
                $('.IsContractor').prop('checked', true);
                $('.current-mode').text('Current Mode: Contractor');
                break;
            case false:
                $('.IsContractor').prop('checked', false);
                $('.current-mode').text('Current Mode: Customer');
                break;
        }

    });

    $('a[data-toggle="tooltip"]').tooltip({
        animated: 'fade',
        placement: 'bottom',
        html: true
    });
  

    // this sets the hourly amout to a $format 
    $('.currency').currencyFormat();


   


    $('.remove-profileimage').click(function () {
        $.ajax({
            type: "POST",
            url: '/Account/RemoveUpload?type=profile',
            success: function () {
                $('.ProfileImage').empty();
            }
        });
        return false;
    });

    $('.remove-idimage').click(function () {
        $.ajax({
            type: "POST",
            url: '/Account/RemoveUpload?type=id',
            success: function () {
                $('.IdImage').empty();
            }
        });
        return false;
    });



    $('#BirthDate').datepicker({
        uiLibrary: 'bootstrap4',
        dateFormat: 'mm/dd/yy'
    });

    $('.save-profile').on('click', function (event) {
        $("#form-profile").submit();
    });

    $('.submit').on('click', function (event) {
        event.preventDefault();
        getGeoCode();
       
       
    });


    function getGeoCode() {
        var geocoder = new google.maps.Geocoder();
        geocoder.geocode({ 'address': "'" + $('#Address').val() + $('#City').val() + $("#State option:selected").val() + $('#ZipCode').val() + "'" }, function (results, status) {
            if (status === 'OK') {
                $('#latitude').val(results[0].geometry.location.lat());
                $('#longitude').val(results[0].geometry.location.lng());

                //  $("#BasicInfo").submit();

                $("#accordion").accordion("option", "active", 1);

                $("#form-profile").submit();
            } else {
                result = 'Unable to find address: ' + status;
                event.preventDefault();
            }

        });
    }




    $('.ApplicationUser-Professions').hide();
    $('.ApplicationUser-SubProfessions').hide();


    $('.ApplicationUser-skills .Alphabetical').click(function () {
        $('.ApplicationUser-Professions').show();
        $.getJSON('/Account/AutoComplete', { term: this.innerText }, function (item) {

            $('.ApplicationUser-Professions').empty();
            $('.ApplicationUser-Professions').append("<option value='- Please Select A Profession Category -'>- Please Select A Profession Category -</option>");

            $.each(item, function (index, data) {
                $('.ApplicationUser-Professions').append("<option value='" + data.ID + "'>" + data.Name + "</option>");
            });

        });
    });

    $('.ApplicationUser-Professions').change(function (event, ui) {
        $.get('/Account/GetSubCategoryList', { Id: this.value }, function (data) {

            $('.ApplicationUser-SubProfessions').empty();
            $('.ApplicationUser-SubProfessions').show();

            $('.ApplicationUser-SubProfessions').append("<option value='- Please Select A Job Title -'>- Please Select A Job Title -</option>");
            $.each(data, function (index, row) {
                $('.ApplicationUser-SubProfessions').append("<option data-info='" + $(".ApplicationUser-Professions option:selected").text() + "'  value='" + this.MainCatId + '_' + row.Id + "'>" + row.SubCatNames + "</option>");

            });
        });
    });

    $('.ApplicationUser-add').click(function () {

        if ($(".ApplicationUser-SubProfessions option:selected").val() !== '- Please Select A Job Title -') {      

            $('.ApplicationUser-result').append('<div class="result-added new" id="' + $(".ApplicationUser-SubProfessions option:selected").val() + '"><span class="btn btn-outline-danger btn-sm " role="button" style="margin: 5px;">remove</span>' + $(".ApplicationUser-Professions option:selected").text() + ' -- ' + $(".ApplicationUser-SubProfessions option:selected").text() + '</div>')

            // updates the hidden field
            $('.ApplicationUser-skills .new').each(function (index, value) {
                json += $(".ApplicationUser-SubProfessions option:selected").val() + ',';
            });
            //sets the hidden field for postback
            $('#JsonProfession').val(json);

            //add cat and sub cat
            var mainID = $(".ApplicationUser-Professions option:selected").val();
            var subID = $(".ApplicationUser-SubProfessions option:selected").val().split('_')[1];
           
            $.post('/Account/AddUserContractorCustomerCategories', { json: $('#JsonProfession').val() }, function (data) { });

            // remove the selected one after we add it
            $('.ApplicationUser-SubProfessions').find('option:selected').remove().end();
        }
        else {
            alert('Please Select A Job Title');
        }

    });

    $('.ApplicationUser-remove').click(function (e) {

        $(this).parent().remove();

        $.post('/Account/RemoveUserContractorCustomerCategories', { mainId: $(this).attr('data-id').split(" ")[0], subId: $(this).attr('data-id').split(" ")[1] }, function (data) {

        });

    });





});

$('.currency').currencyFormat();

$("#dropzoneProfilePic").dropzone({
    init: function () {
        this.on("error", function (file, message, xhr) {
            if (xhr === null) this.removeFile(file);

            $('.dropzone-error').append(message);
        });
    },
    url: "/Account/Upload?type=profile",
    addRemoveLinks: false,
    createImageThumbnails: false,
    uploadMultiple: false,
    acceptedFiles: ".jpeg,.jpg,.png",
    dictDefaultMessage: "  Upload a photo of yourself for your contractor profile.",
    success: function (file, response) {
        $('.ProfileImage').empty();
        $('.ProfileImage').append('<img style="margin-bottom:10px;" class="img-thumbnail" src="/Uploads/ProfileImages/' + $('#Id').val() + '/' + response.Message + '"> <button class="btn remove-profileimage">X</button>');

        $('.remove-profileimage').click(function () {
            $.ajax({
                type: "POST",
                url: '/Account/RemoveUpload?type=profile',
                success: function () {
                    $('.ProfileImage').empty();
                }
            });
            return false;
        });
    },
    error: function (file, response) {
        file.previewElement.classList.add("dz-error");
    },
    complete: function (file, response) {
        this.removeAllFiles(true);
    }

});


$("#dropzoneIdPic").dropzone({
    url: "/Account/Upload?type=id",
    init: function () {
        this.on("error", function (file, message, xhr) {
            if (xhr === null) this.removeFile(file);

            $('.dropzone-error2').append(message);
        });
    },
    addRemoveLinks: false,
    uploadMultiple: false,
    createImageThumbnails: false,
    acceptedFiles: ".jpeg,.jpg,.png",
    dictDefaultMessage: "Upload a scan of your driver's license or government issued photo ID.",
    success: function (file, response) {
        $('.IdImage').empty();
        $('.IdImage').append('<img style="margin-bottom:10px;" class="img-thumbnail" src="/Uploads/ProfileImages/' + $('#Id').val() + '/' + response.Message + '"> <button class="btn remove-idimage">X</button>');

        $('.remove-idimage').click(function () {
            $.ajax({
                type: "POST",
                url: '/Account/Upload?type=id',
                success: function () {
                    $('.IdImage').empty();
                }
            });
            return false;
        });
    },
    error: function (file, response) {
        file.previewElement.classList.add("dz-error");
    },
    complete: function (file, response) {
        this.removeAllFiles(true);
    }


});