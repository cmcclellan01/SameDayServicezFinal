﻿(function () {


    /******** Our main function ********/
   
        jQuery(document).ready(function ($) {
            //can run jQuery code here

            //get the app type
            var miniAppType = $("#miniAppContainer").attr("data-miniapptype");
         
                switch (miniAppType) {
                    case "time-duration-calculator": setupTimeDurationCalculator();
                        break;
                    case "convert-decimal-hours-to-minutes": setupConvertDecimalHoursToMinutes();

                }

                function setupConvertDecimalHoursToMinutes() {
                    var pos = 0;

                    $("#divSwap").click(function () {

                        $("#inputDecimalHours").val("");
                        $("#inputHours").val("");
                        $("#inputMinutes").val("");

                        if (pos == 1) {

                            $("#tblHoursMinutes").fadeOut("fast", function () {
                                $("#tblHoursMinutes").appendTo($("#tdSecond"));
                                $(this).fadeIn("fast")
                            });

                            $("#tblDecimalHours").fadeOut("fast", function () {
                                $("#tblDecimalHours").appendTo($("#tdFirst"));
                                $(this).fadeIn("fast")
                            });
                            pos = 2;
                        }

                        else {
                            $("#tblHoursMinutes").fadeOut("fast", function () {
                                $("#tblHoursMinutes").appendTo($("#tdFirst"));
                                $(this).fadeIn("fast")
                            });

                            $("#tblDecimalHours").fadeOut("fast", function () {
                                $("#tblDecimalHours").appendTo($("#tdSecond"));
                                $(this).fadeIn("fast")
                            });
                            pos = 1;
                        }
                    });

                    $("#inputHours").keyup(function (e) {
                        calculateDecimalHour();
                    });

                    $("#inputMinutes").keyup(function (e) {
                        calculateDecimalHour();
                    });

                    $("#inputDecimalHours").keyup(function (e) {
                        calculateHoursMinutes();
                    });


                    $("#inputHours").keydown(function (e) {
                        NumericOnly(e, false);
                    });


                    $("#inputMinutes").keydown(function (e) {
                        NumericOnly(e, false);
                    });

                    $("#inputDecimalHours").keydown(function (e) {
                        var keySuccess = NumericOnly(e, true);
                        if (keySuccess == true) {
                            var c = e.key;
                            if (parseInt(c) >= 0 && parseInt(c) <= 9) {
                                var n = $(this).val() + e.key;
                                var decPart = n.toString().split(".")[1];
                                if (decPart != null && decPart.length > 2) {
                                    e.preventDefault();
                                }
                            }


                        }
                    });



                    function NumericOnly(e, allowDecimal) {

                        if (allowDecimal == false && e.keyCode == 190) {
                            e.preventDefault();
                            return false
                        }

                        // Allow: backspace, delete, tab, escape, enter and .
                        if ($.inArray(e.keyCode, [46, 8, 9, 27, 13, 110, 190]) !== -1 ||
                            // Allow: Ctrl+A, Command+A
                            (e.keyCode === 65 && (e.ctrlKey === true || e.metaKey === true)) ||
                            // Allow: home, end, left, right, down, up
                            (e.keyCode >= 35 && e.keyCode <= 40)) {
                            // let it happen, don't do anything
                            return true
                        }

                        // Ensure that it is a number and stop the keypress
                        if ((e.shiftKey || (e.keyCode < 48 || e.keyCode > 57)) && (e.keyCode < 96 || e.keyCode > 105)) {
                            e.preventDefault();
                            return false
                        }
                        return true;
                    }

                    function calculateDecimalHour() {

                        var hours = parseInt($("#inputHours").val());
                        var minutes = parseInt($("#inputMinutes").val());

                        if (isNaN(hours) && isNaN(minutes)) {
                            $("#inputDecimalHours").val("---");
                            return;
                        }

                        if (isNaN(hours)) {
                            hours = 0;
                        }
                        if (isNaN(minutes)) {
                            minutes = 0;
                        }

                        var decimalHours = moment.duration(hours + ":" + minutes).asHours();
                        decimalHours = Math.round(decimalHours * 100) / 100
                        $("#inputDecimalHours").val(decimalHours);


                    }

                    function calculateHoursMinutes() {


                        var decimalHours = parseFloat($("#inputDecimalHours").val());
                        if (isNaN(decimalHours)) {
                            $("#inputHours").val('');
                            $("#inputMinutes").val('');
                            return
                        }

                        var hrs = parseInt(Number(decimalHours));
                        var min = (Number(decimalHours) - hrs) * 60;
                        min = Math.round(min);
                        $("#inputHours").val(hrs);
                        $("#inputMinutes").val(min);
                    }



                }

                function setupTimeDurationCalculator() {

                    $('.inpTime').keyup(function () {
                        calculateHours();
                    })

                    //$('.inpTime').bind("click", function () { $(this).autocomplete("search", "") });

                    $("#butReset").click(function () {
                        $("#inputTime1").val('');
                        $("#inputTime2").val('');
                        $("#timeDurationOr").html('');
                        $("#timeDurationHoursMinutes").html('');
                        calculateHours();
                    })

                    $('#imgTimeCalculator').click(function () {
                        $('html, body').animate({
                            scrollTop: $("#tblTimeDifferenceCalculator").offset().top - 250
                        }, 500);
                    })



                    function calculateHours() {

                        var inTime = $("#inputTime1").val();
                        var outTime = $("#inputTime2").val();

                        inTime = fixTimeFormat(inTime);
                        outTime = fixTimeFormat(outTime);

                        var a = moment('1/1/2000 ' + inTime);
                        var b = moment('1/1/2000 ' + outTime);

                        if (isTime(inTime) == false || isTime(outTime) == false) {

                            $("#timeDurationDecimal").html('&nbsp');
                            $("#timeDurationOr").html('&nbsp');
                            $("#timeDurationHoursMinutes").html('please use times like 8:05am');
                            return;
                        }


                        var m = b.diff(a, 'minutes');
                        var h = m / 60;

                        var decimalHours = Math.round(h * 100) / 100

                        var diffHours = parseInt(b.diff(a, 'hours'));
                        var difMinutes = parseInt(moment.utc(moment(b, "HH:mm:ss").diff(moment(a, "HH:mm:ss"))).format("mm"));


                        $("#timeDurationDecimal").html(decimalHours + " hours");

                        var hoursLabel = 'hours';
                        var minutesLabel = 'minutes';

                        if (diffHours == 1) {
                            hoursLabel = 'hour';
                        }


                        if (difMinutes == 1) {
                            minutesLabel = 'minute';
                        }

                        $("#timeDurationOr").html('or');

                        $("#timeDurationHoursMinutes").html(diffHours + " " + hoursLabel + " and " + difMinutes + ' ' + minutesLabel);

                    }

                    function isTime(time) {

                        var match = time.match(/^(0?[1-9]|1[012])(:[0-5]\d) [APap][mM]$/);
                        return !!match;
                    }

                    function fixTimeFormat(time) {
                        //lowercase and add missing space before am/pm

                        time = time.toLowerCase();
                        time = time.trim();

                        if (time.indexOf('am') > 0) {
                            var i = time.indexOf('am')
                            var t = time.substring(0, i).trim();
                            time = t + ' am';
                        } else if (time.indexOf('pm') > 0) {
                            var i = time.indexOf('pm')
                            var t = time.substring(0, i).trim();
                            time = t + ' pm';
                        }

                        return time;
                    }
                }
         
        });
    
})(); 