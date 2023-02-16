function showHide(id) {
    let idInput;
    if (id === "showPass")
        idInput = "#userPassword";
    else if (id === "showConfPass")
        idInput = "#userPasswordConfirm";
    let idI = '#' + id;
    if ($(idInput).attr('type') == 'password') {
        $(idInput).attr('type', 'text');
        $(idI).attr('src', '../img/invisible.png');
    }
    else {
        $(idInput).attr('type', 'password');
        $(idI).attr('src', '../img/visible.png');
    }
}