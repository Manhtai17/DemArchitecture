$(document).ready(function () {
    emailJS = new EmailJS();
});

class EmailJS {
    constructor() {
        this.initEvent();
    }
    
    initEvent() {
        $(document).on('click', '#btn-send', { that: this }, this.onClickEditEmail);
    }
    
    onClickSendEmail(event) {
        let subject = $('#email-subject').val;
        let body = $('#email-body').val;
        let recipients = $('#recipient').val;
        var email = {
            "Subject": subject,
            "Body": body,
            "Recipients": recipients
        };
        $.ajax({
            method: 'POST',
            url: "/api/emails/send",
            contentType: 'application/json',
            data: email
        }).done((res) => {
                console.log(res);
        }).fail(() => {
            console.log("fail");
        });
    }
    
}
