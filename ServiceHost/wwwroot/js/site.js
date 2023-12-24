﻿(() => {
    'use strict'
    const formss = document.querySelectorAll('.needs-validation')
    Array.from(formss).forEach(form => {
        form.addEventListener('submit', event => {
            if (!form.checkValidity()) {
                event.preventDefault()
                event.stopPropagation()
            }
            form.classList.add('was-validated')
        }, false)
    })
})()

var SinglePage = {};

SinglePage.LoadModal = function () {
    var url = window.location.hash.toLowerCase();
    if (!url.startsWith("#showmodal")) {
        return;
    }
    url = url.split("showmodal=")[1];
    $.get(url,
        null,
        function (htmlPage) {
            $("#ModalContent").html(htmlPage);
            const container = document.getElementById("ModalContent");
            const forms = container.getElementsByTagName("form");
            const newForm = forms[forms.length - 1];
            const formss = document.querySelectorAll('.needs-validation')
            Array.from(formss).forEach(form => {
                form.addEventListener('submit', event => {
                    if (!form.checkValidity()) {
                        event.preventDefault()
                        event.stopPropagation()
                    }
                    form.classList.add('was-validated')
                }, false)
            })
            $('#Mobiles').formatter({
                'pattern': '+ ({{99}}) {{99}}-{{9999999}}',
                'persistent': true
            });
            $('#Start_Date').formatter({
                'pattern': '{{9999}}/{{99}}/{{99}}',
                'persistent': true
            });
            $('#Date').formatter({
                'pattern': '{{9999}}/{{99}}/{{99}}',
                'persistent': true
            });
            $('#End_Date').formatter({
                'pattern': '{{9999}}/{{99}}/{{99}}',
                'persistent': true
            });
            $('#Buy_Date').formatter({
                'pattern': '{{9999}}/{{99}}/{{99}}',
                'persistent': true
            });
            $('#tbodyv tr').each(function (idx) {
                $(this).children().first().html(idx + 1);
            });
            $(document).ready(function () { $(".input-mask").inputmask() });
            $.validator.unobtrusive.parse(newForm);
            showModal();
        }).fail(function (error) {
            Swal.fire({
                position: 'center',
                icon: 'error',
                title: "خطایی رخ داده است. لطفا با مدیر سیستم تماس بگیرید.",
                showConfirmButton: false,
                timer: 1500
            }).then(function (isConfirm) {
                window.location.reload();
            });
        });
};

function showModal() {
    $("#MainModal").modal("show");
    $(document).ready(function () {
        function alignModal() {
            var modalDialog = $(this).find(".modal-dialog");
            modalDialog.css("margin-top", Math.max(0, ($(window).height() - modalDialog.height()) / 2));
        }
        $(".modal").on("shown.bs.modal", alignModal);
        $(window).on("resize", function () {
            $(".modal:visible").each(alignModal);
        });
    });
}

function hideModal() {
    $("#MainModal").modal("hide");
}

$(document).ready(function () {
    window.onhashchange = function () {
        SinglePage.LoadModal();
    };
    $("#MainModal").on("shown.bs.modal",
        function () {
            window.location.hash = "##";
        });

    $(document).on("submit",
        'form[data-ajax="true"]',
        function (e) {
            e.preventDefault();
            var form = $(this);
            const method = form.attr("method").toLocaleLowerCase();
            const url = form.attr("action");
            var action = form.attr("data-action");

            if (method === "get") {
                const data = form.serializeArray();
                $.get(url,
                    data,
                    function (data) {
                        CallBackHandler(data, action, form);
                    });
            } else {
                var formData = new FormData(this);
                $.ajax({
                    url: url,
                    type: "post",
                    data: formData,
                    enctype: "multipart/form-data",
                    dataType: "json",
                    processData: false,
                    contentType: false,
                    success: function (data) {
                        CallBackHandler(data, action, form);
                    },
                    error: function (data) {
                        Swal.fire({
                            position: 'center',
                            icon: 'error',
                            title: "خطایی رخ داده است. لطفا با مدیر سیستم تماس بگیرید.",
                            showConfirmButton: false,
                            timer: 1500
                        }).then(function (isConfirm) {
                            window.location.reload();
                        });
                    }
                });
            }
            return false;
        });
});

function CallBackHandler(data, action, form) {
    switch (action) {
        case "Message":
            alert(data.Message);
            break;
        case "Refresh":
            if (data.isSuccedded) {
                Swal.fire({
                    position: 'center',
                    icon: 'success',
                    title: data.message,
                    showConfirmButton: false,
                    timer: 1500
                }).then(function (isConfirm) {
                    window.location.reload();
                });
            } else {
                Swal.fire({
                    position: 'center',
                    icon: 'error',
                    title: data.message,
                    showConfirmButton: false,
                    timer: 1500
                }).then(function (isConfirm) {
                });
            }
            break;
        case "RefereshList":
            {
                hideModal();
                const refereshUrl = form.attr("data-refereshurl");
                const refereshDiv = form.attr("data-refereshdiv");
                get(refereshUrl, refereshDiv);
            }
            break;
        case "setValue":
            {
                const element = form.data("element");
                $(`#${element}`).html(data);
            }
            break;
        default:
    }
}

function get(url, refereshDiv) {
    const searchModel = window.location.search;
    $.get(url,
        searchModel,
        function (result) {
            $("#" + refereshDiv).html(result);
        });
}

function makeSlug(source, dist) {
    const value = $('#' + source).val();
    $('#' + dist).val(convertToSlug(value));
}

var convertToSlug = function (str) {
    var $slug = '';
    const trimmed = $.trim(str);
    $slug = trimmed.replace(/[^a-z0-9-آ-ی-]/gi, '-').replace(/-+/g, '-').replace(/^-|-$/g, '');
    return $slug.toLowerCase();
};

function checkSlugDuplication(url, dist) {
    const slug = $('#' + dist).val();
    const id = convertToSlug(slug);
    $.get({
        url: url + '/' + id,
        success: function (data) {
            if (data) {
                sendNotification('error', 'top right', "خطا", "اسلاگ نمی تواند تکراری باشد");
            }
        }
    });
}

function fillField(source, dist) {
    const value = $('#' + source).val();
    $('#' + dist).val(value);
}

$(document).on("click",
    'button[data-ajax="true"]',
    function () {
        const button = $(this);
        const form = button.data("request-form");
        const data = $(`#${form}`).serialize();
        let url = button.data("request-url");
        const method = button.data("request-method");
        const field = button.data("request-field-id");
        if (field !== undefined) {
            const fieldValue = $(`#${field}`).val();
            url = url + "/" + fieldValue;
        }
        if (button.data("request-confirm") == true) {
            if (confirm("آیا از انجام این عملیات اطمینان دارید؟")) {
                handleAjaxCall(method, url, data);
            }
        } else {
            handleAjaxCall(method, url, data);
        }
    });

function handleAjaxCall(method, url, data) {
    if (method === "post") {
        $.post(url,
            data,
            "application/json; charset=utf-8",
            "json",
            function (data) {

            }).fail(function (error) {
                Swal.fire({
                    position: 'center',
                    icon: 'error',
                    title: "خطایی رخ داده است. لطفا با مدیر سیستم تماس بگیرید.",
                    showConfirmButton: false,
                    timer: 1500
                }).then(function (isConfirm) {
                    window.location.reload();
                });
            });
    }
}