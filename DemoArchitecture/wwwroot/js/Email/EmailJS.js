$(document).ready(function () {
    emailJS = new EmailJS();
});

class EmailJS {
    constructor() {
        this.initEvent();
    }
    
    initEvent() {
        $(document).on('click', '.get-infor-email', { that: this }, this.onClickSendEmail);
    }
    
    onClickSendEmail(event) {
        alert("A");
        var me = event.data.that;
        var email = {};
        email.emailSenderName = $('#emailnamefrom').val();
        email.emailSenderAddress = $('#emailfrom').val();
        email.recipients = $('#emailto').val();
        email.subject = $('#emailsubject').val();
        email.body = $('#emailbody').val();
        email.customArgs = $('#emailheader').val();
        console.log(email);
        $.ajax({
            method: 'POST',
            url: "/api/emails/send",
            contentType: 'application/json',
            data: JSON.stringify(email)
        }).done((res) => {
                console.log(res);
        }).fail(() => {
            console.log("fail");
        });
    }
    
}
