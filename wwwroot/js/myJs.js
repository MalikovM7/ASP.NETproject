
var form = document.querySelector("#contact_form");

form.addEventListener("submit", function (e) {

    e.preventDefault();


    let element = e.currentTarget

    let fv = new FormData(element);

    console.log(fv);

    fetch('http://localhost:5055/contact/SendEmail', {
        method: 'POST',
        body: fv

    }).then(res => res.json()).then(resp => console.log(resp))

})