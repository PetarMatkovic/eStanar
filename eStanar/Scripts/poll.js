$(document).ready(function () {
    $('.datefield').datepicker($.datepicker.regional['hr']);
    $('.datefield').datepicker('option', 'changeMonth', true);
    $('.datefield').datepicker('option', 'changeYear', true);
    $('.datefield').datepicker('option', 'yearRange', '-1:+1');
    $('.datefield').datepicker('option', 'showAnim', 'slideDown');

    $('.btn-poll-option-edit').on('click', function (e) {
        e.preventDefault();
        var $btn = $(this);
        $('#txtPollOptionText').val($btn.prev('.poll-option-text').html());
        $('#hidIdPollOption').val($btn.attr('id-poll-option'));
        $('#btnDeletePollOption').removeClass('hidden');
    });

    $('#btnResetPollOption').on('click', function (e) {
        e.preventDefault();
        $('#txtPollOptionText').val('');
        $('#hidIdPollOption').val('');
        $('#btnDeletePollOption').removeClass('hidden').addClass('hidden');
    });
});