var spPhoneMaskBehavior = function (val) {
    return val.replace(/\D/g, '').length === 11 ? '(00) 00000-0000' : '(00) 0000-00009';
};

var spPhoneMaskOptions = {
    onKeyPress: function (val, e, field, options) {
        field.mask(spPhoneMaskBehavior.apply({}, arguments), options);
    }
};

function maskSpPhone(obj) {

    $(obj).mask(spPhoneMaskBehavior, spPhoneMaskOptions);
}

$(document).ready(function() {
    $("*[data-mask-sp-phone=sp-phone]").mask(spPhoneMaskBehavior, spPhoneMaskOptions);
});
