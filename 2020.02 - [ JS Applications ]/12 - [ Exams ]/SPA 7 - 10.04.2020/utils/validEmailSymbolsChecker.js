export default function () {
    let email = document.getElementById("form")[0];
    email.addEventListener('keypress', checkName, false);

    function checkName(evt) {
        var charCode = evt.charCode;
        if (charCode != 0) {
            if (charCode == 46 || charCode == 64 || charCode == 95 || charCode > 96 && charCode < 123 || charCode > 47 && charCode < 58) {
            } else {
                evt.preventDefault();
                toastr.warning('Please enter a valid email symbol.');
            }
        }
    }
}