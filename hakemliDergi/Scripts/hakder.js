﻿$(function () {

    var ajaxFormSubmit = function () {
       var $form = $(this);

          var options = {
                url: $form.attr("action"),
                type: $form.attr("method"),
                data: $form.serialize()
          };

            $.ajax(options).done(function (data) {
                var $target = $($form.attr("data-hakder-target"));
                var $newHtml = $(data);
                $target.replaceWith($newHtml);
                $newHtml.effect("highlight");
            });

            return false;
        };      


    var submitAutoCompleteForm = function (event, ui) {
        var $input = $(this);
        $input.val(ui.item.label);

        var $form = $input.parents("form:first");
        $form.submit();
    };

    var createAutoComplete = function () {
        var $input = $(this);

        var options = {
            source: $input.attr("data-hakder-autocomplete"),
            select: submitAutoCompleteForm
        };

        $input.autocomplete(options);
    };

    var getPage = function () {
        var $a = $(this);

        var options = {
            url: $a.attr("href"),
            data: $("form").serialize(),
            type: "get"
        };

        $.ajax(options).done(function (data) {
            var target = $a.parents("div.pagedList").attr("data-hakder-target");
            $(target).replaceWith(data);
        });

        return false;
    };

    $("form[data-hakder-ajax='true']").submit(ajaxFormSubmit);
    $("input[data-hakder-autocomplete]").each(createAutoComplete);

    //body-content
    $(".body-content").on("click", ".pagedList a", getPage);

 });